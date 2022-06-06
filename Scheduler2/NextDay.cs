namespace Scheduler2
{
    public class NextDay
    {
        public static DateTime DailyFormat(DateTime Current, Settings Settings)
        {
            switch (Settings.DaysPeriodType)
            {
                case DaysPeriodType.Days:
                    return Current.AddDays(Settings.DayPeriod);
                case DaysPeriodType.Weeks:
                    return Current.AddDays(7 * Settings.DayPeriod);
                case DaysPeriodType.Months:
                    return Current.AddMonths(Settings.DayPeriod);
                default:
                    return Current.AddYears(Settings.DayPeriod);

            }
        }


        public static int WeeklyFormat(Settings Settings)
        {
            int weekDay = (int)Settings.TimeDate.DayOfWeek;
            int auxDay = weekDay;
            int index;
            weekDay = (weekDay + 1) % 7;
            while (auxDay != weekDay)
            {
                index = Settings.WeekSettings.WeekDays.IndexOf(weekDay);
                if (index == -1) //El siguiente día no está marcado
                {
                    weekDay = (weekDay + 1) % 7; //Paso al siguiente
                }
                else //Si está marcado el siguiente, devuelvo ese menos la diferencia con el actual para sumarla luego
                {
                    if ((weekDay - (int)Settings.TimeDate.DayOfWeek) > 0)
                    {
                        return weekDay - (int)Settings.TimeDate.DayOfWeek;
                    }
                    else
                    {
                        return 7 * Settings.WeekPeriod + weekDay - (int)Settings.TimeDate.DayOfWeek;
                    }
                }
            }
            return 0;

        }
    }
}
