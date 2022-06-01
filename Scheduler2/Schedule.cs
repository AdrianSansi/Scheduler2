using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class Schedule
    {
        public DateTime currentDate { get; set; } = new DateTime();

        public DateTime timeDate { get; set; } = new DateTime();
        public DateTime endDate { get; set; } = new DateTime();
        
        
        public DateTime endTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        public DateTime startTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);   

        public bool monday { get; set; } = false; public bool tuesday { get; set; } = false; public bool wednesday { get; set; } = false;
        public bool thursday { get; set; } = false; public bool friday { get; set; } = false; public bool saturday { get; set; } = false;
        public bool sunday { get; set; } = false;   

        List<int> weekDays = new List<int>();

        public int weekPeriod { get; set; } = 1;
        public int timePeriod { get; set; } = 0;
        public int periodType { get; set; } = 0; // 1 equals minutes, 2 equals seconds and default equals hours
        public int format { get; set; } = 1; // 2 if days are selected, 1 if not
        public int numberOfDates { get; set; } = 0;
        public int dayPeriod { get; set; } = 1;
        public int dayPeriodType { get; set; } = 1; //1 if days, 2 if weeks, 3 if months 

        public Schedule(DateTime current)
        {
            this.currentDate = current;
            this.timeDate = current;
            this.endDate = DateTime.MaxValue.AddDays(-1);
            

        }
  
        public void createListOfDays()
        {
            if (sunday) weekDays.Add(0);
            if (monday) weekDays.Add(1);
            if(tuesday) weekDays.Add(2);
            if(wednesday) weekDays.Add(3);
            if(thursday) weekDays.Add(4);
            if(friday) weekDays.Add(5);
            if(saturday) weekDays.Add(6);
            
        }

        public void nextDate()
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

       public DateTime nextDayF1(DateTime current)
        {
            switch (dayPeriodType)
            {
                case 1:
                    return current.AddDays(dayPeriod);
                case 2:
                    return current.AddDays(7*dayPeriod);
                case 3:
                    return current.AddMonths(dayPeriod);
                default:
                    return current.AddDays(dayPeriod);

            }
        }
        

        public DateTime calculateDate()
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
                        case 1:
                            return nextMinute(timeDate);
                        case 2:
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
                        case 1:
                            return nextMinuteF1(timeDate);
                        case 2:
                            return nextSecondF1(timeDate);
                        default:
                            return nextHourF1(timeDate);
                    }
                }
            }
            

        }
        //
        // Retorna la diferencia entre el siguiente día y el actual.
        //
        public int nextDayF2()
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
       

        public DateTime nextHour(DateTime current)
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

        public DateTime nextMinute(DateTime current)
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

        public DateTime nextSecond(DateTime current)
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

        public DateTime nextHourF1(DateTime current)
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

        public DateTime nextMinuteF1(DateTime current)
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

        public DateTime nextSecondF1(DateTime current)
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
