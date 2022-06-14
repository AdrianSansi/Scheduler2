namespace Scheduler2
{
    public class MonthSettings
    {
        public MonthyFormat MonthlyFormat { get; set; } = MonthyFormat.FixedDay;
        // The
        public MonthDays MonthDays { get; set; } = MonthDays.Day;
        public MonthyFrequency MonthlyFrequency { get; set; } = MonthyFrequency.First;

        // Day
        public int DayNum = 1;
        public int MonthNum = 1;



        public MonthSettings()
        {

        }
    }
}
