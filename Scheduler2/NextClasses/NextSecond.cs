
namespace Scheduler2
{
    internal class NextSecond
    {
        public static DateTime WeeklyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            DateTime auxiliar = Current.AddSeconds(Settings.TimePeriod);
            if (auxiliar.Day != day | auxiliar.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                if (NextDay.WeeklyFormat(Settings) == 0)
                {
                    return Current;
                }
                Current -= Current.TimeOfDay;
                Current += Settings.StartTime.TimeOfDay;
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
            DateTime auxiliar = Current.AddSeconds(Settings.TimePeriod);
            if (auxiliar.Day != day | auxiliar.TimeOfDay > Settings.EndTime.TimeOfDay)
            {                
                Current -= Current.TimeOfDay;
                Current += Settings.StartTime.TimeOfDay;
                return NextDay.DailyFormat(Current, Settings);
            }
            else
            {
                return auxiliar;
            }

        }

        public static DateTime MonthyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            DateTime auxiliar = Current.AddSeconds(Settings.TimePeriod);
            if (auxiliar.Day != day | auxiliar.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current -= Current.TimeOfDay;
                Current += Settings.StartTime.TimeOfDay;
                return NextDay.MonthyFormat(Settings);
            }
            else
            {
                return auxiliar;
            }

        }
    }
}
