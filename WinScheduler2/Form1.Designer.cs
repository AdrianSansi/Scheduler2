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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.groupBox2.Location = new System.Drawing.Point(21, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 110);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuration";
            // 
            // WeeklyRadioButton
            // 
            this.WeeklyRadioButton.AutoSize = true;
            this.WeeklyRadioButton.Enabled = false;
            this.WeeklyRadioButton.Location = new System.Drawing.Point(540, 72);
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
            this.DailyRadioButton.Location = new System.Drawing.Point(382, 72);
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
            this.label4.Location = new System.Drawing.Point(236, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Occurs";
            // 
            // OnceTextBox
            // 
            this.OnceTextBox.Enabled = false;
            this.OnceTextBox.Location = new System.Drawing.Point(356, 33);
            this.OnceTextBox.Name = "OnceTextBox";
            this.OnceTextBox.Size = new System.Drawing.Size(348, 23);
            this.OnceTextBox.TabIndex = 4;
            this.OnceTextBox.TextChanged += new System.EventHandler(this.OnceTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 37);
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
            this.groupBox3.Location = new System.Drawing.Point(39, 506);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(704, 123);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 664);
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
    }
}