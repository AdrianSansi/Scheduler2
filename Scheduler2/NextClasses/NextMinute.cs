
namespace Scheduler2
{
    internal class NextMinute
    {
        public static DateTime WeeklyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            Current = Current.AddMinutes(Settings.TimePeriod);
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

        public static DateTime DailyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            Current = Current.AddMinutes(Settings.TimePeriod);
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
