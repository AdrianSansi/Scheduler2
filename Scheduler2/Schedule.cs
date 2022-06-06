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
                        
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(1);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(2);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(3);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(4);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(5);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(6);
            if (Settings.WeekSettings.Sunday) Settings.WeekSettings.WeekDays.Add(7);

        }

        public void NextDate(Settings Settings)
        {
            if (NumberOfDates == 0)
            {
                NumberOfDates++; 
                //Lo correcto sería añadir un método para validar el día actual, si es válido hago esto y si no, NextDay
                Settings.TimeDate = Settings.TimeDate + Settings.StartTime.TimeOfDay;
            } else
            {
                DateTime candidate = CalculateDate(Settings);
                if (candidate <=  Settings.EndDate.AddDays(1)) //Cambiar EndDate para que sea la fecha introducida y la hora final
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
                    CreateListOfDays(Settings);

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
                    break;
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


        //-------------------------------------------------------------------------------------------------------------

        public DateTime NextDayDailyFormat(DateTime current, Settings Settings)
        {
            switch (dayPeriodType)
            {
                case 1:
                    return current.AddDays(dayPeriod);
                case 2:
                    return current.AddDays(7 * dayPeriod);
                case 3:
                    return current.AddMonths(dayPeriod);
                default:
                    return current.AddDays(dayPeriod);

            }
        }
        //
        // Retorna la diferencia entre el siguiente día y el actual.
        //
        public int NextDayWeeklyFormat(Settings Settings)
        {
            int weekDay = (int)timeDate.DayOfWeek;
            int auxDay = weekDay;
            int index;
            weekDay = (weekDay + 1) % 7;
            while (auxDay != weekDay)
            {
                index = weekDays.IndexOf(weekDay);
                if (index == -1) //El siguiente día no está marcado
                {
                    weekDay = (weekDay + 1) % 7; //Paso al siguiente
                }
                else //Si está marcado el siguiente, devuelvo ese menos la diferencia con el actual para sumarla luego
                {
                    if ((weekDay - (int)timeDate.DayOfWeek) > 0)
                    {
                        return weekDay - (int)timeDate.DayOfWeek;
                    }
                    else
                    {
                        return 7 * weekPeriod + weekDay - (int)timeDate.DayOfWeek;
                    }
                }
            }
            return 0;
            
        }
       

        

        public DateTime nextHourF1(DateTime current, Settings Settings)
        {
            int day = current.Day;
            current = current.AddHours(timePeriod);
            if (current.Day != day | current.TimeOfDay > endTime.TimeOfDay)
            {
                current = current - current.TimeOfDay;
                current = current + startTime.TimeOfDay;
                return nextDayF1(current);
            }
            else
            {
                return current;
            }
        }


        public DateTime nextMinute(DateTime current, Settings Settings)
        {
            int day = current.Day;
            current = current.AddMinutes(timePeriod);
            if (current.Day != day | current.TimeOfDay > endTime.TimeOfDay)
            {
                current = current - current.TimeOfDay;
                current = current + startTime.TimeOfDay;

                return current.AddDays(nextDayF2());
            }
            else
            {
                return current;
            }
        }

        public DateTime nextSecond(DateTime current, Settings Settings)
        {
            int day = current.Day;
            current = current.AddSeconds(timePeriod);
            if (current.Day != day | current.TimeOfDay > endTime.TimeOfDay)
            {
                current = current - current.TimeOfDay;
                current = current + startTime.TimeOfDay;

                return current.AddDays(nextDayF2());
            }
            else
            {
                return current;
            }
        }

        
        }

        public DateTime nextMinuteF1(DateTime current, Settings Settings)
        {
            int day = current.Day;
            current = current.AddMinutes(timePeriod);
            if (current.Day != day | current.TimeOfDay > endTime.TimeOfDay)
            {
                current = current - current.TimeOfDay;
                current = current + startTime.TimeOfDay;
                return nextDayF1(current);
            }
            else
            {
                return current;
            }

        }

        public DateTime nextSecondF1(DateTime current, Settings Settings)
        {
            int day = current.Day;
            current = current.AddSeconds(timePeriod);
            if (current.Day != day | current.TimeOfDay > endTime.TimeOfDay)
            {
                current = current - current.TimeOfDay;
                current = current + startTime.TimeOfDay;
                return nextDayF1(current);
            }
            else
            {
                return current;
            }

        }




    }
}
