using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class Settings
    {
        public int Id { get; set; }
        public int? WeekSettingsId { get; set; }
        public int? MonthSettingsId { get; set; }
        
        
        public Language Language { get; set; } = Language.Spanish_Es;
        public DateTime CurrentDate { get; set; } = DateTime.Today;

        public DateTime TimeDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.MaxValue.AddDays(-10);
        public DateTime StartDate { get; set; } = DateTime.Today;

        public DateTime EndTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        public DateTime StartTime { get; set; } = new DateTime(1900, 1, 1, 0, 0, 0);
        public virtual WeekSettings WeekSettings { get; set; } = new WeekSettings();
        public int WeekPeriod { get; set; } = 1;
        public int TimePeriod { get; set; } = 1;
        public PeriodType PeriodType { get; set; } = PeriodType.Hours;

        public Format Format { get; set; } = Format.Daily;
        public int DayPeriod { get; set; } = 1;
        public DaysPeriodType DaysPeriodType{get; set; } = DaysPeriodType.Days;
       
        public virtual MonthSettings MonthSettings { get; set; } = new MonthSettings();

        public int NumberOfDates = 0;

       
    }
}
