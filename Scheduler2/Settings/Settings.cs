using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class Settings
    {
        public DateTime CurrentDate { get; set; } = new DateTime();

        public DateTime TimeDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = DateTime.MaxValue.AddDays(-1);
        public DateTime StartDate { get; set; } = new DateTime();

        public DateTime EndTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        public DateTime StartTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        public WeekSettings WeekSettings { get; set; } = new WeekSettings();
        public int WeekPeriod { get; set; } = 1;
        public int TimePeriod { get; set; } = 1;
        public PeriodType PeriodType { get; set; } = PeriodType.Hours;

        public Format Format { get; set; } = Format.Daily;
        public int DayPeriod { get; set; } = 1;
        public DaysPeriodType DaysPeriodType{get; set; } = DaysPeriodType.Days;
       
        public MonthSettings MonthSettings { get; set; } = new MonthSettings();

        public Settings()
        {

        }
    }
}
