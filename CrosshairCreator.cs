using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenCrosshair
{
    public partial class crosshaircreator : Form
    {
        private Color crosshairColor = Color.Red;
        private int thickness = 3;
        private int length = 10;
        private int gap = 10;
        private bool showCenterDot = false;
        private bool showUpperBar = true;

        private CrossHair overlayForm;


        
        public crosshaircreator()
        {
            InitializeComponent();
            this.DragEnter += new DragEventHandler(Form_DragEnter);
            this.DragDrop += new DragEventHandler(Form_DragDrop);
            // Handle form closing to save settings
            this.FormClosing += (sender, e) => SaveTemporaryCrosshairSettings();

            // Load last crosshair settings
            LoadTemporaryCrosshairSettings();
        }

        private void panelCrosshair_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int centerX = panelCrosshair.Width / 2;
            int centerY = panelCrosshair.Height / 2;
            DrawCrosshair(g, centerX, centerY);
        }

        private void DrawCrosshair(Graphics g, int centerX, int centerY)
        {
            using (Pen pen = new Pen(crosshairColor, thickness))
            {
                // Draw horizontal lines
                g.DrawLine(pen, centerX - length - gap, centerY, centerX - gap, centerY);
                g.DrawLine(pen, centerX + gap, centerY, centerX + length + gap, centerY);

                // Draw vertical lines (excluding upper bar if not shown)
                if (showUpperBar)
                {
                    g.DrawLine(pen, centerX, centerY - length - gap, centerX, centerY - gap);
                }
                g.DrawLine(pen, centerX, centerY + gap, centerX, centerY + length + gap);

                // Draw center dot if enabled
                if (showCenterDot)
                {
                    g.FillEllipse(new SolidBrush(crosshairColor), centerX - thickness / 2, centerY - thickness / 2, thickness, thickness);
                }
            }
        }

        private void buttonSetColor_Click(object sender, EventArgs e)
        {
            if (ShowColorDialog(out Color color))
            {
                crosshairColor = color;
                panelCrosshair.Invalidate(); // Redraw the panel
                UpdateOverlayForm();
            }
        }

        private bool ShowColorDialog(out Color selectedColor)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedColor = colorDialog.Color;
                    return true;
                }
            }
            selectedColor = default;
            return false;
        }

        private void trackBarThickness_Scroll(object sender, EventArgs e)
        {
            thickness = trackBarThickness.Value;
            panelCrosshair.Invalidate();
            UpdateOverlayForm();
        }

        private void trackBarLength_Scroll(object sender, EventArgs e)
        {
            length = trackBarLength.Value;
            panelCrosshair.Invalidate();
            UpdateOverlayForm();
        }

        private void trackBarGap_Scroll(object sender, EventArgs e)
        {
            gap = trackBarGap.Value;
            panelCrosshair.Invalidate();
            UpdateOverlayForm();
        }

        private void buttonToggleCrosshair_Click(object sender, EventArgs e)
        {
            ToggleOverlayForm();
        }

        private void ToggleOverlayForm()
        {
            if (overlayForm == null || overlayForm.IsDisposed)
            {
                overlayForm = new CrossHair(crosshairColor, thickness, length, gap, showCenterDot, showUpperBar)
                {
                    TopMost = true
                };
                overlayForm.Show();
                buttonToggleCrosshair.Text = "Hide Crosshair";
            }
            else
            {
                overlayForm.Close();
                buttonToggleCrosshair.Text = "Show Crosshair";
            }
        }

        private void UpdateOverlayForm()
        {
            if (overlayForm != null && !overlayForm.IsDisposed)
            {
                overlayForm.UpdateCrosshair(crosshairColor, thickness, length, gap, showCenterDot, showUpperBar);
            }
        }



        private void SaveCrosshairSettings()
        {
            if (ShowSaveFileDialog(out string path))
            {
                string settings = $"{crosshairColor.R},{crosshairColor.G},{crosshairColor.B},{thickness},{length},{gap},{showCenterDot},{showUpperBar}";
                try
                {
                    File.WriteAllText(path, settings);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ShowSaveFileDialog(out string path)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.InitialDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OpenCrosshair");
                saveFileDialog.FileName = "crosshair";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    return true;
                }
            }
            path = null;
            return false;
        }

        private void LoadCrosshairSettings()
        {
            if (ShowOpenFileDialog(out string path))
            {
                try
                {
                    string[] values = File.ReadAllText(path).Split(',');
                    if (values.Length == 8)
                    {
                        crosshairColor = Color.FromArgb(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
                        thickness = int.Parse(values[3]);
                        length = int.Parse(values[4]);
                        gap = int.Parse(values[5]);
                        showCenterDot = bool.Parse(values[6]);
                        showUpperBar = bool.Parse(values[7]);

                        UpdateUIComponents();
                        panelCrosshair.Invalidate();
                    }
                    else
                    {
                        MessageBox.Show("Invalid file format.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ShowOpenFileDialog(out string path)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Select a crosshair settings file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    return true;
                }
            }
            path = null;
            return false;
        }

        private void UpdateUIComponents()
        {
            trackBarThickness.Value = thickness;
            trackBarLength.Value = length;
            trackBarGap.Value = gap;
            checkBoxCenterDot.Checked = showCenterDot;
            checkBoxUpperBar.Checked = showUpperBar;
        }

        private void buttonLoadCrosshair_Click(object sender, EventArgs e)
        {
            LoadCrosshairSettings();
        }

        public void SaveCrosshairButton_Click(object sender, EventArgs e)
        {
            SaveCrosshairSettings();
        }

        private void checkBoxCenterDot_CheckedChanged(object sender, EventArgs e)
        {
            showCenterDot = checkBoxCenterDot.Checked;
            panelCrosshair.Invalidate();
            UpdateOverlayForm();
        }

        public void checkBoxUpperBar_CheckedChanged(object sender, EventArgs e)
        {
            showUpperBar = checkBoxUpperBar.Checked;
            panelCrosshair.Invalidate();
            UpdateOverlayForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Alt | Keys.Z))
            {
                ToggleOverlayForm();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form_DragEnter(object sender, DragEventArgs e)
{
    // Check if the dragged data is a file
    if (e.Data.GetDataPresent(DataFormats.FileDrop))
    {
        e.Effect = DragDropEffects.Copy;
    }
    else
    {
        e.Effect = DragDropEffects.None;
    }
}

private void Form_DragDrop(object sender, DragEventArgs e)
{
    // Get the dropped files
    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

    if (files.Length > 0)
    {
        string filePath = files[0];
        
        // Load crosshair settings from the file
        try
        {
            string[] values = File.ReadAllText(filePath).Split(',');
            if (values.Length == 8)
            {
                crosshairColor = Color.FromArgb(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
                thickness = int.Parse(values[3]);
                length = int.Parse(values[4]);
                gap = int.Parse(values[5]);
                showCenterDot = bool.Parse(values[6]);
                showUpperBar = bool.Parse(values[7]);

                UpdateUIComponents();
                panelCrosshair.Invalidate();
                UpdateOverlayForm();
                
            }
            else
            {
                MessageBox.Show("Invalid file format.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading file: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    }
    private void SaveTemporaryCrosshairSettings()
{
    try
    {
        string tempFilePath = GetTemporaryFilePath();
        string settings = $"{crosshairColor.R},{crosshairColor.G},{crosshairColor.B},{thickness},{length},{gap},{showCenterDot},{showUpperBar}";
        File.WriteAllText(tempFilePath, settings);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error saving temporary settings: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

private string GetTemporaryFilePath()
{
    string tempDir = Path.GetTempPath();
    return Path.Combine(tempDir, "OpenCrosshair_temp.txt");
}
private void LoadTemporaryCrosshairSettings()
{
    try
    {
        string tempFilePath = GetTemporaryFilePath();

        // Check if the temporary file exists
        if (File.Exists(tempFilePath))
        {
            string[] values = File.ReadAllText(tempFilePath).Split(',');

            // Validate the expected number of values
            if (values.Length == 8)
            {
                // Parse the saved values
                crosshairColor = Color.FromArgb(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
                thickness = int.Parse(values[3]);
                length = int.Parse(values[4]);
                gap = int.Parse(values[5]);
                showCenterDot = bool.Parse(values[6]);
                showUpperBar = bool.Parse(values[7]);

                // Update the UI and redraw the crosshair
                UpdateUIComponents();
                panelCrosshair.Invalidate();
                UpdateOverlayForm();
            }
            else
            {
                MessageBox.Show("Temporary settings file is corrupt or invalid.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Error loading temporary settings: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}



    }
}
