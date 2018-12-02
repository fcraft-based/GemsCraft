// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using fCraft.Properties;
using fCraft.Worlds;
using JetBrains.Annotations;

// ReSharper disable IdentifierTypo

namespace fCraft.GUI {

    /// <summary> Drawing/clipping mode of IsoCat map renderer. </summary>
    public enum IsoCatMode {
        /// <summary> Normal isometric view. </summary>
        Normal,

        /// <summary> Isometric view with the outermost layer of blocks stripped (useful for boxed maps). </summary>
        Peeled,

        /// <summary> Isometric view with a front-facing quarter of the map cut out (to show map cross-section). </summary>
        Cut,

        /// <summary> Only a specified chunk of the map is drawn. </summary>
        Chunk
    }


    /// <summary> Isometric map renderer, tightly integrated with BackgroundWorker.
    /// Creates a bitmap of the map. Every IsoCat instance is single-use. </summary>
    public sealed unsafe class IsoCat {
        private static readonly byte[] Tiles, ShadowTiles;
        private static readonly int TileX, TileY;
        private static readonly int MaxTileDim, TileStride;

        static IsoCat() {
            using( var tilesBmp = Resources.Tileset ) {
                TileX = tilesBmp.Width / 50;
                TileY = tilesBmp.Height;
                TileStride = TileX * TileY * 4;
                Tiles = new byte[50 * TileStride];

                MaxTileDim = Math.Max( TileX, TileY );

                for( var i = 0; i < 50; i++ ) {
                    for( var y = 0; y < TileY; y++ ) {
                        for( var x = 0; x < TileX; x++ ) {
                            var p = i * TileStride + (y * TileX + x) * 4;
                            var c = tilesBmp.GetPixel( x + i * TileX, y );
                            Tiles[p] = c.B;
                            Tiles[p + 1] = c.G;
                            Tiles[p + 2] = c.R;
                            Tiles[p + 3] = c.A;
                        }
                    }
                }
            }

            using( var stilesBmp = Resources.TilesetShadowed ) {

                ShadowTiles = new byte[50 * TileStride];

                for( var i = 0; i < 50; i++ ) {
                    for( var y = 0; y < TileY; y++ ) {
                        for( var x = 0; x < TileX; x++ ) {
                            var p = i * TileStride + (y * TileX + x) * 4;
                            var c = stilesBmp.GetPixel( x + i * TileX, y );
                            ShadowTiles[p] = c.B;
                            ShadowTiles[p + 1] = c.G;
                            ShadowTiles[p + 2] = c.R;
                            ShadowTiles[p + 3] = c.A;
                        }
                    }
                }
            }
        }


        private int _x, _y, _z;
        private byte _block;
        public readonly int[] ChunkCoords = new int[6];

        private readonly byte* _image;
        private readonly Bitmap _imageBmp;
        private readonly BitmapData _imageData;
        private readonly int _imageWidth, _imageHeight;

        private readonly int _dimX, _dimY, _dimX1, _dimY1, _dimX2, _dimY2;
        private readonly int _offsetX, _offsetY;
        private readonly int _isoOffset, _isoX, _isoY, _isoH;
        private readonly int _imageStride;

        public readonly int Rot;
        public readonly IsoCatMode Mode;
        public readonly Map Map;


        public IsoCat( Map map, IsoCatMode mode, int rot ) {
            Rot = rot;
            Mode = mode;
            Map = map;

            _dimX = Map.Width;
            _dimY = Map.Length;
            _offsetY = Math.Max( 0, Map.Width - Map.Length );
            _offsetX = Math.Max( 0, Map.Length - Map.Width );
            _dimX2 = _dimX / 2 - 1;
            _dimY2 = _dimY / 2 - 1;
            _dimX1 = _dimX - 1;
            _dimY1 = _dimY - 1;

            _blendDivisor = 255 * Map.Height;

            _imageWidth = TileX * Math.Max( _dimX, _dimY ) + TileY / 2 * Map.Height + TileX * 2;
            _imageHeight = TileY / 2 * Map.Height + MaxTileDim / 2 * Math.Max( Math.Max( _dimX, _dimY ), Map.Height ) + TileY * 2;

            _imageBmp = new Bitmap( _imageWidth, _imageHeight, PixelFormat.Format32bppArgb );
            _imageData = _imageBmp.LockBits( new Rectangle( 0, 0, _imageBmp.Width, _imageBmp.Height ),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format32bppArgb );

            _image = (byte*)_imageData.Scan0;
            _imageStride = _imageData.Stride;

            _isoOffset = (Map.Height * TileY / 2 * _imageStride + _imageStride / 2 + TileX * 2);
            _isoX = (TileX / 4 * _imageStride + TileX * 2);
            _isoY = (TileY / 4 * _imageStride - TileY * 2);
            _isoH = (-TileY / 2 * _imageStride);

            _mh34 = Map.Height * 3 / 4;
        }

        private byte* _bp, _ctp;
        [CanBeNull]
        public Bitmap Draw( out Rectangle cropRectangle, BackgroundWorker worker ) {
            cropRectangle = Rectangle.Empty;
            try {
                fixed( byte* bpx = Map.Blocks ) {
                    fixed( byte* tp = Tiles ) {
                        fixed( byte* stp = ShadowTiles ) {
                            _bp = bpx;
                            while( _z < Map.Height ) {
                                _block = GetBlock( _x, _y, _z );
                                if( _block != 0 ) {
                                    if (Rot == 0)
                                        _ctp = (_z >= Map.Shadows[_x, _y] ? tp : stp);
                                    else if (Rot == 1)
                                        _ctp = (_z >= Map.Shadows[_dimX1 - _y, _x] ? tp : stp);
                                    else if (Rot == 2)
                                        _ctp = (_z >= Map.Shadows[_dimX1 - _x, _dimY1 - _y] ? tp : stp);
                                    else if (Rot == 3) _ctp = (_z >= Map.Shadows[_y, _dimY1 - _x] ? tp : stp);

                                    var blockRight = _x != (Rot == 1 || Rot == 3 ? _dimY1 : _dimX1) ? GetBlock( _x + 1, _y, _z ) : 0;
                                    var blockLeft = _y != (Rot == 1 || Rot == 3 ? _dimX1 : _dimY1) ? GetBlock( _x, _y + 1, _z ) : 0;
                                    var blockUp = _z != Map.Height - 1 ? GetBlock( _x, _y, _z + 1 ) : 0;

                                    if( blockUp == 0 || blockLeft == 0 || blockRight == 0 || // air
                                        blockUp == 8 || blockLeft == 8 || blockRight == 8 || // water
                                        blockUp == 9 || blockLeft == 9 || blockRight == 9 || // water
                                        (_block != 20 && (blockUp == 20 || blockLeft == 20 || blockRight == 20)) || // glass
                                        blockUp == 18 || blockLeft == 18 || blockRight == 18 || // foliage
                                        blockLeft == 44 || blockRight == 44 || // step

                                        blockUp == 10 || blockLeft == 10 || blockRight == 10 || // lava
                                        blockUp == 11 || blockLeft == 11 || blockRight == 11 || // lava

                                        blockUp == 37 || blockLeft == 37 || blockRight == 37 || // flower
                                        blockUp == 38 || blockLeft == 38 || blockRight == 38 || // flower
                                        blockUp == 6 || blockLeft == 6 || blockRight == 6 || // tree
                                        blockUp == 39 || blockLeft == 39 || blockRight == 39 || // mushroom
                                        blockUp == 40 || blockLeft == 40 || blockRight == 40 ) // mushroom
                                        BlendTile();
                                }

                                _x++;
                                if( _x == (Rot == 1 || Rot == 3 ? _dimY : _dimX) ) {
                                    _y++;
                                    _x = 0;
                                }

                                if (_y != (Rot == 1 || Rot == 3 ? _dimX : _dimY)) continue;
                                _z++;
                                _y = 0;
                                if (worker == null || _z % 4 != 0) continue;
                                if( worker.CancellationPending ) return null;
                                worker.ReportProgress( (_z * 100) / Map.Height );
                            }
                        }
                    }
                }

                int xMin = 0, xMax = _imageWidth - 1, yMin = 0, yMax = _imageHeight - 1;
                var cont = true;
                int offset;

                // find left bound (xMin)
                for( _x = 0; cont && _x < _imageWidth; _x++ ) {
                    offset = _x * 4 + 3;
                    for( _y = 0; _y < _imageHeight; _y++ ) {
                        if( _image[offset] > 0 ) {
                            xMin = _x;
                            cont = false;
                            break;
                        }
                        offset += _imageStride;
                    }
                }

                if( worker != null && worker.CancellationPending ) return null;

                // find top bound (yMin)
                cont = true;
                for( _y = 0; cont && _y < _imageHeight; _y++ ) {
                    offset = _imageStride * _y + xMin * 4 + 3;
                    for( _x = xMin; _x < _imageWidth; _x++ ) {
                        if( _image[offset] > 0 ) {
                            yMin = _y;
                            cont = false;
                            break;
                        }
                        offset += 4;
                    }
                }

                if( worker != null && worker.CancellationPending ) return null;

                // find right bound (xMax)
                cont = true;
                for( _x = _imageWidth - 1; cont && _x >= xMin; _x-- ) {
                    offset = _x * 4 + 3 + yMin * _imageStride;
                    for( _y = yMin; _y < _imageHeight; _y++ ) {
                        if( _image[offset] > 0 ) {
                            xMax = _x + 1;
                            cont = false;
                            break;
                        }
                        offset += _imageStride;
                    }
                }

                if( worker != null && worker.CancellationPending ) return null;

                // find bottom bound (yMax)
                cont = true;
                for( _y = _imageHeight - 1; cont && _y >= yMin; _y-- ) {
                    offset = _imageStride * _y + 3 + xMin * 4;
                    for( _x = xMin; _x < xMax; _x++ ) {
                        if( _image[offset] > 0 ) {
                            yMax = _y + 1;
                            cont = false;
                            break;
                        }
                        offset += 4;
                    }
                }

                cropRectangle = new Rectangle( Math.Max( 0, xMin - 2 ),
                                               Math.Max( 0, yMin - 2 ),
                                               Math.Min( _imageBmp.Width, xMax - xMin + 4 ),
                                               Math.Min( _imageBmp.Height, yMax - yMin + 4 ) );
                return _imageBmp;
            } finally {
                _imageBmp.UnlockBits( _imageData );
                if( worker != null && worker.CancellationPending && _imageBmp != null ) {
                    try {
                        _imageBmp.Dispose();
                    } catch( ObjectDisposedException ) { }
                }
            }
        }


        private void BlendTile() {
            var pos = (_x + (Rot == 1 || Rot == 3 ? _offsetY : _offsetX)) * _isoX + (_y + (Rot == 1 || Rot == 3 ? _offsetX : _offsetY)) * _isoY + _z * _isoH + _isoOffset;
            if( _block > 49 ) return;
            var tileOffset = _block * TileStride;
            BlendPixel( pos, tileOffset );
            BlendPixel( pos + 4, tileOffset + 4 );
            BlendPixel( pos + 8, tileOffset + 8 );
            BlendPixel( pos + 12, tileOffset + 12 );
            pos += _imageStride;
            BlendPixel( pos, tileOffset + 16 );
            BlendPixel( pos + 4, tileOffset + 20 );
            BlendPixel( pos + 8, tileOffset + 24 );
            BlendPixel( pos + 12, tileOffset + 28 );
            pos += _imageStride;
            BlendPixel( pos, tileOffset + 32 );
            BlendPixel( pos + 4, tileOffset + 36 );
            BlendPixel( pos + 8, tileOffset + 40 );
            BlendPixel( pos + 12, tileOffset + 44 );
            pos += _imageStride;
            //BlendPixel( pos, tileOffset + 48 ); // bottom left block, always blank in current tileset
            BlendPixel( pos + 4, tileOffset + 52 );
            BlendPixel( pos + 8, tileOffset + 56 );
            //BlendPixel( pos + 12, tileOffset + 60 ); // bottom right block, always blank in current tileset
        }


        private const byte ShadingStrength = 48;
        private readonly int _blendDivisor, _mh34;

        // inspired by http://www.devmaster.net/wiki/Alpha_blending
        private void BlendPixel( int imageOffset, int tileOffset ) {
            int sourceAlpha;
            if( _ctp[tileOffset + 3] == 0 ) return;

            var tA = _ctp[tileOffset + 3];

            // Get final alpha channel.
            var finalAlpha = tA + ((255 - tA) * _image[imageOffset + 3]) / 255;

            // Get percentage (out of 256) of source alpha compared to final alpha
            if( finalAlpha == 0 ) {
                sourceAlpha = 0;
            } else {
                sourceAlpha = tA * 255 / finalAlpha;
            }

            // Destination percentage is just the additive inverse.
            var destAlpha = 255 - sourceAlpha;

            if( _z < (Map.Height >> 1) ) {
                var shadow = (_z >> 1) + _mh34;
                _image[imageOffset] = (byte)((_ctp[tileOffset] * sourceAlpha * shadow + _image[imageOffset] * destAlpha * Map.Height) / _blendDivisor);
                _image[imageOffset + 1] = (byte)((_ctp[tileOffset + 1] * sourceAlpha * shadow + _image[imageOffset + 1] * destAlpha * Map.Height) / _blendDivisor);
                _image[imageOffset + 2] = (byte)((_ctp[tileOffset + 2] * sourceAlpha * shadow + _image[imageOffset + 2] * destAlpha * Map.Height) / _blendDivisor);
            } else {
                var shadow = (_z - (Map.Height >> 1)) * ShadingStrength;
                _image[imageOffset] = (byte)Math.Min( 255, (_ctp[tileOffset] * sourceAlpha + shadow + _image[imageOffset] * destAlpha) / 255 );
                _image[imageOffset + 1] = (byte)Math.Min( 255, (_ctp[tileOffset + 1] * sourceAlpha + shadow + _image[imageOffset + 1] * destAlpha) / 255 );
                _image[imageOffset + 2] = (byte)Math.Min( 255, (_ctp[tileOffset + 2] * sourceAlpha + shadow + _image[imageOffset + 2] * destAlpha) / 255 );
            }

            _image[imageOffset + 3] = (byte)finalAlpha;
        }

        private byte GetBlock( int xx, int yy, int zz ) {
            int realx;
            int realy;
            switch( Rot ) {
                case 0:
                    realx = xx;
                    realy = yy;
                    break;
                case 1:
                    realx = _dimX1 - yy;
                    realy = xx;
                    break;
                case 2:
                    realx = _dimX1 - xx;
                    realy = _dimY1 - yy;
                    break;
                default:
                    realx = yy;
                    realy = _dimY1 - xx;
                    break;
            }
            var pos = (zz * _dimY + realy) * _dimX + realx;

            if( Mode == IsoCatMode.Normal ) {
                return _bp[pos];
            } else if( Mode == IsoCatMode.Peeled && (xx == (Rot == 1 || Rot == 3 ? _dimY1 : _dimX1) || yy == (Rot == 1 || Rot == 3 ? _dimX1 : _dimY1) || zz == Map.Height - 1) ) {
                return 0;
            } else if( Mode == IsoCatMode.Cut && xx > (Rot == 1 || Rot == 3 ? _dimY2 : _dimX2) && yy > (Rot == 1 || Rot == 3 ? _dimX2 : _dimY2) ) {
                return 0;
            } else if( Mode == IsoCatMode.Chunk && (realx < ChunkCoords[0] || realy < ChunkCoords[1] || zz < ChunkCoords[2] || realx > ChunkCoords[3] || realy > ChunkCoords[4] || zz > ChunkCoords[5]) ) {
                return 0;
            }

            return _bp[pos];
        }
    }
}