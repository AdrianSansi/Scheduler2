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
            if (numberOfDates == 0)
            {
                numberOfDates++; 
                
                timeDate = timeDate + startTime.TimeOfDay;
            } else
            {
                DateTime candidate = calculateDate();
                if (candidate <=  endDate.AddDays(1))
                {
                    timeDate = candidate;
                    numberOfDates++;
                }
                else
                {

                }
            }
            
            
        } 

  
        

        public DateTime CalculateDate(Settings Settings)
        {
            if(format == 2)
            {
                createListOfDays();

                if (DateTime.Compare(startTime, endTime) == 0) //Si ocurre una vez al día, pasar al siguiente día marcado 
                {
                    return timeDate.AddDays(nextDayF2());
                }
                else
                {
                    switch (periodType)
                    {
                        case PeriodType.Minutes:
                            return nextMinute(timeDate);
                        case PeriodType.Seconds:
                            return nextSecond(timeDate);
                        default:
                            return nextHour(timeDate);
                    }
                }
            }
            else
            {
                if (DateTime.Compare(startTime, endTime) == 0) //Si ocurre una vez al día, pasar al siguiente día marcado 
                {
                    return nextDayF1(timeDate);
                }
                else
                {
                    switch (periodType)
                    {
                        case PeriodType.Minutes:
                            return nextMinuteF1(timeDate);
                        case PeriodType.Seconds:
                            return nextSecondF1(timeDate);
                        default:
                            return nextHourF1(timeDate);
                    }
                }
            }
            

        }

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
       

        public DateTime NextHour(DateTime current, Settings Settings)
        {
            int day = current.Day;
            current = current.AddHours(timePeriod);
            if(current.Day != day | current.TimeOfDay>endTime.TimeOfDay)
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
