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
         
        public Schedule(Settings Settings)
        {                      

        }
  
        public void CreateListOfDays(Settings Settings)
        {
            Settings.WeekSettings.WeekDays.Clear();
                        
            if (Settings.WeekSettings.Monday) Settings.WeekSettings.WeekDays.Add(1);
            if (Settings.WeekSettings.Tuesday) Settings.WeekSettings.WeekDays.Add(2);
            if (Settings.WeekSettings.Wednesday) Settings.WeekSettings.WeekDays.Add(3);
            if (Settings.WeekSettings.Thursday) Settings.WeekSettings.WeekDays.Add(4);
            if (Settings.WeekSettings.Friday) Settings.WeekSettings.WeekDays.Add(5);
            if (Settings.WeekSettings.Saturday) Settings.WeekSettings.WeekDays.Add(6);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(7);

        }

        public bool FirstDayChecking(Settings Settings)
        {
            int WeekDay;
            WeekDay = (int)Settings.TimeDate.DayOfWeek;
            if (WeekDay == 0) WeekDay = 7;
            int index = Settings.WeekSettings.WeekDays.IndexOf(WeekDay);
            if (index == -1) return false;
            else return true;
        }

        public void NextDate(Settings Settings)
        {
            if (Settings.Format == Format.Weekly) CreateListOfDays(Settings);
            if (NumberOfDates == 0)
            {
                NumberOfDates++; 
                if (!FirstDayChecking(Settings) && Settings.Format == Format.Weekly) NextDate(Settings);
                else Settings.TimeDate = Settings.TimeDate + Settings.StartTime.TimeOfDay;
            } 
            else
            {
                DateTime candidate = CalculateDate(Settings);
                if (candidate <=  (Settings.EndDate.AddDays(1)-Settings.EndDate.TimeOfDay)) 
                {
                    Settings.TimeDate = candidate;
                    NumberOfDates++;
                }
                else
                {

                }
            }
            
            
        } 

  
        

        public DateTime CalculateDate(Settings Settings)
        {
            switch (Settings.Format)
            {
                case Format.Weekly:

                    
                    if (DateTime.Compare(Settings.StartTime, Settings.EndTime) == 0) //Si ocurre una vez al día, pasar al siguiente día marcado 
                    {
                        return Settings.TimeDate.AddDays(NextDay.WeeklyFormat(Settings));
                    }
                    else
                    {
                        switch (Settings.PeriodType)
                        {
                            case PeriodType.Minutes:
                                return NextMinute.WeeklyFormat(Settings.TimeDate, Settings);
                            case PeriodType.Seconds:
                                return NextSecond.WeeklyFormat(Settings.TimeDate, Settings);
                            default:
                                return NextHour.WeeklyFormat(Settings.TimeDate, Settings);
                        }
                    }
                    
                default:
                    if (DateTime.Compare(Settings.StartTime, Settings.EndTime) == 0) //Si ocurre una vez al día, pasar al siguiente día marcado 
                    {
                        return NextDay.DailyFormat(Settings.TimeDate, Settings);
                    }
                    else
                    {
                        switch (Settings.PeriodType)
                        {
                            case PeriodType.Minutes:
                                return NextMinute.DailyFormat(Settings.TimeDate, Settings);
                            case PeriodType.Seconds:
                                return NextSecond.DailyFormat(Settings.TimeDate, Settings);
                            default:
                                return NextHour.DailyFormat(Settings.TimeDate, Settings);
                        }
                    }
            }
        }
    }
}
