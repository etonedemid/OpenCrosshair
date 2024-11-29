namespace OpenCrosshair
{
    partial class crosshaircreator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private System.Windows.Forms.TrackBar trackBarThickness;
        private System.Windows.Forms.TrackBar trackBarLength;
        private System.Windows.Forms.TrackBar trackBarGap;
        private System.Windows.Forms.Button buttonSetColor;
        private System.Windows.Forms.Button buttonToggleCrosshair;

        private void InitializeComponent()
        {
            AllowDrop = true;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(crosshaircreator));
            panelCrosshair = new Panel();
            trackBarThickness = new TrackBar();
            trackBarLength = new TrackBar();
            trackBarGap = new TrackBar();
            buttonSetColor = new Button();
            buttonToggleCrosshair = new Button();
            panel1 = new Panel();
            checkBoxUpperBar = new CheckBox();
            checkBoxCenterDot = new CheckBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBarThickness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGap).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCrosshair
            // 
            panelCrosshair.BackColor = Color.FromArgb(58, 58, 58);
            panelCrosshair.Location = new Point(3, 3);
            panelCrosshair.Name = "panelCrosshair";
            panelCrosshair.Size = new Size(269, 190);
            panelCrosshair.TabIndex = 0;
            panelCrosshair.Paint += panelCrosshair_Paint;
            // 
            // trackBarThickness
            // 
            trackBarThickness.Location = new Point(278, 33);
            trackBarThickness.Maximum = 25;
            trackBarThickness.Name = "trackBarThickness";
            trackBarThickness.Size = new Size(235, 45);
            trackBarThickness.TabIndex = 1;
            trackBarThickness.Scroll += trackBarThickness_Scroll;
            // 
            // trackBarLength
            // 
            trackBarLength.Location = new Point(278, 93);
            trackBarLength.Maximum = 25;
            trackBarLength.Name = "trackBarLength";
            trackBarLength.Size = new Size(235, 45);
            trackBarLength.TabIndex = 2;
            trackBarLength.Scroll += trackBarLength_Scroll;
            // 
            // trackBarGap
            // 
            trackBarGap.Location = new Point(278, 153);
            trackBarGap.Maximum = 25;
            trackBarGap.Name = "trackBarGap";
            trackBarGap.Size = new Size(235, 45);
            trackBarGap.TabIndex = 3;
            trackBarGap.Scroll += trackBarGap_Scroll;
            // 
            // buttonSetColor
            // 
            buttonSetColor.FlatStyle = FlatStyle.Flat;
            buttonSetColor.Location = new Point(3, 199);
            buttonSetColor.Name = "buttonSetColor";
            buttonSetColor.Size = new Size(89, 52);
            buttonSetColor.TabIndex = 4;
            buttonSetColor.Text = "Set Color";
            buttonSetColor.Click += buttonSetColor_Click;
            // 
            // buttonToggleCrosshair
            // 
            buttonToggleCrosshair.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonToggleCrosshair.AutoSize = true;
            buttonToggleCrosshair.FlatStyle = FlatStyle.Flat;
            buttonToggleCrosshair.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonToggleCrosshair.Location = new Point(12, 269);
            buttonToggleCrosshair.Name = "buttonToggleCrosshair";
            buttonToggleCrosshair.Size = new Size(150, 70);
            buttonToggleCrosshair.TabIndex = 5;
            buttonToggleCrosshair.Text = "Show Crosshair";
            buttonToggleCrosshair.Click += buttonToggleCrosshair_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(checkBoxUpperBar);
            panel1.Controls.Add(checkBoxCenterDot);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(buttonSetColor);
            panel1.Controls.Add(trackBarGap);
            panel1.Controls.Add(trackBarLength);
            panel1.Controls.Add(trackBarThickness);
            panel1.Controls.Add(panelCrosshair);
            panel1.Location = new Point(12, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(517, 256);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // checkBoxUpperBar
            // 
            checkBoxUpperBar.AutoSize = true;
            checkBoxUpperBar.Checked = true;
            checkBoxUpperBar.CheckState = CheckState.Checked;
            checkBoxUpperBar.Location = new Point(430, 204);
            checkBoxUpperBar.Name = "checkBoxUpperBar";
            checkBoxUpperBar.Size = new Size(78, 19);
            checkBoxUpperBar.TabIndex = 10;
            checkBoxUpperBar.Text = "Upper bar";
            checkBoxUpperBar.UseVisualStyleBackColor = true;
            checkBoxUpperBar.CheckedChanged += checkBoxUpperBar_CheckedChanged;
            // 
            // checkBoxCenterDot
            // 
            checkBoxCenterDot.AutoSize = true;
            checkBoxCenterDot.Location = new Point(278, 204);
            checkBoxCenterDot.Name = "checkBoxCenterDot";
            checkBoxCenterDot.Size = new Size(83, 19);
            checkBoxCenterDot.TabIndex = 9;
            checkBoxCenterDot.Text = "Center Dot";
            checkBoxCenterDot.UseVisualStyleBackColor = true;
            checkBoxCenterDot.CheckedChanged += checkBoxCenterDot_CheckedChanged;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(15, 15, 15);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.ForeColor = SystemColors.ScrollBar;
            textBox4.Location = new Point(375, 235);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(138, 16);
            textBox4.TabIndex = 8;
            textBox4.Text = "Made by etonedemid";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(15, 15, 15);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = SystemColors.ScrollBar;
            textBox3.Location = new Point(342, 131);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(100, 16);
            textBox3.TabIndex = 7;
            textBox3.Text = "Gap";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(15, 15, 15);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.ForeColor = SystemColors.ScrollBar;
            textBox2.Location = new Point(342, 71);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(100, 16);
            textBox2.TabIndex = 6;
            textBox2.Text = "Length";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(15, 15, 15);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.ForeColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(342, 11);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(100, 16);
            textBox1.TabIndex = 5;
            textBox1.Text = "Width";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.AutoSize = true;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(168, 269);
            button1.Name = "button1";
            button1.Size = new Size(150, 32);
            button1.TabIndex = 7;
            button1.Text = "Save Crosshair";
            button1.Click += SaveCrosshairButton_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.AutoSize = true;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(168, 307);
            button2.Name = "button2";
            button2.Size = new Size(150, 32);
            button2.TabIndex = 8;
            button2.Text = "Load Crosshair";
            button2.Click += buttonLoadCrosshair_Click;
            // 
            // crosshaircreator
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            BackgroundImage = Properties.Resources.image;
            ClientSize = new Size(541, 349);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonToggleCrosshair);
            Controls.Add(panel1);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlLight;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "crosshaircreator";
            Text = "OpenCrosshair";
            ((System.ComponentModel.ISupportInitialize)trackBarThickness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarGap).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCrosshair;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private TextBox textBox4;
        private CheckBox checkBoxCenterDot;
        private CheckBox checkBoxUpperBar;
    }
}
