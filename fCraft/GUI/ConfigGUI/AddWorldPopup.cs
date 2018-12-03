// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GemsCraft.GUI.ConfigGUI.GUI;
using GemsCraft.MapConversion;
using GemsCraft.Players;
using GemsCraft.Utils;
using GemsCraft.Worlds;

// ReSharper disable CoVariantArrayConversion

namespace GemsCraft.GUI.ConfigGUI {
    internal sealed partial class AddWorldPopup : Form {
        private readonly BackgroundWorker _bwLoader = new BackgroundWorker(),
                                  _bwGenerator = new BackgroundWorker(),
                                  _bwRenderer = new BackgroundWorker();

        private const string MapLoadFilter = "Minecraft Maps|*.fcm;*.lvl;*.dat;*.mclevel;*.gz;*.map;*.meta;*.mine;*.save";

        private readonly object _redrawLock = new object();

        private Map _map;

        private Map Map {
            get => _map;
            set {
                try {
                    bOK.Invoke( (MethodInvoker)delegate {
                        try {
                            bOK.Enabled = (value != null);
                            lCreateMap.Visible = !bOK.Enabled;
                        } catch( ObjectDisposedException ) {
                        } catch( InvalidOperationException ) { }
                    } );
                } catch( ObjectDisposedException ) {
                } catch( InvalidOperationException ) { }
                _map = value;
            }
        }

        private Stopwatch _stopwatch;
        private int _previewRotation;
        private Bitmap _previewImage;
        private bool _floodBarrier;
        private string _originalWorldName;
        private readonly List<WorldListEntry> _copyOptionsList = new List<WorldListEntry>();
        private Tabs _tab;


        internal WorldListEntry World { get; private set; }


        public AddWorldPopup( WorldListEntry world ) {
            InitializeComponent();
            fileBrowser.Filter = MapLoadFilter;

            cBackup.Items.AddRange( WorldListEntry.BackupEnumNames );
            cTemplates.Items.AddRange( Enum.GetNames( typeof( MapGenTemplate ) ) );
            cTheme.Items.AddRange( Enum.GetNames( typeof( MapGenTheme ) ) );

            _bwLoader.DoWork += AsyncLoad;
            _bwLoader.RunWorkerCompleted += AsyncLoadCompleted;

            _bwGenerator.DoWork += AsyncGen;
            _bwGenerator.WorkerReportsProgress = true;
            _bwGenerator.ProgressChanged += AsyncGenProgress;
            _bwGenerator.RunWorkerCompleted += AsyncGenCompleted;

            _bwRenderer.WorkerReportsProgress = true;
            _bwRenderer.WorkerSupportsCancellation = true;
            _bwRenderer.DoWork += AsyncDraw;
            _bwRenderer.ProgressChanged += AsyncDrawProgress;
            _bwRenderer.RunWorkerCompleted += AsyncDrawCompleted;

            nMapWidth.Validating += MapDimensionValidating;
            nMapLength.Validating += MapDimensionValidating;
            nMapHeight.Validating += MapDimensionValidating;

            cAccess.Items.Add( "(everyone)" );
            cBuild.Items.Add( "(everyone)" );
            foreach( var rank in RankManager.Ranks ) {
                cAccess.Items.Add( MainForm.ToComboBoxOption( rank ) );
                cBuild.Items.Add( MainForm.ToComboBoxOption( rank ) );
            }

            tStatus1.Text = "";
            tStatus2.Text = "";

            World = world;

            _savePreviewDialog.Filter = "PNG Image|*.png|TIFF Image|*.tif;*.tiff|Bitmap Image|*.bmp|JPEG Image|*.jpg;*.jpeg";
            _savePreviewDialog.Title = "Saving preview image...";

            _browseTemplateDialog.Filter = "MapGenerator Template|*.ftpl";
            _browseTemplateDialog.Title = "Opening a MapGenerator template...";

            _saveTemplateDialog.Filter = _browseTemplateDialog.Filter;
            _saveTemplateDialog.Title = "Saving a MapGenerator template...";

            Shown += LoadMap;
        }


        void LoadMap( object sender, EventArgs args ) {
            // Fill in the "Copy existing world" combobox
            foreach( WorldListEntry otherWorld in MainForm.Worlds ) {
                if( otherWorld != World ) {
                    cWorld.Items.Add( otherWorld.Name + " (" + otherWorld.Description + ")" );
                    _copyOptionsList.Add( otherWorld );
                }
            }

            if( World == null ) {
                Text = "Adding a New World";

                // keep trying "NewWorld#" until we find an unused number
                int worldNameCounter = 1;
                while( MainForm.IsWorldNameTaken( "NewWorld" + worldNameCounter ) ) {
                    worldNameCounter++;
                }

                World = new WorldListEntry( "NewWorld" + worldNameCounter );

                tName.Text = World.Name;
                cAccess.SelectedIndex = 0;
                cBuild.SelectedIndex = 0;
                cBackup.SelectedIndex = 5;
                xBlockDB.CheckState = CheckState.Indeterminate;
                Map = null;

            } else {
                // Editing a world
                World = new WorldListEntry( World );
                Text = "Editing World \"" + World.Name + "\"";
                _originalWorldName = World.Name;
                tName.Text = World.Name;
                cAccess.SelectedItem = World.AccessPermission;
                cBuild.SelectedItem = World.BuildPermission;
                cBackup.SelectedItem = World.Backup;
                xHidden.Checked = World.Hidden;

                if (World.BlockDBEnabled == YesNoAuto.Auto)
                    xBlockDB.CheckState = CheckState.Indeterminate;
                else if (World.BlockDBEnabled == YesNoAuto.Yes)
                    xBlockDB.CheckState = CheckState.Checked;
                else if (World.BlockDBEnabled == YesNoAuto.No) xBlockDB.CheckState = CheckState.Unchecked;
            }

            // Disable "copy" tab if there are no other worlds
            if( cWorld.Items.Count > 0 ) {
                cWorld.SelectedIndex = 0;
            } else {
                tabs.TabPages.Remove( tabCopy );
            }

            // Disable "existing map" tab if map file does not exist
            _fileToLoad = World.FullFileName;
            if( File.Exists( _fileToLoad ) ) {
                ShowMapDetails( tExistingMapInfo, _fileToLoad );
                StartLoadingMap();
            } else {
                tabs.TabPages.Remove( tabExisting );
                tabs.SelectTab( tabLoad );
            }

            // Set Generator comboboxes to defaults
            cTemplates.SelectedIndex = (int)MapGenTemplate.River;

            _savePreviewDialog.FileName = World.Name;
        }


        #region Loading/Saving Map

        void StartLoadingMap() {
            Map = null;
            tStatus1.Text = "Loading " + new FileInfo( _fileToLoad ).Name;
            tStatus2.Text = "";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;
            _bwLoader.RunWorkerAsync();
        }

        private void bBrowseFile_Click( object sender, EventArgs e ) {
            fileBrowser.FileName = tFile.Text;
            if( fileBrowser.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty( fileBrowser.FileName ) ) {
                tFolder.Text = "";
                tFile.Text = fileBrowser.FileName;
                tFile.SelectAll();

                _fileToLoad = fileBrowser.FileName;
                ShowMapDetails( tLoadFileInfo, _fileToLoad );
                StartLoadingMap();
                World.MapChangedBy = WorldListEntry.WorldInfoSignature;
                World.MapChangedOn = DateTime.UtcNow;
            }
        }

        private void bBrowseFolder_Click( object sender, EventArgs e ) {
            if (folderBrowser.ShowDialog() != DialogResult.OK ||
                string.IsNullOrEmpty(folderBrowser.SelectedPath)) return;
            tFile.Text = "";
            tFolder.Text = folderBrowser.SelectedPath;
            tFolder.SelectAll();

            _fileToLoad = folderBrowser.SelectedPath;
            ShowMapDetails( tLoadFileInfo, _fileToLoad );
            StartLoadingMap();
            World.MapChangedBy = WorldListEntry.WorldInfoSignature;
            World.MapChangedOn = DateTime.UtcNow;
        }

        private string _fileToLoad;

        private void AsyncLoad( object sender, DoWorkEventArgs e ) {
            _stopwatch = Stopwatch.StartNew();
            try {
                Map = MapUtility.Load( _fileToLoad );
                Map.CalculateShadows();
            } catch( Exception ex ) {
                MessageBox.Show($"Could not load specified map: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private void AsyncLoadCompleted( object sender, RunWorkerCompletedEventArgs e ) {
            _stopwatch.Stop();
            if( Map == null ) {
                tStatus1.Text = "Load failed!";
            } else {
                tStatus1.Text = "Load successful (" + _stopwatch.Elapsed.TotalSeconds.ToString( "0.000" ) + "s)";
                tStatus2.Text = ", drawing...";
                Redraw( true );
            }
            if( _tab == Tabs.CopyWorld ) {
                bShow.Enabled = true;
            }
        }

        #endregion Loading


        #region Map Preview

        private IsoCat _renderer;

        void Redraw( bool drawAgain ) {
            lock( _redrawLock ) {
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Continuous;
                if( _bwRenderer.IsBusy ) {
                    _bwRenderer.CancelAsync();
                    while( _bwRenderer.IsBusy ) {
                        Thread.Sleep( 1 );
                        Application.DoEvents();
                    }
                }
                if( drawAgain ) _bwRenderer.RunWorkerAsync();
            }
        }

        private void AsyncDraw( object sender, DoWorkEventArgs e ) {
            _stopwatch = Stopwatch.StartNew();
            _renderer = new IsoCat( Map, IsoCatMode.Normal, _previewRotation );
            if( _bwRenderer.CancellationPending ) return;
            Bitmap rawImage = _renderer.Draw( out var cropRectangle, _bwRenderer );
            if( _bwRenderer.CancellationPending ) return;
            if( rawImage != null ) {
                _previewImage = rawImage.Clone( cropRectangle, rawImage.PixelFormat );
            }
            _renderer = null;
            GC.Collect( GC.MaxGeneration, GCCollectionMode.Optimized );
        }

        private void AsyncDrawProgress( object sender, ProgressChangedEventArgs e ) {
            progressBar.Value = e.ProgressPercentage;
        }

        void AsyncDrawCompleted( object sender, RunWorkerCompletedEventArgs e ) {
            _stopwatch.Stop();
            tStatus2.Text = $"drawn ({_stopwatch.Elapsed.TotalSeconds:0.000}s)";
            if( _previewImage != null && _previewImage != preview.Image ) {
                Image oldImage = preview.Image;
                oldImage?.Dispose();
                preview.Image = _previewImage;
                bSavePreview.Enabled = true;
            }
            progressBar.Visible = false;
        }

        private void bPreviewPrev_Click( object sender, EventArgs e ) {
            if( Map == null ) return;
            if( _previewRotation == 0 ) _previewRotation = 3;
            else _previewRotation--;
            tStatus2.Text = ", redrawing...";
            Redraw( true );
        }

        private void bPreviewNext_Click( object sender, EventArgs e ) {
            if( Map == null ) return;
            if( _previewRotation == 3 ) _previewRotation = 0;
            else _previewRotation++;
            tStatus2.Text = ", redrawing...";
            Redraw( true );
        }

        #endregion


        #region Map Generation

        private MapGeneratorArgs _generatorArgs = new MapGeneratorArgs();

        private void bGenerate_Click( object sender, EventArgs e ) {
            Map = null;
            bGenerate.Enabled = false;
            bFlatgrassGenerate.Enabled = false;

            if( _tab == Tabs.Generator ) {
                if( !xSeed.Checked ) {
                    nSeed.Value = GetRandomSeed();
                }

                SaveGeneratorArgs();
            }

            tStatus1.Text = "Generating...";
            tStatus2.Text = "";
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Value = 0;

            Refresh();
            _bwGenerator.RunWorkerAsync();
            World.MapChangedBy = WorldListEntry.WorldInfoSignature;
            World.MapChangedOn = DateTime.UtcNow;
        }

        void AsyncGen( object sender, DoWorkEventArgs e ) {
            _stopwatch = Stopwatch.StartNew();
            GC.Collect( GC.MaxGeneration, GCCollectionMode.Forced );
            Map generatedMap;
            if( _tab == Tabs.Generator ) {
                MapGenerator gen = new MapGenerator( _generatorArgs );
                gen.ProgressChanged +=
                    ( progressSender, progressArgs ) =>
                    _bwGenerator.ReportProgress( progressArgs.ProgressPercentage, progressArgs.UserState );
                generatedMap = gen.Generate();
            } else {
                generatedMap = MapGenerator.GenerateFlatgrass( Convert.ToInt32( nFlatgrassDimX.Value ),
                                                               Convert.ToInt32( nFlatgrassDimY.Value ),
                                                               Convert.ToInt32( nFlatgrassDimZ.Value ) );
            }

            if( _floodBarrier ) generatedMap.MakeFloodBarrier();
            generatedMap.CalculateShadows();
            Map = generatedMap;
            GC.Collect( GC.MaxGeneration, GCCollectionMode.Forced );
        }

        void AsyncGenProgress( object sender, ProgressChangedEventArgs e ) {
            progressBar.Value = e.ProgressPercentage;
            tStatus1.Text = (string)e.UserState;
        }

        void AsyncGenCompleted( object sender, RunWorkerCompletedEventArgs e ) {
            _stopwatch.Stop();
            if( Map == null ) {
                tStatus1.Text = "Generation failed!";
            } else {
                tStatus1.Text = "Generation successful (" + _stopwatch.Elapsed.TotalSeconds.ToString( "0.000" ) + "s)";
                tStatus2.Text = ", drawing...";
                Redraw( true );
            }
            bGenerate.Enabled = true;
            bFlatgrassGenerate.Enabled = true;
        }


        private readonly Random _rand = new Random();

        private int GetRandomSeed() {
            return _rand.Next() - _rand.Next();
        }

        #endregion


        #region Input Handlers

        private void xFloodBarrier_CheckedChanged( object sender, EventArgs e ) {
            _floodBarrier = xFloodBarrier.Checked;
        }


        static void MapDimensionValidating( object sender, CancelEventArgs e ) {
            ((NumericUpDown)sender).Value = Convert.ToInt32( ((NumericUpDown)sender).Value / 16 ) * 16;
        }


        void tName_Validating( object sender, CancelEventArgs e ) {
            if( Worlds.World.IsValidName( tName.Text ) &&
                (!MainForm.IsWorldNameTaken( tName.Text ) ||
                (_originalWorldName != null && tName.Text.ToLower() == _originalWorldName.ToLower())) ) {
                tName.ForeColor = SystemColors.ControlText;
            } else {
                tName.ForeColor = System.Drawing.Color.Red;
                e.Cancel = true;
            }
        }


        void tName_Validated( object sender, EventArgs e ) {
            World.Name = tName.Text;
        }


        void cAccess_SelectedIndexChanged( object sender, EventArgs e ) {
            World.AccessPermission = cAccess.SelectedItem.ToString();
        }


        void cBuild_SelectedIndexChanged( object sender, EventArgs e ) {
            World.BuildPermission = cBuild.SelectedItem.ToString();
        }


        void cBackup_SelectedIndexChanged( object sender, EventArgs e ) {
            World.Backup = cBackup.SelectedItem.ToString();
        }


        void xHidden_CheckedChanged( object sender, EventArgs e ) {
            World.Hidden = xHidden.Checked;
        }


        void bShow_Click( object sender, EventArgs e ) {
            if( cWorld.SelectedIndex != -1 && File.Exists( _copyOptionsList[cWorld.SelectedIndex].FullFileName ) ) {
                bShow.Enabled = false;
                _fileToLoad = _copyOptionsList[cWorld.SelectedIndex].FullFileName;
                ShowMapDetails( tCopyInfo, _fileToLoad );
                StartLoadingMap();
            }
        }


        void cWorld_SelectedIndexChanged( object sender, EventArgs e ) {
            if( cWorld.SelectedIndex != -1 ) {
                string fileName = _copyOptionsList[cWorld.SelectedIndex].FullFileName;
                bShow.Enabled = File.Exists( fileName );
                ShowMapDetails( tCopyInfo, fileName );
            }
        }


        void xAdvanced_CheckedChanged( object sender, EventArgs e ) {
            gTerrainFeatures.Visible = xAdvanced.Checked;
            gHeightmapCreation.Visible = xAdvanced.Checked;
            gTrees.Visible = xAdvanced.Checked && xAddTrees.Checked;
            gCaves.Visible = xCaves.Checked && xAdvanced.Checked;
            gSnow.Visible = xAdvanced.Checked && xAddSnow.Checked;
            gCliffs.Visible = xAdvanced.Checked && xAddCliffs.Checked;
            gBeaches.Visible = xAdvanced.Checked && xAddBeaches.Checked;
        }


        void MapDimensionChanged( object sender, EventArgs e ) {
            sFeatureScale.Maximum = (int)Math.Log( (double)Math.Max( nMapWidth.Value, nMapLength.Value ), 2 );
            int value = sDetailScale.Maximum - sDetailScale.Value;
            sDetailScale.Maximum = sFeatureScale.Maximum;
            sDetailScale.Value = sDetailScale.Maximum - value;

            int resolution = 1 << (sDetailScale.Maximum - sDetailScale.Value);
            lDetailSizeDisplay.Text = resolution + "×" + resolution;
            resolution = 1 << (sFeatureScale.Maximum - sFeatureScale.Value);
            lFeatureSizeDisplay.Text = resolution + "×" + resolution;
        }


        void sFeatureSize_ValueChanged( object sender, EventArgs e ) {
            int resolution = 1 << (sFeatureScale.Maximum - sFeatureScale.Value);
            lFeatureSizeDisplay.Text = resolution + "×" + resolution;
            if( sDetailScale.Value < sFeatureScale.Value ) {
                sDetailScale.Value = sFeatureScale.Value;
            }
        }


        void sDetailSize_ValueChanged( object sender, EventArgs e ) {
            int resolution = 1 << (sDetailScale.Maximum - sDetailScale.Value);
            lDetailSizeDisplay.Text = resolution + "×" + resolution;
            if( sFeatureScale.Value > sDetailScale.Value ) {
                sFeatureScale.Value = sDetailScale.Value;
            }
        }


        void xMatchWaterCoverage_CheckedChanged( object sender, EventArgs e ) {
            sWaterCoverage.Enabled = xMatchWaterCoverage.Checked;
        }


        void sWaterCoverage_ValueChanged( object sender, EventArgs e ) {
            lMatchWaterCoverageDisplay.Text = sWaterCoverage.Value + "%";
        }


        void sBias_ValueChanged( object sender, EventArgs e ) {
            lBiasDisplay.Text = sBias.Value + "%";
            bool useBias = (sBias.Value != 0);

            nRaisedCorners.Enabled = useBias;
            nLoweredCorners.Enabled = useBias;
            cMidpoint.Enabled = useBias;
            xDelayBias.Enabled = useBias;
        }


        void sRoughness_ValueChanged( object sender, EventArgs e ) {
            lRoughnessDisplay.Text = sRoughness.Value + "%";
        }


        void xSeed_CheckedChanged( object sender, EventArgs e ) {
            nSeed.Enabled = xSeed.Checked;
        }


        void nRaisedCorners_ValueChanged( object sender, EventArgs e ) {
            nLoweredCorners.Value = Math.Min( 4 - nRaisedCorners.Value, nLoweredCorners.Value );
        }


        void nLoweredCorners_ValueChanged( object sender, EventArgs e ) {
            nRaisedCorners.Value = Math.Min( 4 - nLoweredCorners.Value, nRaisedCorners.Value );
        }

        #endregion


        #region Tabs

        private void tabs_SelectedIndexChanged( object sender, EventArgs e ) {
            if( tabs.SelectedTab == tabExisting ) {
                _tab = Tabs.ExistingMap;
            } else if( tabs.SelectedTab == tabLoad ) {
                _tab = Tabs.LoadFile;
            } else if( tabs.SelectedTab == tabCopy ) {
                _tab = Tabs.CopyWorld;
            } else if( tabs.SelectedTab == tabFlatgrass ) {
                _tab = Tabs.Flatgrass;
            } else {
                _tab = Tabs.Generator;
            }

            switch( _tab ) {
                case Tabs.ExistingMap:
                    _fileToLoad = World.FullFileName;
                    ShowMapDetails( tExistingMapInfo, _fileToLoad );
                    StartLoadingMap();
                    return;
                case Tabs.LoadFile:
                    if( !String.IsNullOrEmpty( tFile.Text ) ) {
                        tFile.SelectAll();
                        _fileToLoad = tFile.Text;
                        ShowMapDetails( tLoadFileInfo, _fileToLoad );
                        StartLoadingMap();
                    }
                    return;
                case Tabs.CopyWorld:
                    if( cWorld.SelectedIndex != -1 ) {
                        bShow.Enabled = File.Exists( _copyOptionsList[cWorld.SelectedIndex].FullFileName );
                    }
                    return;
                case Tabs.Flatgrass:
                    return;
                case Tabs.Generator:
                    return;
            }
        }

        private enum Tabs {
            ExistingMap,
            LoadFile,
            CopyWorld,
            Flatgrass,
            Generator
        }

        #endregion


        private static void ShowMapDetails( TextBox textBox, string fileName ) {
            DateTime creationTime, modificationTime;
            long fileSize;

            if( File.Exists( fileName ) ) {
                FileInfo existingMapFileInfo = new FileInfo( fileName );
                creationTime = existingMapFileInfo.CreationTime;
                modificationTime = existingMapFileInfo.LastWriteTime;
                fileSize = existingMapFileInfo.Length;

            } else if( Directory.Exists( fileName ) ) {
                DirectoryInfo dirInfo = new DirectoryInfo( fileName );
                creationTime = dirInfo.CreationTime;
                modificationTime = dirInfo.LastWriteTime;
                fileSize = dirInfo.GetFiles().Sum( finfo => finfo.Length );

            } else {
                textBox.Text = "File or directory \"" + fileName + "\" does not exist.";
                return;
            }

            MapFormat format = MapUtility.Identify( fileName, true );
            try {
                Map loadedMap = MapUtility.LoadHeader( fileName );
                const string msgFormat =
@"  Location: {0}
    Format: {1}
  Filesize: {2} KB
   Created: {3}
  Modified: {4}
Dimensions: {5}×{6}×{7}
    Blocks: {8}";
                textBox.Text = string.Format( msgFormat,
                                              fileName,
                                              format,
                                              (fileSize / 1024),
                                              creationTime.ToLongDateString(),
                                              modificationTime.ToLongDateString(),
                                              loadedMap.Width,
                                              loadedMap.Length,
                                              loadedMap.Height,
                                              loadedMap.Volume );

            } catch( Exception ex ) {
                const string msgFormat =
@"  Location: {0}
    Format: {1}
  Filesize: {2} KB
   Created: {3}
  Modified: {4}

Could not load more information:
{5}: {6}";
                textBox.Text = string.Format( msgFormat,
                                              fileName,
                                              format,
                                              (fileSize / 1024),
                                              creationTime.ToLongDateString(),
                                              modificationTime.ToLongDateString(),
                                              ex.GetType().Name,
                                              ex.Message );
            }
        }


        private void AddWorldPopup_FormClosing( object sender, FormClosingEventArgs e ) {
            Redraw( false );
            if( DialogResult == DialogResult.OK ) {
                if( Map == null ) {
                    e.Cancel = true;
                } else {
                    _bwRenderer.CancelAsync();
                    Enabled = false;
                    progressBar.Visible = true;
                    progressBar.Style = ProgressBarStyle.Marquee;
                    tStatus1.Text = "Saving map...";
                    tStatus2.Text = "";
                    Refresh();

                    string newFileName = World.FullFileName;
                    Map.Save( newFileName );
                    string oldFileName = Path.Combine( Paths.MapPath, _originalWorldName + ".fcm" );

                    if (_originalWorldName == null || _originalWorldName == World.Name ||
                        !File.Exists(oldFileName)) return;
                    try {
                        File.Delete( oldFileName );
                    } catch( Exception ex ) {
                        var errorMessage =
                            $"Renaming the map file failed. Please delete the old file ({_originalWorldName}.fcm) manually.{Environment.NewLine}{ex}";
                        MessageBox.Show( errorMessage, "Error renaming the map file" );
                    }
                }
            }
        }


        private readonly SaveFileDialog _savePreviewDialog = new SaveFileDialog();
        private void bSavePreview_Click( object sender, EventArgs e ) {
            try {
                using( Image img = (Image)preview.Image.Clone() )
                {
                    if (_savePreviewDialog.ShowDialog() != DialogResult.OK ||
                        string.IsNullOrEmpty(_savePreviewDialog.FileName)) return;
                    switch( _savePreviewDialog.FilterIndex ) {
                        case 1:
                            img.Save( _savePreviewDialog.FileName, ImageFormat.Png ); break;
                        case 2:
                            img.Save( _savePreviewDialog.FileName, ImageFormat.Tiff ); break;
                        case 3:
                            img.Save( _savePreviewDialog.FileName, ImageFormat.Bmp ); break;
                        case 4:
                            img.Save( _savePreviewDialog.FileName, ImageFormat.Jpeg ); break;
                    }
                }
            } catch( Exception ex ) {
                MessageBox.Show( "Could not prepare image for saving: " + ex );
            }
        }


        private readonly OpenFileDialog _browseTemplateDialog = new OpenFileDialog();
        private void bBrowseTemplate_Click( object sender, EventArgs e )
        {
            if (_browseTemplateDialog.ShowDialog() != DialogResult.OK ||
                string.IsNullOrEmpty(_browseTemplateDialog.FileName)) return;
            try {
                _generatorArgs = new MapGeneratorArgs( _browseTemplateDialog.FileName );
                LoadGeneratorArgs();
                bGenerate.PerformClick();
            } catch( Exception ex ) {
                MessageBox.Show( "Could not open template file: " + ex );
            }
        }

        private void LoadGeneratorArgs() {
            nMapHeight.Value = _generatorArgs.MapHeight;
            nMapWidth.Value = _generatorArgs.MapWidth;
            nMapLength.Value = _generatorArgs.MapLength;

            cTheme.SelectedIndex = (int)_generatorArgs.Theme;

            sDetailScale.Value = _generatorArgs.DetailScale;
            sFeatureScale.Value = _generatorArgs.FeatureScale;

            xLayeredHeightmap.Checked = _generatorArgs.LayeredHeightmap;
            xMarbledMode.Checked = _generatorArgs.MarbledHeightmap;
            xMatchWaterCoverage.Checked = _generatorArgs.MatchWaterCoverage;
            xInvert.Checked = _generatorArgs.InvertHeightmap;

            nMaxDepth.Value = _generatorArgs.MaxDepth;
            nMaxHeight.Value = _generatorArgs.MaxHeight;
            sRoughness.Value = (int)(_generatorArgs.Roughness * 100);
            nSeed.Value = _generatorArgs.Seed;
            xWater.Checked = _generatorArgs.AddWater;

            if( _generatorArgs.UseBias ) sBias.Value = (int)(_generatorArgs.Bias * 100);
            else sBias.Value = 0;
            xDelayBias.Checked = _generatorArgs.DelayBias;

            sWaterCoverage.Value = (int)(100 * _generatorArgs.WaterCoverage);
            cMidpoint.SelectedIndex = _generatorArgs.MidPoint + 1;
            nRaisedCorners.Value = _generatorArgs.RaisedCorners;
            nLoweredCorners.Value = _generatorArgs.LoweredCorners;

            xAddTrees.Checked = _generatorArgs.AddTrees;
            xGiantTrees.Checked = _generatorArgs.AddGiantTrees;
            nTreeHeight.Value = (_generatorArgs.TreeHeightMax + _generatorArgs.TreeHeightMin) / 2m;
            nTreeHeightVariation.Value = (_generatorArgs.TreeHeightMax - _generatorArgs.TreeHeightMin) / 2m;
            nTreeSpacing.Value = (_generatorArgs.TreeSpacingMax + _generatorArgs.TreeSpacingMin) / 2m;
            nTreeSpacingVariation.Value = (_generatorArgs.TreeSpacingMax - _generatorArgs.TreeSpacingMin) / 2m;

            xCaves.Checked = _generatorArgs.AddCaves;
            xCaveLava.Checked = _generatorArgs.AddCaveLava;
            xCaveWater.Checked = _generatorArgs.AddCaveWater;
            xOre.Checked = _generatorArgs.AddOre;
            sCaveDensity.Value = (int)(_generatorArgs.CaveDensity * 100);
            sCaveSize.Value = (int)(_generatorArgs.CaveSize * 100);

            xWaterLevel.Checked = _generatorArgs.CustomWaterLevel;
            nWaterLevel.Maximum = _generatorArgs.MapHeight;
            nWaterLevel.Value = Math.Min( _generatorArgs.WaterLevel, _generatorArgs.MapHeight );

            xAddSnow.Checked = _generatorArgs.AddSnow;

            nSnowAltitude.Value = _generatorArgs.SnowAltitude - (_generatorArgs.CustomWaterLevel ? _generatorArgs.WaterLevel : _generatorArgs.MapHeight / 2);
            nSnowTransition.Value = _generatorArgs.SnowTransition;

            xAddCliffs.Checked = _generatorArgs.AddCliffs;
            sCliffThreshold.Value = (int)(_generatorArgs.CliffThreshold * 100);
            xCliffSmoothing.Checked = _generatorArgs.CliffSmoothing;

            xAddBeaches.Checked = _generatorArgs.AddBeaches;
            nBeachExtent.Value = _generatorArgs.BeachExtent;
            nBeachHeight.Value = _generatorArgs.BeachHeight;

            sAboveFunc.Value = ExponentToTrackBar( sAboveFunc, _generatorArgs.AboveFuncExponent );
            sBelowFunc.Value = ExponentToTrackBar( sBelowFunc, _generatorArgs.BelowFuncExponent );

            nMaxHeightVariation.Value = _generatorArgs.MaxHeightVariation;
            nMaxDepthVariation.Value = _generatorArgs.MaxDepthVariation;
        }

        void SaveGeneratorArgs() {
            _generatorArgs = new MapGeneratorArgs {
                DetailScale = sDetailScale.Value,
                FeatureScale = sFeatureScale.Value,
                MapHeight = (int)nMapHeight.Value,
                MapWidth = (int)nMapWidth.Value,
                MapLength = (int)nMapLength.Value,
                LayeredHeightmap = xLayeredHeightmap.Checked,
                MarbledHeightmap = xMarbledMode.Checked,
                MatchWaterCoverage = xMatchWaterCoverage.Checked,
                MaxDepth = (int)nMaxDepth.Value,
                MaxHeight = (int)nMaxHeight.Value,
                AddTrees = xAddTrees.Checked,
                AddGiantTrees = xGiantTrees.Checked,
                Roughness = sRoughness.Value / 100f,
                Seed = (int)nSeed.Value,
                Theme = (MapGenTheme)cTheme.SelectedIndex,
                TreeHeightMax = (int)(nTreeHeight.Value + nTreeHeightVariation.Value),
                TreeHeightMin = (int)(nTreeHeight.Value - nTreeHeightVariation.Value),
                TreeSpacingMax = (int)(nTreeSpacing.Value + nTreeSpacingVariation.Value),
                TreeSpacingMin = (int)(nTreeSpacing.Value - nTreeSpacingVariation.Value),
                UseBias = (sBias.Value != 0),
                DelayBias = xDelayBias.Checked,
                WaterCoverage = sWaterCoverage.Value / 100f,
                Bias = sBias.Value / 100f,
                MidPoint = cMidpoint.SelectedIndex - 1,
                RaisedCorners = (int)nRaisedCorners.Value,
                LoweredCorners = (int)nLoweredCorners.Value,
                InvertHeightmap = xInvert.Checked,
                AddWater = xWater.Checked,
                AddCaves = xCaves.Checked,
                AddOre = xOre.Checked,
                AddCaveLava = xCaveLava.Checked,
                AddCaveWater = xCaveWater.Checked,
                CaveDensity = sCaveDensity.Value / 100f,
                CaveSize = sCaveSize.Value / 100f,
                CustomWaterLevel = xWaterLevel.Checked,
                WaterLevel = (int)(xWaterLevel.Checked ? nWaterLevel.Value : nMapHeight.Value / 2),
                AddSnow = xAddSnow.Checked,
                SnowTransition = (int)nSnowTransition.Value,
                SnowAltitude = (int)(nSnowAltitude.Value + (xWaterLevel.Checked ? nWaterLevel.Value : nMapHeight.Value / 2)),
                AddCliffs = xAddCliffs.Checked,
                CliffThreshold = sCliffThreshold.Value / 100f,
                CliffSmoothing = xCliffSmoothing.Checked,
                AddBeaches = xAddBeaches.Checked,
                BeachExtent = (int)nBeachExtent.Value,
                BeachHeight = (int)nBeachHeight.Value,
                AboveFuncExponent = TrackBarToExponent( sAboveFunc ),
                BelowFuncExponent = TrackBarToExponent( sBelowFunc ),
                MaxHeightVariation = (int)nMaxHeightVariation.Value,
                MaxDepthVariation = (int)nMaxDepthVariation.Value
            };
        }


        private readonly SaveFileDialog _saveTemplateDialog = new SaveFileDialog();
        private void bSaveTemplate_Click( object sender, EventArgs e )
        {
            if (_saveTemplateDialog.ShowDialog() != DialogResult.OK ||
                String.IsNullOrEmpty(_saveTemplateDialog.FileName)) return;
            try {
                SaveGeneratorArgs();
                _generatorArgs.Save( _saveTemplateDialog.FileName );
            } catch( Exception ex ) {
                MessageBox.Show( "Could not open template file: " + ex );
            }
        }

        private void cTemplates_SelectedIndexChanged( object sender, EventArgs e ) {
            _generatorArgs = MapGenerator.MakeTemplate( (MapGenTemplate)cTemplates.SelectedIndex );
            LoadGeneratorArgs();
            bGenerate.PerformClick();
        }

        private void xCaves_CheckedChanged( object sender, EventArgs e ) {
            gCaves.Visible = xCaves.Checked && xAdvanced.Checked;
        }

        private void sCaveDensity_ValueChanged( object sender, EventArgs e ) {
            lCaveDensityDisplay.Text = sCaveDensity.Value + "%";
        }

        private void sCaveSize_ValueChanged( object sender, EventArgs e ) {
            lCaveSizeDisplay.Text = sCaveSize.Value + "%";
        }

        private void xWaterLevel_CheckedChanged( object sender, EventArgs e ) {
            nWaterLevel.Enabled = xWaterLevel.Checked;
        }

        private void nHeight_ValueChanged( object sender, EventArgs e ) {
            nWaterLevel.Value = Math.Min( nWaterLevel.Value, nMapHeight.Value );
            nWaterLevel.Maximum = nMapHeight.Value;
        }

        private void xAddTrees_CheckedChanged( object sender, EventArgs e ) {
            gTrees.Visible = xAddTrees.Checked;
        }

        private void xWater_CheckedChanged( object sender, EventArgs e ) {
            xAddBeaches.Enabled = xWater.Checked;
        }

        private void sAboveFunc_ValueChanged( object sender, EventArgs e ) {
            lAboveFuncUnits.Text = (1 / TrackBarToExponent( sAboveFunc )).ToString( "0.0%" );
        }

        private void sBelowFunc_ValueChanged( object sender, EventArgs e ) {
            lBelowFuncUnits.Text = (1 / TrackBarToExponent( sBelowFunc )).ToString( "0.0%" );
        }

        static float TrackBarToExponent( TrackBar bar ) {
            if( bar.Value >= bar.Maximum / 2 ) {
                float normalized = (bar.Value - bar.Maximum / 2f) / (bar.Maximum / 2f);
                return 1 + normalized * normalized * 3;
            } else {
                float normalized = (bar.Value / (bar.Maximum / 2f));
                return normalized * .75f + .25f;
            }
        }

        static int ExponentToTrackBar( TrackBar bar, float val ) {
            if( val >= 1 ) {
                float normalized = (float)Math.Sqrt( (val - 1) / 3f );
                return (int)(bar.Maximum / 2f + normalized * (bar.Maximum / 2f));
            } else {
                float normalized = (val - .25f) / .75f;
                return (int)(normalized * bar.Maximum / 2f);
            }
        }

        private void sCliffThreshold_ValueChanged( object sender, EventArgs e ) {
            lCliffThresholdUnits.Text = sCliffThreshold.Value + "%";
        }

        private void xAddSnow_CheckedChanged( object sender, EventArgs e ) {
            gSnow.Visible = xAdvanced.Checked && xAddSnow.Checked;
        }

        private void xAddCliffs_CheckedChanged( object sender, EventArgs e ) {
            gCliffs.Visible = xAdvanced.Checked && xAddCliffs.Checked;
        }

        private void xAddBeaches_CheckedChanged( object sender, EventArgs e ) {
            gBeaches.Visible = xAdvanced.Checked && xAddBeaches.Checked;
        }

        private void xBlockDB_CheckStateChanged( object sender, EventArgs e ) {
            switch( xBlockDB.CheckState ) {
                case CheckState.Indeterminate:
                    World.BlockDBEnabled = YesNoAuto.Auto;
                    xBlockDB.Text = "BlockDB (Auto)";
                    break;
                case CheckState.Checked:
                    World.BlockDBEnabled = YesNoAuto.Yes;
                    xBlockDB.Text = "BlockDB (On)";
                    break;
                case CheckState.Unchecked:
                    World.BlockDBEnabled = YesNoAuto.No;
                    xBlockDB.Text = "BlockDB (Off)";
                    break;
            }
        }
    }
}