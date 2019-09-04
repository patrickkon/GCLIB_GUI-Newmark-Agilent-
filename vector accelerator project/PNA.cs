using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AgilentPNA835x;

// Pat:
// I assume that the packages missing here will be included once i include the above missing
// agilent library. 

namespace vector_accelerator_project
{
    class PNA
    {
        public enum MEASUREMENT { S11 = 0, S12 = 1, S21 = 2, S22 = 3};
        public enum FORMAT {
            LogMag = 0,
            Phase = 1, 
            GroupDelay = 2,
            SmithChart = 3, 
            Polar = 4, 
            LinearMag = 5, 
            SWR = 6, 
            Real = 7, 
            Imaginary = 8};
        
        //private bool online;
        private AgilentPNA835x.ApplicationClass application; //send all instructions via this variable "application" which repr. PNA
        private IChannel channel;
        private IArrayTransfer measurement;
        //private ICalSet calSet; //calset object
        private float startFreq;
        private float stopFreq;
        private int points;
        private int ifbw;
        private int avgFactor; //added this
        private string calFile; //added this
        //private string guid; //variable to store calset guid
        private FORMAT format;
        private MEASUREMENT type;

        public float StartFrequency
        {
            get { return startFreq; }
            set { startFreq = value; }
        }

        public float StopFrequency
        {
            get { return stopFreq; }
            set { stopFreq = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public int IFBW
        {
            get { return ifbw; }
            set { ifbw = value; }
        }

        public int AvgFactor
        {
            get { return avgFactor; }
            set { avgFactor = value; }
        }

        public string CalFile
        {
            get { return calFile; }
            set { calFile = value; }
        }

        //public string Guid
        //{
         //   get { return guid; }
          //  set { guid = value; }
        //}

        public FORMAT Format
        {
            get { return format; }
            set { format = value; }
        }

        public MEASUREMENT Type
        {
            get { return type; }
            set { type = value; }
        }
        
        public PNA()
        {
            online = false;
        }

        public bool Open()
        {
            try
            {
                application = new AgilentPNA835x.ApplicationClass(); //is this object obtained by running the PNAproxy script?
                online = true;
            }
            catch(Exception e)
            {
                StringBuilder sb = new StringBuilder(e.Message);
                if (e.Data != null)
                {
                    sb.Append("  Extra details:");
                    foreach (DictionaryEntry de in e.Data)
                    {
                        sb.AppendFormat("    Key: {0}, Value: {1}" + 
                            de.Key, de.Value);
                    }
                }
                MessageBox.Show(sb.ToString(), "PNA Exception on Connect");

                return false;
            }

            online = true;
            return true;
        }

        public void Close()
        {
            if (online)
            {
                this.application.Quit();
                this.application = null;
                online = false;
            }
        }

        public bool IsOnline
        {
            get
            {
                return online;
            }
        }

        public AgilentPNA835x.ApplicationClass Application
        {
            get { return application; }
        }

        public void SetupMeasurement()
        {
           
            channel = application.Channel(2); //default channel when no calset (update: calset has been removed by me) selected
            channel.StartFrequency = startFreq;
            channel.StopFrequency = stopFreq;
            channel.NumberOfPoints = points;
            channel.IFBandwidth = ifbw; //decreasing IF bandwidth has effect similar to avg'g but takes longer __ I disagree
            
            application.CreateMeasurement(2, type.ToString(), 1, 1); //make the first argument 1 for S11, 2 for S21, or whatever the calset says
            measurement = (IArrayTransfer)application.ActiveMeasurement;
            
        }

        public NAComplex[] Measure()
        {
            NAComplex[] data = new NAComplex[points];
            if (this.online)
            {
                if (avgFactor == 1)
                {
                    channel.Averaging = false;
                    channel.Single(true);
                }
                else
                {
                    channel.AveragingFactor = avgFactor;
                    channel.Averaging = true;
                    channel.NumberOfGroups(avgFactor, true); //added this line to wait until the averagefactor # of sweeps are taken
                }
                measurement.getNAComplex(NADataStore.naCorrectedData, ref this.points, out data[0]);
               // measurement.getNAComplex(NADataStore.naMeasResult, ref this.points, out data[0]);
            }
            return data;
        }
    }
}
