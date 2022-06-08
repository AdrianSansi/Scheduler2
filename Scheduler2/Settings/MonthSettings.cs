namespace Scheduler2
{
    public class MonthSettings
    {
        public MonthlyFormat MonthlyFormat { get; set; } = MonthlyFormat.FixedDay;
        // The
        public MonthDays MonthDays { get; set; } = MonthDays.Day;
        public MonthlyFrequency MonthlyFrequency { get; set; } = MonthlyFrequency.First;

        // Day
        public int DayNum = 1;
        public int MonthNum = 1;



        public MonthSettings()
        {

        }
    }
}
