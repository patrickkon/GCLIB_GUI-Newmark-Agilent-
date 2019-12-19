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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.translatorTabPage = new System.Windows.Forms.TabPage();
            this.manualBox = new System.Windows.Forms.GroupBox();
            this.axisCinputBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.segmentBox = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.PNAtabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelPNA = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownAvg = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStop = new System.Windows.Forms.NumericUpDown();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelStop = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.labelMeasure = new System.Windows.Forms.Label();
            this.comboBoxMeasure = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.numericUpDownPoints = new System.Windows.Forms.NumericUpDown();
            this.SelectCST = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.numericUpDownIFBW = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.manualButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.segmentButton = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.returnOriginButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.mmButton = new System.Windows.Forms.RadioButton();
            this.stepperButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.configBox = new System.Windows.Forms.GroupBox();
            this.button25 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.MainToolStrip.SuspendLayout();
            this.GeneralGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.translatorTabPage.SuspendLayout();
            this.manualBox.SuspendLayout();
            this.axisCinputBox.SuspendLayout();
            this.segmentBox.SuspendLayout();
            this.PNAtabPage.SuspendLayout();
            this.tableLayoutPanelPNA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAvg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIFBW)).BeginInit();
            this.configBox.SuspendLayout();
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
            this.label6.Location = new System.Drawing.Point(321, 284);
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
            this.textBox2.Size = new System.Drawing.Size(290, 731);
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
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripLabel1,
            this.DisconnectStripButton,
            this.ConnectStripButton,
            this.AddressTextBox});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(1118, 32);
            this.MainToolStrip.TabIndex = 15;
            this.MainToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(159, 29);
            this.toolStripButton1.Text = "Save PNA Data";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(159, 29);
            this.toolStripButton2.Text = "Clear PNA data";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 38);
            this.button3.TabIndex = 16;
            this.button3.Text = "- (b-axis)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
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
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 38);
            this.button2.TabIndex = 13;
            this.button2.Text = "- (a-axis)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
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
            this.originButton.Location = new System.Drawing.Point(1266, 4);
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
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.manualButton);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.segmentButton);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Location = new System.Drawing.Point(319, 316);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 680);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anchor coordinates";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.translatorTabPage);
            this.tabControl1.Controls.Add(this.PNAtabPage);
            this.tabControl1.Location = new System.Drawing.Point(24, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 549);
            this.tabControl1.TabIndex = 44;
            // 
            // translatorTabPage
            // 
            this.translatorTabPage.Controls.Add(this.manualBox);
            this.translatorTabPage.Controls.Add(this.axisCinputBox);
            this.translatorTabPage.Controls.Add(this.segmentBox);
            this.translatorTabPage.Controls.Add(this.label14);
            this.translatorTabPage.Controls.Add(this.label15);
            this.translatorTabPage.Controls.Add(this.label19);
            this.translatorTabPage.Location = new System.Drawing.Point(4, 29);
            this.translatorTabPage.Name = "translatorTabPage";
            this.translatorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.translatorTabPage.Size = new System.Drawing.Size(430, 516);
            this.translatorTabPage.TabIndex = 0;
            this.translatorTabPage.Text = "Translator";
            this.translatorTabPage.UseVisualStyleBackColor = true;
            // 
            // manualBox
            // 
            this.manualBox.Controls.Add(this.button9);
            this.manualBox.Controls.Add(this.button10);
            this.manualBox.Controls.Add(this.button8);
            this.manualBox.Controls.Add(this.textBox3);
            this.manualBox.Controls.Add(this.button7);
            this.manualBox.Controls.Add(this.label8);
            this.manualBox.Location = new System.Drawing.Point(9, 12);
            this.manualBox.Name = "manualBox";
            this.manualBox.Size = new System.Drawing.Size(407, 149);
            this.manualBox.TabIndex = 43;
            this.manualBox.TabStop = false;
            this.manualBox.Text = "Manual Input:";
            // 
            // axisCinputBox
            // 
            this.axisCinputBox.Controls.Add(this.label10);
            this.axisCinputBox.Controls.Add(this.textBox5);
            this.axisCinputBox.Controls.Add(this.button11);
            this.axisCinputBox.Controls.Add(this.button15);
            this.axisCinputBox.Location = new System.Drawing.Point(3, 178);
            this.axisCinputBox.Name = "axisCinputBox";
            this.axisCinputBox.Size = new System.Drawing.Size(399, 110);
            this.axisCinputBox.TabIndex = 51;
            this.axisCinputBox.TabStop = false;
            this.axisCinputBox.Text = "Axis-c input:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(259, 20);
            this.label10.TabIndex = 30;
            this.label10.Text = "Other parameter input (format: \"Z\"):";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(274, 24);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 26);
            this.textBox5.TabIndex = 27;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(9, 58);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(164, 48);
            this.button11.TabIndex = 28;
            this.button11.Text = "Axis-c drop bar by (relative):";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(194, 58);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(195, 50);
            this.button15.TabIndex = 31;
            this.button15.Text = "Set Axis-c resting position:";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
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
            this.segmentBox.Location = new System.Drawing.Point(0, 297);
            this.segmentBox.Name = "segmentBox";
            this.segmentBox.Size = new System.Drawing.Size(407, 211);
            this.segmentBox.TabIndex = 44;
            this.segmentBox.TabStop = false;
            this.segmentBox.Text = "Input by segment:";
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
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(9, 173);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(390, 2);
            this.label14.TabIndex = 35;
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(9, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(390, 2);
            this.label15.TabIndex = 36;
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(9, 291);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(390, 2);
            this.label19.TabIndex = 49;
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // PNAtabPage
            // 
            this.PNAtabPage.Controls.Add(this.tableLayoutPanelPNA);
            this.PNAtabPage.Location = new System.Drawing.Point(4, 29);
            this.PNAtabPage.Name = "PNAtabPage";
            this.PNAtabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PNAtabPage.Size = new System.Drawing.Size(430, 516);
            this.PNAtabPage.TabIndex = 1;
            this.PNAtabPage.Text = "PNA";
            this.PNAtabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelPNA
            // 
            this.tableLayoutPanelPNA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPNA.AutoSize = true;
            this.tableLayoutPanelPNA.ColumnCount = 2;
            this.tableLayoutPanelPNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.6396F));
            this.tableLayoutPanelPNA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.3604F));
            this.tableLayoutPanelPNA.Controls.Add(this.numericUpDownAvg, 1, 8);
            this.tableLayoutPanelPNA.Controls.Add(this.numericUpDownStop, 1, 1);
            this.tableLayoutPanelPNA.Controls.Add(this.labelStart, 0, 0);
            this.tableLayoutPanelPNA.Controls.Add(this.labelStop, 0, 1);
            this.tableLayoutPanelPNA.Controls.Add(this.labelPoints, 0, 2);
            this.tableLayoutPanelPNA.Controls.Add(this.numericUpDownStart, 1, 0);
            this.tableLayoutPanelPNA.Controls.Add(this.labelMeasure, 0, 4);
            this.tableLayoutPanelPNA.Controls.Add(this.comboBoxMeasure, 1, 4);
            this.tableLayoutPanelPNA.Controls.Add(this.label16, 0, 5);
            this.tableLayoutPanelPNA.Controls.Add(this.comboBoxFormat, 1, 5);
            this.tableLayoutPanelPNA.Controls.Add(this.numericUpDownPoints, 1, 2);
            this.tableLayoutPanelPNA.Controls.Add(this.SelectCST, 1, 6);
            this.tableLayoutPanelPNA.Controls.Add(this.label17, 0, 6);
            this.tableLayoutPanelPNA.Controls.Add(this.label22, 0, 9);
            this.tableLayoutPanelPNA.Controls.Add(this.numericUpDownIFBW, 1, 9);
            this.tableLayoutPanelPNA.Controls.Add(this.label23, 0, 8);
            this.tableLayoutPanelPNA.Location = new System.Drawing.Point(23, 22);
            this.tableLayoutPanelPNA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanelPNA.Name = "tableLayoutPanelPNA";
            this.tableLayoutPanelPNA.RowCount = 11;
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelPNA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelPNA.Size = new System.Drawing.Size(357, 388);
            this.tableLayoutPanelPNA.TabIndex = 51;
            // 
            // numericUpDownAvg
            // 
            this.numericUpDownAvg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownAvg.Location = new System.Drawing.Point(156, 282);
            this.numericUpDownAvg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownAvg.Name = "numericUpDownAvg";
            this.numericUpDownAvg.Size = new System.Drawing.Size(197, 26);
            this.numericUpDownAvg.TabIndex = 15;
            this.numericUpDownAvg.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownStop
            // 
            this.numericUpDownStop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownStop.DecimalPlaces = 3;
            this.numericUpDownStop.Location = new System.Drawing.Point(156, 41);
            this.numericUpDownStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownStop.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownStop.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownStop.Name = "numericUpDownStop";
            this.numericUpDownStop.Size = new System.Drawing.Size(197, 26);
            this.numericUpDownStop.TabIndex = 11;
            this.numericUpDownStop.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            // 
            // labelStart
            // 
            this.labelStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(53, 0);
            this.labelStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(95, 36);
            this.labelStart.TabIndex = 0;
            this.labelStart.Text = "Start (MHz):";
            this.labelStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelStop
            // 
            this.labelStop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStop.AutoSize = true;
            this.labelStop.Location = new System.Drawing.Point(54, 36);
            this.labelStop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStop.Name = "labelStop";
            this.labelStop.Size = new System.Drawing.Size(94, 36);
            this.labelStop.TabIndex = 1;
            this.labelStop.Text = "Stop (MHz):";
            this.labelStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPoints
            // 
            this.labelPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(91, 72);
            this.labelPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(57, 36);
            this.labelPoints.TabIndex = 2;
            this.labelPoints.Text = "Points:";
            this.labelPoints.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownStart.DecimalPlaces = 3;
            this.numericUpDownStart.Location = new System.Drawing.Point(156, 5);
            this.numericUpDownStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownStart.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownStart.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(197, 26);
            this.numericUpDownStart.TabIndex = 10;
            this.numericUpDownStart.Value = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            // 
            // labelMeasure
            // 
            this.labelMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMeasure.AutoSize = true;
            this.labelMeasure.Location = new System.Drawing.Point(73, 139);
            this.labelMeasure.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMeasure.Name = "labelMeasure";
            this.labelMeasure.Size = new System.Drawing.Size(75, 38);
            this.labelMeasure.TabIndex = 6;
            this.labelMeasure.Text = "Measure:";
            this.labelMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxMeasure
            // 
            this.comboBoxMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMeasure.FormattingEnabled = true;
            this.comboBoxMeasure.Location = new System.Drawing.Point(156, 144);
            this.comboBoxMeasure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxMeasure.Name = "comboBoxMeasure";
            this.comboBoxMeasure.Size = new System.Drawing.Size(197, 28);
            this.comboBoxMeasure.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(84, 177);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 38);
            this.label16.TabIndex = 8;
            this.label16.Text = "Format:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Location = new System.Drawing.Point(156, 182);
            this.comboBoxFormat.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(197, 28);
            this.comboBoxFormat.TabIndex = 14;
            // 
            // numericUpDownPoints
            // 
            this.numericUpDownPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownPoints.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownPoints.Location = new System.Drawing.Point(156, 77);
            this.numericUpDownPoints.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownPoints.Maximum = new decimal(new int[] {
            16001,
            0,
            0,
            0});
            this.numericUpDownPoints.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPoints.Name = "numericUpDownPoints";
            this.numericUpDownPoints.Size = new System.Drawing.Size(197, 26);
            this.numericUpDownPoints.TabIndex = 12;
            this.numericUpDownPoints.Value = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.numericUpDownPoints.ValueChanged += new System.EventHandler(this.numericUpDownPoints_ValueChanged);
            // 
            // SelectCST
            // 
            this.SelectCST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectCST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectCST.Location = new System.Drawing.Point(156, 220);
            this.SelectCST.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectCST.Name = "SelectCST";
            this.SelectCST.Size = new System.Drawing.Size(197, 35);
            this.SelectCST.TabIndex = 17;
            this.SelectCST.Text = "None (NOT working)";
            this.SelectCST.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Location = new System.Drawing.Point(55, 215);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(93, 45);
            this.label17.TabIndex = 18;
            this.label17.Text = "Cal. Set:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Location = new System.Drawing.Point(50, 326);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(98, 31);
            this.label22.TabIndex = 20;
            this.label22.Text = "IFBW (Hz):";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDownIFBW
            // 
            this.numericUpDownIFBW.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownIFBW.Location = new System.Drawing.Point(156, 331);
            this.numericUpDownIFBW.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownIFBW.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownIFBW.Name = "numericUpDownIFBW";
            this.numericUpDownIFBW.Size = new System.Drawing.Size(197, 26);
            this.numericUpDownIFBW.TabIndex = 19;
            this.numericUpDownIFBW.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.Location = new System.Drawing.Point(50, 277);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 49);
            this.label23.TabIndex = 16;
            this.label23.Text = "Avg. Factor:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(115, 606);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(221, 57);
            this.button13.TabIndex = 32;
            this.button13.Text = "Start special movement";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // manualButton
            // 
            this.manualButton.AutoSize = true;
            this.manualButton.Location = new System.Drawing.Point(87, 25);
            this.manualButton.Name = "manualButton";
            this.manualButton.Size = new System.Drawing.Size(125, 24);
            this.manualButton.TabIndex = 33;
            this.manualButton.TabStop = true;
            this.manualButton.Text = "Manual input";
            this.manualButton.UseVisualStyleBackColor = true;
            this.manualButton.CheckedChanged += new System.EventHandler(this.manualButton_CheckedChanged);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(524, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(2, 560);
            this.label9.TabIndex = 25;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(555, 23);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(422, 562);
            this.textBox4.TabIndex = 25;
            this.textBox4.Text = "Click on button once input has been added. Allows multi intermediate points. This" +
    " textbox displays our parameter values";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // segmentButton
            // 
            this.segmentButton.AutoSize = true;
            this.segmentButton.Location = new System.Drawing.Point(232, 25);
            this.segmentButton.Name = "segmentButton";
            this.segmentButton.Size = new System.Drawing.Size(138, 24);
            this.segmentButton.TabIndex = 34;
            this.segmentButton.Text = "Segment input";
            this.segmentButton.UseVisualStyleBackColor = true;
            this.segmentButton.CheckedChanged += new System.EventHandler(this.segmentButton_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 20);
            this.label20.TabIndex = 50;
            this.label20.Text = "Mode:";
            // 
            // returnOriginButton
            // 
            this.returnOriginButton.Location = new System.Drawing.Point(1396, 4);
            this.returnOriginButton.Name = "returnOriginButton";
            this.returnOriginButton.Size = new System.Drawing.Size(134, 34);
            this.returnOriginButton.TabIndex = 29;
            this.returnOriginButton.Text = "Return to Origin";
            this.returnOriginButton.UseVisualStyleBackColor = true;
            this.returnOriginButton.Click += new System.EventHandler(this.returnOriginButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1350, 316);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(450, 270);
            this.richTextBox1.TabIndex = 32;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // mmButton
            // 
            this.mmButton.AutoSize = true;
            this.mmButton.Location = new System.Drawing.Point(25, 56);
            this.mmButton.Name = "mmButton";
            this.mmButton.Size = new System.Drawing.Size(60, 24);
            this.mmButton.TabIndex = 33;
            this.mmButton.TabStop = true;
            this.mmButton.Text = "Mm";
            this.mmButton.UseVisualStyleBackColor = true;
            this.mmButton.CheckedChanged += new System.EventHandler(this.mmButton_CheckedChanged);
            // 
            // stepperButton
            // 
            this.stepperButton.AutoSize = true;
            this.stepperButton.Location = new System.Drawing.Point(25, 87);
            this.stepperButton.Name = "stepperButton";
            this.stepperButton.Size = new System.Drawing.Size(132, 24);
            this.stepperButton.TabIndex = 34;
            this.stepperButton.TabStop = true;
            this.stepperButton.Text = "Stepper Units";
            this.stepperButton.UseVisualStyleBackColor = true;
            this.stepperButton.CheckedChanged += new System.EventHandler(this.stepperButton_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Unit of Choice:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(21, 132);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 20);
            this.label21.TabIndex = 42;
            this.label21.Text = "Slew Speed:";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(125, 129);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(139, 26);
            this.textBox8.TabIndex = 41;
            // 
            // configBox
            // 
            this.configBox.Controls.Add(this.button25);
            this.configBox.Controls.Add(this.button24);
            this.configBox.Controls.Add(this.button23);
            this.configBox.Controls.Add(this.label13);
            this.configBox.Controls.Add(this.label21);
            this.configBox.Controls.Add(this.mmButton);
            this.configBox.Controls.Add(this.textBox8);
            this.configBox.Controls.Add(this.stepperButton);
            this.configBox.Location = new System.Drawing.Point(1134, 58);
            this.configBox.Name = "configBox";
            this.configBox.Size = new System.Drawing.Size(420, 223);
            this.configBox.TabIndex = 43;
            this.configBox.TabStop = false;
            this.configBox.Text = "Start-up Config";
            this.configBox.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(216, 161);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(75, 29);
            this.button25.TabIndex = 45;
            this.button25.Text = "axis-c";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(125, 161);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(75, 29);
            this.button24.TabIndex = 44;
            this.button24.Text = "axis-b";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(37, 161);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(75, 29);
            this.button23.TabIndex = 43;
            this.button23.Text = "axis-a";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "dat";
            this.saveFileDialog.Filter = "Measurement files|*.dat|All files|*.*";
            this.saveFileDialog.Title = "Save";
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(1608, 1003);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(192, 26);
            this.textBox6.TabIndex = 44;
            this.textBox6.Text = "Made by Patrick Kon 2019";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1837, 1050);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.configBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.returnOriginButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GeneralGroup);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.originButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Surface Scan 2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.GeneralGroup.ResumeLayout(false);
            this.GeneralGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.translatorTabPage.ResumeLayout(false);
            this.manualBox.ResumeLayout(false);
            this.manualBox.PerformLayout();
            this.axisCinputBox.ResumeLayout(false);
            this.axisCinputBox.PerformLayout();
            this.segmentBox.ResumeLayout(false);
            this.segmentBox.PerformLayout();
            this.PNAtabPage.ResumeLayout(false);
            this.PNAtabPage.PerformLayout();
            this.tableLayoutPanelPNA.ResumeLayout(false);
            this.tableLayoutPanelPNA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAvg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIFBW)).EndInit();
            this.configBox.ResumeLayout(false);
            this.configBox.PerformLayout();
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
        private Button returnOriginButton;
        //private Button button14;
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
        private GroupBox configBox;
        private GroupBox axisCinputBox;
        private Button button25;
        private Button button24;
        private Button button23;
        private ToolStripButton toolStripButton1;
        private TabControl tabControl1;
        private TabPage translatorTabPage;
        private TabPage PNAtabPage;
        private TableLayoutPanel tableLayoutPanelPNA;
        private NumericUpDown numericUpDownAvg;
        private NumericUpDown numericUpDownStop;
        private Label labelStart;
        private Label labelStop;
        private Label labelPoints;
        private NumericUpDown numericUpDownStart;
        private Label labelMeasure;
        private ComboBox comboBoxMeasure;
        private Label label16;
        private ComboBox comboBoxFormat;
        private NumericUpDown numericUpDownPoints;
        private Button SelectCST;
        private Label label17;
        private Label label22;
        private NumericUpDown numericUpDownIFBW;
        private Label label23;
        private SaveFileDialog saveFileDialog;
        private ToolStripButton toolStripButton2;
        private TextBox textBox6;
    }
}

