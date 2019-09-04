using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AgilentPNA835x;

namespace SurfaceScan
{
    class DataPoint
    {
        private int index;
        private PointF location;
        private float locationZ;
        private NAComplex[] data;

        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }

        public PointF Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public float LocationZ
        {
            get { return this.locationZ; }
            set { this.locationZ = value; }
        }

        public NAComplex[] Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public DataPoint(int num)
        {
            location = new PointF();
            //data = new NAComplex[num];
        }
    }
}
