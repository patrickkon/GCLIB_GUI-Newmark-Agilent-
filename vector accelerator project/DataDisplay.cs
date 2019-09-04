using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace vector_accelerator_project
{
    class DataDisplay
    {
        public enum DisplayState { Empty, NoSelection, Selected, Active };
        private float imageScale;
        private float probeWidth;
        private float probeHalfWidth;
        
        private Color passiveColor;
        private Color selectedColor;
        private Color activeColor;
        private Color activePointColor;
        
        private Matrix forwardTransform;
        private Matrix inverseTransform;

        private Control control;
        private ScanObject scanObject;
        private List<int> selectedPoints;
        private int activePoint;
        private DisplayState state;
        
        public float ImageScale
        {
            get { return this.imageScale; }
        }

        public float ProbeWidth
        {
            get { return this.probeWidth; }
            set
            {
                this.probeWidth = value;
                this.probeHalfWidth = this.probeWidth / 2.0F;
            }
        }

        public List<int> SelectedPoints
        {
            get { return this.selectedPoints; }
        }

        #region Color Settings Attributes
        public Color PassiveColor
        {
            get { return this.passiveColor; }
            set { this.passiveColor = value; }
        }

        public Color SelectedColor
        {
            get { return this.selectedColor; }
            set { this.selectedColor = value; }
        }

        public Color ActiveColor
        {
            get { return this.activeColor; }
            set { this.activeColor = value; }
        }
        #endregion

        public DisplayState State
        {
            get { return this.state; }
        }

        public DataDisplay(Control ctrl, ScanObject obj)
        {
            this.imageScale = 1.0F;
            this.ProbeWidth = 1.0F;
            this.passiveColor = Color.SlateBlue;
            this.selectedColor = Color.RosyBrown;
            this.activeColor = Color.Red;
            this.activePointColor = this.activeColor;
            this.forwardTransform = new Matrix();
            this.inverseTransform = new Matrix();
            this.selectedPoints = new List<int>();
            this.activePoint = -1;

            this.state = DisplayState.Empty;
            this.scanObject = obj;
            if (this.scanObject.IsInitialized)
            {
                this.state = DisplayState.NoSelection;
            }
            this.control = ctrl;
        }

        private Matrix SetupTransform(RectangleF logicalBoundingBox, Rectangle physicalBoundingBox)
        {
            Matrix logicalTransform = new Matrix();

            // Move logical drawing reference to origin
            logicalTransform.Translate(-logicalBoundingBox.X, -logicalBoundingBox.Y);

            // Scale the logical drawing to fill the physical space
            float sx = physicalBoundingBox.Width / logicalBoundingBox.Width;
            float sy = physicalBoundingBox.Height / logicalBoundingBox.Height;
            float ScaleFactor = (sx < sy) ? sx : sy;
            logicalTransform.Scale(ScaleFactor, ScaleFactor, MatrixOrder.Append);

            // Scale and Translate to create margin that is 5% of the physical width or height
            // Check physical margins in physical coordinate
            float mxp = (physicalBoundingBox.Width - physicalBoundingBox.Width * 0.9F) / 2;
            float myp = (physicalBoundingBox.Height - physicalBoundingBox.Height * 0.9F) / 2;
            // Check logical margins in physical coordinate
            float mxl = (physicalBoundingBox.Width - logicalBoundingBox.Width * ScaleFactor * 0.9F) / 2;
            float myl = (physicalBoundingBox.Height - logicalBoundingBox.Height * ScaleFactor * 0.9F) / 2;
            // Assign the greater offset of the two (physical or logical) as the margin
            float mx = (mxp > mxl) ? mxp : mxl;
            float my = (myp > myl) ? myp : myl;
            Matrix marginTransform = new Matrix();
            marginTransform.Scale(0.9F, 0.9F, MatrixOrder.Append);
            marginTransform.Translate(mx, my, MatrixOrder.Append);            

            // Define logical view port
            Rectangle logicalRectangle = new Rectangle(
                0, physicalBoundingBox.Height,
                physicalBoundingBox.Width, -physicalBoundingBox.Height);
            // Define physical view port
            Point[] viewPort = new Point[3];
            viewPort[0].X = 0; viewPort[0].Y = 0;
            viewPort[1].X = physicalBoundingBox.Width; viewPort[1].Y = 0;
            viewPort[2].X = 0; viewPort[2].Y = physicalBoundingBox.Height;
            // Apply Transformation
            Matrix physicalTransform = new Matrix(logicalRectangle, viewPort);

            this.imageScale = ScaleFactor;
            Matrix completeTransform = new Matrix();

            completeTransform.Reset();
            completeTransform.Multiply(logicalTransform, MatrixOrder.Append);
            completeTransform.Multiply(marginTransform, MatrixOrder.Append);
            completeTransform.Multiply(physicalTransform, MatrixOrder.Append);

            this.forwardTransform = completeTransform.Clone();

            return completeTransform;
        }

        private PointF TransformPhysicalPoint(Point location)
        {
            this.inverseTransform = this.forwardTransform;
            this.inverseTransform.Invert();

            PointF[] logicalLocation = new PointF[1];
            logicalLocation[0] = location;
            this.inverseTransform.TransformPoints(logicalLocation);

            return logicalLocation[0];
        }

        public void DrawDisplay(Rectangle physicalBoundingBox, bool recalculate)
        {
            if (!this.scanObject.IsInitialized)
            {
                return;
            }

            Graphics graphics = control.CreateGraphics();
            if (recalculate)
            {
                graphics.Transform = SetupTransform(this.scanObject.BoundingBox,
                    physicalBoundingBox);
            }
            else
            {
                graphics.Transform = this.forwardTransform;
            }
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            SolidBrush brush = new SolidBrush(this.passiveColor);

            foreach (PointF point in scanObject.ProbePoints)
            {
                DrawPoint(graphics, brush, point);
            }
            brush.Dispose();
            HighLight(graphics);
            if (this.state == DisplayState.Active)
                DrawPoint(graphics, this.activePointColor, this.activePoint);
            graphics.Dispose();
        }

        public void Reset()
        {
            this.state = DisplayState.Empty;
            this.selectedPoints.Clear();
            if (this.scanObject.IsInitialized)
            {
                this.state = DisplayState.NoSelection;
            }
        }

        public void ClearSelection()
        {
            for (int i = 0; i < this.selectedPoints.Count; i++)
            {
                control.Invalidate(InvalidatePoint(this.selectedPoints[i]));
            }

            this.selectedPoints.Clear();

            this.state = DisplayState.NoSelection;
        }

        public void TogglePoint(Point physicalLocation)
        {
            PointF logicalLocation = TransformPhysicalPoint(physicalLocation);

            int selection = Contains(logicalLocation);
            if (selection > -1)
            {
                int index = this.selectedPoints.IndexOf(selection);
                if (index > -1)
                {
                    this.selectedPoints.RemoveAt(index);
                    if (this.selectedPoints.Count == 0)
                    {
                        this.state = DisplayState.NoSelection;
                    }
                }
                else
                {
                    this.selectedPoints.Add(selection);
                    this.state = DisplayState.Selected;
                }
                control.Invalidate(InvalidatePoint(selection));
            }
        }

        private int Contains(PointF logicalLocation)
        {
            if (!this.scanObject.IsInitialized)
            {
                return -1;
            }

            for (int i = 0; i < this.scanObject.ProbePoints.Count; i++)
            {
                PointF point = this.scanObject.ProbePoints[i];
                
                RectangleF probeLogicalRectangle = new
                    RectangleF(
                        point.X - probeHalfWidth,
                        point.Y - probeHalfWidth,
                        probeWidth, probeWidth);

                if (probeLogicalRectangle.Contains(logicalLocation))
                {
                    return i;
                }
                /*

                //GraphicsPath graphicsPath = new GraphicsPath();
                //graphicsPath.AddEllipse(probeRectangle);

                Region region = new Region(probeRectangle);
                
                if (region.IsVisible(logicalLocation))
                {
                    return i;
                }*/
            }
            return -1;
        }

        private void HighLight(Graphics graphics)
        {
            if (this.state == DisplayState.Empty)
            {
                return;
            }

            SolidBrush brush = new SolidBrush(this.selectedColor);
            for (int i = 0; i < this.selectedPoints.Count; i++)
            {
                DrawPoint(graphics, brush, this.selectedPoints[i]);
            }
            brush.Dispose();
        }

        public void SetActivePoint(int pointIndex)
        {
            if (pointIndex < 0)
            {
                this.state = DisplayState.NoSelection;
                this.control.Invalidate();
                this.activePoint = -1;
            }
            else
            {
                this.state = DisplayState.Active;
                this.activePoint = pointIndex;
                this.control.Invalidate(InvalidatePoint(this.activePoint));
            }
        }

        public void ToggleActivePoint()
        {
            if (this.activePoint > -1)
            {
                if (this.activePointColor == this.activeColor)
                {
                    this.activePointColor = this.passiveColor;
                }
                else
                {
                    this.activePointColor = this.activeColor;
                }
                this.control.Invalidate(InvalidatePoint(this.activePoint));
            }
        }

        private Rectangle InvalidatePoint(int pointIndex)
        {
            PointF[] point = new PointF[1];
            
            point[0] = this.scanObject.ProbePoints[pointIndex];
            this.forwardTransform.TransformPoints(point);
            Rectangle probeRectangle = new
                Rectangle(
                    (int)(point[0].X - probeHalfWidth*imageScale),
                    (int)(point[0].Y - probeHalfWidth*imageScale),
                    (int)(probeWidth*imageScale), (int)(probeWidth*imageScale));
            

            return probeRectangle;
        }

        #region DrawPoint
        private void DrawPoint(Graphics graphics, Color color, int pointIndex)
        {
            SolidBrush brush = new SolidBrush(color);
            DrawPoint(graphics, brush, pointIndex);
            brush.Dispose();
        }

        private void DrawPoint(Graphics graphics, Color color, PointF point)
        {
            SolidBrush brush = new SolidBrush(color);
            DrawPoint(graphics, brush, point);
            brush.Dispose();
        }

        private void DrawPoint(Graphics graphics, Brush brush, int pointIndex)
        {
            PointF point = this.scanObject.ProbePoints[pointIndex];

            RectangleF probeRectangle = new
                RectangleF(
                    point.X - this.probeHalfWidth,
                    point.Y - this.probeHalfWidth,
                    this.probeWidth, this.probeWidth);
            graphics.FillEllipse(brush, probeRectangle);
        }

        private void DrawPoint(Graphics graphics, Brush brush, PointF point)
        {
            RectangleF probeRectangle = new
                RectangleF(
                    point.X - this.probeHalfWidth,
                    point.Y - this.probeHalfWidth,
                    this.probeWidth, this.probeWidth);

            graphics.FillEllipse(brush,
                probeRectangle);
        }
        #endregion
    }
}
