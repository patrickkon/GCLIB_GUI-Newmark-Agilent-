using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AgilentPNA835x;
using System.Drawing;
using System.IO;

/// <remarks>
/// Pat:
/// I assume that the packages missing here will be included once i include the above missing
/// agilent library. 
///
/// Note that I converted the line AgilentPNA835x.ApplicationClass application to AgilentPNA835x.Application application
/// </remarks>


/// <summary>
/// Package contains most classes and methods related to PNA functions, from its setup, and usage.
/// </summary>

namespace vector_accelerator_project
{

    // Partial class for Agilent PNA functions used:
    partial class Form1
    {
        // Setup for PNA, used everytime special movement is initiated (i.e button 13 is clicked).
        private void PNA_init()
        {
            this.analyzer.StartFrequency
                = Convert.ToSingle(this.numericUpDownStart.Value) * 1e6F;
            this.analyzer.StopFrequency
                = Convert.ToSingle(this.numericUpDownStop.Value) * 1e6F;
            this.analyzer.Points =
                Convert.ToInt32(this.numericUpDownPoints.Value);
            this.analyzer.IFBW =
                Convert.ToInt32(this.numericUpDownIFBW.Value);
            this.analyzer.AvgFactor =
                Convert.ToInt32(this.numericUpDownAvg.Value); //added this line
            //this.analyzer.CalFile = calFileTemp;  *This is supposed to store PNA state, but I don't want to implement it now, might make it more complex
            this.analyzer.Type = (PNA.MEASUREMENT)this.comboBoxMeasure.SelectedIndex;
            this.analyzer.Format = (PNA.FORMAT)this.comboBoxFormat.SelectedIndex;
            this.analyzer.SetupMeasurement();
        }
        #region "Other PNA event handlers"
        // when Save PNA data button is clicked:
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.ShowDialog();
        }

        // when SaveData button is clicked, we eventually enter this function:
        private void saveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.analyzer.SaveData(this.saveFileDialog.FileName);
        }

        // when Clear PNA data button is clicked:
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.analyzer.ClearDataPoints();
        }
        #endregion

    }


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

        // Pat: I uncommented this. Appears to be a mistake
        private bool online;
        private AgilentPNA835x.Application application; //send all instructions via this variable "application" which repr. PNA
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
        private List<DataPoint> dataPoints;

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
            dataPoints = new List<DataPoint>(); // Container we will use to store all PNA readings. 
        }

        public bool Open()
        {
            try
            {
                application = new AgilentPNA835x.Application(); //is this object obtained by running the PNAproxy script?
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

        public AgilentPNA835x.Application Application
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

        // run PNA VNA scanning when position has been reached by controller:
        public void PNA_scan(int[] coor, MovementVariables movementVariables)
        {
            DataPoint dbpt = new DataPoint(Points);
            // Let the probe settle
            System.Threading.Thread.Sleep(200);
            dbpt.Data = Measure();
            // Landing point to do PNA scan:
            dbpt.Location = new Point(coor[0], coor[1]);
            dbpt.LocationZ = movementVariables.Axis_c_rest_position + movementVariables.Axis_c_drop_by;
            //dbpt.Index = i;
            dataPoints.Add(dbpt);
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


        #region "agilent helper functions"



        //Saving PNA datapoints that have been recorded:
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

        // Clearing PNA dataPoints that have been recorded:
        public void ClearDataPoints()
        {
            DialogResult result = MessageBox.Show("Are you sure you wish to clear all data points?",
                "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                return;
            else
                this.dataPoints.Clear();
        }
        #endregion
    }
}