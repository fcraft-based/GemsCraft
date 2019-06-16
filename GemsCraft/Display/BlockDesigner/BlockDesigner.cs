using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using GemsCraft.Worlds.CustomBlocks;
using Color = System.Drawing.Color;

namespace GemsCraft.Display.BlockDesigner
{
    public partial class BlockDesigner : Form
    {
        private CustomBlock[] Current;
        private bool _canSave;
        private CustomBlock _block;
        public BlockDesigner()
        {
            InitializeComponent();
            _block = new CustomBlock();
            Current = CustomBlock.LoadBlocks().ToArray();
            // Display warning messages if close or at max amount of custom blocks
            if (Current.Length >= 151)
            {
                MessageBox.Show("Warning: Server cannot hold anymore custom blocks.\n" +
                                "Custom block will not be saved.");
                _canSave = false;
            }
            else if (Current.Length >= 140)
            {
                MessageBox.Show("Warning: Server almost out of room for custom blocks.\n" +
                                $"The server can only hold 151 and there are {Current.Length}" +
                                " saved");
                _canSave = true; // Allows blocks to be saved
            }
            else
            {
                _canSave = true;
            }

            _onesTaken = Current.Select(block => block.ID).Select(dummy => (int) dummy).ToList();
            
            // Add vanilla ID's
            for (int x = 0; x <= 84; x++)
            {
                _onesTaken.Add(x);
            }

            _onesTaken.Add(86);
            for (int x = 240; x <= 249; x++)
            {
                _onesTaken.Add(x);
            }

            numID.Value = GetValidInt();
            SetForeColor();
        }

        private readonly List<int> _onesTaken;

        private int GetValidInt()
        {
            int good = 0;
            while (_onesTaken.Contains(good))
            {
                good++;
            }

            return good;
        }
        private bool SaveBlock()
        {
            if (!_canSave) return false;
            return true;
        }

        private void numID_ValueChanged(object sender, EventArgs e)
        {
            if (_onesTaken.Contains((int) numID.Value))
            {
                numID.Value = GetValidInt();
            }
        }

        private void gboSettings_Enter(object sender, EventArgs e)
        {

        }

        private void btnFogColor_Click(object sender, EventArgs e)
        {
            colorChooser.AllowFullOpen = true;
            colorChooser.FullOpen = true;
            colorChooser.ShowHelp = true;
            colorChooser.ShowDialog();
            btnFogColor.BackColor = colorChooser.Color;
            SetForeColor();
            _block.FogR = btnFogColor.BackColor.R;
            _block.FogG = btnFogColor.BackColor.G;
            _block.FogB = btnFogColor.BackColor.B;
        }

        private void SetForeColor()
        {
            int r = btnFogColor.BackColor.R;
            int g = btnFogColor.BackColor.G;
            int b = btnFogColor.BackColor.B;

            btnFogColor.ForeColor =
                btnFogColor.BackColor.GetBrightness() < 0.5f
                    ? ControlPaint.LightLight(Color.FromArgb(r, g, b))
                    : ControlPaint.DarkDark(Color.FromArgb(r, g, b));
        }

        private void numSize_ValueChanged(object sender, EventArgs e)
        {
            _block.Shape = (byte) numSize.Value;
        }

        private void cboTransparency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransparency.SelectedIndex < 0) return;
            _block.BlockDraw = (BlockDraw) cboTransparency.SelectedIndex;
        }

        private void numFogDensity_ValueChanged(object sender, EventArgs e)
        {
            _block.FogDensity = (byte) numFogDensity.Value;
        }

        CustomBlockTexture texture = new CustomBlockTexture();
        private string GetFileSelection(string side)
        {
            while (true)
            {
                imageChooser.Title = $"Select {side} Texture";
                imageChooser.ShowDialog();
                while (imageChooser.FileName == null)
                {
                    imageChooser.ShowDialog();
                }

                string file = imageChooser.FileName;
                if (Path.GetExtension(file) != ".png")
                {
                    MessageBox.Show("Only png files are supported!");
                    continue;
                }

                break;
            }

            return imageChooser.FileName;
        }

        private List<string> imageLocations = new List<string>
        {
            "", "", ""
        };

        private void btnBottom_Click(object sender, EventArgs e) // 0
        {
            // Open File Open Dialog
            string s = GetFileSelection("Bottom");
            // Set the file selected
            imageLocations[0] = s;
            // Setup the value for the json object
            texture.BottomFilePath = s.Substring(s.LastIndexOf("/") + 1);
            // Check for any duplicate file names
            if (texture.BottomFilePath != texture.TopFilePath && texture.BottomFilePath != texture.SideFilePath) return;
            int rnd = new Random().Next(); // Use a random int to identify new file
            // Setup new name
            string newName = texture.BottomFilePath.Replace(".png", "") + rnd + ".png";
            // Copy to new name
            File.Copy(texture.BottomFilePath, newName);
            // Reset the file names to their new names
            imageLocations[0] = newName;
            texture.BottomFilePath = newName.Substring(s.LastIndexOf("/") + 1);
        }

        private void btnTop_Click(object sender, EventArgs e) // 1
        {
            string s = GetFileSelection("Top");
            imageLocations[1] = s;
            texture.TopFilePath = s.Substring(s.LastIndexOf("/") + 1);
            if (texture.TopFilePath != texture.BottomFilePath && texture.TopFilePath != texture.SideFilePath) return;
            int rnd = new Random().Next();
            string newName = texture.TopFilePath.Replace(".png", "") + rnd + ".png";
            File.Copy(texture.TopFilePath, newName);
            imageLocations[1] = newName;
            texture.TopFilePath = newName.Substring(s.LastIndexOf("/") + 1);
        }

        private void btnSide_Click(object sender, EventArgs e) // 2
        {
            string s = GetFileSelection("Side");
            imageLocations[2] = s;
            texture.SideFilePath = s.Substring(s.LastIndexOf("/") + 1);
            if (texture.SideFilePath != texture.TopFilePath && texture.SideFilePath != texture.BottomFilePath) return;
            int rnd = new Random().Next();
            string newName = texture.SideFilePath.Replace(".png", "") + rnd + ".png";
            File.Copy(texture.SideFilePath, newName);
            imageLocations[2] = newName;
            texture.SideFilePath = newName.Substring(s.LastIndexOf("/") + 1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Errors())
            {
                MessageBox.Show(_errorMessage);
                _errorMessage = FixedMessage; // Reset the error message
                return;
            }

            CustomBlock block = new CustomBlock
            {
                Name = txtName.Text,
                Solidity = (CustomBlockSolidity) cboSolidity.SelectedIndex,
                MovementSpeed = (byte) numMovementSpeed.Value,
                Texture = texture,
                TransmitsLight = chkTransmitsLight.Checked,
                WalkSound = (WalkSound) cboWalkSound.SelectedIndex,
                FullBright = chkFullBright.Checked,
                Shape = (byte) numSize.Value,
                BlockDraw = (BlockDraw) cboTransparency.SelectedIndex,
                FogDensity = (byte) numFogDensity.Value,
                FogR = btnFogColor.BackColor.R,
                FogG = btnFogColor.BackColor.G,
                FogB = btnFogColor.BackColor.B
            };
            string json = block.ToJson(); // Bottom Top Side
            const string tempDir = "CBTemp/";
            Directory.CreateDirectory(tempDir);
            var jsonWriter = File.CreateText(tempDir + "block.json");
            jsonWriter.Flush();
            jsonWriter.Close();
            File.Move(imageLocations[0], tempDir + texture.BottomFilePath);
            File.Move(imageLocations[1], tempDir + texture.TopFilePath);
            File.Move(imageLocations[2], tempDir + texture.SideFilePath);
            string fileName = txtName.Text + ".gcblock";
            ZipFile.CreateFromDirectory(tempDir, fileName);
            File.Move(fileName, "Custom Blocks/" + fileName);
            foreach (string file in Directory.GetFiles(tempDir)) File.Delete(file);
            Directory.Delete(tempDir);
        }

        private string _errorMessage = "Please fix the following errors:\n";
        private const string FixedMessage = "Please fix the following errors:\n";
        private bool Errors()
        {
            if (txtName.Text == string.Empty) _errorMessage += "Block Name cannot be empty\n";
            if (txtName.Text.Length > 64)
                _errorMessage += $"Block name cannot be more than 64. Currently is {txtName.Text.Length}\n";
            if (numMovementSpeed.Value < 0) _errorMessage += "Movement speed cannot be less than 0\n";
            if (numMovementSpeed.Value > 255) _errorMessage += "Movement speed cannot be more than 255\n";
            if (texture.BottomFilePath == null) _errorMessage += "You must choose a bottom texture\n";
            if (texture.TopFilePath == null) _errorMessage += "You must choose a top texture\n";
            if (texture.SideFilePath == null) _errorMessage += "You must choose a side texture\n";
            if (cboWalkSound.SelectedIndex == -1) _errorMessage += "You must select a walk sound\n";
            if (cboSolidity.SelectedIndex == -1) _errorMessage += "You must select a solidity\n";
            if (numSize.Value < 0) _errorMessage += "Size cannot be less than 0\n";
            if (numSize.Value > 16) _errorMessage += "Size cannot be more than 16\n";
            if (cboTransparency.SelectedIndex == -1) _errorMessage += "You must select a block draw.\n";
            if (numFogDensity.Value < 0) _errorMessage += "Fog Density cannot be less than 0\n";
            if (numFogDensity.Value > 255) _errorMessage += "Fog Density cannot be more than 255\n";

            return _errorMessage != FixedMessage;
        }
    }
    

}
