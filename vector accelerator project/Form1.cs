using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vector_accelerator_project
{
    public partial class Form1 : Form
    {

        #region "Variable declaration"
        //global gclib so that other functions can use the most updated one
        //e.g. are we connected or not..
        gclib gclib = null;
        // value is given by unitbox, otherwise keep default
        //Note to self: might reformat this to include values
        // for each independent axis, and type of movement. Total = 6
        private int increment_unit = 10000;

        //Variables that store coordinates:
        int[] abs_position = new int[2] {0,0};
        int[] start_position = new int[2] { 0, 0};
        int[] end_position = new int[2] { 0, 0};
        //a list of integer arrays, each with 2 elements:
        List<int[]> intermediate_positions = new List<int[]>{ new int[2] { 0, 0 } };


        //Variables that store other parameters:
        int drop_by = 0;  //axis-c drop by how many units while sampling
        int[] sample_units = new int[2] { 0, 0 }; //sample every "sample_units" units

        #endregion

        public Form1()
        {
            InitializeComponent();
            this.Text = "gclib simple testing example (TITLE HERE)";
            
        }

        //Runs when form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            
            gclib = new gclib(); //constructor can throw, so SHOULD keep it in a Try block

            PrintOutput(textBox1, "Enter a FULL GOpen() address above and press Enter", PrintStyle.Instruction);
            PrintOutput(textBox1, "NOTE: This demo will attempt to move Axis A", PrintStyle.Instruction);

            //this block here to list out available connections
            //make it easier for user to refer to when typing out address
            PrintOutput(textBox1, "Available connections:");
            string[] addrs = gclib.GAddresses();
            if (addrs.Length == 0)
            {
                PrintOutput(textBox1, "None");
            }
            else
            {
                foreach (string a in addrs)
                {
                    PrintOutput(textBox1, a, PrintStyle.GclibData);
                }
            }


            //disable ability to move before a connection with controller has been established
            DisconnectStripButton.Enabled = false;
            GeneralGroup.Enabled = false;
        }

        //Various print styles.
        private enum PrintStyle
        {
            Instruction,
            Normal,
            GalilData,
            GclibData,
            Err,
        }

        private void PrintOutput(System.Windows.Forms.RichTextBox Output, string Message, PrintStyle Style = PrintStyle.Normal, bool SuppressCrLf = false)
        {
            if (Output.InvokeRequired)
            {
                Output.Invoke(new Printer(PrintOutput), new object[] {Output, Message, Style, SuppressCrLf });
            }
            else
            {
                Color color;

                switch (Style)
                {
                    case PrintStyle.Instruction:
                        color = Color.Black;
                        break;
                    case PrintStyle.GalilData:
                        color = Color.Green;
                        break;
                    case PrintStyle.Normal:
                        color = Color.Blue;
                        break;
                    case PrintStyle.Err:
                        color = Color.Red;
                        break;
                    case PrintStyle.GclibData:
                        color = Color.Magenta;
                        break;
                    default:
                        color = Color.Blue;
                        break;
                }//switch

                Output.SelectionStart = Output.Text.Length;
                Output.SelectionColor = color;
                Output.AppendText(Message);

                if (!SuppressCrLf)
                    Output.AppendText("\r\n");

            }//invoke check
        }

        private void runCommand(string command)
        {
            try
            {
                PrintOutput(textBox1, "Downloading Program... ", PrintStyle.Normal, true);
                gclib.GProgramDownload(command, "");
                PrintOutput(textBox1, "Uploading Program");
                PrintOutput(textBox1, gclib.GProgramUpload(), PrintStyle.GalilData);

                PrintOutput(textBox1, "Blocking GMessage call");
                gclib.GCommand("XQ");
                System.Threading.Thread.Sleep(200);
                //wait a bit to queue up some messages
                PrintOutput(textBox1, gclib.GMessage(), PrintStyle.GalilData);
                //get them all in one blocking read
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in runCommand: " + ex.Message, PrintStyle.Instruction);
            }
        }


        //Note to self: axis must be in Capital letters
        private void runMoveCommand(string axis, int distance_units)
        {
            try
            {
                PrintOutput(textBox1, "Preparing " + axis + " axis. This could cause errors if the axis is not initialized...", PrintStyle.Normal, true);
                gclib.GCommand("AB;MO;SH" + axis);
                //compound commands are possible though typically not recommended
                PrintOutput(textBox1, "Ok");
                gclib.GCommand("PR" + axis + "=" + distance_units);

                //might implement speed control parameter in future
                gclib.GCommand("SP" + axis + "=" +"5000");
                PrintOutput(textBox1, "Profiling a move on axis"+ axis + "... ", PrintStyle.Normal, true);
                gclib.GCommand("BG" + axis);
                PrintOutput(textBox1, "Waiting for motion to complete... ", PrintStyle.Normal, true);
                gclib.GMotionComplete(axis);
                PrintOutput(textBox1, "done");
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in runMoveCommand on axis " + axis+ ": " + ex.Message, PrintStyle.Instruction);
            }
        }

        //Function for event when enter key is pressed, for "unitbox". 
        //registered as eventhandler for unitbox in .designer file
        private void CheckEnter_unitbox(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                // Enter key pressed. Now do:
                if (!(Int32.TryParse(unitbox.Text, out increment_unit)))
                {
                    //if parsing attempt was unsuccessful
                    //need to revert back to default because:
                    //value is zero if the conversion failed.
                    // source: https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse?redirectedfrom=MSDN&view=netframework-4.8#System_Int32_TryParse_System_String_System_Int32__
                    increment_unit = 10000;
                }
            }
        }

        //Note to self: currently not working
        public void Main(string address)
        {
            gclib gclib = new gclib();

            try
            {
                //execute any program as dictated by all buttons and given script

                //i plan to change the way we do this abit. i want to establish a connection. check for it
                // then just use this Main function to execute the intention of the comment 2 lines above this

                //calls to gclib should be in a try-catch
                textBox1.AppendText("GVersion: " + gclib.GVersion() + "\n");
                gclib.GOpen(address + " -d"); //Set an appropriate IP address here
                textBox1.AppendText("GInfo: " + gclib.GInfo() + "\n");
                textBox1.AppendText("GCommand: " + gclib.GCommand("MG TIME") + "\n");






            }
            catch (Exception ex)
            {
                textBox1.AppendText("ERROR: " + ex.Message);

            }

            finally
            {
                gclib.GClose(); //Don't forget to close!
            }

        }

        #region "Threading"

        /// <summary>
        /// Delegate used to print status when the status is generated in a thread other than the UI thread.
        /// </summary>
        /// <param name="Message">Message to print</param>
        /// <param name="Style">Print Style</param>
        /// <param name="SuppressCrLf">If true, the string will be printed without a trailing cr+lf</param>
        private delegate void Printer(RichTextBox Output, string Message, PrintStyle Style, bool SuppressCrLf);


        /// <summary>
        /// Fires up the demo via the background worker thread
        /// AS OF NOW, this function is not utilized
        /// </summary>
        /// <param name="address">The full GOpen() addresss<</param>
        /// <remarks>Runs in UI thread</remarks>
        private void RunDemo(string address)
        {
            MainToolStrip.Enabled = false;
            DisconnectStripButton.Enabled = true;

            textBox1.Clear();
            textBox2.Clear();
            GClibBackgroundWorker1.RunWorkerAsync(address);
        }


        /// <summary>
        /// Runs in second thread to call the demo.
        /// </summary>
        private void GClibBackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            PrintOutput(textBox1, "Running Demo with address " + e.Argument, PrintStyle.Normal);
            Main((string)e.Argument); //call the actual demo code
        }

        /// <summary>
        /// Runs in the main thread after the second thread returns.
        /// </summary>
        private void GClibBackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PrintOutput(textBox1, "Demo thread done.", PrintStyle.Normal);
            MainToolStrip.Enabled = true;
            DisconnectStripButton.Enabled = false;
        }
        #endregion


        #region "Controls currently unused"

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void unitbox_TextChanged(object sender, EventArgs e)
        {



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void GeneralGroup_Enter(object sender, EventArgs e)
        {

        }

        private void AddressTextBox_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        #endregion


        private void ConnectStripButton_Click(object sender, EventArgs e)
        {
            //only checking for empty string, otherwise we enter the Main program.
            //because invalid address will itself trigger an exception, exiting the Main program. 
            if(AddressTextBox.Text.Length == 0)
            {
                PrintOutput(textBox1, "Cannot be Null. Enter a FULL GOpen() address above and click Go", PrintStyle.Instruction);
                return;
            }

 
            try
            {
                string address = AddressTextBox.Text;
                PrintOutput(textBox1, "Opening connection to \"" + address + "\"... ", PrintStyle.Normal, true);
                gclib.GOpen(address);
                PrintOutput(textBox1, "CONNECTED!", PrintStyle.Normal);
                PrintOutput(textBox1, gclib.GInfo(), PrintStyle.GalilData);

                //now that we've successfully connected, here we modify how user
                //can interact with the app:
                AddressTextBox.Enabled = false;
                ConnectStripButton.Enabled = false;
                DisconnectStripButton.Enabled = true;
                GeneralGroup.Enabled = true;

                return;
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR: " + ex.Message, PrintStyle.Instruction);
                PrintOutput(textBox1, "Invalid address. Re-enter a FULL GOpen() address above and click Go", PrintStyle.Instruction);
                return;
            }
            
            //Given previously, because it was meant to execute demo only ONCE, when the connect button is clicked. 
            //RunDemo(AddressTextBox.Text);

        }

        private void DisconnectStripButton_Click(object sender, EventArgs e)
        {
            gclib.GClose();
            AddressTextBox.Enabled = true;
            ConnectStripButton.Enabled = true;
            DisconnectStripButton.Enabled = false;
            GeneralGroup.Enabled = false;
            PrintOutput(textBox1, "DISCONNECTED!", PrintStyle.Normal);
        }        


        //Note to self: this is complete. Can be applied to other buttons in this group
        private void button1_Click(object sender, EventArgs e)
        {
            //FUTURE: not sure what this string command does
            //runCommand("i=0\r#A;MG i{N};i=i+1;WT10;JP#A,i<10;EN");

            //take a single button click as moving 10000 units in a-axis
            runMoveCommand("A", increment_unit);           
        }

        // For mapping grid to movement, based on mouse click in grid box:
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point coordinates = e.Location;
        }

        // Start selected "special movement" motion:
        private void button14_Click(object sender, EventArgs e)
        {

        }

       
    }
}
