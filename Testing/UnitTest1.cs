using FluentAssertions;
using Xunit;
using System;
using Scheduler2;


namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test_next_second()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 5, 30);
            Data.EndDate = new DateTime(2022, 5, 31);
            Data.Format = Format.Daily;
            Data.PeriodType = PeriodType.Seconds; //seconds
            Data.TimePeriod = 7; // every 7 seconds
            Data.StartTime = new DateTime(1900, 1, 1, 10, 00, 50);
            Data.EndTime = new DateTime(1900, 1, 1, 10, 01, 0);
            Data.WeekPeriod = 1;
            Schedule schedule = new Schedule(Data);
            

            DateTime expectedValue = new DateTime(2022, 5, 31, 10, 00, 57);
            int i = 0;
            while (i < 4)
            {
                schedule.NextDate(Data);
                i++;
            }
            DateTime actualValue = Data.TimeDate;
            actualValue.Should().Be(expectedValue);

        }

        [Fact]
        public void Test_three_days_a_week_period_2_weeks()
        {
            //Arrange
            Settings Data = new Settings
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Weekly,
                WeekPeriod = 2
            };
            Data.WeekSettings.Monday = true;
            Data.WeekSettings.Wednesday = true;
            Data.WeekSettings.Sunday = true;
            Schedule schedule = new Schedule(Data);
            
            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 6, 8),
                new DateTime(2022, 6, 12),
                new DateTime(2022, 6, 20),
                new DateTime(2022, 6, 22),
                new DateTime(2022, 6, 26)
            };
            int i = 0;
            while (i < 5)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }            
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
        }

        [Fact]
        public void Test_six_days_a_week_period_2_weeks_10am_and_11am()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 7);
            Data.StartTime = new DateTime(200,1,1,10,1,1);
            Data.EndTime = new DateTime(200, 1, 1, 11, 1, 1);
            Data.Format = Format.Weekly;
            Data.WeekSettings.Monday = true;
            Data.WeekSettings.Tuesday = true;
            Data.WeekSettings.Wednesday = true;
            Data.WeekSettings.Friday = true;
            Data.WeekSettings.Saturday = true;
            Data.WeekSettings.Sunday = true;
            Data.WeekPeriod = 2;
            Data.TimePeriod = 1;
            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];
            expectedValue[0] = new DateTime(2022, 6, 7,10,1,1);
            expectedValue[1] = new DateTime(2022, 6, 7, 11, 1, 1);
            expectedValue[2] = new DateTime(2022, 6, 8, 10, 1, 1);
            expectedValue[3] = new DateTime(2022, 6, 8, 11, 1, 1);
            expectedValue[4] = new DateTime(2022, 6, 10, 10, 1, 1);
            expectedValue[5] = new DateTime(2022, 6, 10, 11, 1, 1);
            expectedValue[6] = new DateTime(2022, 6, 11, 10, 1, 1);
            expectedValue[7] = new DateTime(2022, 6, 11, 11, 1, 1);
            expectedValue[8] = new DateTime(2022, 6, 12, 10, 1, 1);
            expectedValue[9] = new DateTime(2022, 6, 12, 11, 1, 1);
            expectedValue[10] = new DateTime(2022, 6, 20, 10, 1, 1);
           
            int i = 0;
            while (i < 11)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_daily_period_2_30minutes_from_10am_to_11am()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 1, 1);
            Data.EndTime = new DateTime(200, 1, 1, 11, 1, 1);
            Data.Format = Format.Daily;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Minutes;
            Data.TimePeriod = 30;
            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];
            expectedValue[0] = new DateTime(2022, 6, 12, 10, 1, 1);
            expectedValue[1] = new DateTime(2022, 6, 12, 10, 31, 1);
            expectedValue[2] = new DateTime(2022, 6, 12, 11, 1, 1);
            expectedValue[3] = new DateTime(2022, 6, 13, 10, 1, 1);
            expectedValue[4] = new DateTime(2022, 6, 13, 10, 31, 1);
            expectedValue[5] = new DateTime(2022, 6, 13, 11, 1, 1);
            
            int i = 0;
            while (i < 6)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_weekly_everyday_period_2_30minutes_from_10am_to_11am()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 1, 1);
            Data.EndTime = new DateTime(200, 1, 1, 11, 1, 1);
            Data.Format = Format.Weekly;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Minutes;
            Data.TimePeriod = 30;
            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];
            Data.WeekSettings.Thursday = true;
            Data.WeekSettings.Monday = true;
            Data.WeekSettings.Tuesday = true;
            Data.WeekSettings.Wednesday = true;
            Data.WeekSettings.Friday = true;
            Data.WeekSettings.Saturday = true;
            Data.WeekSettings.Sunday = true;
            expectedValue[0] = new DateTime(2022, 6, 12, 10, 1, 1);
            expectedValue[1] = new DateTime(2022, 6, 12, 10, 31, 1);
            expectedValue[2] = new DateTime(2022, 6, 12, 11, 1, 1);
            expectedValue[3] = new DateTime(2022, 6, 20, 10, 1, 1);
            expectedValue[4] = new DateTime(2022, 6, 20, 10, 31, 1);
            expectedValue[5] = new DateTime(2022, 6, 20, 11, 1, 1);

            int i = 0;
            while (i < 6)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_weekly_sundays_period_2_30seconds_from_10am_to_10_01()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 10, 1, 7);
            Data.Format = Format.Weekly;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 30;
            Data.WeekSettings.Sunday = true;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];
            
            
            
            expectedValue[0] = new DateTime(2022, 6, 12, 10, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 12, 10, 0, 30);
            expectedValue[2] = new DateTime(2022, 6, 12, 10, 1, 0);
            expectedValue[3] = new DateTime(2022, 6, 26, 10, 0, 0);
            expectedValue[4] = new DateTime(2022, 6, 26, 10, 0, 30);
            expectedValue[5] = new DateTime(2022, 6, 26, 10, 1, 0);
            expectedValue[6] = new DateTime(2022, 7, 10, 10, 0, 0);
            expectedValue[7] = new DateTime(2022, 7, 10, 10, 0, 30);
            

            int i = 0;
            while (i < 8)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_once_a_month_from_10am_to_end_of_day_every_5_hours()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 23, 59, 59);

            Data.Format = Format.Daily;
            
            Data.PeriodType = PeriodType.Hours;
            Data.TimePeriod = 5;
            Data.DaysPeriodType = DaysPeriodType.Months;
            Data.DayPeriod = 1;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];



            expectedValue[0] = new DateTime(2022, 6, 12, 10, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 12, 15, 0, 0);
            expectedValue[2] = new DateTime(2022, 6, 12, 20, 0, 0);
            expectedValue[3] = new DateTime(2022, 7, 12, 10, 0, 0);
            expectedValue[4] = new DateTime(2022, 7, 12, 15, 0, 0);
            expectedValue[5] = new DateTime(2022, 7, 12, 20, 0, 0);
            expectedValue[6] = new DateTime(2022, 8, 12, 10, 0, 0);
            expectedValue[7] = new DateTime(2022, 8, 12, 15, 0, 0);
            expectedValue[8] = new DateTime(2022, 8, 12, 20, 0, 0);

            int i = 0;
            while (i < 8)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_once_a_year_from_15am_to_16am_every_27minutes()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 16, 0, 0);

            Data.Format = Format.Daily;

            Data.PeriodType = PeriodType.Minutes;
            Data.TimePeriod = 27;
            Data.DaysPeriodType = DaysPeriodType.Years;
            Data.DayPeriod = 1;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];



            expectedValue[0] = new DateTime(2022, 6, 14, 15, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 14, 15, 27, 0);
            expectedValue[2] = new DateTime(2022, 6, 14, 15, 54, 0);
            expectedValue[3] = new DateTime(2023, 6, 14, 15, 0, 0);
            expectedValue[4] = new DateTime(2023, 6, 14, 15, 27, 0);
            expectedValue[5] = new DateTime(2023, 6, 14, 15, 54, 0);
            expectedValue[6] = new DateTime(2024, 6, 14, 15, 0, 0);
            expectedValue[7] = new DateTime(2024, 6, 14, 15, 27, 0);
            expectedValue[8] = new DateTime(2024, 6, 14, 15, 54, 0);
            

            int i = 0;
            while (i < 9)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_once_a_day_once_a_week()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 15, 0, 0);

            Data.Format = Format.Daily;
            Data.DaysPeriodType = DaysPeriodType.Weeks;
            Data.DayPeriod = 1;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];

            expectedValue[0] = new DateTime(2022, 6, 14, 15, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 21, 15, 0, 0);
            expectedValue[2] = new DateTime(2022, 6, 28, 15, 0, 0);
            expectedValue[3] = new DateTime(2022, 7, 5, 15, 0, 0);
            expectedValue[4] = new DateTime(2022, 7, 12, 15, 0, 0);
            expectedValue[5] = new DateTime(2022, 7, 19, 15, 0, 0);
            expectedValue[6] = new DateTime(2022, 7, 26, 15, 0, 0);
            expectedValue[7] = new DateTime(2022, 8, 2, 15, 0, 0);
            expectedValue[8] = new DateTime(2022, 8, 9, 15, 0, 0);


            int i = 0;
            while (i < 9)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        } 
        [Fact]
        public void Test_once_a_day_every_8_days()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 15, 0, 0);

            Data.Format = Format.Daily;
            Data.DaysPeriodType = DaysPeriodType.Days;
            Data.DayPeriod = 8;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];

            expectedValue[0] = new DateTime(2022, 6, 14, 15, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 22, 15, 0, 0);
            expectedValue[2] = new DateTime(2022, 6, 30, 15, 0, 0);
            expectedValue[3] = new DateTime(2022, 7, 8, 15, 0, 0);
            expectedValue[4] = new DateTime(2022, 7, 16, 15, 0, 0);
            expectedValue[5] = new DateTime(2022, 7, 24, 15, 0, 0);
            
            int i = 0;
            while (i < 6)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_once_a_day_everyday_till_endDate()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.EndDate = new DateTime(2022, 6, 18);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 15, 0, 0);

            Data.Format = Format.Daily;
            Data.DaysPeriodType = DaysPeriodType.Days;
            Data.DayPeriod = 1;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];

            expectedValue[0] = new DateTime(2022, 6, 14, 15, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 15, 15, 0, 0);
            expectedValue[2] = new DateTime(2022, 6, 16, 15, 0, 0);
            expectedValue[3] = new DateTime(2022, 6, 17, 15, 0, 0);
            expectedValue[4] = new DateTime(2022, 6, 18, 15, 0, 0);
            expectedValue[5] = new DateTime(2022, 6, 18, 15, 0, 0);
            expectedValue[6] = new DateTime(2022, 6, 18, 15, 0, 0);

            int i = 0;
            while (i < 7)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_just_one_day_every_4hours_till_end_of_the_day()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.EndDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 23, 59, 59);

            Data.Format = Format.Daily;

            Data.PeriodType = PeriodType.Hours;
            Data.TimePeriod = 4;
            Data.DaysPeriodType = DaysPeriodType.Months;
            Data.DayPeriod = 1;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];



            expectedValue[0] = new DateTime(2022, 6, 12, 10, 0, 0);
            expectedValue[1] = new DateTime(2022, 6, 12, 14, 0, 0);
            expectedValue[2] = new DateTime(2022, 6, 12, 18, 0, 0);
            expectedValue[3] = new DateTime(2022, 6, 12, 22, 0, 0);
            expectedValue[4] = new DateTime(2022, 6, 12, 22, 0, 0);
            expectedValue[5] = new DateTime(2022, 6, 12, 22, 0, 0);
            expectedValue[6] = new DateTime(2022, 6, 12, 22, 0, 0);
            
            int i = 0;
            while (i < 7)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Just_Tomorrow_at_16_25_37_with_weekly()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 7);
            Data.EndDate = new DateTime(2022, 6, 10);
            Data.StartTime = new DateTime(200, 1, 1, 16, 25, 37);
            Data.EndTime = new DateTime(200, 1, 1, 16, 25, 37);
            Data.Format = Format.Weekly;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 30;
            Data.WeekSettings.Wednesday = true;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];

            expectedValue[0] = new DateTime(2022, 6, 8, 16, 25, 37);
            expectedValue[1] = new DateTime(2022, 6, 8, 16, 25, 37);
            
            int i = 0;
            while (i < 2)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Weekly_but_no_valid_day()
        {
            Settings Data = new Settings();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 10, 1, 7);
            Data.Format = Format.Weekly;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 30;

            Schedule schedule = new Schedule(Data);
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];



            
            expectedValue[0] = new DateTime(2022, 6, 12, 10, 0, 30);
            expectedValue[1] = new DateTime(2022, 6, 12, 10, 1, 0);
            expectedValue[2] = new DateTime(2022, 6, 12, 10, 1, 0);
            


            int i = 0;
            while (i < 3)
            {
                schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
    }
}