using System.Windows.Forms;
//using System.Windows.Controls;

namespace vector_accelerator_project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.GClibBackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.DisconnectStripButton = new System.Windows.Forms.ToolStripButton();
            this.ConnectStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddressTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.GeneralGroup = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.unitbox = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.originButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button22 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.segmentButton = new System.Windows.Forms.RadioButton();
            this.manualButton = new System.Windows.Forms.RadioButton();
            this.button13 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.returnOriginButton = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mmButton = new System.Windows.Forms.RadioButton();
            this.stepperButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.manualBox = new System.Windows.Forms.GroupBox();
            this.segmentBox = new System.Windows.Forms.GroupBox();
            this.MainToolStrip.SuspendLayout();
            this.GeneralGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.manualBox.SuspendLayout();
            this.segmentBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(12, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(623, 197);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "System Output";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 29);
            this.label6.TabIndex = 12;
            this.label6.Text = "Special Movement";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(244, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Current Absolute Position Display";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 307);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(243, 468);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // GClibBackgroundWorker1
            // 
            this.GClibBackgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GClibBackgroundWorker1_DoWork);
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.MainToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.DisconnectStripButton,
            this.ConnectStripButton,
            this.AddressTextBox});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(800, 32);
            this.MainToolStrip.TabIndex = 15;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(152, 29);
            this.toolStripLabel1.Text = "GOpen() Address:";
            // 
            // DisconnectStripButton
            // 
            this.DisconnectStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DisconnectStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DisconnectStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DisconnectStripButton.Image")));
            this.DisconnectStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DisconnectStripButton.Name = "DisconnectStripButton";
            this.DisconnectStripButton.Size = new System.Drawing.Size(103, 29);
            this.DisconnectStripButton.Text = "Disconnect";
            this.DisconnectStripButton.Click += new System.EventHandler(this.DisconnectStripButton_Click);
            // 
            // ConnectStripButton
            // 
            this.ConnectStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ConnectStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ConnectStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConnectStripButton.Name = "ConnectStripButton";
            this.ConnectStripButton.Size = new System.Drawing.Size(81, 29);
            this.ConnectStripButton.Text = "Connect";
            this.ConnectStripButton.Click += new System.EventHandler(this.ConnectStripButton_Click);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(450, 32);
            this.AddressTextBox.Text = "COM14 --direct --baud 19200 --subscribe ALL";
            this.AddressTextBox.Click += new System.EventHandler(this.AddressTextBox_Click);
            // 
            // GeneralGroup
            // 
            this.GeneralGroup.Controls.Add(this.label5);
            this.GeneralGroup.Controls.Add(this.unitbox);
            this.GeneralGroup.Controls.Add(this.button5);
            this.GeneralGroup.Controls.Add(this.label4);
            this.GeneralGroup.Controls.Add(this.button6);
            this.GeneralGroup.Controls.Add(this.button3);
            this.GeneralGroup.Controls.Add(this.label3);
            this.GeneralGroup.Controls.Add(this.button4);
            this.GeneralGroup.Controls.Add(this.button2);
            this.GeneralGroup.Controls.Add(this.label1);
            this.GeneralGroup.Controls.Add(this.button1);
            this.GeneralGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralGroup.Location = new System.Drawing.Point(641, 58);
            this.GeneralGroup.Name = "GeneralGroup";
            this.GeneralGroup.Size = new System.Drawing.Size(464, 223);
            this.GeneralGroup.TabIndex = 16;
            this.GeneralGroup.TabStop = false;
            this.GeneralGroup.Text = "General Relative Movement";
            this.GeneralGroup.Enter += new System.EventHandler(this.GeneralGroup_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Unit (>300):";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // unitbox
            // 
            this.unitbox.Location = new System.Drawing.Point(329, 81);
            this.unitbox.Name = "unitbox";
            this.unitbox.Size = new System.Drawing.Size(100, 26);
            this.unitbox.TabIndex = 17;
            this.unitbox.TextChanged += new System.EventHandler(this.unitbox_TextChanged);
            this.unitbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter_unitbox);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(221, 161);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(96, 38);
            this.button5.TabIndex = 19;
            this.button5.Text = "- (c-axis)";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "c-axis";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(103, 161);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(96, 38);
            this.button6.TabIndex = 17;
            this.button6.Text = "+ (c-axis)";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 38);
            this.button3.TabIndex = 16;
            this.button3.Text = "- (b-axis)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "b-axis";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(103, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 38);
            this.button4.TabIndex = 14;
            this.button4.Text = "+ (b-axis)";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 38);
            this.button2.TabIndex = 13;
            this.button2.Text = "- (a-axis)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "a-axis";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "+ (a-axis)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // originButton
            // 
            this.originButton.Location = new System.Drawing.Point(1039, 4);
            this.originButton.Name = "originButton";
            this.originButton.Size = new System.Drawing.Size(124, 34);
            this.originButton.TabIndex = 17;
            this.originButton.Text = "Set as Origin";
            this.originButton.UseVisualStyleBackColor = true;
            this.originButton.Click += new System.EventHandler(this.originButton_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(14, 73);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(121, 30);
            this.button7.TabIndex = 18;
            this.button7.Text = "Set Start point";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(14, 109);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(178, 34);
            this.button8.TabIndex = 19;
            this.button8.Text = "Set Intermediate point (multiple)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(198, 109);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(205, 34);
            this.button9.TabIndex = 20;
            this.button9.Text = "Clear Intermediate points";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(141, 73);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(121, 30);
            this.button10.TabIndex = 21;
            this.button10.Text = "Set End point";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(214, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(179, 26);
            this.textBox3.TabIndex = 22;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Point Input (format \"A, B\"):";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.segmentBox);
            this.groupBox1.Controls.Add(this.manualBox);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.segmentButton);
            this.groupBox1.Controls.Add(this.manualButton);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Location = new System.Drawing.Point(257, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(884, 604);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anchor coordinates";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(26, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 20);
            this.label20.TabIndex = 50;
            this.label20.Text = "Mode:";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(16, 447);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(390, 2);
            this.label19.TabIndex = 49;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(209, 166);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(160, 34);
            this.button22.TabIndex = 48;
            this.button22.Text = "Clear all segments";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.button22_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(51, 166);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(121, 34);
            this.button21.TabIndex = 47;
            this.button21.Text = "Add Segment";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(266, 73);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(121, 30);
            this.button19.TabIndex = 46;
            this.button19.Text = "A (delta)";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(266, 109);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(121, 34);
            this.button20.TabIndex = 45;
            this.button20.Text = "B (delta)";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(8, 73);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(121, 30);
            this.button12.TabIndex = 41;
            this.button12.Text = "A (start)";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(8, 109);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(121, 34);
            this.button16.TabIndex = 42;
            this.button16.Text = "B (start)";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(135, 73);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(121, 30);
            this.button17.TabIndex = 44;
            this.button17.Text = "A (end)";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(135, 109);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(121, 34);
            this.button18.TabIndex = 43;
            this.button18.Text = "B (end)";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(176, 20);
            this.label18.TabIndex = 40;
            this.label18.Text = "Point Input (format \"Z\"):";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(208, 28);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(179, 26);
            this.textBox7.TabIndex = 39;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(16, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(390, 2);
            this.label15.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(16, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(390, 2);
            this.label14.TabIndex = 35;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // segmentButton
            // 
            this.segmentButton.AutoSize = true;
            this.segmentButton.Location = new System.Drawing.Point(240, 26);
            this.segmentButton.Name = "segmentButton";
            this.segmentButton.Size = new System.Drawing.Size(138, 24);
            this.segmentButton.TabIndex = 34;
            this.segmentButton.TabStop = true;
            this.segmentButton.Text = "Segment input";
            this.segmentButton.UseVisualStyleBackColor = true;
            this.segmentButton.CheckedChanged += new System.EventHandler(this.segmentButton_CheckedChanged);
            // 
            // manualButton
            // 
            this.manualButton.AutoSize = true;
            this.manualButton.Location = new System.Drawing.Point(95, 26);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(125, 24);
            this.manualButton.TabIndex = 33;
            this.manualButton.TabStop = true;
            this.manualButton.Text = "Manual input";
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.CheckedChanged += new System.EventHandler(this.manualButton_CheckedChanged);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(83, 559);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(221, 39);
            this.button13.TabIndex = 32;
            this.button13.Text = "Start special motion";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(201, 490);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(195, 50);
            this.button15.TabIndex = 31;
            this.button15.Text = "Set Axis-c resting position:";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Other parameter input:";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(16, 490);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(164, 48);
            this.button11.TabIndex = 28;
            this.button11.Text = "Axis-c drop bar by (relative):";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(188, 456);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 26);
            this.textBox5.TabIndex = 27;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(429, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 560);
            this.label9.TabIndex = 25;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(444, 23);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(422, 562);
            this.textBox4.TabIndex = 25;
            this.textBox4.Text = "Click on button once input has been added. Allows multi intermediate points. This" +
    " textbox displays our parameters";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1171, 642);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1167, 876);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(224, 26);
            this.textBox6.TabIndex = 26;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(1165, 609);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(242, 30);
            this.label11.TabIndex = 27;
            this.label11.Text = "Single Coor (Clickable Map):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1167, 853);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(184, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Mapped relative position:";
            // 
            // returnOriginButton
            // 
            this.returnOriginButton.Location = new System.Drawing.Point(1169, 4);
            this.returnOriginButton.Name = "returnOriginButton";
            this.returnOriginButton.Size = new System.Drawing.Size(134, 34);
            this.returnOriginButton.TabIndex = 29;
            this.returnOriginButton.Text = "Return to Origin";
            this.returnOriginButton.UseVisualStyleBackColor = true;
            this.returnOriginButton.Click += new System.EventHandler(this.returnOriginButton_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(1180, 908);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(181, 30);
            this.button14.TabIndex = 31;
            this.button14.Text = "Start mapped motion";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1169, 316);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(415, 256);
            this.richTextBox1.TabIndex = 32;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // mmButton
            // 
            this.mmButton.AutoSize = true;
            this.mmButton.Location = new System.Drawing.Point(1134, 79);
            this.mmButton.Name = "mmButton";
            this.mmButton.Size = new System.Drawing.Size(60, 24);
            this.mmButton.TabIndex = 33;
            this.mmButton.TabStop = true;
            this.mmButton.Text = "Mm";
            this.mmButton.UseVisualStyleBackColor = true;
            // 
            // stepperButton
            // 
            this.stepperButton.AutoSize = true;
            this.stepperButton.Location = new System.Drawing.Point(1134, 110);
            this.stepperButton.Name = "stepperButton";
            this.stepperButton.Size = new System.Drawing.Size(132, 24);
            this.stepperButton.TabIndex = 34;
            this.stepperButton.TabStop = true;
            this.stepperButton.Text = "Stepper Units";
            this.stepperButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1130, 56);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Unit of Choice:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1130, 155);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 20);
            this.label21.TabIndex = 42;
            this.label21.Text = "Slew Speed:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(1234, 152);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(139, 26);
            this.textBox8.TabIndex = 41;
            // 
            // manualBox
            // 
            this.manualBox.Controls.Add(this.button9);
            this.manualBox.Controls.Add(this.button10);
            this.manualBox.Controls.Add(this.button8);
            this.manualBox.Controls.Add(this.textBox3);
            this.manualBox.Controls.Add(this.button7);
            this.manualBox.Controls.Add(this.label8);
            this.manualBox.Location = new System.Drawing.Point(16, 63);
            this.manualBox.Name = "manualBox";
            this.manualBox.Size = new System.Drawing.Size(407, 149);
            this.manualBox.TabIndex = 43;
            this.manualBox.TabStop = false;
            this.manualBox.Text = "Manual Input:";
            // 
            // segmentBox
            // 
            this.segmentBox.Controls.Add(this.label18);
            this.segmentBox.Controls.Add(this.textBox7);
            this.segmentBox.Controls.Add(this.button18);
            this.segmentBox.Controls.Add(this.button17);
            this.segmentBox.Controls.Add(this.button22);
            this.segmentBox.Controls.Add(this.button16);
            this.segmentBox.Controls.Add(this.button21);
            this.segmentBox.Controls.Add(this.button12);
            this.segmentBox.Controls.Add(this.button19);
            this.segmentBox.Controls.Add(this.button20);
            this.segmentBox.Location = new System.Drawing.Point(16, 229);
            this.segmentBox.Name = "segmentBox";
            this.segmentBox.Size = new System.Drawing.Size(407, 211);
            this.segmentBox.TabIndex = 44;
            this.segmentBox.TabStop = false;
            this.segmentBox.Text = "Input by segment:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 962);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.stepperButton);
            this.Controls.Add(this.mmButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.returnOriginButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GeneralGroup);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.originButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Vector Accelerator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.GeneralGroup.ResumeLayout(false);
            this.GeneralGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.manualBox.ResumeLayout(false);
            this.manualBox.PerformLayout();
            this.segmentBox.ResumeLayout(false);
            this.segmentBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBox1;
        private Label label2;
        private Label label6;
        private Label label7;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.ComponentModel.BackgroundWorker GClibBackgroundWorker1;
        private ToolStrip MainToolStrip;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton ConnectStripButton;
        private ToolStripTextBox AddressTextBox;
        private ToolStripButton DisconnectStripButton;
        private GroupBox GeneralGroup;
        private Button button5;
        private Label label4;
        private Button button6;
        private Button button3;
        private Label label3;
        private Button button4;
        private Button button2;
        private Label label1;
        private Button button1;
        private TextBox unitbox;
        private Label label5;
        private Button originButton;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private TextBox textBox3;
        private Label label8;
        private GroupBox groupBox1;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label9;
        private Label label10;
        private Button button11;
        private PictureBox pictureBox1;
        private TextBox textBox6;
        private Label label11;
        private Label label12;
        private Button returnOriginButton;
        private Button button14;
        private Button button15;
        private Button button13;
        private RichTextBox richTextBox1;
        private RadioButton mmButton;
        private RadioButton stepperButton;
        private Label label13;
        private Label label15;
        private Label label14;
        private RadioButton segmentButton;
        private RadioButton manualButton;
        private Label label18;
        private TextBox textBox7;
        private Button button12;
        private Button button16;
        private Button button17;
        private Button button18;
        private Label label19;
        private Button button22;
        private Button button21;
        private Button button19;
        private Button button20;
        private Label label20;
        private Label label21;
        private TextBox textBox8;
        private GroupBox segmentBox;
        private GroupBox manualBox;
    }
}

