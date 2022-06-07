
namespace Scheduler2
{
    internal class NextMinute
    {
        public static DateTime WeeklyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            DateTime auxiliar = Current.AddMinutes(Settings.TimePeriod);
            if (auxiliar.Day != day | auxiliar.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current = Current - Current.TimeOfDay;
                Current = Current + Settings.StartTime.TimeOfDay;
                return Current.AddDays(NextDay.WeeklyFormat(Settings));
            }
            else
            {
                return auxiliar;
            }
        }

        public static DateTime DailyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            DateTime auxiliar = Current.AddMinutes(Settings.TimePeriod);
            if (auxiliar.Day != day | auxiliar.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current = Current - Current.TimeOfDay;
                Current = Current + Settings.StartTime.TimeOfDay;
                return NextDay.DailyFormat(Current, Settings);
            }
            else
            {
                return auxiliar;
            }

        }
    }
}
