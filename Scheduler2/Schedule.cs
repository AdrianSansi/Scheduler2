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

    }
}
