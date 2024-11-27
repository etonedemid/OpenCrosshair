using System;
using System.Drawing;
using System.Windows.Forms;

namespace OpenCrosshair
{
    public partial class OverlayForm : Form
    {
        private Color crosshairColor;
        private int thickness;
        private int length;
        private int gap;
        private bool showCenterDot;
        private bool showUpperBar;

        private readonly Pen crosshairPen;

        public OverlayForm(Color color, int thickness, int length, int gap, bool showCenterDot, bool showUpperBar)
        {
            InitializeComponent();

            this.crosshairColor = color;
            this.thickness = thickness;
            this.length = length;
            this.gap = gap;
            this.showCenterDot = showCenterDot;
            this.showUpperBar = showUpperBar;

            crosshairPen = new Pen(crosshairColor, thickness);

            // Form setup for overlay
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawCrosshair(e.Graphics);
        }

        private void DrawCrosshair(Graphics g)
        {
            int centerX = this.Width / 2;
            int centerY = this.Height / 2;

            // Draw horizontal lines
            g.DrawLine(crosshairPen, centerX - length - gap, centerY, centerX - gap, centerY);
            g.DrawLine(crosshairPen, centerX + gap, centerY, centerX + length + gap, centerY);

            // Draw vertical lines (excluding upper bar if not shown)
            if (showUpperBar)
            {
                g.DrawLine(crosshairPen, centerX, centerY - length - gap, centerX, centerY - gap);
            }
            g.DrawLine(crosshairPen, centerX, centerY + gap, centerX, centerY + length + gap);

            // Draw center dot if enabled
            if (showCenterDot)
            {
                g.FillEllipse(new SolidBrush(crosshairColor), centerX - thickness / 2, centerY - thickness / 2, thickness, thickness);
            }
        }

        // Method to update crosshair parameters dynamically
        public void UpdateCrosshair(Color color, int thickness, int length, int gap, bool showCenterDot, bool showUpperBar)
        {
            this.crosshairColor = color;
            this.thickness = thickness;
            this.length = length;
            this.gap = gap;
            this.showCenterDot = showCenterDot;
            this.showUpperBar = showUpperBar;

            crosshairPen.Color = color;
            crosshairPen.Width = thickness;

            this.Invalidate(); // Forces the form to redraw with the new settings
        }

        protected override void WndProc(ref Message m)
        {
            // Ignore mouse clicks to prevent interacting with the overlay form
            const int WM_NCHITTEST = 0x84;
            const int HTTRANSPARENT = -1;

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
                return;
            }

            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // Allow click-through by setting extended window style
                cp.ExStyle |= 0x80000; // WS_EX_LAYERED
                cp.ExStyle |= 0x20;    // WS_EX_TRANSPARENT
                return cp;
            }
        }
    }
}
