namespace Scheduler2
{
    public class NextHour
    {
        public static DateTime WeeklyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            Current = Current.AddHours(Settings.TimePeriod);
            if (Current.Day != day | Current.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current = Current - Current.TimeOfDay;
                Current = Current + Settings.StartTime.TimeOfDay;
                return Current.AddDays(NextDay.WeeklyFormat(Settings));
            }
            else
            {
                return Current;
            }
        }

        public DateTime DailyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            Current = Current.AddHours(Settings.TimePeriod);
            if (Current.Day != day | Current.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current = Current - Current.TimeOfDay;
                Current = Current + Settings.StartTime.TimeOfDay;
                return NextDay.DailyFormat(Current, Settings);
            }
            else
            {
                return Current;
            }
        }
    }
}
