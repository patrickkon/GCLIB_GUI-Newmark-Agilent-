using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AgilentPNA835x;

namespace vector_accelerator_project
{
    class DataPoint
    {
        
        private Point location;
        private int locationZ;
        private NAComplex[] data;

        

        public Point Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public int LocationZ
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
            location = new Point();
            //data = new NAComplex[num];
        }
    }
}
