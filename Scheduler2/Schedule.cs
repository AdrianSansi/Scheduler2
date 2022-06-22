using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class Schedule
    {    
        public int NumberOfDates { get; set; } = 0;
        public Settings Settings { get; }

        public Schedule(Settings settings)
        {
            Settings = settings;
        }
  
        public static void CreateListOfDays(Settings settings)
        {
            settings.WeekSettings.WeekDays.Clear();
                        
            if (settings.WeekSettings.Monday) settings.WeekSettings.WeekDays.Add(1);
            if (settings.WeekSettings.Tuesday) settings.WeekSettings.WeekDays.Add(2);
            if (settings.WeekSettings.Wednesday) settings.WeekSettings.WeekDays.Add(3);
            if (settings.WeekSettings.Thursday) settings.WeekSettings.WeekDays.Add(4);
            if (settings.WeekSettings.Friday) settings.WeekSettings.WeekDays.Add(5);
            if (settings.WeekSettings.Saturday) settings.WeekSettings.WeekDays.Add(6);
            if (settings.WeekSettings.Sunday) settings.WeekSettings.WeekDays.Add(7);

        }

        public static bool FirstDayChecking(Settings settings)
        {
            int WeekDay;
            WeekDay = (int)settings.TimeDate.DayOfWeek;
            if (WeekDay == 0) WeekDay = 7;
            int index = settings.WeekSettings.WeekDays.IndexOf(WeekDay);
            if (index == -1) return false;
            else return true;
        }

        public DateTime NextDate(Settings settings)
        {
            if (settings.Format == Format.Weekly) CreateListOfDays(settings);
            if (NumberOfDates == 0)
            {
                NumberOfDates++;
                settings.StartDate = settings.TimeDate;
                settings.TimeDate = ItsFirstDate(settings);
                return ItsFirstDate(settings);               
                
            } 
            else
            {
                return NotFirstDate(settings);
            }            
        }
        private static DateTime NotFirstDate(Settings settings)
        {
            DateTime candidate = CalculateDate(settings);
            if (!LastDate(candidate, settings))
            {
                settings.TimeDate = candidate;
                return settings.TimeDate;
            }
            else
            {
                return settings.TimeDate;
            }
        }

        private static bool LastDate(DateTime candidate, Settings settings)
        {
            return candidate > (settings.EndDate.AddDays(1) - settings.EndDate.TimeOfDay);
        }
        private static DateTime ItsFirstDate(Settings settings)
        {
            if (!FirstDayChecking(settings) && settings.Format == Format.Weekly)
            {
                SetTimeDate(settings);
                return NotFirstDate(settings);
            }
            else if (settings.Format == Format.Monthy)
            {
                SetTimeDate(settings);
                return ItsFirstDateMonthy(settings);
                

            }
            else
            {
                SetTimeDate(settings);
                return settings.TimeDate;
            }
        }
        private static DateTime ItsFirstDateMonthy(Settings settings)
        {
            DateTime actualTimeDate = settings.TimeDate;
            settings.TimeDate = settings.TimeDate.AddMonths(-1);
            int actualMonthNumber = settings.MonthSettings.MonthNum;
            settings.MonthSettings.MonthNum = 1;
            if (AreMoreDates(settings))
            {
                settings.TimeDate = NextDay.MonthyFormat(settings);
                if (actualTimeDate > settings.TimeDate) settings.TimeDate = NextDay.MonthyFormat(settings);
                settings.MonthSettings.MonthNum = actualMonthNumber;
                return settings.TimeDate;
            }
            else
            {
                settings.TimeDate = actualTimeDate;
                return settings.TimeDate;
            }
        }

        private static void SetTimeDate(Settings settings)
        {
            settings.TimeDate -= settings.TimeDate.TimeOfDay;
            settings.TimeDate += settings.StartTime.TimeOfDay;
        }

        
        private static bool AreMoreDates(Settings settings)
        {
            return NextDay.MonthyFormat(settings) < settings.EndDate.AddDays(1) - settings.EndDate.TimeOfDay;
        }
        

        public static DateTime CalculateDate(Settings settings)
        {
            if (IsOnce(settings)) 
            {
                return CalculateOnceDate(settings);
            }
            else
            {
                return CalculateRecurringDate(settings);                           
            }
        }  
        
        private static bool IsOnce(Settings settings)
        {
            return settings.StartTime.TimeOfDay == settings.EndTime.TimeOfDay;
        }

        private static DateTime CalculateOnceDate(Settings settings)
        {
            return settings.Format switch
            {
                Format.Monthy => NextDay.MonthyFormat(settings),
                Format.Weekly => settings.TimeDate.AddDays(NextDay.WeeklyFormat(settings)),
                _ => NextDay.DailyFormat(settings.TimeDate, settings),
            };
        }

        private static DateTime CalculateRecurringDate(Settings settings)
        {
            return settings.PeriodType switch
            {
                PeriodType.Minutes => NextMinute.Calculate(settings.TimeDate, settings),
                PeriodType.Seconds => NextSecond.Calculate(settings.TimeDate, settings),
                _ => NextHour.Calculate(settings.TimeDate, settings),
            };
        }


    }
}
