namespace Scheduler2
{
    public class MonthSettings
    {
        public MonthyFormat MonthlyFormat { get; set; } = MonthyFormat.FixedDay;
        // The
        public MonthDays MonthDays { get; set; } = MonthDays.Day;
        public MonthyFrequency MonthlyFrequency { get; set; } = MonthyFrequency.First;

        // Day
        private int dayNum = 1;
        public int DayNum { 
            get { return dayNum; } 
            set { dayNum = value; } 
        }


        private int monthNum = 1;
        public int MonthNum
        {
            get { return monthNum; }
            set { monthNum = value; }
        }



        public MonthSettings()
        {

        }
    }
}
