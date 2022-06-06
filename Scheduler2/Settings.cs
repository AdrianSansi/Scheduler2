using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class Settings
    {
        public DateTime currentDate { get; set; } = new DateTime();

        public DateTime timeDate { get; set; } = new DateTime();
        public DateTime endDate { get; set; } = new DateTime();

        public DateTime endTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        public DateTime startTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);

        public WeekSettings weekSettings { get; set; } = new WeekSettings();

        List<int> weekDays = new List<int>();

        public int weekPeriod { get; set; } = 1;
        public int timePeriod { get; set; } = 0;
        public PeriodType PeriodType { get; set; } = PeriodType.Hours;

        public Format Format { get; set; } = Format.Daily;
        public int numberOfDates { get; set; } = 0;
        public int dayPeriod { get; set; } = 1;
        public DaysPeriodType DaysPeriodType{get; set; } = DaysPeriodType.Days;
       
        public Settings()
        {

        }
    }
}
