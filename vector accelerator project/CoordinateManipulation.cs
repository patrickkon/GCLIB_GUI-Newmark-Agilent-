using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vector_accelerator_project
{
    class CoordinateManipulation
    {
    }

    public class Movement_variables
    {
        //Variables that store coordinates:
        public int[] start_position;
        public int[] end_position;
        //a list of integer arrays, each with 2 elements:
        public List<int[]> intermediate_positions;

        //Variables that store other parameters:
        public int drop_by;  //axis-c drop by how many units while sampling
        //private int[] sample_units = new int[2] { 0, 0 }; //sample every "sample_units" units
        public int axis_c_rest_position ;

        public int increment_unit;
        public int speed_a; //recommended speed
        public int speed_b; //recommended speed
        public int speed_c; //recommended speed


        public Movement_variables()
        {
            //Variables that store coordinates:
            start_position = new int[2] { 0, 0 };
            end_position = new int[2] { 0, 0 };
            //a list of integer arrays, each with 2 elements:
            intermediate_positions = null;

            //Variables that store other parameters:
            drop_by = 0;  //axis-c drop by how many units while sampling
            //private int[] sample_units = new int[2] { 0, 0 }; //sample every "sample_units" units
            axis_c_rest_position = 0;


            increment_unit = 10000;
            speed_a = 5000; //recommended speed
            speed_b = 5000; //recommended speed
            speed_c = 400000; //recommended speed
        }
    }

    // initially was planning to use this for special_manual_movement and so on, but might be removed now instead:
    partial class Form1 {
        class Movement_util
        {
            private Form1 form;
            private gclib gclib;

            public Movement_util(Form1 form, gclib gclib)
            {
                this.form = form;
                this.gclib = gclib;
            }
            
            //Basic PA movement, while printing output to TextBox1:
            private void runAbsoluteMoveCommand(string axis, int distance_units, int speed)
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
                    //cur_abs_pos(abs_position);  // as stated in Master, this is commented as it has been identified as the source of neg move problem
                }
                catch (Exception ex)
                {
                    form.printTextBox1("ERROR in runAbsoluteMoveCommand on axis " + axis + ": " + ex.Message, Form1.PrintStyle.Instruction);
                }
            }

            //Simplifier function used for function proceeding this:
            private void special_move_helper(int [] position, Movement_variables move_vars)
            {
                int dropped_abs_position = move_vars.drop_by + move_vars.axis_c_rest_position;
                runAbsoluteMoveCommand("C", move_vars.axis_c_rest_position, move_vars.speed_c);
                runAbsoluteMoveCommand("A", position[0], move_vars.speed_a);
                runAbsoluteMoveCommand("B", position[1], move_vars.speed_b);
                runAbsoluteMoveCommand("C", dropped_abs_position, move_vars.speed_c);
            }
        }
    }

    partial class Form1
    {
        public delegate void runAbsoluteMoveCommand(string axis, int distance_units, int speed);
        public delegate void special_move_helper(int[] position, Movement_variables move_vars);

        class MovementType
        {
            protected PNA analyzer;
            //protected gclib gclib;
            public MovementType(PNA analyzer)
            {
                this.analyzer = analyzer;
                //this.gclib = gclib;
            }


            public virtual void move(runAbsoluteMoveCommand runAbsoluteMoveCommand, Movement_variables move_vars) { }
            
        }

        class ManualMovement : MovementType
        {
            public ManualMovement(PNA analyzer)
                : base(analyzer)
            {

            }

            override
            public void move(runAbsoluteMoveCommand runAbsoluteMoveCommand, special_move_helper special_move_helper, Movement_variables move_vars)
            {   
                special_move_helper(move_vars.start_position, move_vars);
                // BLOCK of code to complete user specified task....
                // I replace it temporarily with a simple pause:

                // i add VNA stuff in now: 
                analyzer.PNA_scan(move_vars.start_position, move_vars.drop_by);
                                                            //WANT TO PASS PNA_SCAN ARGUMENTS TO BE ACCESSED WITHIN THAT METHOD ITSELF
                System.Threading.Thread.Sleep(200);
                move_vars.intermediate_positions?.ForEach(a => {      
                    special_move_helper(a, move_vars);
                    // BLOCK of code to complete user specified task....
                    // I replace it temporarily with a simple pause:
                    System.Threading.Thread.Sleep(200);
                
                    // i add VNA stuff in now:
                    analyzer.PNA_scan(a, move_vars.drop_by);
                });

                special_move_helper(move_vars.end_position, move_vars);
                // BLOCK of code to complete user specified task....
                // I replace it temporarily with a simple pause:
                System.Threading.Thread.Sleep(200);

                // i add VNA stuff in now:
                PNA_scan(move_vars.end_position, move_vars.drop_by);

                // return to original axis-c rest position before ending movement:
                runAbsoluteMoveCommand("C", move_vars.axis_c_rest_position, move_vars.speed_c);
            }   
        }

        class SegmentMovement : MovementType
        {

        }


        // All execution comes from these below classes, the above classes are utilities for these classes only:

        class Movement
        {

            public Movement()
            {

            }

            public void move(MovementType a)
            {
                a.move();
            }

        }


        class Stepper : Movement
        {
            public void move()
            {

            }
        }

        class Mm : Movement
        {

        }


    }
}

