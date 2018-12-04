// Copyright 2009-2012 Matvei Stefarov <me@matvei.org>

using System;
using System.Windows.Forms;
using GemsCraft.Utils;

namespace GemsCraft.GUI.ConfigGUI {
    public sealed partial class UpdaterSettingsPopup : Form {

        public string RunBeforeUpdate {
            get => xRunBeforeUpdate.Checked ? tRunBeforeUpdate.Text : "";
            set => tRunBeforeUpdate.Text = value;
        }

        public string RunAfterUpdate {
            get => xRunAfterUpdate.Checked ? tRunAfterUpdate.Text : "";
            set => tRunAfterUpdate.Text = value;
        }
        

        public bool BackupBeforeUpdate {
            get => xBackupBeforeUpdating.Checked;
            set => xBackupBeforeUpdating.Checked = value;
        }

        string oldRunBeforeUpdate, oldRunAfterUpdate;
        bool oldBackupBeforeUpdate;

        public UpdaterSettingsPopup() {
            InitializeComponent();
            Shown += delegate {
                oldRunBeforeUpdate = RunBeforeUpdate;
                oldRunAfterUpdate = RunAfterUpdate;
                oldBackupBeforeUpdate = BackupBeforeUpdate;
            };
            FormClosed += delegate {
                if( DialogResult != DialogResult.OK ) {
                    RunBeforeUpdate = oldRunBeforeUpdate;
                    RunAfterUpdate = oldRunAfterUpdate;
                    BackupBeforeUpdate = oldBackupBeforeUpdate;
                }
            };
        }

        private void xRunBeforeUpdate_CheckedChanged( object sender, EventArgs e ) {
            tRunBeforeUpdate.Enabled = xRunBeforeUpdate.Checked;
        }

        private void xRunAfterUpdate_CheckedChanged( object sender, EventArgs e ) {
            tRunAfterUpdate.Enabled = xRunAfterUpdate.Checked;
        }

        private void rDisabled_CheckedChanged( object sender, EventArgs e ) {
            gOptions.Enabled = !rDisabled.Checked;
        }


        private void tRunBeforeUpdate_TextChanged( object sender, EventArgs e ) {
            if( tRunBeforeUpdate.Text.Length > 0 ) {
                xRunBeforeUpdate.Checked = true;
            }
        }

        private void tRunAfterUpdate_TextChanged( object sender, EventArgs e ) {
            if( tRunAfterUpdate.Text.Length > 0 ) {
                xRunAfterUpdate.Checked = true;
            }
        }
    }
}