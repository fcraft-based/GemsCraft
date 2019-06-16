﻿// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GemsCraft.Display.ConfigGUI.GUI;
using GemsCraft.Properties;
using Color = GemsCraft.Utils.Color;

namespace GemsCraft.Display.ConfigGUI {
    public sealed partial class ChatPreview : UserControl {
        private struct ColorPair {
            public ColorPair( int r, int g, int b, int sr, int sg, int sb ) {
                Foreground = new SolidBrush( System.Drawing.Color.FromArgb( r, g, b ) );
                Shadow = new SolidBrush( System.Drawing.Color.FromArgb( sr, sg, sb ) );
            }
            public readonly Brush Foreground, Shadow;
        }

        public static Font MinecraftFont;
        private static readonly ColorPair[] ColorPairs;
        private static readonly PrivateFontCollection Fonts;
        static unsafe ChatPreview() {
            Fonts = new PrivateFontCollection();
            fixed( byte* fontPointer = Resources.MinecraftFont ) {
                Fonts.AddMemoryFont( (IntPtr)fontPointer, Resources.MinecraftFont.Length );
            }

            FontFamily fam = Fonts.Families[0];

            MinecraftFont = new Font(fam, 12, FontStyle.Regular);
            ColorPairs = new[]{
                new ColorPair(0,0,0,0,0,0),
                new ColorPair(0,0,191,0,0,47),
                new ColorPair(0,191,0,0,47,0),
                new ColorPair(0,191,191,0,47,47),
                new ColorPair(191,0,0,47,0,0),
                new ColorPair(191,0,191,47,0,47),
                new ColorPair(191,191,0,47,47,0),
                new ColorPair(191,191,191,47,47,47),

                new ColorPair(64,64,64,16,16,16),
                new ColorPair(64,64,255,16,16,63),
                new ColorPair(64,255,64,16,63,16),
                new ColorPair(64,255,255,16,63,63),
                new ColorPair(255,64,64,63,16,16),
                new ColorPair(255,64,255,63,16,63),
                new ColorPair(255,255,64,63,63,16),
                new ColorPair(255,255,255,63,63,63)
            };
        }


        public ChatPreview() {
            InitializeComponent();
            DoubleBuffered = true;
        }


        private sealed class TextSegment {
            public string Text;
            public ColorPair Color;
            public int X, Y;

            public void Draw( Graphics g ) {
                g.DrawString( Text, MinecraftFont, Color.Shadow, X + 2, Y + 2 );
                g.DrawString( Text, MinecraftFont, Color.Foreground, X, Y );
            }
        }

        private static readonly Regex SplitByColorRegex = new Regex( "(&[0-9a-zA-Z])", RegexOptions.Compiled );
        private TextSegment[] _segments;

        public void SetText( string[] lines ) {
            List<TextSegment> newSegments = new List<TextSegment>();
            using( Bitmap b = new Bitmap( 1, 1 ) ) {
                using( Graphics g = Graphics.FromImage( b ) ) { // graphics for string measurement
                    g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

                    int y = 5;
                    foreach (var t in lines)
                    {
                        if( string.IsNullOrEmpty(t) ) continue;
                        int x = 5;
                        string[] plainTextSegments = SplitByColorRegex.Split( t );

                        int color = Color.ParseToIndex( Color.White );

                        foreach (var t1 in plainTextSegments)
                        {
                            if( t1.Length == 0 ) continue;
                            if( t1[0] == '&' ) {
                                color = Color.ParseToIndex( t1 );
                            } else {
                                newSegments.Add( new TextSegment {
                                    Color = ColorPairs[color],
                                    Text = t1,
                                    X = x,
                                    Y = y
                                } );
                                try
                                {
                                    if (!SectionClasses.ChatConfig.isPressed) x += (int) g.MeasureString(t1, MinecraftFont).Width;
                                    else
                                    {
                                        SectionClasses.ChatConfig.isPressed = false;
                                    }
                                }
                                catch (AccessViolationException)
                                {
                                    // Ignored
                                }
                            }
                        }
                        y += 20;
                    }

                }
            }
            _segments = newSegments.ToArray();
            Invalidate();
        }


        protected override void OnPaint( PaintEventArgs e ) {
            e.Graphics.DrawImageUnscaledAndClipped( Resources.ChatBackground, e.ClipRectangle );

            e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            if( _segments != null && _segments.Length > 0 )
            {
                foreach (var t in _segments)
                {
                    t.Draw( e.Graphics );
                }
            }

            base.OnPaint( e );
        }
    }
}