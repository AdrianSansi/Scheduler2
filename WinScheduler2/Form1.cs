using Scheduler2;
namespace WinScheduler2
{
    public partial class Form1 : Form
    {

        Settings Data;
        Schedule Schedule;
        


        public Form1()
        {
            Data = new Settings();
            Schedule = new Schedule(Data);
                        
            InitializeComponent();
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Data.CurrentDate = DateTime.Parse(InputBox.Text);
                if(Data.TimeDate<Data.CurrentDate) Data.TimeDate = Data.CurrentDate;                
                Data.StartTime = DateTime.Parse(InputBox.Text);
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
                Data.Format = Format.Daily;
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
                Data.Format = Format.Weekly;

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
                Data.Format = Format.Daily;
            }
        }

        private void OnceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Data.TimeDate = DateTime.Parse(OnceTextBox.Text);
                NextButton.Enabled = true;
            }
            catch (Exception FormatException)
            {
                NextButton.Enabled = false;
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (DailyOnce.Checked == true)
            {
                Schedule.NextDate(Data);
                OutputBox.Text = Data.TimeDate.ToString();
            }
            else if (DailyEvery.Checked == true)
            {
                Schedule.NextDate(Data);
                OutputBox.Text = Data.TimeDate.ToString();
            }
            else
            {
                OutputBox.Text = Data.TimeDate.ToString();
            }
        }

        private void WeeksUpDown_ValueChanged(object sender, EventArgs e)
        {
            Data.WeekPeriod = (int)WeeksUpDown.Value;
        }


        private void MondayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MondayBox.Checked == true)
            {
                Data.WeekSettings.Monday = true;
            }
            else
            {
                Data.WeekSettings.Monday = false;
            }
        }
        private void TuesdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TuesdayBox.Checked == true)
            {
                Data.WeekSettings.Tuesday = true;
            }
            else
            {
                Data.WeekSettings.Tuesday = false;
            }
        }
        private void WednesdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (WednesdayBox.Checked == true)
            {
                Data.WeekSettings.Wednesday = true;
            }
            else
            {
                Data.WeekSettings.Wednesday = false;
            }
        }
        private void ThursdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ThursdayBox.Checked == true)
            {
                Data.WeekSettings.Thursday = true;
            }
            else
            {
                Data.WeekSettings.Thursday = false;
            }
        }
        private void FridayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FridayBox.Checked == true)
            {
                Data.WeekSettings.Friday = true;
            }
            else
            {
                Data.WeekSettings.Friday = false;
            }
        }
        private void SaturdayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaturdayBox.Checked == true)
            {
                Data.WeekSettings.Saturday = true;
            }
            else
            {
                Data.WeekSettings.Saturday = false;
            }
        }
        private void SundayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SundayBox.Checked == true)
            {
                Data.WeekSettings.Sunday = true;
            }
            else
            {
                Data.WeekSettings.Sunday = false;
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
                OnceTimePicker.Enabled = false;
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
                    Data.PeriodType = PeriodType.Minutes;
                    EveryUpDown.Maximum = 24 * 60 - 1;
                    break;
                case "Seconds":
                    Data.PeriodType = PeriodType.Seconds;
                    EveryUpDown.Maximum = 24 * 60 + 60 - 1;
                    break;
                default:
                    Data.PeriodType = PeriodType.Hours;
                    break;
            }
        }

        private void OnceTimePickler_ValueChanged(object sender, EventArgs e)
        {
            Data.StartTime = OnceTimePicker.Value;
            Data.EndTime = OnceTimePicker.Value;
        }

        private void OnceTimePicker_EnabledChanged(object sender, EventArgs e)
        {
            if (OnceTimePicker.Enabled == true)
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
            Data.TimePeriod = (int)EveryUpDown.Value;
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
                Data.TimeDate = DateTime.Parse(StartDate.Text);
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
                Data.EndDate = DateTime.Parse(EndDate.Text);
                Data.TimeDate = Data.TimeDate;

                if (Data.EndDate + Data.EndDate.TimeOfDay < Data.TimeDate + Data.StartTime.TimeOfDay)
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
            Data.StartTime = StartTimePicker.Value;
            EndTimePicker.MinDate = StartTimePicker.Value;
        }
        private void EndTimePicker_ValueChanged(Object sender, EventArgs e)
        {
            Data.EndTime = EndTimePicker.Value;
        }

        private void DayPeriod_ValueChanged(Object sender, EventArgs e)
        {
            Data.DayPeriod = (int)DayPeriod.Value;
        }
        private void DayPeriodType_ItemChanged(Object sender, EventArgs e)
        {
            switch (DayPeriodType.SelectedItem)
            {
                case "Days":
                    Data.DaysPeriodType = DaysPeriodType.Days;
                    break;
                case "Weeks":
                    Data.DaysPeriodType = DaysPeriodType.Weeks;
                    break;
                case "Months":
                    Data.DaysPeriodType = DaysPeriodType.Months;
                    break;
                default:
                    break;
            }
        }
    }

}