namespace Scheduler2
{
    public class NextHour
    {
        private static DateTime SetTimeDate(DateTime current, Settings settings)
        {
            current -= current.TimeOfDay;
            current += settings.StartTime.TimeOfDay;
            return current;
        }

        public static DateTime Calculate(DateTime current, Settings settings)
        {
            int day = current.Day;
            DateTime auxiliar = current.AddHours(settings.TimePeriod);
            if (auxiliar.Day != day || auxiliar.TimeOfDay > settings.EndTime.TimeOfDay)
            {
                switch (settings.Format)
                {
                    case Format.Weekly:
                        if (NextDay.WeeklyFormat(settings) == 0)
                        {
                            return current;
                        }
                        current = SetTimeDate(current, settings);
                        return current.AddDays(NextDay.WeeklyFormat(settings));
                    case Format.Monthy:
                        current = SetTimeDate(current, settings);
                        return NextDay.MonthyFormat(settings);
                    default:
                        current = SetTimeDate(current, settings);
                        return NextDay.DailyFormat(current, settings);

                }
            }
            else
            {
                return auxiliar;
            }
        }


    }
}
