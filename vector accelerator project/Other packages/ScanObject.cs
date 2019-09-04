using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using AgilentPNA835x;

namespace SurfaceScan
{
    class ScanObject
    {
        private List<PointF> probePoints;
        private List<float> probeZPoints;
        private List<DataPoint> dataPoints;

        private RectangleF boundingBox;
        private bool initialized;

        private static int ComparePointFX(PointF a, PointF b)
        {
            if (a.IsEmpty)
            {
                if (b.IsEmpty)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                if (b.IsEmpty)
                {
                    return 1;
                }
                else
                {
                    return a.X.CompareTo(b.X);
                }
            }
        }

        private static int ComparePointFY(PointF a, PointF b)
        {
            if (a.IsEmpty)
            {
                if (b.IsEmpty)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                if (b.IsEmpty)
                {
                    return 1;
                }
                else
                {
                    return a.Y.CompareTo(b.Y);
                }
            }
        }

        public List<PointF> ProbePoints
        {
            get
            {
                return probePoints;
            }
        }


        public RectangleF BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
        }

        public bool IsInitialized
        {
            get
            {
                return this.initialized;
            }
        }

        public ScanObject()
        {
            this.initialized = false;
            this.boundingBox = new RectangleF();
            this.probePoints = new List<PointF>();
            this.probeZPoints = new List<float>();
            this.dataPoints = new List<DataPoint>();
        }

        public void ClearDataPoints()
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to clear all data points?",
                "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            else
                this.dataPoints.Clear();
        }

        public void Empty()
        {
            this.probePoints.Clear();
            this.probeZPoints.Clear();
            this.initialized = false;
        }

        // loads the scanning probe points from a file when "custom scan" is selected under the "scanning" tab
        public bool LoadProbePoints(string filename)
        {
            float minimumRawX, maximumRawX, minimumRawY, maximumRawY;
            long TotalLines, HeaderLines, TotalPoints, count;
            string[] ReadText;
            
            if (!File.Exists(filename))
            {
                return false;
            }

            ReadText = File.ReadAllLines(filename);
            TotalLines = ReadText.Length;
            for (count = 0; count < TotalLines; count++)
            {
                if (ReadText[count].Length > 0)
                    if (ReadText[count][0] == '=')
                    {
                        break;
                    }
            }
            HeaderLines = count;
            TotalPoints = TotalLines - HeaderLines - 1;

            minimumRawX = 0;
            maximumRawX = 0;
            minimumRawY = 0;
            maximumRawY = 0;
            Regex rx = new Regex(@"(?<component>\w+)\s+(?<referenceID>\w+)\s+(?<x>[-\.\d]+),(?<y>[-\.\d]+).*");

            this.probePoints.Clear();
            for (int i = 0; i < TotalPoints; i++)
            {
                Match m = rx.Match(ReadText[i + HeaderLines + 1]);
                if (m.Success)
                {
                    PointF point = new PointF();
                    point.X = Convert.ToSingle(m.Groups["x"].Value);
                    point.Y = Convert.ToSingle(m.Groups["y"].Value);

                    if (point.X < minimumRawX)
                    {
                        minimumRawX = point.X;
                    }
                    if (point.Y < minimumRawY)
                    {
                        minimumRawY = point.Y;
                    }
                    if (point.X > maximumRawX)
                    {
                        maximumRawX = point.X;
                    }
                    if (point.Y > maximumRawY)
                    {
                        maximumRawY = point.Y;
                    }
                    
                    this.probePoints.Add(point);
                }

            }

            this.boundingBox.X = minimumRawX;
            this.boundingBox.Width = maximumRawX - minimumRawX;
            this.boundingBox.Y = minimumRawY;
            this.boundingBox.Height = maximumRawY - minimumRawY;

            if (boundingBox.Width == 0.0F)
            {
                boundingBox.Width = 1.0F;
            }
            if (boundingBox.Height == 0.0F)
            {
                boundingBox.Height = 1.0F;
            }
            this.probePoints.Sort(ComparePointFY);
            this.probePoints.Sort(ComparePointFX);

            // set the z position for compatibility with the modified 3D scanning code (currently does not
            // support custom 3D scans
            this.probeZPoints.Add(0.0F);

            this.initialized = true;

            return true;
        }

        // generate scanning probe points when "rectangular periodic" is selected under the "scanning" tab
        public bool CreateRegularProbePoints(float x0, float y0, float z0,
            float dx, float dy, float dz, int nx, int ny, int nz)
        {

            float minimumRawX, maximumRawX, minimumRawY, maximumRawY;
            long TotalPoints = nx * ny;

            float x, y, z;

            x = x0; y = y0; z = z0;
            minimumRawX = x;
            minimumRawY = y;

            this.probePoints.Clear();
            for (int row = 0; row < ny; row++)
            {
                for (int col = 0; col < nx; col++)
                {
                    PointF point = new PointF(x, y);
                    this.probePoints.Add(point);

                    x += dx;
                }
                x = x0;
                y += dy;
            }

            // generate probeZPoints
            this.probeZPoints.Clear();
            for (int i = 0; i < nz; i++)
            {
                this.probeZPoints.Add(z);
                z += dz;
            }

            maximumRawX = x0 + dx * (nx - 1);
            maximumRawY = y0 + dy * (ny - 1);

            this.boundingBox.X = minimumRawX;
            this.boundingBox.Width = maximumRawX - minimumRawX;
            this.boundingBox.Y = minimumRawY;
            this.boundingBox.Height = maximumRawY - minimumRawY;

            if (boundingBox.Width == 0.0F)
            {
                boundingBox.X = x0 - dx / 2.0F;
                boundingBox.Width = dx;
            }
            if (boundingBox.Height == 0.0F)
            {
                boundingBox.Y = y0 - dy / 2.0F;
                boundingBox.Height = dy;
            }

            this.initialized = true;

            return true;
        }

        private void SortPoints()
        {
            this.probePoints.Sort(ComparePointFY);
            this.probePoints.Sort(ComparePointFX);
        }

        
        // note that AsyncScan is Scan implemented through a backgroundWorker so as not to hang the program
        // can we add a progress bar here??? try it...
        public int AsyncScan(ref ToolStripProgressBar progressBar, ref ToolStripStatusLabel statusLabelPercentCompleted,
            ref BackgroundWorker bw, ref PNA analyzer, ref DataDisplay dataDisplay)
        {

            int i = 0, i_xy = 0, i_z = 0;

            progressBar.Minimum = 0;
            progressBar.Maximum = this.probePoints.Count * this.probeZPoints.Count;
            progressBar.Visible = true;
            progressBar.ForeColor = Color.DarkRed; // try to change the progressbar colour
            for (i_xy = 0; i_xy < this.probePoints.Count; i_xy++)
            {
                for (i_z = 0; i_z < this.probeZPoints.Count; i_z++)
                {
                    i = i_xy * this.probeZPoints.Count + i_z;
                    progressBar.Value = i;
                    progressBar.Invalidate();
                    statusLabelPercentCompleted.Text = String.Format("{0}%", (progressBar.Value * 100) / progressBar.Maximum);
                    if (bw.CancellationPending)
                    {
                        progressBar.Visible = false;
                        statusLabelPercentCompleted.Text = "";
                        return 0;
                    }
                    dataDisplay.SetActivePoint(i_xy);
                    PointF point = this.probePoints[i_xy];
                    float zpoint = this.probeZPoints[i_z];
                    Translator.Move((decimal)point.X, (decimal)point.Y, (decimal)zpoint);
                    DataPoint dbpt = new DataPoint(analyzer.Points);
                    // Let the probe settle
                    Thread.Sleep(200);
                    dbpt.Data = analyzer.Measure();
                    dbpt.Location = this.probePoints[i_xy];
                    dbpt.LocationZ = this.probeZPoints[i_z];
                    dbpt.Index = i;
                    dataPoints.Add(dbpt);
                }
            }
            dataDisplay.SetActivePoint(-1);
            progressBar.Visible = false;
            statusLabelPercentCompleted.Text = "";
            return 1;
        }
        
        public void SaveData(string filename)
        {
            using (StreamWriter sw = File.CreateText(filename))
            {

                if (this.dataPoints.Count != 0)
                {
                    sw.WriteLine("Number of probe points: {0}", this.dataPoints.Count);
                    sw.WriteLine("Number of sweep points: {0}", this.dataPoints[0].Data.Length);
                }
                foreach (DataPoint dataPoint in this.dataPoints)
                {
                    sw.Write("{0}, {1}, {2}, ",
                        dataPoint.Location.X,
                        dataPoint.Location.Y,
                        dataPoint.LocationZ);
                    foreach (NAComplex nadata in dataPoint.Data)
                    {
                        sw.Write("{0}, {1}, ",
                            nadata.Re, nadata.Im);
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }

    }
}
