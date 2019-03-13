using System;
using System.ComponentModel;
using GemsCraft.Plugins;
using MetroFramework.Forms;

namespace GemsCraft.Display.ConfigGUI.GUI.Sections
{
    public partial class PluginConfig : MetroForm
    {
        public PluginConfig()
        {
            InitializeComponent();
            InputHandlers();
            this.Closing += Exit;
        }
        private void Exit(object sender, CancelEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void InputHandlers()
        {
            propertyGrid3.SelectedObjectsChanged += PluginPropertyChanged;
        }

        private void PluginPropertyChanged(object sender, EventArgs e)
        {
            int index = listPlugins.SelectedIndex;
            PluginManager.Plugins[index] = (IPlugin)propertyGrid3.SelectedObject;
        }

        private void PluginConfig_Load(object sender, System.EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            listPlugins.Enabled = checkBox2.Checked;
            propertyGrid3.Enabled = checkBox2.Checked;
        }
    }
}
