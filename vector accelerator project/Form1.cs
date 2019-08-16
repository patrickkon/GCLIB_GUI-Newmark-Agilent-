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
        public const int G_SMALL_BUFFER = 1024;

        #region "Variable declaration"
        //global gclib so that other functions can use the most updated one
        //e.g. are we connected or not..
        gclib gclib = null;
        // value is given by unitbox, otherwise keep default
        //Note to self: might reformat this to include values
        // for each independent axis, and type of movement. Total = 6
        private int increment_unit = 10000;
        private int speed_a = 5000; //recommended speed
        private int speed_b = 5000; //recommended speed
        private int speed_c = 400000; //recommended speed

        //Variables that store coordinates:
        private int[] start_position = new int[2] {0, 0};
        private int[] end_position = new int[2] {0, 0};
        //a list of integer arrays, each with 2 elements:
        private List<int[]> intermediate_positions = null;

        // used for movement by segment:
        // each int[] has 6 elements (in-order): 
        // a(start), a(end), a(delta), b(start), b(end), b(delta)
        private List<int[]> segment_positions = null;

        // for abs_position the coor will be constantly displayed/updated, so I use this method:
        // Accessor function for private variable _abs_position (absolute position of gantry)
        public int[] abs_position
        {
            get { return _abs_position; }
            set
            {
                _abs_position = value;
                //next line does not work:
                //textBox2.Text += "X = " + _abs_position[0] + " Y = " + _abs_position[1] + "Z = " + _abs_position[2] + Environment.NewLine; 
            }
        }
        private int[] _abs_position = new int[3] {0,0,0};

        //Retrieve absolute position of gantry (Axes a,b, c):
        //Note that retrieval can only be done when the gantry is no longer moving.
        private void cur_abs_pos(int[] abs_position)
        {

            try
            {
                PrintOutput(textBox1, "Updating absolute position.. ", PrintStyle.Normal, true);
                PrintOutput(textBox2, "Updating absolute position.. ", PrintStyle.Normal, true);
                // Apparently GCommand would not allow me to display the TD returned result in GMessage
                // So I used these 2 lines instead:
                gclib.GProgramDownload("TD", "");
                gclib.GCommand("XQ");
                string td_value = gclib.GMessage();
                // Needed to extract substring because for some reason there is another string being outputted:
                td_value =td_value.Substring(0, td_value.IndexOf(Environment.NewLine));
                PrintOutput(textBox2, td_value , PrintStyle.GalilData);
                PrintOutput(textBox1, "Done!", PrintStyle.Normal, true);

                // Here onwards we update the variable abs_position:
                // this function only updates X, Y coordinates
                coor_string_to_intArr(td_value, abs_position);
                // To update Z coordinate (axis-c), we do so manually:
                // Note that IndexOf in this case has 2 args and works like such:
                // 1st arg = char to look for in str, 2nd arg = index in str to begin searching
                int index_2nd_comma = td_value.IndexOf(',', td_value.IndexOf(',') + 2);    
                string temp = td_value.Substring(index_2nd_comma);
                int temp_abs = abs_position[2];
                if (!(Int32.TryParse(temp, out abs_position[2])))
                {
                    //if conversion failed
                    abs_position[2] = temp_abs;
                }

            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in TD command (absolute position): " + ex.Message, PrintStyle.Instruction);
            }
        }

        //Variables that store other parameters:
        private int drop_by = 0;  //axis-c drop by how many units while sampling
        //private int[] sample_units = new int[2] { 0, 0 }; //sample every "sample_units" units
        private int axis_c_rest_position = 0;

        // Used in "mapped" movement to store X, Y coordinates:
        Point coordinates = new Point();


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
            DisconnectStripButton.Enabled = false; groupBox1.Enabled = false;
            GeneralGroup.Enabled = false;
            originButton.Enabled = false; returnOriginButton.Enabled = false;
            pictureBox1.Enabled = false; textBox6.Enabled = false;
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


        // function still not used as of yet:
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


        //Note to self: axis must be in Capital letters.
        //Simple PR movement:
        private void runRelativeMoveCommand(string axis, int distance_units, int speed)
        {
            try
            {
                PrintOutput(textBox1, "Preparing " + axis + " axis for PR movement. This could cause errors if the axis is not initialized...", PrintStyle.Normal, true);
                gclib.GCommand("AB;MO;SH" + axis);
                //compound commands are possible though typically not recommended
                PrintOutput(textBox1, "Ok");
                gclib.GCommand("PR" + axis + "=" + distance_units);

                //might implement speed control parameter in future
                gclib.GCommand("SP" + axis + "=" +speed);
                PrintOutput(textBox1, "Profiling a move on axis"+ axis + "... ", PrintStyle.Normal, true);
                gclib.GCommand("BG" + axis);
                PrintOutput(textBox1, "Waiting for motion to complete... ", PrintStyle.Normal, true);
                gclib.GMotionComplete(axis);
                PrintOutput(textBox1, "done");
                //update absolute position and display in textBox2:
                cur_abs_pos(abs_position);
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in runRelativeMoveCommand on axis " + axis+ ": " + ex.Message, PrintStyle.Instruction);
            }
        }

        //Note to self: axis must be in Capital letters
        //Simple PA movement:
        private void runAbsoluteMoveCommand(string axis, int distance_units, int speed)
        {
            try
            {
                PrintOutput(textBox1, "Preparing " + axis + " axis for PA movement. This could cause errors if the axis is not initialized...", PrintStyle.Normal, true);
                gclib.GCommand("AB;MO;SH" + axis);
                //compound commands are possible though typically not recommended
                PrintOutput(textBox1, "Ok");
                gclib.GCommand("PA" + axis + "=" + distance_units);

                //might implement speed control parameter in future
                gclib.GCommand("SP" + axis + "=" + speed);
                PrintOutput(textBox1, "Profiling a move on axis" + axis + "... ", PrintStyle.Normal, true);
                gclib.GCommand("BG" + axis);
                PrintOutput(textBox1, "Waiting for motion to complete... ", PrintStyle.Normal, true);
                gclib.GMotionComplete(axis);
                PrintOutput(textBox1, "done");
                //update absolute position and display in textBox2:
                cur_abs_pos(abs_position);
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in runAbsoluteMoveCommand on axis " + axis + ": " + ex.Message, PrintStyle.Instruction);
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

        // From string from textBox, to X, Y coordinates in int array:
        private void coor_string_to_intArr(string text, int[] prev_position)
        {
            int[] arr = new int[2];

            try
            {
                
                Array.Copy(prev_position, arr, 0);
                string temp = text.Substring(0, text.IndexOf(", "));
                if (!(Int32.TryParse(temp, out prev_position[0])))
                {
                    //if conversion failed
                    prev_position[0] = arr[0];
                }

                temp = text.Substring(text.IndexOf(", ") + 2);

                if (!(Int32.TryParse(temp, out prev_position[1])))
                {
                    //if conversion failed
                    prev_position[1] = arr[1];
                }
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in converting text to int: " + ex.Message, PrintStyle.Instruction);
                // revert back to previous values.  
                prev_position[1] = arr[1]; prev_position[0] = arr[0];
            }

        }


        //display for textbox4 : displays variables in groupBox1
        private void display_textbox4_manual()
        {   
            textBox4.Clear();
            textBox4.Text += "Start position: " + start_position[0] + ", " + start_position[1] + Environment.NewLine;
            
            intermediate_positions?.ForEach(a => {
                textBox4.Text += "Intermediate position: " + a[0] + ", " + a[1] + Environment.NewLine;
            });
            textBox4.Text += "End position: " + end_position[0] + ", " + end_position[1] + Environment.NewLine;
            textBox4.Text += "Drop bar by (units): " + drop_by + Environment.NewLine;
            //textBox4.Text += "Sample every (units): " + sample_units[0] + ", " + sample_units[1] + Environment.NewLine;
            textBox4.Text += "Axis-c resting position: " + axis_c_rest_position;
        }

        private void display_textbox4_segment()
        {
            textBox4.Clear();
            int counter = 1;
            //here we display completed/validated segments:
            segment_positions?.ForEach(a => {
                if (counter != segment_positions.Count)
                {
                    textBox4.Text += "Segment " + counter + ".. " + Environment.NewLine;
                    textBox4.Text += "A(start): " + a[0] + ", A(end): " + a[1] + ", delta A: " + a[2] + Environment.NewLine;
                    textBox4.Text += "B(start): " + a[3] + ", B(end): " + a[4] + ", delta B: " + a[5] + Environment.NewLine;
                    counter += 1;
                }
            });
            //here we display the segment that that the user is currently trying to input:
            int[] b = segment_positions.Last();
            textBox4.Text += "Current segment input.. : " + Environment.NewLine;
            textBox4.Text += "A(start): " + b[0] + ", A(end): " + b[1] + ", delta A: " + b[2] + Environment.NewLine;
            textBox4.Text += "B(start): " + b[3] + ", B(end): " + b[4] + ", delta B: " + b[5] + Environment.NewLine;
            counter += 1;

            textBox4.Text += "Drop bar by (units): " + drop_by + Environment.NewLine;
            textBox4.Text += "Axis-c resting position: " + axis_c_rest_position;
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

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

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



        #region "Completed control implementations"

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

                //Now that we've successfully connected, here we modify how user
                //can interact with the GUI:
                AddressTextBox.Enabled = false;
                ConnectStripButton.Enabled = false;
                DisconnectStripButton.Enabled = true; groupBox1.Enabled = true;
                GeneralGroup.Enabled = true;
                originButton.Enabled = true; returnOriginButton.Enabled = true;
                pictureBox1.Enabled = true; textBox6.Enabled = true;

                //Update gantry absolute position to variable abs_position:
                cur_abs_pos(abs_position); 
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

            DisconnectStripButton.Enabled = false; groupBox1.Enabled = false;
            GeneralGroup.Enabled = false;
            originButton.Enabled = false; returnOriginButton.Enabled = false;
            pictureBox1.Enabled = false; textBox6.Enabled = false;

            PrintOutput(textBox1, "DISCONNECTED!", PrintStyle.Normal);
        }        

        //Note to self: this is complete. Can be applied to other buttons in this group
        private void button1_Click(object sender, EventArgs e)
        {
            //FUTURE: not sure what this string command does
            //runCommand("i=0\r#A;MG i{N};i=i+1;WT10;JP#A,i<10;EN");

            //take a single button click as moving 10000 units in a-axis
            runRelativeMoveCommand("A", increment_unit, speed_a);           
        }

        //Set as origin button:
        private void originButton_Click(object sender, EventArgs e)
        {
            try
            {
                PrintOutput(textBox1, "Setting origin..", PrintStyle.Normal, true);
                gclib.GCommand("AB;MO;SHA");
                //command to controller to set origin:
                gclib.GCommand("DP0,0,0");
                PrintOutput(textBox1, "done");
                cur_abs_pos(abs_position);
            }
            catch (Exception ex)
            {
                PrintOutput(textBox1, "ERROR in setting gantry origin: " + ex.Message, PrintStyle.Instruction);
            }
        }

        //Return to origin button:
        private void returnOriginButton_Click(object sender, EventArgs e)
        {
            runAbsoluteMoveCommand("A", 0, speed_a);
            runAbsoluteMoveCommand("B", 0, speed_b);
            runAbsoluteMoveCommand("C", 0, speed_c);
            PrintOutput(textBox1, "Move back to origin successful!");
        }


        #region "Special movement controls"

        // Set number of units to drop axis-c, according to input from textBox5: 
        private void button11_Click(object sender, EventArgs e)
        {
            int temp = drop_by; //restore in case of conversion failure of input from textBox
            if (!(Int32.TryParse(textBox5.Text, out drop_by)))
            {
                //if conversion failed
                drop_by = temp;
            }

            display_textbox4_manual();

        }

        //Set Axis-c rest position (for special movement)
        private void button15_Click(object sender, EventArgs e)
        {
            int temp = axis_c_rest_position; //restore in case of conversion failure of input from textBox
            if (!(Int32.TryParse(textBox5.Text, out axis_c_rest_position)))
            {
                //if conversion failed
                axis_c_rest_position = temp;
            }

            display_textbox4_manual();
        }


        //Set start_position:
        private void button7_Click(object sender, EventArgs e)
        {
            coor_string_to_intArr(textBox3.Text, start_position);
            //System.Threading.Thread.Sleep(200);
            display_textbox4_manual();

        }

        //Set end position:
        private void button10_Click(object sender, EventArgs e)
        {
            coor_string_to_intArr(textBox3.Text, end_position);
            display_textbox4_manual();
        }

        //Add intermediate position:
        private void button8_Click(object sender, EventArgs e)
        {
            int[] temp_pos = new int[2] { 0, 0 };
            coor_string_to_intArr(textBox3.Text, temp_pos);
            if (intermediate_positions == null) intermediate_positions = new List<int[]>();
            intermediate_positions.Add(temp_pos);
            display_textbox4_manual();
        }

        //Clear all intermediate positions:
        private void button9_Click(object sender, EventArgs e)
        {
            intermediate_positions.Clear();
            display_textbox4_manual();
        }

        //Simplifier function used for function proceeding this:
        private void special_move_helper(int[] position, int drop_by)
        {
            int dropped_abs_position = drop_by + axis_c_rest_position;
            runAbsoluteMoveCommand("C", axis_c_rest_position, speed_c);
            runAbsoluteMoveCommand("A", position[0], speed_a);
            runAbsoluteMoveCommand("B", position[1], speed_b);
            runAbsoluteMoveCommand("C", dropped_abs_position, speed_c);
        }

        private void special_manual_movement()
        {
            special_move_helper(start_position, drop_by);
            // BLOCK of code to complete user specified task....
            // I replace it temporarily with a simple pause:
            System.Threading.Thread.Sleep(200);
            intermediate_positions?.ForEach(a => {
                special_move_helper(a, drop_by);
                // BLOCK of code to complete user specified task....
                // I replace it temporarily with a simple pause:
                System.Threading.Thread.Sleep(200);
            });

            special_move_helper(end_position, drop_by);
            // BLOCK of code to complete user specified task....
            // I replace it temporarily with a simple pause:
            System.Threading.Thread.Sleep(200);

            // return to original axis-c rest position before ending movement:
            runAbsoluteMoveCommand("C", axis_c_rest_position, speed_c);
        }

        //Button for start special movement (movement depends on which radio box (manual or segment) is checked):
        private void button13_Click(object sender, EventArgs e)
        {
            if (manualButton.Checked == true)
            {
                special_manual_movement();
            }
            else if (segmentButton.Checked == true)
            {
                //remove last element of list (as it only contains values that we have not validated via function call to button21_clicked):
                segment_positions.RemoveAt(segment_positions.Count - 1);

                segment_positions?.ForEach(a =>
                {
                    int counter = 0;
                    while (true)
                    {
                        start_position[0] = counter * a[2] + a[0];
                        start_position[1] = counter * a[5] + a[3];
                        if (start_position[0] > a[1] || start_position[1] > a[4]) break;
                        special_move_helper(start_position, drop_by);
                        counter += 1;
                    }

                });

                // return to original axis-c rest position before ending movement:
                runAbsoluteMoveCommand("C", axis_c_rest_position, speed_c);
            }
        }

        // For mapping grid to movement, based on mouse click in grid box:
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            coordinates = e.Location;
            textBox6.Clear();
            textBox6.Text += "X = " + coordinates.X.ToString() + ", Y = " + coordinates.Y.ToString();

        }

        // Start "mapped" motion:
        // i.e. move gantry to mouse click position on "map" (X,Y coordinates)
        private void button14_Click(object sender, EventArgs e)
        {
            //first, go to bottom left edge (move faster than normal):
            runRelativeMoveCommand("A", -249000, speed_a + 10000);
            runRelativeMoveCommand("B", 249000, speed_b + 10000);

            //go to position indicated by mouse click on "map":
            runRelativeMoveCommand("A", 1245 * coordinates.Y, speed_a);
            runRelativeMoveCommand("B", 1245 * coordinates.X, speed_b);
        }




        #endregion

        #endregion

        #region "controllers under construction"

        #region "Segment_movement input buttons"

        // Segment movement: A (start) button:
        private void button12_Click(object sender, EventArgs e)
        {
            // initialize if segment_positions has not been initialized before
            // length (.Count) of list is now 1. This is important because we only display in 
            // textBox4 if list has items. 
            if (!segment_positions.Any()) {
                segment_positions = new List<int[]>();
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            if (!(Int32.TryParse(textBox7.Text, out segment_positions.Last()[0]))) {
                segment_positions.Last()[0] = 0;
            }

            display_textbox4_segment();

        }

        // Segment movement: A (end) button:
        private void button17_Click(object sender, EventArgs e)
        {
            // initialize if segment_positions has not been initialized before
            // length (.Count) of list is now 1. This is important because we only display in 
            // textBox4 if list has items. 
            if (!segment_positions.Any())
            {
                segment_positions = new List<int[]>();
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            if (!(Int32.TryParse(textBox7.Text, out segment_positions.Last()[1])))
            {
                segment_positions.Last()[1] = 0;
            }

            display_textbox4_segment();
        }

        // Segment movement: A (delta) button:
        private void button19_Click(object sender, EventArgs e)
        {
            // initialize if segment_positions has not been initialized before
            // length (.Count) of list is now 1. This is important because we only display in 
            // textBox4 if list has items. 
            if (!segment_positions.Any())
            {
                segment_positions = new List<int[]>();
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            if (!(Int32.TryParse(textBox7.Text, out segment_positions.Last()[2])))
            {
                segment_positions.Last()[2] = 0;
            }
            display_textbox4_segment();
        }

        // Segment movement: B (start) button:
        private void button16_Click(object sender, EventArgs e)
        {
            // initialize if segment_positions has not been initialized before
            // length (.Count) of list is now 1. This is important because we only display in 
            // textBox4 if list has items. 
            if (!segment_positions.Any())
            {
                segment_positions = new List<int[]>();
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            if (!(Int32.TryParse(textBox7.Text, out segment_positions.Last()[3])))
            {
                segment_positions.Last()[3] = 0;
            }
            display_textbox4_segment();
        }

        // Segment movement: B (end) button:
        private void button18_Click(object sender, EventArgs e)
        {
            // initialize if segment_positions has not been initialized before
            // length (.Count) of list is now 1. This is important because we only display in 
            // textBox4 if list has items. 
            if (!segment_positions.Any())
            {
                segment_positions = new List<int[]>();
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            if (!(Int32.TryParse(textBox7.Text, out segment_positions.Last()[4])))
            {
                segment_positions.Last()[4] = 0;
            }
            display_textbox4_segment();
        }

        // Segment movement: B (delta) button:
        private void button20_Click(object sender, EventArgs e)
        {
            // initialize if segment_positions has not been initialized before
            // length (.Count) of list is now 1. This is important because we only display in 
            // textBox4 if list has items. 
            if (!segment_positions.Any())
            {
                segment_positions = new List<int[]>();
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
            }
            if (!(Int32.TryParse(textBox7.Text, out segment_positions.Last()[5])))
            {
                segment_positions.Last()[5] = 0;
            }
            display_textbox4_segment();
        }

        // Segment movement: clear segments button:
        private void button22_Click(object sender, EventArgs e)
        {
            segment_positions.Clear();
            display_textbox4_segment();
        }

        // Segment movement: add segment button:
        private void button21_Click(object sender, EventArgs e)
        {
            // check if segment values are valid (i.e. if they add up):
            if( ((segment_positions.Last()[1] - segment_positions.Last()[0]) % segment_positions.Last()[2] == 0) && ((segment_positions.Last()[4] - segment_positions.Last()[3]) % segment_positions.Last()[5] == 0) )
            {
                segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
                
            }
            else
            {
                MessageBox.Show("Segment values do not add up. Check your input values.", "Invalid Input.");
            }
            display_textbox4_segment();
        }


       
        //Configuration of GUI if manual_button is checked:
        private void manualButton_CheckedChanged(object sender, EventArgs e)
        {
            if (manualButton.Checked == true)
            {

                manualBox.Enabled = true;
                segment_positions.Clear();
                segmentBox.Enabled = false;
                start_position = new int[2]; end_position = new int[2];
                intermediate_positions.Clear();
                textBox4.Clear();
            }
        }

        //Configuration of GUI if segment_button is checked:
        private void segmentButton_CheckedChanged(object sender, EventArgs e)
        {
            if (segmentButton.Checked == true)
            {
                segmentBox.Enabled = true;
                manualBox.Enabled = false;
                start_position = new int[2]; end_position = new int[2];
                intermediate_positions.Clear();
                textBox4.Clear();
            }
        }



        #endregion

        #endregion

        private void mmButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
