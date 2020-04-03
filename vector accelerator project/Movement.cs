using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MovementTests")]


namespace vector_accelerator_project
{
    class MovementVariables
    {
        //Variables that store coordinates: 
        public virtual int[] Start_position { get; private set; }
        public virtual int[] End_position { get; private set; }
        //a list of integer arrays, each with 2 elements:
        public virtual List<int[]> Intermediate_positions { get; private set; }

        // Used for Segment Movement:
        // each int[] has 6 elements (in-order): 
        // a(start), a(end), a(delta), b(start), b(end), b(delta)
        public List<int[]> Segment_positions { get; private set; }
    

        //Variables that store other parameters:
        public virtual int Axis_c_drop_by { get; set; }  //axis-c drop by how many units while sampling
        public virtual int Axis_c_rest_position { get; set; }

        public virtual int Increment_unit { get; set; }
        public virtual int Speed_a { get; set; } //recommended speed
        public virtual int Speed_b { get; set; } //recommended speed
        public virtual int Speed_c { get; set; } //recommended speed


        public MovementVariables()
        {
            //Variables that store coordinates:
            Start_position = new int[2] { 0, 0 };
            End_position = new int[2] { 0, 0 };
            //a list of integer arrays, each with 2 elements:
            Intermediate_positions = new List<int[]>();
            //Intermediate_positions.Add(new int[2] { 0, 0 });

            Segment_positions = new List<int[]>();
            Segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });


            //Variables that store other parameters:
            Axis_c_drop_by = 0;  //axis-c drop by how many units while sampling
            Axis_c_rest_position = 0;

            Increment_unit = 10000;
            Speed_a = 5000; //recommended speed
            Speed_b = 5000; //recommended speed
            Speed_c = 400000; //recommended speed
        }

        public virtual bool set_StartPosition(int index, int value) { return true; }
        public virtual bool set_EndPosition(int index, int value) { return true; }
        public virtual bool set_IntermediatePosition(int index, int value) { return true; }
        public virtual bool set_SegmentPosition(int index, int value) { return true; }

        public delegate void displayFunc(); 

        public bool add_Segment(displayFunc display)
        {
            // check if Segment values are valid (i.e. if they add up):
            bool same_num_samples = false;
            int b_sample_num = (Math.Abs(Segment_positions.Last()[5]) > 0) ? (Segment_positions.Last()[4] - Segment_positions.Last()[3]) / Segment_positions.Last()[5] : 0;
            int a_sample_num = (Math.Abs(Segment_positions.Last()[2]) > 0) ? (Segment_positions.Last()[1] - Segment_positions.Last()[0]) / Segment_positions.Last()[2] : 0;
            same_num_samples = (b_sample_num == 0 || a_sample_num == 0 || (b_sample_num != a_sample_num)) ? false : true;
            if (same_num_samples && ((Segment_positions.Last()[1] - Segment_positions.Last()[0]) % Segment_positions.Last()[2] == 0) && ((Segment_positions.Last()[4] - Segment_positions.Last()[3]) % Segment_positions.Last()[5] == 0))
            {
                Segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
                display?.Invoke();
                return true;
            }
            else if(b_sample_num != 0 || a_sample_num != 0)
            {
                // added 24/3/2020
                // edge case: if either a or b direction is stationary, but not both

                if(b_sample_num != 0)
                {
                    if (((Segment_positions.Last()[4] - Segment_positions.Last()[3]) % Segment_positions.Last()[5] == 0))
                    {
                        Segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
                        display?.Invoke();
                        return true;
                    }
                }
                else if(a_sample_num != 0)
                {
                    if(((Segment_positions.Last()[1] - Segment_positions.Last()[0]) % Segment_positions.Last()[2] == 0))
                    {
                        Segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });
                        display?.Invoke();
                        return true;
                    }
                }
            }
            // if has not return, it is false
                System.Windows.Forms.MessageBox.Show("Segment values do not add up. Check your input values.", "Invalid Input.");
                return false;
        }

        // added 24/3/2020. Updated 1 april 2020
        // Feature update: Grid segment type movement, that "reformats" the segment value input. This is different from add_segment above
        public bool add_SegmentGrid(displayFunc display)
        {
            // Note now: y = a axis in GUI
            // Note now: x = b axis in GUI
            // Note -a = move backwards
            // Note -b = move right
            int anchorStart_y = Segment_positions.Last()[0];
            int anchorStart_x = Segment_positions.Last()[3];

            int anchorEnd_y = Segment_positions.Last()[1];
            int anchorEnd_x = Segment_positions.Last()[4];

            int increment_y = Segment_positions.Last()[2];
            int increment_x = Segment_positions.Last()[5];

            // We iterate through y_axis end to end, then move increment x_axis once, then repeat:

            // Section1: check alignment: increment multiple is valid


            // sub-section1: normal non-zero multiple:
            bool validIncrement_x = (Math.Abs(Segment_positions.Last()[5]) > 0) ? (Segment_positions.Last()[4] - Segment_positions.Last()[3]) % Segment_positions.Last()[5] == 0 ? true : false : false;
            bool validIncrement_y = (Math.Abs(Segment_positions.Last()[2]) > 0) ? (Segment_positions.Last()[1] - Segment_positions.Last()[0]) % Segment_positions.Last()[2] == 0 ? true : false : false;

            // sub-section2: edge case of 0 increment:
            validIncrement_y = (validIncrement_y == false && increment_y == 0) ? (anchorStart_y - anchorEnd_y == 0) ? true : false : validIncrement_y;
            validIncrement_x = (validIncrement_x == false && increment_x == 0) ? (anchorStart_x - anchorEnd_x == 0) ? true : false : validIncrement_x;

            if (!validIncrement_x || !validIncrement_y)
            {
                System.Windows.Forms.MessageBox.Show("Segment values do not add up. Check your input values.", "Invalid Input.");
                return false;
            }

            // Start inserting segments into array:
            for (int j = anchorStart_y; Math.Abs(j) <= Math.Abs(anchorEnd_y); j += increment_y)
            {
                Segment_positions.Last()[0] = j;
                Segment_positions.Last()[1] = j;
                Segment_positions.Last()[2] = 0;

                Segment_positions.Last()[3] = anchorStart_x;
                Segment_positions.Last()[4] = anchorEnd_x;
                Segment_positions.Last()[5] = increment_x;

                Segment_positions.Add(new int[6] { 0, 0, 0, 0, 0, 0 });

                // Prevent infinite loop
                if (increment_y == 0 && increment_x == 0) break;
            }

            display?.Invoke();

            return true;
        }
    }

    class MovementVariables_stepperUnit : MovementVariables
    {
        public MovementVariables_stepperUnit()
            : base()
        {
        }

        public override bool set_StartPosition(int index, int value)
        {
            try
            {
                Start_position[index] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

        public override bool set_EndPosition(int index, int value)
        {
            try
            {
                End_position[index] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

        public override bool set_IntermediatePosition(int index, int value)
        {
            try
            {
                Intermediate_positions.Last()[index] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

        public override bool set_SegmentPosition(int index, int value)
        {
            try
            {
                Segment_positions.Last()[index] = value;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

    }

    class MovementVariables_mmUnit : MovementVariables
    {
        public MovementVariables_mmUnit()
            : base()
        {
        }

        //Variables that store other parameters:
        private int axis_c_drop_by;
        private int axis_c_rest_position;
        public override int Axis_c_drop_by
        {
            get => axis_c_drop_by;
            set => axis_c_drop_by = value * 14970;

        }  
        public override int Axis_c_rest_position
        {
            get => axis_c_rest_position;
            set => axis_c_rest_position = value * 14970;
        }

        public override int Increment_unit { get; set; }

        public override bool set_StartPosition(int index, int value)
        {
            try
            {
                Start_position[index] = value * 207;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

        public override bool set_EndPosition(int index, int value)
        {
            try
            {
                End_position[index] = value * 207;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

        public override bool set_IntermediatePosition(int index, int value)
        {
            try
            {
                Intermediate_positions.Last()[index] = value * 207;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }

        public override bool set_SegmentPosition(int index, int value)
        {
            try
            {
                Segment_positions.Last()[index] = value * 207;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic exception handler: {e}");
                return false;
            }
            return true;
        }


    }

    // Not to be exposed to other modules. (clean code purposes)
    // Use higher level wrappers listed below instead
    class MoveFactory
    {
        private Form1 form;
        private gclib gclib;

        public MoveFactory(Form1 form, gclib gclib)
        {
            this.form = form;
            this.gclib = gclib;
        }

        //Basic PA movement, while printing output to TextBox1:
        protected internal void runAbsoluteMoveCommand(string axis, int distance_units, int speed)
        {
            try
            {
                form.printTextBox1("Preparing " + axis + " axis for PA movement. This could cause errors if the axis is not initialized...");
                gclib.GCommand("AB;MO;SH" + axis);
                //compound commands are possible though typically not recommended
                form.printTextBox1("Ok");
                gclib.GCommand("PA" + axis + "=" + distance_units);

                //might implement speed control parameter in future
                gclib.GCommand("SP" + axis + "=" + speed);
                form.printTextBox1("Profiling a move on axis" + axis + "... ");
                gclib.GCommand("BG" + axis);
                form.printTextBox1("Waiting for motion to complete... ");
                gclib.GMotionComplete(axis);
                form.printTextBox1("done");
                //update absolute position and display in textBox2:
                //System.Threading.Thread.Sleep(200); // maybe pausing first might fix this error
                //cur_abs_pos(abs_position);  // as stated in Master, this is commented as it has been identified as the source of neg move problem
            }
            catch (Exception ex)
            {
                form.printTextBox1("ERROR in runAbsoluteMoveCommand on axis " + axis + ": " + ex.Message, Form1.PrintStyle.Instruction);
            }
        }
        //Note to self: axis must be in Capital letters.
        //Simple PR movement:
        public void runRelativeMoveCommand(string axis, int distance_units, int speed)
        {
            try
            {
                form.printTextBox1("Preparing " + axis + " axis for PR movement. This could cause errors if the axis is not initialized...");
                gclib.GCommand("AB;MO;SH" + axis);
                //compound commands are possible though typically not recommended
                form.printTextBox1("Ok");
                gclib.GCommand("PR" + axis + "=" + distance_units);

                //might implement speed control parameter in future
                gclib.GCommand("SP" + axis + "=" + speed);
                form.printTextBox1("Profiling a move on axis" + axis + "... ");
                gclib.GCommand("BG" + axis);
                form.printTextBox1("Waiting for motion to complete... ");
                gclib.GMotionComplete(axis);
                form.printTextBox1("done");
                //update absolute position and display in textBox2:
                //cur_abs_pos(abs_position);  // as stated in Master, this is commented as it has been identified as the source of neg move problem
            }
            catch (Exception ex)
            {
                form.printTextBox1("ERROR in runRelativeMoveCommand on axis " + axis + ": " + ex.Message, Form1.PrintStyle.Instruction);
            }
        }

        //Movement for a specific set of AB-axis coordinates within MovementVariables:
        protected internal void special_move_helper(int[] position, MovementVariables movementVariables)
        {
            int dropped_abs_position = movementVariables.Axis_c_drop_by + movementVariables.Axis_c_rest_position;
            runAbsoluteMoveCommand("C", movementVariables.Axis_c_rest_position, movementVariables.Speed_c);
            runAbsoluteMoveCommand("A", position[0], movementVariables.Speed_a);
            runAbsoluteMoveCommand("B", position[1], movementVariables.Speed_b);
            runAbsoluteMoveCommand("C", dropped_abs_position, movementVariables.Speed_c);
        }


        // Return to Origin
        public void goHome(MovementVariables movementVariables)
        {
            runAbsoluteMoveCommand("A", 0, movementVariables.Speed_a);
            runAbsoluteMoveCommand("B", 0, movementVariables.Speed_b);
            runAbsoluteMoveCommand("C", 0, movementVariables.Speed_c);
            form.printTextBox1("Move back to origin successful!");
        }
    }

    // Currently supports both manual and segmented movement:
    class MovementType
    {
        //protected MovementVariables movementVariables;
        protected PNA analyzer;
        protected MoveFactory moveFactory;
        protected Form1_EventListeners form1_EventListeners;
        
        public MovementType(PNA analyzer, Form1 form, gclib gclib /*ref MovementVariables movementVariables*/)
        {
            //this.movementVariables = movementVariables;
            this.analyzer = analyzer;
            this.moveFactory = new MoveFactory(form, gclib);
            this.form1_EventListeners = new Form1_EventListeners(form);
            //this.gclib = gclib;
        }

        public virtual void move(MovementVariables movementVariables) { }
        //public virtual void displayFunc() { } // Format for displaying your movement required values

        public void goHome(MovementVariables movementVariables)
        {
            moveFactory.goHome(movementVariables);
        }

        public void runRelativeMoveCommand(string axis, int distance_units, int speed)
        {
            moveFactory.runRelativeMoveCommand(axis, distance_units, speed);
        }
    }
    
    class ManualMovement : MovementType
    {
        public ManualMovement(PNA analyzer, Form1 form, gclib gclib/* ref MovementVariables movementVariables*/)
            : base(analyzer, form, gclib/* ref movementVariables*/)
        {
        }

        override
        public void move(MovementVariables movementVariables)
        {
            moveFactory.special_move_helper(movementVariables.Start_position, movementVariables);
            // BLOCK of code to complete user specified task....
            // I replace it temporarily with a simple pause:

            // i add VNA stuff in now: 
            analyzer.PNA_scan(movementVariables.Start_position, movementVariables);
            //WANT TO PASS PNA_SCAN ARGUMENTS TO BE ACCESSED WITHIN THAT METHOD ITSELF
            System.Threading.Thread.Sleep(200);
            movementVariables.Intermediate_positions?.ForEach(a => {
                moveFactory.special_move_helper(a, movementVariables);
                // BLOCK of code to complete user specified task....
                // I replace it temporarily with a simple pause:
                System.Threading.Thread.Sleep(200);

                // i add VNA stuff in now:
                analyzer.PNA_scan(a, movementVariables);
            });

            moveFactory.special_move_helper(movementVariables.End_position, movementVariables);
            // BLOCK of code to complete user specified task....
            // I replace it temporarily with a simple pause:
            System.Threading.Thread.Sleep(200);

            // i add VNA stuff in now:
            analyzer.PNA_scan(movementVariables.End_position, movementVariables);

            // return to original axis-c rest position before ending movement:
            moveFactory.runAbsoluteMoveCommand("C", movementVariables.Axis_c_rest_position, movementVariables.Speed_c);
        }
    }

    class SegmentMovement : MovementType
    {
        public SegmentMovement(PNA analyzer, Form1 form, gclib gclib/*, ref MovementVariables movementVariables*/)
            : base(analyzer, form, gclib/*, ref movementVariables*/)
        {
        }

        override
        public void move(MovementVariables movementVariables)
        {
            int counter = 0; // indicates how many segments have been processed.
            movementVariables.Segment_positions?.ForEach(a =>
            {
                int multiplier = 0;
                // Do not consider last element of segment_positions as it does not contain validated input that has passed through the function button21_clicked:
                if (counter < movementVariables.Segment_positions.Count - 1)
                {
                    while (true)
                    {
                        // Reuse Start_position array to place each of our segment movement coordinates
                        movementVariables.Start_position[0] = multiplier * a[2] + a[0];
                        movementVariables.Start_position[1] = multiplier * a[5] + a[3];                                 
                        multiplier += 1;
                        //if ( (start_position[0] < 0 && (Math.Abs(start_position[0]) > Math.Abs(a[1])  || Math.Abs(start_position[1]) > Math.Abs(a[4])) ) || (start_position[0] < 0 && (Math.Abs(start_position[0]) > Math.Abs(a[1]) || Math.Abs(start_position[1]) > Math.Abs(a[4])))) break;
                        moveFactory.special_move_helper(movementVariables.Start_position, movementVariables);

                        // i add VNA stuff in now:
                        analyzer.PNA_scan(movementVariables.Start_position, movementVariables);

                        if (movementVariables.Start_position[0] == a[1] && movementVariables.Start_position[1] == a[4]) break;                      
                    }
                    counter += 1;
                }
            });
            // return to original axis-c rest position before ending movement:
            moveFactory.runAbsoluteMoveCommand("C", movementVariables.Axis_c_rest_position, movementVariables.Speed_c);
        }
    }

    #region "Classes currently ununsed"
    // Not needed. Left in case
    public class Movement
    {
        public Movement()
        {

        }
    }


    class Form1_EventListeners
    {
        private Form1 form;

        public Form1_EventListeners(Form1 form)
        {
            this.form = form;
        }

        internal Boolean mmButton_checked()
        {
            return form.mmButton_checked();
        }

        //internal void clearMovementValueDisplay()
        //{
        //     form.clearMovementValue_textBox();
        // }

    }
    #endregion
}
