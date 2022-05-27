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
        
        
        public DateTime endTime { get; set; } = new DateTime();
        public DateTime startTime { get; set; } = new DateTime();   

        public bool monday { get; set; } = false;
        public bool tuesday { get; set; } = false;
        public bool wednesday { get; set; } = false;
        public bool thursday { get; set; } = false;
        public bool friday { get; set; } = false;
        public bool saturday { get; set; } = false;
        public bool sunday { get; set; } = false;   

        List<int> weekDays = new List<int>();

        public int weekPeriod { get; set; } = 1;
        public int hourPeriod { get; set; } = 0;
        public int numberOfDates = 0;


        public Schedule(DateTime date)
        {
            currentDate = DateTime.Today;
        }
        public Schedule()
        {
            
        }
   
        public void sumOnePeriod(string period, int numPeriod)
        {
            switch (period)
            {
                case "hour":
                    timeDate.AddHours(numPeriod);
                    break;
                case "day":
                    timeDate = timeDate.AddDays(numPeriod);
                    break;
                case "week":
                    timeDate=timeDate.AddDays(numPeriod*7);
                    break;
                case "month":
                    timeDate = timeDate.AddMonths(numPeriod);
                    break;
                default:
                    timeDate = timeDate.AddYears(numPeriod);
                    break;
            }
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
                if (candidate < endDate)
                {
                    timeDate = candidate;
                    numberOfDates++;
                }
                else
                {

                }
            }
            
            
        }

        
        public DateTime calculateDate()
        {
            createListOfDays();

            if (DateTime.Compare(startTime, endTime) == 0) //Si ocurre una vez al día, pasar al siguiente día marcado 
            {
                return timeDate.AddDays(nextDay());
            }
            else
            {
                return nextHour(timeDate);
            }

        }
        //
        // Retorna la diferencia entre el siguiente día y el actual.
        //
        public int nextDay()
        {
            int weekDay = (int)timeDate.DayOfWeek;
            int auxDay = weekDay;
            int index;
            weekDay = (weekDay+1)%7;
            while (auxDay != weekDay)
            {
                index = weekDays.IndexOf(weekDay);
                if (index == -1) //El siguiente día no está marcado
                {
                    weekDay = (weekDay + 1) % 7; //Paso al siguiente
                }
                else //Si está marcado el siguiente, devuelvo ese menos la diferencia con el actual para sumarla luego
                {
                    if ((weekDay- (int)timeDate.DayOfWeek) > 0){
                        return weekDay - (int)timeDate.DayOfWeek;
                    }
                    else
                    {
                        return 7*weekPeriod + weekDay - (int)timeDate.DayOfWeek;
                    }
                }
            }
            return 0;
            
        }
        public int nextDay(DateTime current)
        {
            int weekDay = (int)current.DayOfWeek;
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
                    if ((weekDay - (int)current.DayOfWeek) > 0)
                    {
                        return weekDay - (int)current.DayOfWeek;
                    }
                    else
                    {
                        return 7*weekPeriod + weekDay - (int)current.DayOfWeek;
                    }
                }
            }
            return 0;

        }

        public DateTime nextHour(DateTime current)
        {
            int day = current.Day;
            current = current.AddHours(hourPeriod);
            if(current.Day != day | current.TimeOfDay>endTime.TimeOfDay)
            {
                current = current - current.TimeOfDay;
                current = current + startTime.TimeOfDay;                

                return current.AddDays(nextDay());
            }
            else
            {
                return current;
            }
            
        }

        

        

    }
}
