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
        
        public DateTime hourTime { get; set; } = new DateTime();
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

        public int weekPeriod { get; set; } = 0;
        public int hourPeriod { get; set; } = 0;



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

        
        public void calculateDate()
        {
            createListOfDays();

            if (DateTime.Compare(startTime, endTime) == 0) //Si ocurre una vez al día, pasar al siguiente día marcado 
            {
                if (nextDay() == 0) timeDate = timeDate.AddDays(7);
                else timeDate = timeDate.AddDays(nextDay());
            }
            else
            {
                nextHour(timeDate);
            }
        }
        //
        // Retorna el número del siguiente día, si no encuentra porque no hay días marcados, retorna -1.
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
                        return 7 + weekDay - (int)timeDate.DayOfWeek;
                    }
                }
            }
            return 0;
            
        }

        public void nextHour(DateTime current)
        {
            int day = timeDate.Day;
            current.AddHours(hourPeriod);
            if(day != current.Day | current.TimeOfDay>endTime.TimeOfDay)
            {
                timeDate = timeDate - timeDate.TimeOfDay;
                timeDate = timeDate + startTime.TimeOfDay;                

                if (nextDay() == 0) timeDate.AddDays(7);
                else timeDate.AddDays(nextDay());
            }
            else
            {
                timeDate = current;
            }
            
        }

        

        

    }
}
