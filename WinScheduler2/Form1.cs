using Scheduler2;
namespace WinScheduler2
{
    public partial class Form1 : Form
    {
        
        Schedule schedule;
        DateTime endDate;


        public Form1()
        {
            schedule = new Schedule(DateTime.Today); 
            
            endDate = DateTime.MinValue;
            InitializeComponent();
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                schedule.currentDate = DateTime.Parse(InputBox.Text);
                schedule.startTime = DateTime.Parse(InputBox.Text);
                OnceCheckBox.Enabled = true;
                RecurringCheckBox.Enabled = true;
                
            }
            catch (Exception FormatException)
            {
                OnceCheckBox.Checked = false;
                RecurringCheckBox.Checked = false;
                OnceCheckBox.Enabled = false;
                RecurringCheckBox.Enabled = false;
            }

        }

        private void RecurringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurringCheckBox.Checked == true)
            {
                OnceCheckBox.Checked = false;
                DailyRadioButton.Enabled = true;
                WeeklyRadioButton.Enabled = true;
                                
            }
            else
            {
                DailyRadioButton.Enabled = false;
                WeeklyRadioButton.Enabled = false;
            }
        }

        private void OnceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnceCheckBox.Checked == true)
            {
                RecurringCheckBox.Checked = false;
                OnceTextBox.Enabled = true;
                DailyRadioButton.Checked = false;
                WeeklyRadioButton.Checked = false;
            }
            else
            {
                OnceTextBox.Enabled = false;
            }
        }

        private void DailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyRadioButton.Checked == true)
            {
                DailyEvery.Enabled = true;
                DailyOnce.Enabled = true;
                MondayBox.Enabled = false;
                TuesdayBox.Enabled = false;
                WednesdayBox.Enabled = false;
                ThursdayBox.Enabled = false;
                FridayBox.Enabled = false;
                SaturdayBox.Enabled = false;
                SundayBox.Enabled = false;
                MondayBox.Checked = true;
                TuesdayBox.Checked = true;
                WednesdayBox.Checked = true;
                ThursdayBox.Checked = true;
                FridayBox.Checked = true;
                SaturdayBox.Checked = true;
                SundayBox.Checked = true;
                schedule.format = 1;
                DayPeriod.Enabled = true;
                DayPeriodType.Enabled = true;

            }
            else
            {

            }
        }

        private void WeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WeeklyRadioButton.Checked == true)
            {

                WeeksUpDown.Enabled = true;
                MondayBox.Enabled = true;
                TuesdayBox.Enabled = true;
                WednesdayBox.Enabled = true;
                ThursdayBox.Enabled = true;
                FridayBox.Enabled = true;
                SaturdayBox.Enabled = true;
                SundayBox.Enabled = true;
                DailyEvery.Enabled = true;
                DailyOnce.Enabled = true;
                schedule.format = 2;

            }
            else
            {
                WeeksUpDown.Enabled = false;
                MondayBox.Enabled = false;
                TuesdayBox.Enabled = false;
                WednesdayBox.Enabled = false;
                ThursdayBox.Enabled = false;
                FridayBox.Enabled = false;
                SaturdayBox.Enabled = false;
                SundayBox.Enabled = false;
                schedule.format = 1;
            }
        }

        private void OnceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                schedule.timeDate = DateTime.Parse(OnceTextBox.Text);
                NextButton.Enabled = true;
            }
            catch (Exception FormatException)
            {
                NextButton.Enabled = false;
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if(DailyOnce.Checked == true)
            {
                schedule.nextDate();
                OutputBox.Text = schedule.timeDate.ToString();
            }
            else if(DailyEvery.Checked == true )
            {
                schedule.nextDate();
                OutputBox.Text = schedule.timeDate.ToString();
            }
            else
            {
                OutputBox.Text = schedule.timeDate.ToString();
            }
        }

        private void WeeksUpDown_ValueChanged(object sender, EventArgs e)
        {
            schedule.weekPeriod = (int)WeeksUpDown.Value;
        }


        private void MondayBox_CheckedChanged(object sender, EventArgs e)
        {
            if(MondayBox.Checked == true)
            {
                schedule.monday = true;
            }
            else
            {
                schedule.monday = false;
            }
        }
        private void TuesdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TuesdayBox.Checked == true)
            {
                schedule.tuesday = true;
            }
            else
            {
                schedule.tuesday = false;
            }
        }
        private void WednesdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WednesdayBox.Checked == true)
            {
                schedule.wednesday = true;
            }
            else
            {
                schedule.wednesday = false;
            }
        }
        private void ThursdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ThursdayBox.Checked == true)
            {
                schedule.thursday = true;
            }
            else
            {
                schedule.thursday = false;
            }
        }
        private void FridayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FridayBox.Checked == true)
            {
                schedule.friday = true;
            }
            else
            {
                schedule.friday = false;
            }
        }
        private void SaturdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaturdayBox.Checked == true)
            {
                schedule.saturday = true;
            }
            else
            {
                schedule.saturday = false;
            }
        }
        private void SundayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SundayBox.Checked == true)
            {
                schedule.sunday= true;
            }
            else
            {
                schedule.sunday= false;
            }
        }





        private void DailyOnce_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyOnce.Checked == true)
            {
                OnceTimePicker.Enabled = true;
                DailyEvery.Checked = false;
            }
            else
            {
                OnceTimePicker.Enabled= false;
            }
        }

        private void DailyEvery_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyEvery.Checked == true)
            {
                DailyOnce.Checked = false;
                EveryUpDown.Enabled = true;
                EveryPeriod.Enabled = true;
            }
            else
            {
                EveryUpDown.Enabled = false;
                EveryPeriod.Enabled = false;
            }
        }

        private void EveryPeriod_ItemChanged(object sender, EventArgs e)
        {
            switch (EveryPeriod.SelectedItem)
            {
                case "Minutes":
                    schedule.periodType = 1;
                    EveryUpDown.Maximum = 24 * 60-1;
                    break;
                case "Seconds":
                    schedule.periodType= 2;
                    EveryUpDown.Maximum = 24 * 60+60-1;
                    break;
                default:
                    schedule.periodType= 0;
                    break;
            }
        }

        private void OnceTimePickler_ValueChanged(object sender, EventArgs e) 
        {
            schedule.startTime = OnceTimePicker.Value;
            schedule.endTime = OnceTimePicker.Value;
        }

        private void OnceTimePicker_EnabledChanged(object sender, EventArgs e)
        {
            if(OnceTimePicker.Enabled == true)
            {
                StartDate.Enabled = true;
                EndDate.Enabled = true;
                NextButton.Enabled = true;
            }
            else
            {
                
            }
        }

        private void EveryUpDown_ValueChanged(Object sender, EventArgs e)
        {
            schedule.timePeriod = (int)EveryUpDown.Value;
            StartTimePicker.Enabled = true;
            EndTimePicker.Enabled = true;
            StartDate.Enabled = true;
            EndDate.Enabled = true;
            NextButton.Enabled = true;
        }

       private void StartDate_TextChanged(Object sender, EventArgs e)
        {
            try
            {
                schedule.timeDate = DateTime.Parse(StartDate.Text);
                EndDate.Enabled = true;

            }
            catch (Exception FormatException)
            {
                NextButton.Enabled = false;
                EndDate.Enabled = false;
            }
        }

        private void EndDate_TextChanged(Object sender, EventArgs e)
        {
            try
            {
                schedule.endDate = DateTime.Parse(EndDate.Text);
                schedule.endDate = schedule.endDate;
                schedule.timeDate = schedule.timeDate;

                if (schedule.endDate + schedule.endDate.TimeOfDay < schedule.timeDate + schedule.startTime.TimeOfDay)
                {
                    NextButton.Enabled = false;
                    OutputBox.Text = "Start date can not be later than end date!";
                }
                else
                {
                    NextButton.Enabled = true;
                    OutputBox.Text = "";
                }

            }
            catch (Exception FormatException)
            {
                NextButton.Enabled = false;
            }
        }

        private void StartTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            schedule.startTime = StartTimePicker.Value;
            EndTimePicker.MinDate = StartTimePicker.Value;
        }
        private void EndTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            schedule.endTime = EndTimePicker.Value;
        }

        private void DayPeriod_ValueChanged(Object sender, EventArgs e)
        {
            schedule.dayPeriod = (int)DayPeriod.Value;
        }
       private void DayPeriodType_ItemChanged(Object sender, EventArgs e)
        {
            switch (DayPeriodType.SelectedItem)
            {
                case "Days":
                    schedule.dayPeriodType = 1;
                    break;
                case "Weeks":
                    schedule.dayPeriodType = 2;
                    break;
                case "Months":
                    schedule.dayPeriodType = 3;
                    break;
                default:
                    break;
            }
        }
    }

}