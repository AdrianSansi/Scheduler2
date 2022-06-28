using FluentAssertions;
using Xunit;
using System;
using System.Threading;
using System.Globalization;
using Scheduler2;
using System.Linq;
using System.Collections.Generic;

namespace Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test_next_second()
        {
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 5, 30),
                EndDate = new DateTime(2022, 5, 31),
                Format = Format.Daily,
                PeriodType = PeriodType.Seconds, //seconds
                TimePeriod = 7, // every 7 seconds
                StartTime = new DateTime(1900, 1, 1, 10, 00, 50),
                EndTime = new DateTime(1900, 1, 1, 10, 01, 0),
                WeekPeriod = 1
            };
            


            DateTime expectedValue = new(2022, 5, 31, 10, 00, 57);
            int i = 0;
            while (i < 4)
            {
                Schedule.NextDate(Data);
                i++;
            }
            DateTime actualValue = Data.TimeDate;
            actualValue.Should().Be(expectedValue);

        }

        [Fact]
        public void Test_three_days_a_week_period_2_weeks()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Weekly,
                WeekPeriod = 2
            };
            Data.WeekSettings.Monday = true;
            Data.WeekSettings.Wednesday = true;
            Data.WeekSettings.Sunday = true;
            

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
                Schedule.NextDate(Data);
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
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 7);
            Data.StartTime = new DateTime(200, 1, 1, 10, 1, 1);
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
            
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];
            expectedValue[0] = new DateTime(2022, 6, 7, 10, 1, 1);
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_daily_period_2_30minutes_from_10am_to_11am()
        {
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 12),
                StartTime = new DateTime(200, 1, 1, 10, 1, 1),
                EndTime = new DateTime(200, 1, 1, 11, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 2,
                PeriodType = PeriodType.Minutes,
                TimePeriod = 30
            };
            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_weekly_everyday_period_2_30minutes_from_10am_to_11am()
        {
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 12),
                StartTime = new DateTime(200, 1, 1, 10, 1, 1),
                EndTime = new DateTime(200, 1, 1, 11, 1, 1),
                Format = Format.Weekly,
                WeekPeriod = 2,
                PeriodType = PeriodType.Minutes,
                TimePeriod = 30
            };
            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_weekly_sundays_period_2_30seconds_from_10am_to_10_01()
        {
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 12),
                StartTime = new DateTime(200, 1, 1, 10, 0, 0),
                EndTime = new DateTime(200, 1, 1, 10, 1, 7),
                Format = Format.Weekly,
                WeekPeriod = 2,
                PeriodType = PeriodType.Seconds,
                TimePeriod = 30
            };
            Data.WeekSettings.Sunday = true;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_once_a_month_from_10am_to_end_of_day_every_5_hours()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 23, 59, 59);

            Data.Format = Format.Daily;

            Data.PeriodType = PeriodType.Hours;
            Data.TimePeriod = 5;
            Data.DaysPeriodType = DaysPeriodType.Months;
            Data.DayPeriod = 1;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }

        [Fact]
        public void Test_once_a_year_from_15am_to_16am_every_27minutes()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 16, 0, 0);

            Data.Format = Format.Daily;

            Data.PeriodType = PeriodType.Minutes;
            Data.TimePeriod = 27;
            Data.DaysPeriodType = DaysPeriodType.Years;
            Data.DayPeriod = 1;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_once_a_day_once_a_week()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 15, 0, 0);

            Data.Format = Format.Daily;
            Data.DaysPeriodType = DaysPeriodType.Weeks;
            Data.DayPeriod = 1;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_once_a_day_every_8_days()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 15, 0, 0);

            Data.Format = Format.Daily;
            Data.DaysPeriodType = DaysPeriodType.Days;
            Data.DayPeriod = 8;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_once_a_day_everyday_till_endDate()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 14);
            Data.EndDate = new DateTime(2022, 6, 18);
            Data.StartTime = new DateTime(200, 1, 1, 15, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 15, 0, 0);

            Data.Format = Format.Daily;
            Data.DaysPeriodType = DaysPeriodType.Days;
            Data.DayPeriod = 1;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_just_one_day_every_4hours_till_end_of_the_day()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.EndDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 23, 59, 59);

            Data.Format = Format.Daily;

            Data.PeriodType = PeriodType.Hours;
            Data.TimePeriod = 4;
            Data.DaysPeriodType = DaysPeriodType.Months;
            Data.DayPeriod = 1;

            
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
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Just_Tomorrow_at_16_25_37_with_weekly()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 7);
            Data.EndDate = new DateTime(2022, 6, 10);
            Data.StartTime = new DateTime(200, 1, 1, 16, 25, 37);
            Data.EndTime = new DateTime(200, 1, 1, 16, 25, 37);
            Data.Format = Format.Weekly;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 30;
            Data.WeekSettings.Wednesday = true;

            
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];

            expectedValue[0] = new DateTime(2022, 6, 8, 16, 25, 37);
            expectedValue[1] = new DateTime(2022, 6, 8, 16, 25, 37);

            int i = 0;
            while (i < 2)
            {
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Weekly_but_no_valid_day()
        {
            Settings Data = new();
            Data.TimeDate = new DateTime(2022, 6, 12);
            Data.StartTime = new DateTime(200, 1, 1, 10, 0, 0);
            Data.EndTime = new DateTime(200, 1, 1, 10, 1, 7);
            Data.Format = Format.Weekly;
            Data.WeekPeriod = 2;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 30;

            
            DateTime[] expectedValue = new DateTime[11];
            DateTime[] actualValue = new DateTime[11];




            expectedValue[0] = new DateTime(2022, 6, 12, 10, 0, 30);
            expectedValue[1] = new DateTime(2022, 6, 12, 10, 1, 0);
            expectedValue[2] = new DateTime(2022, 6, 12, 10, 1, 0);



            int i = 0;
            while (i < 3)
            {
                Schedule.NextDate(Data);
                actualValue[i] = Data.TimeDate;
                actualValue[i].Should().Be(expectedValue[i]);
                i++;
            }
        }
        [Fact]
        public void Test_NextDay_MonthyFormat_FixedDay_every2Months()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Monthy,
            };
            Data.MonthSettings.DayNum = 7;
            Data.MonthSettings.MonthNum = 2;
            Data.MonthSettings.MonthyFormat = MonthyFormat.FixedDay;


            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 8, 7),
                new DateTime(2022, 10, 7),
                new DateTime(2022, 12, 7),
                new DateTime(2023, 2, 7),
                new DateTime(2023, 4, 7)
            };
            int i = 0;
            while (i < 5)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
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
        public void Test_NextDay_MonthyFormat_FixedDay_every13Months()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Monthy,
            };
            Data.MonthSettings.DayNum = 2;
            Data.MonthSettings.MonthNum = 13;
            Data.MonthSettings.MonthyFormat = MonthyFormat.FixedDay;


            DateTime[] actualValue = new DateTime[7];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2023, 7, 2),
                new DateTime(2024, 8, 2),
                new DateTime(2025, 9, 2),
                new DateTime(2026, 10, 2),
                new DateTime(2027, 11, 2),
                new DateTime(2028, 12, 2),
                new DateTime(2030, 1, 2)
            };
            int i = 0;
            while (i < 7)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
        }
        [Fact]
        public void Test_NextDay_MonthyFormat_DayOfDay_mondays()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 2;
            Data.MonthSettings.MonthDays = MonthDays.Monday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;


            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 8, 1),
                new DateTime(2022, 10, 3),
                new DateTime(2022, 12, 5),
                new DateTime(2023, 2, 6),
                new DateTime(2023, 4, 3),
            };
            int i = 0;
            while (i < 5)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
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
        public void Test_NextDay_MonthyFormat_DayOfDay_seconds_fridays()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 3;
            Data.MonthSettings.MonthDays = MonthDays.Friday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Second;


            DateTime[] actualValue = new DateTime[3];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 9,9),
                new DateTime(2022, 12, 9),
                new DateTime(2023, 3, 10),

            };
            int i = 0;
            while (i < 3)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);

        }
        [Fact]
        public void Test_NextDay_MonthyFormat_DayOfDay_Last_saturdays()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 7),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.Saturday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;


            DateTime[] actualValue = new DateTime[7];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 7,30),
                new DateTime(2022, 8, 27),
                new DateTime(2022, 9, 24),
                new DateTime(2022, 10, 29),
                new DateTime(2022, 11, 26),
                new DateTime(2022, 12, 31),
                new DateTime(2023, 1, 28),
            };
            int i = 0;
            while (i < 7)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);

        }
        [Fact]
        public void Test_NextDay_MonthyFormat_Second_WeekDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Second;


            DateTime[] actualValue = new DateTime[7];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 7,4),
                new DateTime(2022, 8, 2),
                new DateTime(2022, 9, 2),
                new DateTime(2022, 10,4),
                new DateTime(2022, 11, 2),
                new DateTime(2022, 12, 2),
                new DateTime(2023, 1,3)

            };
            int i = 0;
            while (i < 7)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);

        }
        [Fact]
        public void Test_NextDay_MonthyFormat_Last_WeekDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 2;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;


            DateTime[] actualValue = new DateTime[7];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 8,31),
                new DateTime(2022, 10, 31),
                new DateTime(2022, 12, 30),
                new DateTime(2023, 2,28),
                new DateTime(2023, 4, 28),
                new DateTime(2023, 6, 30),
                new DateTime(2023, 8,31)

            };
            int i = 0;
            while (i < 7)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);

        }
        [Fact]
        public void Test_NextDay_MonthyFormat_Fourth_WeekendDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Fourth;


            DateTime[] actualValue = new DateTime[7];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 7,10),
                new DateTime(2022, 8, 14),
                new DateTime(2022, 9, 11),
                new DateTime(2022, 10, 9),
                new DateTime(2022, 11, 13),
                new DateTime(2022, 12, 11),
                new DateTime(2023, 1, 14)

            };
            int i = 0;
            while (i < 7)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);

        }

        [Fact]
        public void Test_NextDay_MonthyFormat_Last_WeekendDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 3;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;


            DateTime[] actualValue = new DateTime[7];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 9,25),
                new DateTime(2022, 12, 31),
                new DateTime(2023, 3, 26),
                new DateTime(2023, 6, 25),
                new DateTime(2023, 9, 30),
                new DateTime(2023, 12, 31),
                new DateTime(2024, 2, 25)
            };
            int i = 0;
            while (i < 6)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);

            Data.MonthSettings.MonthNum = 2;
            Data.TimeDate = NextDay.MonthyFormat(Data);
            actualValue[i] = Data.TimeDate;
            actualValue[6].Should().Be(expectedValue[6]);
        }
        [Fact]
        public void Test_NextDay_MonthyFormat_Last_WeekendDay_Of_Frebruary()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 2, 17),
                Format = Format.Monthy,
            };
            Data.MonthSettings.MonthNum = 12;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;


            DateTime[] actualValue = new DateTime[4];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2023, 2,26),
                new DateTime(2024, 2, 25),

            };
            int i = 0;
            while (i < 2)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);

        }

        [Fact]
        public void Test_NextDay_MonthyFormat_Second_WeekendDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9, 5, 4, 2),
                Format = Format.Monthy,
                StartTime = new DateTime(2022, 6, 9, 5, 0, 0)
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Second;


            DateTime[] actualValue = new DateTime[12];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 7,3,5,0,0),
                new DateTime(2022, 8, 7,5,0,0),
                new DateTime(2022, 9,4,5,0,0),
                new DateTime(2022, 10, 2,5,0,0),
                new DateTime(2022, 11,6,5,0,0),
                new DateTime(2022, 12, 4,5,0,0),
                new DateTime(2023, 1,7,5,0,0),
                new DateTime(2023, 2, 5,5,0,0),
                new DateTime(2023, 3,5,5,0,0),
                new DateTime(2023, 4, 2,5,0,0),
                new DateTime(2023, 5,7,5,0,0),
                new DateTime(2023, 6, 4,5,0,0)

            };
            int i = 0;
            while (i < 12)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);
        }
        [Fact]
        public void Test_NextDay_MonthyFormat_Third_WeekDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9),
                Format = Format.Monthy,
                StartTime = new DateTime(1987, 10, 9, 5, 0, 0),
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Third;


            DateTime[] actualValue = new DateTime[12];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 7,5,5,0,0),
                new DateTime(2022, 8, 3,5,0,0),
                new DateTime(2022, 9,5,5,0,0),
                new DateTime(2022, 10, 5,5,0,0),
                new DateTime(2022, 11,3,5,0,0),
                new DateTime(2022, 12, 5,5,0,0),
                new DateTime(2023, 1,4,5,0,0),
                new DateTime(2023, 2, 3,5,0,0),
                new DateTime(2023, 3,3,5,0,0),
                new DateTime(2023, 4, 5,5,0,0),
                new DateTime(2023, 5,3,5,0,0),
                new DateTime(2023, 6, 5,5,0,0)

            };
            int i = 0;
            while (i < 12)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);

        }
        [Fact]
        public void Test_NextDay_MonthyFormat_Fourth_WeekDay()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 6, 9),
                Format = Format.Monthy,
                StartTime = new DateTime(1987, 10, 9, 5, 0, 0),
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Fourth;


            DateTime[] actualValue = new DateTime[12];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 7,6,5,0,0),
                new DateTime(2022, 8, 4,5,0,0),
                new DateTime(2022, 9,6,5,0,0),
                new DateTime(2022, 10, 6,5,0,0),
                new DateTime(2022, 11,4,5,0,0),
                new DateTime(2022, 12, 6,5,0,0),
                new DateTime(2023, 1,5,5,0,0),
                new DateTime(2023, 2, 6,5,0,0),
                new DateTime(2023, 3,6,5,0,0),
                new DateTime(2023, 4, 6,5,0,0),
                new DateTime(2023, 5,4,5,0,0),
                new DateTime(2023, 6, 6,5,0,0)

            };
            int i = 0;
            while (i < 12)
            {
                Data.TimeDate = NextDay.MonthyFormat(Data);
                actualValue[i] = Data.TimeDate;
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);

        }
        [Fact]
        public void Test_First_Thursday_Every_3_Months_From_3_To_6_Every_Hour()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2020, 1, 1),
                StartTime = new DateTime(1988, 8, 8, 3, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 6, 0, 0),
                Format = Format.Monthy,
                WeekPeriod = 2,
                TimePeriod = 1,
                PeriodType = PeriodType.Hours
            };
            Data.MonthSettings.MonthNum = 3;
            Data.MonthSettings.MonthDays = MonthDays.Thursday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.First;
            
            DateTime[] actualValue = new DateTime[9];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2020, 1, 2, 3, 0, 0),
                new DateTime(2020, 1, 2, 4, 0, 0),
                new DateTime(2020, 1, 2, 5, 0, 0),
                new DateTime(2020, 1, 2, 6, 0, 0),
                new DateTime(2020, 4, 2, 3, 0, 0),
                new DateTime(2020, 4, 2, 4, 0, 0),
                new DateTime(2020, 4, 2, 5, 0, 0),
                new DateTime(2020, 4, 2, 6, 0, 0),
                new DateTime(2020, 7, 2, 3, 0, 0),
            };
            int i = 0;
            while (i < 9)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
        }
        [Fact]
        public void Test_Second_WeekendDay_Every_1_Months_From_3_To_6_Every_30_Minutes()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2020, 1, 1),
                StartTime = new DateTime(1988, 8, 8, 3, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 6, 0, 0),
                Format = Format.Monthy,
                WeekPeriod = 89,
                TimePeriod = 30,
                PeriodType = PeriodType.Minutes,
                Language = Language.Spanish_Es
            };
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Second;
           

            DateTime[] actualValue = new DateTime[20];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2020, 1, 5, 3, 0, 0),
                new DateTime(2020, 1, 5, 3, 30, 0),
                new DateTime(2020, 1, 5, 4, 0, 0),
                new DateTime(2020, 1, 5, 4, 30, 0),
                new DateTime(2020, 1, 5, 5, 0, 0),
                new DateTime(2020, 1, 5, 5, 30, 0),
                new DateTime(2020, 1, 5, 6, 0, 0),
                new DateTime(2020, 2, 2, 3, 0, 0),
                new DateTime(2020, 2, 2, 3, 30, 0),
                new DateTime(2020, 2, 2, 4, 0, 0),
                new DateTime(2020, 2, 2, 4, 30, 0),
                new DateTime(2020, 2, 2, 5, 0, 0),
                new DateTime(2020, 2, 2, 5, 30, 0),
                new DateTime(2020, 2, 2, 6, 0, 0),
                new DateTime(2020, 3, 7, 3, 0, 0),
                new DateTime(2020, 3, 7, 3, 30, 0),
                new DateTime(2020, 3, 7, 4, 0, 0),
                new DateTime(2020, 3, 7, 4, 30, 0),
                new DateTime(2020, 3, 7, 5, 0, 0),
                new DateTime(2020, 3, 7, 5, 30, 0),

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);

            string expectedDescription = "Ocurre el segundo día fin de semana de cada 1 mes cada 30 minutos entre 03:00:00 y 06:00:00 comenzando el 1/1/2020";

            int i = 0;
            while (i < 20)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualDescription = DescriptionClass.Description(Data);
            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);
            actualValue[12].Should().Be(expectedValue[12]);
            actualValue[13].Should().Be(expectedValue[13]);
            actualValue[14].Should().Be(expectedValue[14]);
            actualValue[15].Should().Be(expectedValue[15]);
            actualValue[16].Should().Be(expectedValue[16]);
            actualValue[17].Should().Be(expectedValue[17]);
            actualValue[18].Should().Be(expectedValue[18]);
            actualValue[19].Should().Be(expectedValue[19]);
            actualDescription.Should().Be(expectedDescription);
        }
        [Fact]
        public void Test_27th_Day_Every_4_Months_From_3_30_To_3_31_Every_20_Seconds()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 3, 30, 0),
                EndTime = new DateTime(1950, 1, 1, 3, 31, 0),
                Format = Format.Monthy,
                WeekPeriod = 89,
                TimePeriod = 20,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK
            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.MonthSettings.MonthNum = 4;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.FixedDay;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Second;
            

            DateTime[] actualValue = new DateTime[12];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2023, 12, 27, 3, 30, 0),
                new DateTime(2023, 12, 27, 3, 30, 20),
                new DateTime(2023, 12, 27, 3, 30, 40),
                new DateTime(2023, 12, 27, 3, 31, 0),
                new DateTime(2024, 4, 27, 3, 30, 0),
                new DateTime(2024, 4, 27, 3, 30, 20),
                new DateTime(2024, 4, 27, 3, 30, 40),
                new DateTime(2024, 4, 27, 3, 31, 0),
                new DateTime(2024, 8, 27, 3, 30, 0),
                new DateTime(2024, 8, 27, 3, 30, 20),
                new DateTime(2024, 8, 27, 3, 30, 40),
                new DateTime(2024, 8, 27, 3, 31, 0),
            };
            String expectedValue2 = "Occurs the day 27 of very 4 months every 20 seconds between 03:30:00 and 03:31:00 starting on 01/12/2023";



            int i = 0;
            while (i < 12)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(Data);


            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);

            actualValue2.Should().Be(expectedValue2);
        }
        [Fact]
        public void Test_Last_Day_Every_Month_At_12()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 0),
                Format = Format.Monthy,
                WeekPeriod = 89,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK
            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            

            DateTime[] actualValue = new DateTime[12];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2023, 12, 31, 12, 0, 0),
                new DateTime(2024, 1, 31, 12, 0, 0),
                new DateTime(2024, 2, 29, 12, 0, 0),
                new DateTime(2024, 3, 31, 12, 0, 0),
                new DateTime(2024, 4, 30, 12, 0, 0),
                new DateTime(2024, 5, 31, 12, 0, 0),
                new DateTime(2024, 6, 30, 12, 0, 0),
                new DateTime(2024, 7, 31, 12, 0, 0),
                new DateTime(2024, 8, 31, 12, 0, 0),
                new DateTime(2024, 9, 30, 12, 0, 0),
                new DateTime(2024, 10, 31, 12, 0, 0),
                new DateTime(2024, 11, 30, 12, 0, 0),
            };
            String expectedValue2 = "Occurs the last day of very 1 month once at 12:00:00 starting on 01/12/2023";

            int i = 0;
            while (i < 12)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(Data);

            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);
            actualValue2.Should().Be(expectedValue2);


        }
        [Fact]
        public void Test_Spanish_Description_Last_Day_Every_Month_At_12()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 0),
                Format = Format.Monthy,
                WeekPeriod = 89,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es
            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            
            Schedule.NextDate(Data);

            String expectedValue2 = "Ocurre el último día de cada 1 mes una vez a las 12:00:00 comenzando el 1/12/2023";

            String actualValue2 = DescriptionClass.Description(Data);


            actualValue2.Should().Be(expectedValue2);
        }
        [Fact]
        public void Test_US_Description_Last_Day_Every_Month_At_12()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 0),
                Format = Format.Weekly,
                WeekPeriod = 89,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_US

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.WeekSettings.Monday = true;
            Data.WeekSettings.Tuesday = true;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;

            Schedule.NextDate(Data);

            String expectedValue2 = "Occurs every 89 weeks on Monday and Tuesday once at 12:00:00 starting on 12/1/2023";

            String actualValue2 = DescriptionClass.Description(Data);


            actualValue2.Should().Be(expectedValue2);
        }

        [Fact]
        public void Test_US_Description_Once_At_12()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartDate = new DateTime(2023, 12, 1),
                EndDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 0),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_US

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.WeekSettings.Monday = true;
            Data.WeekSettings.Tuesday = true;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            Schedule.NextDate(Data);

            String expectedValue2 = "Occurs once at 12:00:00 on 12/1/2023";

            String actualValue2 = DescriptionClass.Description(Data);


            actualValue2.Should().Be(expectedValue2);
        }


        [Fact]
        public void Test_Es_Description_Some_Days_Of_Week_Every_Seconds_With_End_Date()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 19, 0, 0),
                EndDate = new DateTime(2024, 11, 7),
                EndTime = new DateTime(1950, 1, 1, 19, 1, 0),
                Format = Format.Weekly,
                WeekPeriod = 2,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.WeekSettings.Sunday = true;
            Data.WeekSettings.Thursday = true;
            Data.WeekSettings.Wednesday = true;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 5;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            Schedule.NextDate(Data);

            String expectedValue2 = "Ocurre cada 2 semanas los Miércoles, Jueves y Domingo cada 5 segundos entre 19:00:00 y 19:01:00 comenzando el 1/12/2023 y finalizando el día 7/11/2024";

            String actualValue2 = DescriptionClass.Description(Data);


            actualValue2.Should().Be(expectedValue2);
        }

        [Fact]
        public void Test_EnUS_Description_Some_Days_Of_Week_Every_Seconds_With_End_Date()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 19, 0, 0),
                EndDate = new DateTime(2024, 11, 7),
                EndTime = new DateTime(1950, 1, 1, 19, 1, 0),
                Format = Format.Weekly,
                WeekPeriod = 2,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_US

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.WeekSettings.Sunday = true;
            Data.WeekSettings.Thursday = true;
            Data.WeekSettings.Wednesday = true;
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 5;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            Schedule.NextDate(Data);

            String expectedValue2 = "Occurs every 2 weeks on Wednesday, Thursday and Sunday every 5 seconds between 19:00:00 and 19:01:00 starting on 12/1/2023 and ending on 11/7/2024";


            String actualValue2 = DescriptionClass.Description(Data);


            actualValue2.Should().Be(expectedValue2);
        }
        [Fact]
        public void Test_Last_WeekendDay_Every_Month_From_12_To_1_Every_1Hour_From_02_08_2025_To_09_07_2026()
        {
            //Arrange


            Settings Data = new()
            {

                TimeDate = new DateTime(2025, 8, 2),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 13, 0, 0),
                EndDate = new DateTime(2026, 7, 9),
                Format = Format.Monthy,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Hours,
                Language = Language.English_US
            };


            SetTheCultureFormat.SetCultureAndLanguage(Data);

            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.WeekendDay;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            

            DateTime[] actualValue = new DateTime[24];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2025, 08, 31, 12, 0, 0),
                new DateTime(2025, 08, 31, 13, 0, 0),
                new DateTime(2025, 09, 28, 12, 0, 0),
                new DateTime(2025, 09, 28, 13, 0, 0),
                new DateTime(2025, 10, 26, 12, 0, 0),
                new DateTime(2025, 10, 26, 13, 0, 0),
                new DateTime(2025, 11, 30, 12, 0, 0),
                new DateTime(2025, 11, 30, 13, 0, 0),
                new DateTime(2025, 12, 28, 12, 0, 0),
                new DateTime(2025, 12, 28, 13, 0, 0),
                new DateTime(2026, 01, 31, 12, 0, 0),
                new DateTime(2026, 01, 31, 13, 0, 0),
                new DateTime(2026, 02, 28, 12, 0, 0),
                new DateTime(2026, 02, 28, 13, 0, 0),
                new DateTime(2026, 03, 29, 12, 0, 0),
                new DateTime(2026, 03, 29, 13, 0, 0),
                new DateTime(2026, 04, 26, 12, 0, 0),
                new DateTime(2026, 04, 26, 13, 0, 0),
                new DateTime(2026, 05, 31, 12, 0, 0),
                new DateTime(2026, 05, 31, 13, 0, 0),
                new DateTime(2026, 06, 28, 12, 0, 0),
                new DateTime(2026, 06, 28, 13, 0, 0),
                new DateTime(2026, 06, 28, 13, 0, 0),
                new DateTime(2026, 06, 28, 13, 0, 0)


            };
            String expectedValue2 = $"Occurs the last weekend day of very 1 month every 1 hour between 12:00:00 and 13:00:00 starting on 8/2/2025 and ending on 7/9/2026";

            int i = 0;
            while (i < 24)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(Data);

            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);
            actualValue[5].Should().Be(expectedValue[5]);
            actualValue[6].Should().Be(expectedValue[6]);
            actualValue[7].Should().Be(expectedValue[7]);
            actualValue[8].Should().Be(expectedValue[8]);
            actualValue[9].Should().Be(expectedValue[9]);
            actualValue[10].Should().Be(expectedValue[10]);
            actualValue[11].Should().Be(expectedValue[11]);
            actualValue[12].Should().Be(expectedValue[12]);
            actualValue[13].Should().Be(expectedValue[13]);
            actualValue[14].Should().Be(expectedValue[14]);
            actualValue[15].Should().Be(expectedValue[15]);
            actualValue[16].Should().Be(expectedValue[16]);
            actualValue[17].Should().Be(expectedValue[17]);
            actualValue[18].Should().Be(expectedValue[18]);
            actualValue[19].Should().Be(expectedValue[19]);
            actualValue[20].Should().Be(expectedValue[20]);
            actualValue[21].Should().Be(expectedValue[21]);
            actualValue[22].Should().Be(expectedValue[22]);
            actualValue[23].Should().Be(expectedValue[23]);
            actualValue2.Should().Be(expectedValue2);


        }

        [Fact]
        public void Test_First_Day_Is_Sunday_And_I_Want_A_WeekDay()
        {
            //Arrange

            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 12, 8),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09),
                Format = Format.Monthy,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es
            };


            SetTheCultureFormat.SetCultureAndLanguage(Data);

            Data.MonthSettings.MonthNum = 2;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.First;
            

            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2023, 01, 2, 12, 0, 0),
                new DateTime(2023, 01, 2, 12, 0, 1),
                new DateTime(2023, 01, 2, 12, 0, 2),
                new DateTime(2023, 03, 1, 12, 0, 0),
                new DateTime(2023, 03, 1, 12, 0, 1),
            };
            String expectedValue2 = $"Ocurre el primer día entre semana de cada 2 meses cada 1 segundo entre 12:00:00 y 12:00:02 comenzando el 8/12/2022 y finalizando el día 9/7/2026";

            int i = 0;
            while (i < 5)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(Data);

            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);

            actualValue2.Should().Be(expectedValue2);


        }
        [Fact]
        public void Test_Daily_Descripion()
        {
            //Arrange

            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 12, 8),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es,
                DaysPeriodType = DaysPeriodType.Weeks,
                DayPeriod = 5
            };


            SetTheCultureFormat.SetCultureAndLanguage(Data);

            Data.MonthSettings.MonthNum = 2;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.First;
            

            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 12, 8, 12, 0, 0),
                new DateTime(2022, 12, 8, 12, 0, 1),
                new DateTime(2022, 12, 8, 12, 0, 2),
                new DateTime(2023, 1, 12, 12, 0, 0),
                new DateTime(2023, 1, 12, 12, 0, 1),
            };
            String expectedValue2 = "Ocurre cada 5 semanas cada 1 segundo entre 12:00:00 y 12:00:02 comenzando el 8/12/2022 y finalizando el día 9/7/2026";

            int i = 0;
            while (i < 5)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(Data);

            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);

            actualValue2.Should().Be(expectedValue2);


        }

        [Fact]
        public void Test_esES_Description_EveryDay_Of_Week()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2023, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 19, 0, 0),
                EndDate = new DateTime(2024, 11, 7),
                EndTime = new DateTime(1950, 1, 1, 19, 0, 0),
                Format = Format.Weekly,
                WeekPeriod = 2,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.WeekSettings.Sunday = true;
            Data.WeekSettings.Thursday = true;
            Data.WeekSettings.Wednesday = true;
            Data.WeekSettings.Saturday = true;
            Data.WeekSettings.Tuesday = true;
            Data.WeekSettings.Friday = true;
            Data.WeekSettings.Monday = true;

            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 5;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Day;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            
            Schedule.NextDate(Data);

            String expectedValue2 = "Ocurre cada 2 semanas los Lunes, Martes, Miércoles, Jueves, Viernes, Sábado y Domingo una vez a las 19:00:00 comenzando el 1/12/2023 y finalizando el día 7/11/2024";


            String actualValue2 = DescriptionClass.Description(Data);


            actualValue2.Should().Be(expectedValue2);
        }


        [Fact]
        public void Test_esES_Description_Days_Of_Week()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 19, 0, 0),
                EndDate = new DateTime(2024, 11, 7),
                EndTime = new DateTime(1950, 1, 1, 19, 0, 0),
                Format = Format.Monthy,
                WeekPeriod = 2,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 5;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Monday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Third;
            Data.MonthSettings.MonthDays = MonthDays.Monday;
            
            

            DateTime expectedValue = new DateTime(2022, 12, 19, 19, 0, 0);

            String expectedValue2 = "Ocurre el tercer Lunes de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";

            DateTime actualValue = Schedule.NextDate(Data);
            String actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);

            Data.MonthSettings.MonthDays = MonthDays.Tuesday;
            expectedValue = new DateTime(2023, 1, 17,19,0,0);
            expectedValue2 = "Ocurre el tercer Martes de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";
            
            actualValue = Schedule.NextDate(Data);
            actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);

            Data.MonthSettings.MonthDays = MonthDays.Wednesday;
            expectedValue = new DateTime(2023, 2, 15, 19, 0, 0);
            expectedValue2 = "Ocurre el tercer Miércoles de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";

            actualValue = Schedule.NextDate(Data);
            actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);

            Data.MonthSettings.MonthDays = MonthDays.Thursday;
            expectedValue = new DateTime(2023, 3, 16, 19, 0, 0);
            expectedValue2 = "Ocurre el tercer Jueves de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";

            actualValue = Schedule.NextDate(Data);
            actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);

            Data.MonthSettings.MonthDays = MonthDays.Friday;
            expectedValue = new DateTime(2023, 4, 21, 19, 0, 0);
            expectedValue2 = "Ocurre el tercer Viernes de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";

            actualValue = Schedule.NextDate(Data);
            actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);

            Data.MonthSettings.MonthDays = MonthDays.Saturday;
            expectedValue = new DateTime(2023, 5, 20, 19, 0, 0);
            expectedValue2 = "Ocurre el tercer Sábado de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";

            actualValue = Schedule.NextDate(Data);
            actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);

            Data.MonthSettings.MonthDays = MonthDays.Sunday;
            expectedValue = new DateTime(2023, 6, 18, 19, 0, 0);
            expectedValue2 = "Ocurre el tercer Domingo de cada 1 mes una vez a las 19:00:00 comenzando el 1/12/2022 y finalizando el día 7/11/2024";

            actualValue = Schedule.NextDate(Data);
            actualValue2 = DescriptionClass.Description(Data);

            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);
        }

        [Fact]
        public void Test_Last_Day_Sunday_I_Want_a_Week_Day()
        {
            //Arrange
            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 12, 1),
                StartTime = new DateTime(1988, 8, 8, 19, 0, 0),
                EndDate = new DateTime(2024, 11, 7),
                EndTime = new DateTime(1950, 1, 1, 19, 0, 0),
                Format = Format.Monthy,
                WeekPeriod = 2,
                TimePeriod = 894,
                PeriodType = PeriodType.Seconds,
                Language = Language.Spanish_Es

            };
            SetTheCultureFormat.SetCultureAndLanguage(Data);
            

            Data.PeriodType = PeriodType.Seconds;
            Data.TimePeriod = 5;
            Data.MonthSettings.MonthNum = 1;
            Data.MonthSettings.DayNum = 27;
            Data.MonthSettings.MonthDays = MonthDays.Weekday;
            Data.MonthSettings.MonthyFormat = MonthyFormat.DayOfWeek;
            Data.MonthSettings.MonthyFrequency = MonthyFrequency.Last;
            

            DateTime expectedValue = new DateTime(2022, 12, 30,19,00,00);
            DateTime expectedValue2 = new DateTime(2023, 1, 31,19,00,00);
           
            
            Schedule.NextDate(Data);
            DateTime actualValue = Data.TimeDate;
            Schedule.NextDate(Data);
            DateTime actualValue2 = Data.TimeDate;


            actualValue.Should().Be(expectedValue);
            actualValue2.Should().Be(expectedValue2);
        }

        [Fact]
        public void Test_Daily_Descripion_Days()
        {
            //Arrange

            Settings Data = new()
            {
                TimeDate = new DateTime(2022, 12, 8),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5
            };


            SetTheCultureFormat.SetCultureAndLanguage(Data);

            

            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 12, 8, 12, 0, 0),
                new DateTime(2022, 12, 8, 12, 0, 1),
                new DateTime(2022, 12, 8, 12, 0, 2),
                new DateTime(2022, 12, 13, 12, 0, 0),
                new DateTime(2022, 12, 13, 12, 0, 1),
            };
            
            String expectedValue2 = "Occurs every 5 days every 1 second between 12:00:00 and 12:00:02 starting on 08/12/2022 and ending on 09/07/2026";

            int i = 0;
            while (i < 5)
            {
                actualValue[i] = Schedule.NextDate(Data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(Data);

            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);

            actualValue2.Should().Be(expectedValue2);

        }

        [Fact]
        public void Test_Daily_Descripion_Days_Db()
        {
            using var scheduleDataBase = new SchedulerDb();
            scheduleDataBase.Database.Delete();
            scheduleDataBase.SaveChanges();

            var data1 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8,0,0,0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09,0,0,0),
                CurrentDate = new DateTime(2028,1,1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5
            };

            DBManager.StoreSettings(data1);

            Settings data = scheduleDataBase.Settings
                .OrderBy(b => b.Id)
                .First();


            
            SetTheCultureFormat.SetCultureAndLanguage(data);

            

            DateTime[] actualValue = new DateTime[5];
            DateTime[] expectedValue = new DateTime[]
            {
                new DateTime(2022, 12, 8, 12, 0, 0),
                new DateTime(2022, 12, 8, 12, 0, 1),
                new DateTime(2022, 12, 8, 12, 0, 2),
                new DateTime(2022, 12, 13, 12, 0, 0),
                new DateTime(2022, 12, 13, 12, 0, 1),
                
            };

            String expectedValue2 = "Occurs every 5 days every 1 second between 12:00:00 and 12:00:02 starting on 08/12/2022 and ending on 09/07/2026";

            int i = 0;
            while (i < 5)
            {
                actualValue[i] = Schedule.NextDate(data);
                i++;
            }
            String actualValue2 = DescriptionClass.Description(data);

            actualValue[0].Should().Be(expectedValue[0]);
            actualValue[1].Should().Be(expectedValue[1]);
            actualValue[2].Should().Be(expectedValue[2]);
            actualValue[3].Should().Be(expectedValue[3]);
            actualValue[4].Should().Be(expectedValue[4]);

            actualValue2.Should().Be(expectedValue2);
            DBManager.DeleteSettings(data.Id);

            
        }


        [Fact]
        public void Test_OutDateSchedules()
        {
            
            using var scheduleDataBase = new SchedulerDb();



            var data1 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8, 0, 0, 0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09, 0, 0, 0),
                CurrentDate = new DateTime(2028, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5,
                Id = 5
            };

            DBManager.StoreSettings(data1);
            
            int expectedValue = 1;
            int actualValue = DBManager.OutDateSchedules().Count();
            actualValue.Should().Be(expectedValue);

            Settings data = scheduleDataBase.Settings
                .OrderBy(b => b.Id)
                .First();
            DBManager.DeleteSettings(data.Id);
            
        }

        [Fact]
        public void Test_update_DB()
        {
            using var scheduleDataBase = new SchedulerDb();

            var data1 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8, 0, 0, 0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09, 0, 0, 0),
                CurrentDate = new DateTime(2028, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5,
                Id = 5
            };

            DBManager.StoreSettings(data1);
            scheduleDataBase.SaveChanges();

            Settings data;
            data = scheduleDataBase.Settings
                .OrderBy(b => b.Id)
                .First();

            data.WeekPeriod = 5;
            
            DBManager.UpdateSettings();

            int expectedNumElements = 1;
            int actualNumElements = DBManager.OutDateSchedules().Count();
            actualNumElements.Should().Be(expectedNumElements);

            data = scheduleDataBase.Settings
                .OrderBy(b => b.Id)
                .First();
            int expectedWeekPeriod = 5;
            int actualWeekPeriod = data.WeekPeriod;

            actualWeekPeriod.Should().Be(expectedWeekPeriod);

            DBManager.DeleteSettings(data.Id);
            
        }

        [Fact]
        public void Test_Some_outDateSchedules()
        {


            using var scheduleDataBase = new SchedulerDb();


            var data1 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8, 0, 0, 0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09, 0, 0, 0),
                CurrentDate = new DateTime(2020, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5,
                Id = 1
            };

            var data2 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8, 0, 0, 0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09, 0, 0, 0),
                CurrentDate = new DateTime(2028, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5,
                Id = 2
            };

            var data3 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8, 0, 0, 0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09, 0, 0, 0),
                CurrentDate = new DateTime(2021, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5,
                Id = 3
            };

            var data4 = new Settings
            {
                TimeDate = new DateTime(2022, 12, 8, 0, 0, 0),
                StartTime = new DateTime(1988, 8, 8, 12, 0, 0),
                EndTime = new DateTime(1950, 1, 1, 12, 0, 2),
                EndDate = new DateTime(2026, 07, 09, 0, 0, 0),
                CurrentDate = new DateTime(2028, 1, 1),
                Format = Format.Daily,
                WeekPeriod = 89,
                TimePeriod = 1,
                PeriodType = PeriodType.Seconds,
                Language = Language.English_UK,
                DaysPeriodType = DaysPeriodType.Days,
                DayPeriod = 5,
                Id = 4
            };

            DBManager.StoreSettings(data1);
            
            DBManager.StoreSettings(data2);
           
            DBManager.StoreSettings(data3);
            
            DBManager.StoreSettings(data4);
            

            int expectedNumElements = 2;
            int actualNumElements = DBManager.OutDateSchedules().Count();
            actualNumElements.Should().Be(expectedNumElements);

            DBManager.DeleteSettings(data1.Id);
            DBManager.DeleteSettings(data2.Id);
            DBManager.DeleteSettings(data3.Id);
            DBManager.DeleteSettings(data4.Id);

            int expectedValue = 0;
            int actualValue = DBManager.OutDateSchedules().Count();
            expectedValue.Should().Be(actualValue);
            scheduleDataBase.Database.Delete();
            scheduleDataBase.SaveChanges();
        }

       

        
    }    
}