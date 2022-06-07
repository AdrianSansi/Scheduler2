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
            if (weekDay == 0) weekDay = 7;
            int auxDay = weekDay;
            int index;
            int i = 0;
            weekDay = (weekDay + 1) % 7;
            if (weekDay == 0) weekDay = 7;
            while (i<8)
            {
                i++;
                index = Settings.WeekSettings.WeekDays.IndexOf(weekDay);
                if (index == -1) //El siguiente día no está marcado
                {
                    weekDay = (weekDay + 1) % 7;
                    if (weekDay == 0) weekDay = 7;  //Paso al siguiente
                }
                else //Si está marcado el siguiente, devuelvo ese menos la diferencia con el actual para sumarla luego
                {
                    if ((weekDay - auxDay) > 0)
                    {
                        return weekDay - auxDay;
                    }
                    else
                    {
                        return 7 * Settings.WeekPeriod + weekDay - auxDay;
                    }
                }
            }
            return 0;

        }
    }
}
