namespace WinScheduler2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RecurringCheckBox = new System.Windows.Forms.CheckBox();
            this.OnceCheckBox = new System.Windows.Forms.CheckBox();
            this.WeeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.DailyRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.OnceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SundayBox = new System.Windows.Forms.CheckBox();
            this.SaturdayBox = new System.Windows.Forms.CheckBox();
            this.FridayBox = new System.Windows.Forms.CheckBox();
            this.ThursdayBox = new System.Windows.Forms.CheckBox();
            this.WednesdayBox = new System.Windows.Forms.CheckBox();
            this.TuesdayBox = new System.Windows.Forms.CheckBox();
            this.MondayBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.WeeksUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DailyEvery = new System.Windows.Forms.CheckBox();
            this.DailyOnce = new System.Windows.Forms.CheckBox();
            this.EveryPeriod = new System.Windows.Forms.DomainUpDown();
            this.EveryUpDown = new System.Windows.Forms.NumericUpDown();
            this.OnceTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EndDate = new System.Windows.Forms.TextBox();
            this.StartDate = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.DayPeriod = new System.Windows.Forms.NumericUpDown();
            this.DayPeriodType = new System.Windows.Forms.DomainUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeeksUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EveryUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DayPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.NextButton);
            this.groupBox1.Controls.Add(this.InputBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 67);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // NextButton
            // 
            this.NextButton.Enabled = false;
            this.NextButton.Location = new System.Drawing.Point(532, 26);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(190, 25);
            this.NextButton.TabIndex = 2;
            this.NextButton.Text = "Calculate next date";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(164, 26);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(269, 23);
            this.InputBox.TabIndex = 1;
            this.InputBox.TextChanged += new System.EventHandler(this.InputBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current date";
            // 
            // OutputBox
            // 
            this.OutputBox.Enabled = false;
            this.OutputBox.Location = new System.Drawing.Point(198, 38);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(470, 23);
            this.OutputBox.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RecurringCheckBox);
            this.groupBox2.Controls.Add(this.OnceCheckBox);
            this.groupBox2.Controls.Add(this.WeeklyRadioButton);
            this.groupBox2.Controls.Add(this.DailyRadioButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.OnceTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(21, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 99);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // RecurringCheckBox
            // 
            this.RecurringCheckBox.AutoSize = true;
            this.RecurringCheckBox.Location = new System.Drawing.Point(74, 66);
            this.RecurringCheckBox.Name = "RecurringCheckBox";
            this.RecurringCheckBox.Size = new System.Drawing.Size(77, 19);
            this.RecurringCheckBox.TabIndex = 9;
            this.RecurringCheckBox.Text = "Recurring";
            this.RecurringCheckBox.UseVisualStyleBackColor = true;
            this.RecurringCheckBox.CheckedChanged += new System.EventHandler(this.RecurringCheckBox_CheckedChanged);
            // 
            // OnceCheckBox
            // 
            this.OnceCheckBox.AutoSize = true;
            this.OnceCheckBox.Location = new System.Drawing.Point(74, 31);
            this.OnceCheckBox.Name = "OnceCheckBox";
            this.OnceCheckBox.Size = new System.Drawing.Size(54, 19);
            this.OnceCheckBox.TabIndex = 8;
            this.OnceCheckBox.Text = "Once";
            this.OnceCheckBox.UseVisualStyleBackColor = true;
            this.OnceCheckBox.CheckedChanged += new System.EventHandler(this.OnceCheckBox_CheckedChanged);
            // 
            // WeeklyRadioButton
            // 
            this.WeeklyRadioButton.AutoSize = true;
            this.WeeklyRadioButton.Enabled = false;
            this.WeeklyRadioButton.Location = new System.Drawing.Point(532, 64);
            this.WeeklyRadioButton.Name = "WeeklyRadioButton";
            this.WeeklyRadioButton.Size = new System.Drawing.Size(63, 19);
            this.WeeklyRadioButton.TabIndex = 7;
            this.WeeklyRadioButton.Text = "Weekly";
            this.WeeklyRadioButton.UseVisualStyleBackColor = true;
            this.WeeklyRadioButton.CheckedChanged += new System.EventHandler(this.WeeklyRadioButton_CheckedChanged);
            // 
            // DailyRadioButton
            // 
            this.DailyRadioButton.AutoSize = true;
            this.DailyRadioButton.Enabled = false;
            this.DailyRadioButton.Location = new System.Drawing.Point(382, 62);
            this.DailyRadioButton.Name = "DailyRadioButton";
            this.DailyRadioButton.Size = new System.Drawing.Size(51, 19);
            this.DailyRadioButton.TabIndex = 6;
            this.DailyRadioButton.Text = "Daily";
            this.DailyRadioButton.UseVisualStyleBackColor = true;
            this.DailyRadioButton.CheckedChanged += new System.EventHandler(this.DailyRadioButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Occurs";
            // 
            // OnceTextBox
            // 
            this.OnceTextBox.Enabled = false;
            this.OnceTextBox.Location = new System.Drawing.Point(356, 27);
            this.OnceTextBox.Name = "OnceTextBox";
            this.OnceTextBox.Size = new System.Drawing.Size(348, 23);
            this.OnceTextBox.TabIndex = 4;
            this.OnceTextBox.TextChanged += new System.EventHandler(this.OnceTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Once time at";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.OutputBox);
            this.groupBox3.Location = new System.Drawing.Point(21, 554);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 81);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Next execution time";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SundayBox);
            this.groupBox4.Controls.Add(this.SaturdayBox);
            this.groupBox4.Controls.Add(this.FridayBox);
            this.groupBox4.Controls.Add(this.ThursdayBox);
            this.groupBox4.Controls.Add(this.WednesdayBox);
            this.groupBox4.Controls.Add(this.TuesdayBox);
            this.groupBox4.Controls.Add(this.MondayBox);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.WeeksUpDown);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(21, 188);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(767, 97);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Weekly Configuration";
            // 
            // SundayBox
            // 
            this.SundayBox.AutoSize = true;
            this.SundayBox.Enabled = false;
            this.SundayBox.Location = new System.Drawing.Point(639, 72);
            this.SundayBox.Name = "SundayBox";
            this.SundayBox.Size = new System.Drawing.Size(65, 19);
            this.SundayBox.TabIndex = 9;
            this.SundayBox.Text = "Sunday";
            this.SundayBox.UseVisualStyleBackColor = true;
            this.SundayBox.CheckedChanged += new System.EventHandler(this.SundayBox_CheckedChanged);
            // 
            // SaturdayBox
            // 
            this.SaturdayBox.AutoSize = true;
            this.SaturdayBox.Enabled = false;
            this.SaturdayBox.Location = new System.Drawing.Point(532, 72);
            this.SaturdayBox.Name = "SaturdayBox";
            this.SaturdayBox.Size = new System.Drawing.Size(72, 19);
            this.SaturdayBox.TabIndex = 8;
            this.SaturdayBox.Text = "Saturday";
            this.SaturdayBox.UseVisualStyleBackColor = true;
            this.SaturdayBox.CheckedChanged += new System.EventHandler(this.SaturdayBox_CheckedChanged);
            // 
            // FridayBox
            // 
            this.FridayBox.AutoSize = true;
            this.FridayBox.Enabled = false;
            this.FridayBox.Location = new System.Drawing.Point(435, 72);
            this.FridayBox.Name = "FridayBox";
            this.FridayBox.Size = new System.Drawing.Size(58, 19);
            this.FridayBox.TabIndex = 7;
            this.FridayBox.Text = "Friday";
            this.FridayBox.UseVisualStyleBackColor = true;
            this.FridayBox.CheckedChanged += new System.EventHandler(this.FridayBox_CheckedChanged);
            // 
            // ThursdayBox
            // 
            this.ThursdayBox.AutoSize = true;
            this.ThursdayBox.Enabled = false;
            this.ThursdayBox.Location = new System.Drawing.Point(332, 72);
            this.ThursdayBox.Name = "ThursdayBox";
            this.ThursdayBox.Size = new System.Drawing.Size(74, 19);
            this.ThursdayBox.TabIndex = 6;
            this.ThursdayBox.Text = "Thursday";
            this.ThursdayBox.UseVisualStyleBackColor = true;
            this.ThursdayBox.CheckedChanged += new System.EventHandler(this.ThursdayBox_CheckedChanged);
            // 
            // WednesdayBox
            // 
            this.WednesdayBox.AutoSize = true;
            this.WednesdayBox.Enabled = false;
            this.WednesdayBox.Location = new System.Drawing.Point(216, 72);
            this.WednesdayBox.Name = "WednesdayBox";
            this.WednesdayBox.Size = new System.Drawing.Size(87, 19);
            this.WednesdayBox.TabIndex = 5;
            this.WednesdayBox.Text = "Wednesday";
            this.WednesdayBox.UseVisualStyleBackColor = true;
            this.WednesdayBox.CheckedChanged += new System.EventHandler(this.WednesdayBox_CheckedChanged);
            // 
            // TuesdayBox
            // 
            this.TuesdayBox.AutoSize = true;
            this.TuesdayBox.Enabled = false;
            this.TuesdayBox.Location = new System.Drawing.Point(117, 72);
            this.TuesdayBox.Name = "TuesdayBox";
            this.TuesdayBox.Size = new System.Drawing.Size(69, 19);
            this.TuesdayBox.TabIndex = 4;
            this.TuesdayBox.Text = "Tuesday";
            this.TuesdayBox.UseVisualStyleBackColor = true;
            this.TuesdayBox.CheckedChanged += new System.EventHandler(this.TuesdayBox_CheckedChanged);
            // 
            // MondayBox
            // 
            this.MondayBox.AutoSize = true;
            this.MondayBox.Enabled = false;
            this.MondayBox.Location = new System.Drawing.Point(18, 72);
            this.MondayBox.Name = "MondayBox";
            this.MondayBox.Size = new System.Drawing.Size(70, 19);
            this.MondayBox.TabIndex = 3;
            this.MondayBox.Text = "Monday";
            this.MondayBox.UseVisualStyleBackColor = true;
            this.MondayBox.CheckedChanged += new System.EventHandler(this.MondayBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "week (s)";
            // 
            // WeeksUpDown
            // 
            this.WeeksUpDown.Enabled = false;
            this.WeeksUpDown.Location = new System.Drawing.Point(74, 32);
            this.WeeksUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WeeksUpDown.Name = "WeeksUpDown";
            this.WeeksUpDown.Size = new System.Drawing.Size(164, 23);
            this.WeeksUpDown.TabIndex = 1;
            this.WeeksUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WeeksUpDown.ValueChanged += new System.EventHandler(this.WeeksUpDown_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Every";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.EndTimePicker);
            this.groupBox5.Controls.Add(this.StartTimePicker);
            this.groupBox5.Controls.Add(this.DailyEvery);
            this.groupBox5.Controls.Add(this.DailyOnce);
            this.groupBox5.Controls.Add(this.EveryPeriod);
            this.groupBox5.Controls.Add(this.EveryUpDown);
            this.groupBox5.Controls.Add(this.OnceTimePicker);
            this.groupBox5.Location = new System.Drawing.Point(21, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(767, 134);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Daily Frequency";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(247, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "End at";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Starting at";
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Enabled = false;
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.EndTimePicker.Location = new System.Drawing.Point(300, 95);
            this.EndTimePicker.MaxDate = new System.DateTime(1753, 1, 1, 23, 59, 0, 0);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowUpDown = true;
            this.EndTimePicker.Size = new System.Drawing.Size(106, 23);
            this.EndTimePicker.TabIndex = 8;
            this.EndTimePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.EndTimePicker.ValueChanged += new System.EventHandler(this.EndTimePicker_ValueChanged);
            // 
            // StartTimePicker
            // 
            this.StartTimePicker.Enabled = false;
            this.StartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.StartTimePicker.Location = new System.Drawing.Point(90, 95);
            this.StartTimePicker.MaxDate = new System.DateTime(1753, 1, 1, 23, 59, 0, 0);
            this.StartTimePicker.Name = "StartTimePicker";
            this.StartTimePicker.ShowUpDown = true;
            this.StartTimePicker.Size = new System.Drawing.Size(114, 23);
            this.StartTimePicker.TabIndex = 7;
            this.StartTimePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.StartTimePicker.ValueChanged += new System.EventHandler(this.StartTimePicker_ValueChanged);
            // 
            // DailyEvery
            // 
            this.DailyEvery.AutoSize = true;
            this.DailyEvery.Location = new System.Drawing.Point(18, 61);
            this.DailyEvery.Name = "DailyEvery";
            this.DailyEvery.Size = new System.Drawing.Size(88, 19);
            this.DailyEvery.TabIndex = 6;
            this.DailyEvery.Text = "Ocurs every";
            this.DailyEvery.UseVisualStyleBackColor = true;
            this.DailyEvery.CheckedChanged += new System.EventHandler(this.DailyEvery_CheckedChanged);
            // 
            // DailyOnce
            // 
            this.DailyOnce.AutoSize = true;
            this.DailyOnce.Location = new System.Drawing.Point(19, 30);
            this.DailyOnce.Name = "DailyOnce";
            this.DailyOnce.Size = new System.Drawing.Size(99, 19);
            this.DailyOnce.TabIndex = 5;
            this.DailyOnce.Text = "Ocurs once at";
            this.DailyOnce.UseVisualStyleBackColor = true;
            this.DailyOnce.CheckedChanged += new System.EventHandler(this.DailyOnce_CheckedChanged);
            // 
            // EveryPeriod
            // 
            this.EveryPeriod.Enabled = false;
            this.EveryPeriod.Items.Add("Hours");
            this.EveryPeriod.Items.Add("Minutes");
            this.EveryPeriod.Items.Add("Seconds");
            this.EveryPeriod.Location = new System.Drawing.Point(393, 57);
            this.EveryPeriod.Name = "EveryPeriod";
            this.EveryPeriod.ReadOnly = true;
            this.EveryPeriod.Size = new System.Drawing.Size(159, 23);
            this.EveryPeriod.TabIndex = 4;
            this.EveryPeriod.Text = "Hours";
            this.EveryPeriod.SelectedItemChanged += new System.EventHandler(this.EveryPeriod_ItemChanged);
            // 
            // EveryUpDown
            // 
            this.EveryUpDown.Enabled = false;
            this.EveryUpDown.Location = new System.Drawing.Point(233, 57);
            this.EveryUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.EveryUpDown.Name = "EveryUpDown";
            this.EveryUpDown.Size = new System.Drawing.Size(102, 23);
            this.EveryUpDown.TabIndex = 3;
            this.EveryUpDown.ValueChanged += new System.EventHandler(this.EveryUpDown_ValueChanged);
            // 
            // OnceTimePicker
            // 
            this.OnceTimePicker.Enabled = false;
            this.OnceTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.OnceTimePicker.Location = new System.Drawing.Point(233, 24);
            this.OnceTimePicker.MaxDate = new System.DateTime(1753, 1, 1, 23, 59, 59, 0);
            this.OnceTimePicker.Name = "OnceTimePicker";
            this.OnceTimePicker.ShowUpDown = true;
            this.OnceTimePicker.Size = new System.Drawing.Size(200, 23);
            this.OnceTimePicker.TabIndex = 2;
            this.OnceTimePicker.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.OnceTimePicker.ValueChanged += new System.EventHandler(this.OnceTimePickler_ValueChanged);
            this.OnceTimePicker.EnabledChanged += new System.EventHandler(this.OnceTimePicker_EnabledChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.EndDate);
            this.groupBox6.Controls.Add(this.StartDate);
            this.groupBox6.Location = new System.Drawing.Point(21, 487);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(767, 61);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Limits";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(403, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "End date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "Start date";
            // 
            // EndDate
            // 
            this.EndDate.Enabled = false;
            this.EndDate.Location = new System.Drawing.Point(512, 22);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(249, 23);
            this.EndDate.TabIndex = 1;
            this.EndDate.TextChanged += new System.EventHandler(this.EndDate_TextChanged);
            // 
            // StartDate
            // 
            this.StartDate.Enabled = false;
            this.StartDate.Location = new System.Drawing.Point(106, 22);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(219, 23);
            this.StartDate.TabIndex = 0;
            this.StartDate.TextChanged += new System.EventHandler(this.StartDate_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.DayPeriod);
            this.groupBox7.Controls.Add(this.DayPeriodType);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Location = new System.Drawing.Point(21, 429);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(767, 57);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "PeriodConfiguration";

            // 
            // DayPeriod
            // 
            this.DayPeriod.Enabled = false;
            this.DayPeriod.Location = new System.Drawing.Point(115, 27);
            this.DayPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DayPeriod.Name = "DayPeriod";
            this.DayPeriod.Size = new System.Drawing.Size(143, 23);
            this.DayPeriod.TabIndex = 2;
            this.DayPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DayPeriod.ValueChanged += new System.EventHandler(this.DayPeriod_ValueChanged);
            // 
            // DayPeriodType
            // 
            this.DayPeriodType.Enabled = false;
            this.DayPeriodType.Items.Add("Days");
            this.DayPeriodType.Items.Add("Weeks");
            this.DayPeriodType.Items.Add("Months");
            this.DayPeriodType.Location = new System.Drawing.Point(300, 26);
            this.DayPeriodType.Name = "DayPeriodType";
            this.DayPeriodType.Size = new System.Drawing.Size(154, 23);
            this.DayPeriodType.TabIndex = 1;
            this.DayPeriodType.Text = "Days";
            this.DayPeriodType.SelectedItemChanged += new System.EventHandler(this.DayPeriodType_ItemChanged);
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Ocurs every";


            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 664);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeeksUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EveryUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DayPeriod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox InputBox;
        private Label label1;
        private TextBox OutputBox;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox OnceTextBox;
        private Label label3;
        private Label label2;
        private RadioButton DailyRadioButton;
        private RadioButton WeeklyRadioButton;
        private GroupBox groupBox3;
        private Label label5;
        private Button NextButton;
        private GroupBox groupBox4;
        private CheckBox SundayBox;
        private CheckBox SaturdayBox;
        private CheckBox FridayBox;
        private CheckBox ThursdayBox;
        private CheckBox WednesdayBox;
        private CheckBox TuesdayBox;
        private CheckBox MondayBox;
        private Label label7;
        private NumericUpDown WeeksUpDown;
        private Label label6;
        private GroupBox groupBox5;
        private DateTimePicker OnceTimePicker;
        private DomainUpDown EveryPeriod;
        private NumericUpDown EveryUpDown;
        private CheckBox OnceCheckBox;
        private CheckBox RecurringCheckBox;
        private CheckBox DailyEvery;
        private CheckBox DailyOnce;
        private GroupBox groupBox6;
        private Label label9;
        private Label label8;
        private TextBox EndDate;
        private TextBox StartDate;
        private Label label11;
        private Label label10;
        private DateTimePicker EndTimePicker;
        private DateTimePicker StartTimePicker;
        private GroupBox groupBox7;
        private Label label12;
        private NumericUpDown DayPeriod;
        private DomainUpDown DayPeriodType;
    }
}