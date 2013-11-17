using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Design
{
    public partial class BitrackBar : UserControl
    {
        const int TickSize = 2;
        const int TrackHeight = 7;
        const int TrackWidth = 5;

        public delegate void IntervalChangeEvent(object sender, int min, int max);

        public event IntervalChangeEvent OnIntervalChanged;

        public BitrackBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            TickCount = 10;
            Up = 0;
            Down = TickCount - 1;

        }

        private int tickCount;
        public int TickCount { 
            get 
            {
                return tickCount;
            }
            set
            {
                if (tickCount < 0) throw new Exception("Tick count must be greater than 0");
                tickCount = value;
                up = validate(up);
                down = validate(down);
                Invalidate(ClientRectangle);
            }
        }

        private int up;
        public int Up 
        { 
            get {return up;} 
            set 
            {
                up = validate(value);
                if (OnIntervalChanged != null)
                    OnIntervalChanged(this, Min, Max);
                Invalidate(ClientRectangle);
            } 
        }

        private int down;
        public int Down 
        { 
            get {return down;}
            set 
            {
                down = validate(value);
                if (OnIntervalChanged != null)
                    OnIntervalChanged(this, Min, Max);
                Invalidate(ClientRectangle);
            } 
        }

        public int Max
        {
            get
            {
                return Math.Max(Up, Down);
            }
        }
        public int Min
        {
            get
            {
                return Math.Min(Up, Down);
            }
        }
        private Brush trackBrush = new SolidBrush(Color.DarkRed);
        private enum DragState {UP, DOWN, NONE};
        private DragState dragging = DragState.NONE;

        protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);

            Brush b = new SolidBrush(BackColor);
            e.Graphics.FillRectangle(b, ClientRectangle);

            float step = ((float)ClientRectangle.Width - 2*TrackWidth) / (float)(TickCount - 1);
            float cy = ClientRectangle.Height / 2;

            e.Graphics.DrawLine(Pens.Black, TrackWidth, cy, TrackWidth + step * (TickCount - 1), cy);
            for (int i = 0; i < TickCount; i++)
                e.Graphics.DrawLine(Pens.Black, TrackWidth + step * i, cy - TickSize, TrackWidth + step * i, cy + TickSize);


            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Upper track
            drawTriangle(e, step, cy, true, new PointF(TrackWidth + step * Up, cy));

            //Down track
            drawTriangle(e, step, cy, false, new PointF(TrackWidth + step * Down, cy));

            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Y > ClientRectangle.Height / 2)
                dragging = DragState.DOWN;
            else
                dragging = DragState.UP;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
 	        base.OnMouseUp(e);
            doMagnet(e);
            dragging = DragState.NONE;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            dragging = DragState.NONE;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (dragging == DragState.NONE) return;

            doMagnet(e);

        }

        private void doMagnet(MouseEventArgs e)
        {
            float halfy = (float)ClientRectangle.Width / (2 * (TickCount - 1));
            int magnet = (int)((1 + e.X / halfy) / 2);

            if (dragging == DragState.UP && up != magnet)
                Up = magnet;
            else if (dragging == DragState.DOWN && down != magnet)
                Down = magnet;

            Invalidate(ClientRectangle);
        }

        private void drawTriangle(PaintEventArgs e, float step, float cy, bool up, PointF origin)
        {

            int sign = up ? -1 : 1;

            e.Graphics.FillPolygon(trackBrush, new PointF[] { 
                new PointF(origin.X, origin.Y + sign*(TickSize + 2)), 
                new PointF(origin.X - TrackWidth, origin.Y + sign * (TrackHeight + TickSize + 2)),
                new PointF(origin.X + TrackWidth, origin.Y + sign * (TrackHeight + TickSize + 2)) });
            e.Graphics.DrawPolygon(Pens.Black, new PointF[] { 
                new PointF(origin.X, origin.Y + sign*(TickSize + 2)), 
                new PointF(origin.X - TrackWidth, origin.Y + sign * (TrackHeight + TickSize + 2)),
                new PointF(origin.X + TrackWidth, origin.Y + sign * (TrackHeight + TickSize + 2)) });
        }

        private int validate(int value)
        {
            if (value < 0) return 0;
            if (value >= TickCount) return TickCount - 1;
            return value;
        }

    }
}
