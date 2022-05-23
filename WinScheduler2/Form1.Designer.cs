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
            this.WeeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.DailyRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.OnceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RecurringRadioButton = new System.Windows.Forms.RadioButton();
            this.OnceRadioButton = new System.Windows.Forms.RadioButton();
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
            this.EveryPeriod = new System.Windows.Forms.DomainUpDown();
            this.EveryUpDown = new System.Windows.Forms.NumericUpDown();
            this.OnceTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DailyEveryRadioButton = new System.Windows.Forms.RadioButton();
            this.DailyOnceRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WeeksUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EveryUpDown)).BeginInit();
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
            this.groupBox2.Controls.Add(this.WeeklyRadioButton);
            this.groupBox2.Controls.Add(this.DailyRadioButton);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.OnceTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.RecurringRadioButton);
            this.groupBox2.Controls.Add(this.OnceRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(21, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 99);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // WeeklyRadioButton
            // 
            this.WeeklyRadioButton.AutoSize = true;
            this.WeeklyRadioButton.Enabled = false;
            this.WeeklyRadioButton.Location = new System.Drawing.Point(532, 64);
            this.WeeklyRadioButton.Name = "WeeklyRadioButton";
            this.WeeklyRadioButton.Size = new System.Drawing.Size(63, 19);
            this.WeeklyRadioButton.TabIndex = 7;
            this.WeeklyRadioButton.TabStop = true;
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
            this.DailyRadioButton.TabStop = true;
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
            // RecurringRadioButton
            // 
            this.RecurringRadioButton.AutoSize = true;
            this.RecurringRadioButton.Enabled = false;
            this.RecurringRadioButton.Location = new System.Drawing.Point(74, 62);
            this.RecurringRadioButton.Name = "RecurringRadioButton";
            this.RecurringRadioButton.Size = new System.Drawing.Size(76, 19);
            this.RecurringRadioButton.TabIndex = 1;
            this.RecurringRadioButton.TabStop = true;
            this.RecurringRadioButton.Text = "Recurring";
            this.RecurringRadioButton.UseVisualStyleBackColor = true;
            this.RecurringRadioButton.CheckedChanged += new System.EventHandler(this.RecurringRadioButton_CheckedChanged);
            // 
            // OnceRadioButton
            // 
            this.OnceRadioButton.AutoSize = true;
            this.OnceRadioButton.Enabled = false;
            this.OnceRadioButton.Location = new System.Drawing.Point(74, 37);
            this.OnceRadioButton.Name = "OnceRadioButton";
            this.OnceRadioButton.Size = new System.Drawing.Size(53, 19);
            this.OnceRadioButton.TabIndex = 0;
            this.OnceRadioButton.TabStop = true;
            this.OnceRadioButton.Text = "Once";
            this.OnceRadioButton.UseVisualStyleBackColor = true;
            this.OnceRadioButton.CheckedChanged += new System.EventHandler(this.OnceRadioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.OutputBox);
            this.groupBox3.Location = new System.Drawing.Point(21, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(767, 123);
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
            this.groupBox5.Controls.Add(this.EveryPeriod);
            this.groupBox5.Controls.Add(this.EveryUpDown);
            this.groupBox5.Controls.Add(this.OnceTimePicker);
            this.groupBox5.Controls.Add(this.DailyEveryRadioButton);
            this.groupBox5.Controls.Add(this.DailyOnceRadioButton);
            this.groupBox5.Location = new System.Drawing.Point(21, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(767, 129);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Daily Frequency";
            // 
            // EveryPeriod
            // 
            this.EveryPeriod.Enabled = false;
            this.EveryPeriod.Items.Add("Hours");
            this.EveryPeriod.Items.Add("Minutes");
            this.EveryPeriod.Location = new System.Drawing.Point(393, 57);
            this.EveryPeriod.Name = "EveryPeriod";
            this.EveryPeriod.ReadOnly = true;
            this.EveryPeriod.Size = new System.Drawing.Size(159, 23);
            this.EveryPeriod.TabIndex = 4;
            this.EveryPeriod.Text = "Hours";
            // 
            // EveryUpDown
            // 
            this.EveryUpDown.Enabled = false;
            this.EveryUpDown.Location = new System.Drawing.Point(233, 57);
            this.EveryUpDown.Name = "EveryUpDown";
            this.EveryUpDown.Size = new System.Drawing.Size(102, 23);
            this.EveryUpDown.TabIndex = 3;
            // 
            // OnceTimePicker
            // 
            this.OnceTimePicker.Enabled = false;
            this.OnceTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.OnceTimePicker.Location = new System.Drawing.Point(233, 24);
            this.OnceTimePicker.Name = "OnceTimePicker";
            this.OnceTimePicker.ShowUpDown = true;
            this.OnceTimePicker.Size = new System.Drawing.Size(200, 23);
            this.OnceTimePicker.TabIndex = 2;
            this.OnceTimePicker.Value = new System.DateTime(2022, 5, 23, 0, 0, 0, 0);
            // 
            // DailyEveryRadioButton
            // 
            this.DailyEveryRadioButton.AutoSize = true;
            this.DailyEveryRadioButton.Enabled = false;
            this.DailyEveryRadioButton.Location = new System.Drawing.Point(13, 61);
            this.DailyEveryRadioButton.Name = "DailyEveryRadioButton";
            this.DailyEveryRadioButton.Size = new System.Drawing.Size(87, 19);
            this.DailyEveryRadioButton.TabIndex = 1;
            this.DailyEveryRadioButton.TabStop = true;
            this.DailyEveryRadioButton.Text = "Ocurs every";
            this.DailyEveryRadioButton.UseVisualStyleBackColor = true;
            // 
            // DailyOnceRadioButton
            // 
            this.DailyOnceRadioButton.AutoSize = true;
            this.DailyOnceRadioButton.Enabled = false;
            this.DailyOnceRadioButton.Location = new System.Drawing.Point(13, 28);
            this.DailyOnceRadioButton.Name = "DailyOnceRadioButton";
            this.DailyOnceRadioButton.Size = new System.Drawing.Size(98, 19);
            this.DailyOnceRadioButton.TabIndex = 0;
            this.DailyOnceRadioButton.TabStop = true;
            this.DailyOnceRadioButton.Text = "Ocurs once at";
            this.DailyOnceRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 664);
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
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private TextBox InputBox;
        private Label label1;
        private TextBox OutputBox;
        private GroupBox groupBox2;
        private RadioButton RecurringRadioButton;
        private RadioButton OnceRadioButton;
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
        private RadioButton DailyEveryRadioButton;
        private RadioButton DailyOnceRadioButton;
        private DateTimePicker OnceTimePicker;
        private DomainUpDown EveryPeriod;
        private NumericUpDown EveryUpDown;
    }
}