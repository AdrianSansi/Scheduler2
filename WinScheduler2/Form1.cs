using Scheduler2;
namespace WinScheduler2
{
    public partial class Form1 : Form
    {
        readonly Settings Data;
        readonly Schedule Schedule;
        


        public Form1()
        {
            InitializeComponent();
            Data = new Settings();
            

        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Data.CurrentDate = DateTime.Parse(InputBox.Text);
                if (Data.TimeDate < Data.CurrentDate)
                {
                    Data.StartDate = Data.CurrentDate;
                    Data.TimeDate = Data.CurrentDate;
                }
                Data.StartTime = DateTime.Parse(InputBox.Text);
                OnceCheckBox.Enabled = true;
                RecurringCheckBox.Enabled = true;

            }
            catch (Exception)
            {
                OnceCheckBox.Checked = false;
                RecurringCheckBox.Checked = false;
                OnceCheckBox.Enabled = false;
                RecurringCheckBox.Enabled = false;
            }

        }

        private void RecurringCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurringCheckBox.Checked)
            {
                OnceCheckBox.Checked = false;
                DailyRadioButton.Enabled = true;
                WeeklyRadioButton.Enabled = true;
                MonthyRadioButton.Enabled = true;

            }
            else
            {
                DailyRadioButton.Enabled = false;
                WeeklyRadioButton.Enabled = false;
                MonthyRadioButton.Enabled = false;
            }
        }

        private void OnceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnceCheckBox.Checked)
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
            if (DailyRadioButton.Checked)
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
                DayMonthy.Enabled = false;
                TheMonthy.Enabled = false;
                DayMonthy.Enabled = false;
                TheMonthy.Enabled = false;
            }           
        }

        private void WeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WeeklyRadioButton.Checked)
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
                DayMonthy.Enabled = false;
                TheMonthy.Enabled = false;
                DayMonthy.Enabled = false;
                TheMonthy.Enabled = false;

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
                Data.StartDate = Data.TimeDate;
                Data.EndDate = Data.TimeDate;
                Data.StartTime = Data.TimeDate;
                Data.EndTime = Data.TimeDate;
                NextButton.Enabled = true;
            }
            catch (Exception)
            {
                NextButton.Enabled = false;
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            
            if (DailyOnce.Checked || DailyEvery.Checked)
            {
                Schedule.NextDate(Data);
                OutputBox.Text = Data.TimeDate.ToString();
            }            
            else
            {
                OutputBox.Text = Data.TimeDate.ToString();
            }
            Description.Text = DescriptionClass.Description(Data);
        }

        private void WeeksUpDown_ValueChanged(object sender, EventArgs e)
        {
            Data.WeekPeriod = (int)WeeksUpDown.Value;
        }


        private void MondayBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MondayBox.Checked)
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
            if (TuesdayBox.Checked)
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
            if (WednesdayBox.Checked)
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
            if (ThursdayBox.Checked)
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
            if (FridayBox.Checked)
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
            if (SaturdayBox.Checked)
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
            if (SundayBox.Checked)
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
            if (DailyOnce.Checked)
            {
                Data.StartTime = OnceTimePicker.Value;
                Data.EndTime = OnceTimePicker.Value;
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
            if (DailyEvery.Checked)
            {
                DailyOnce.Checked = false;
                EveryUpDown.Enabled = true;
                EveryPeriod.Enabled = true;
                Data.StartTime = StartTimePicker.Value;
                Data.EndTime = EndTimePicker.Value;
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
            if (OnceTimePicker.Enabled)
            {
                StartDate.Enabled = true;
                EndDate.Enabled = true;
                NextButton.Enabled = true;
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
                NextButton.Enabled = true;

            }
            catch (Exception)
            {
                NextButton.Enabled = false;
                EndDate.Enabled = false;
            }
        }

        private void EndDate_TextChanged(Object sender, EventArgs e)
        {
            if(EndDate.Text.Length == 0)
            {
                Data.TimeDate = DateTime.MaxValue.AddDays(-1) + Data.EndTime.TimeOfDay;
                NextButton.Enabled = true;
            }
            else
            {
                try
                {
                    Data.EndDate = DateTime.Parse(EndDate.Text);
                    
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
                catch (Exception)
                {
                    NextButton.Enabled = false;
                }
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
               

        private void MonthyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MonthyRadioButton.Checked)
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
                Data.Format = Format.Monthy;
                DayPeriod.Enabled = false;
                DayPeriodType.Enabled = false;
                DayMonthy.Enabled = true;
                TheMonthy.Enabled = true;
                Data.MonthSettings.MonthyFormat = MonthyFormat.FixedDay;
                EveryMonthMonthy.Enabled = true;
                EveryMonthy.Enabled = true;

            }            
        }

        private void DayMonthy_CheckedChanged(object sender, EventArgs e)
        {
           if(DayMonthy.Checked)
            {
                Data.MonthSettings.MonthyFormat = MonthyFormat.FixedDay;
                EveryMonthMonthy.Enabled = true;
                EveryMonthy.Enabled = true;
                TheMonthy.Checked = false;
                Data.MonthSettings.MonthNum = (int)EveryMonthMonthy.Value;
            }
            else
            {
                EveryMonthMonthy.Enabled = false;
                EveryMonthy.Enabled = false;
            }
        }

        private void TheMonthy_CheckedChanged(object sender, EventArgs e)
        {
            if(TheMonthy.Checked)
            {
                Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
                MonthyFrequencyDomain.Enabled = true;
                MonthNumMonthy.Enabled = true;
                MonthDaysMonthyDomain.Enabled = true;
                DayMonthy.Checked = false;
                Data.MonthSettings.MonthNum = (int)MonthNumMonthy.Value;
            }
            else
            {
                MonthyFrequencyDomain.Enabled = false;
                MonthNumMonthy.Enabled = false;
                MonthDaysMonthyDomain.Enabled = false;
            }

        }

        private void EveryMonthy_ValueChanged(object sender, EventArgs e)
        {
            Data.MonthSettings.DayNum = (int)EveryMonthy.Value;
        }

        private void EveryMonthMonthy_ValueChanged(object sender, EventArgs e)
        {
            Data.MonthSettings.MonthNum = (int)EveryMonthMonthy.Value;
        }

        private void MonthyFrequency_SelectedItemChanged(object sender, EventArgs e)
        {
            Data.MonthSettings.MonthyFrequency = MonthyFrequencyDomain.SelectedItem switch
            {
                "Second" => MonthyFrequency.Second,
                "Third" => MonthyFrequency.Third,
                "Fourth" => MonthyFrequency.Fourth,
                "Last" => MonthyFrequency.Last,
                _ => MonthyFrequency.First,
            };
        }

        private void MonthDaysMonthy_SelectedItemChanged(object sender, EventArgs e)
        {
            Data.MonthSettings.MonthDays = MonthDaysMonthyDomain.SelectedItem switch
            {
                "Monday" => MonthDays.Monday,
                "Tuesday" => MonthDays.Tuesday,
                "Wednesday" => MonthDays.Wednesday,
                "Thursday" => MonthDays.Thursday,
                "Friday" => MonthDays.Friday,
                "Saturday" => MonthDays.Saturday,
                "Sunday" => MonthDays.Sunday,
                "Weekday" => MonthDays.Weekday,
                "Weekend day" => MonthDays.WeekendDay,
                _ => MonthDays.Day,
            };
        }

        private void MonthNumMonthy_ValueChanged(object sender, EventArgs e)
        {
            Data.MonthSettings.MonthNum = (int)MonthNumMonthy.Value;
        }
       
        private void LanguageDomain_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (LanguageDomain.SelectedItem)
            {
                case "Spanish ES":
                    Data.Language = Language.Spanish_Es;
                    break;
                case "English UK":
                    Data.Language = Language.English_UK;
                    break;
                case "English US":
                    Data.Language = Language.English_US;
                    break;
                default:
                    break;
            }
            SetTheCultureFormat.SetCultureAndLanguage(Data);
        }
    }
}