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

        public static DateTime MonthlyFormat(Settings Settings)
        {
            if (Settings.MonthSettings.MonthlyFormat == Scheduler2.MonthlyFormat.FixedDay)
            {
                return FixedDay(Settings);
            }
            
            else
            {
                return DayOfWeek(Settings);
            }
            
        }

        internal static DateTime FixedDay(Settings Settings)
        {
            int currentMonth = Settings.TimeDate.Month;
            int sumMonths = Settings.MonthSettings.MonthNum;
            int nextMonth = (sumMonths + currentMonth) % 12;
            if(nextMonth == 0) nextMonth = 12;
            int nextYear = Settings.TimeDate.Year+(sumMonths+currentMonth-1)/12;
            DateTime Date = new DateTime(nextYear, nextMonth, Settings.MonthSettings.DayNum);
            return Date+Settings.StartTime.TimeOfDay;
        }

        internal static DateTime DayOfWeek(Settings Settings)
        {
            int currentMonth = Settings.TimeDate.Month;
            int sumMonths = Settings.MonthSettings.MonthNum;
            int nextMonth = (sumMonths + currentMonth) % 12;
            if (nextMonth == 0) nextMonth = 12;
            int nextYear = Settings.TimeDate.Year + (sumMonths + currentMonth-1) / 12;
            DateTime aux = new DateTime(nextYear, nextMonth, 1);
            
            switch (Settings.MonthSettings.MonthDays)
            {
                case MonthDays.Day:
                    return Settings.TimeDate;
                case MonthDays.Weekday:
                    return Settings.TimeDate;
                case MonthDays.WeekendDay:
                    return Settings.TimeDate;
                default:
                    return SpecificDay(Settings, aux);
            }
            
            // En este mes, ver cuál es el día indicado. Si es weekend y sabado, coger el domingo de current. Si no pasamos.
            // Si es weekday y no es viernes coger el siguiente día de la semana

        }

        //internal static DateTime Day(Settings Settings, DateTime Aux)
        //{
        //    return new DateTime(Aux.Year, Aux.Month, 1);
        //}

        //internal static DateTime WeekDay(Settings Settings, DateTime Aux)
        //{
        //    Aux =  new DateTime(Aux.Year, Aux.Month, 1);
        //    int day = (int)Aux.DayOfWeek;
        //    if(day == 0) day = 7;
        //    switch (day)
        //    {
        //        case 6: //its Saturday
        //            Aux = Aux.AddDays(2);
        //            return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
        //        case 7: // its Sunday
        //            Aux = Aux.AddDays(2);
        //            return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
        //        default:
        //            return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
        //    }
        //}

        //internal static DateTime WeekendDay(Settings Settings, DateTime Aux)
        //{
        //    Aux = new DateTime(Aux.Year, Aux.Month, 1);
        //    int day = (int)Aux.DayOfWeek;
        //    if (day == 0) day = 7;
        //    switch (day)
        //    {
        //        case 6: //its Saturday
        //            return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
        //        case 7: // its Sunday
        //            if (Settings.MonthSettings.MonthlyFrequency == MonthlyFrequency.First) return Aux;
        //            Aux = Aux.AddDays(-1);
        //            return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
        //        default:
        //            return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
        //    }
        //}

        internal static DateTime SpecificDay(Settings Settings, DateTime Aux)
        {
            Aux = new DateTime(Aux.Year, Aux.Month, 1);
            int day = (int)Aux.DayOfWeek;
            if (day == 0) day = 7;
            switch (Settings.MonthSettings.MonthDays)
            {
                case MonthDays.Monday:
                    Aux = Aux.AddDays(DaySum(day,1));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
                    case MonthDays.Tuesday:
                    Aux = Aux.AddDays(DaySum(day, 2));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
                case MonthDays.Wednesday:
                    Aux = Aux.AddDays(DaySum(day, 3));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
                case MonthDays.Thursday:
                    Aux = Aux.AddDays(DaySum(day, 4));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
                case MonthDays.Friday:
                    Aux = Aux.AddDays(DaySum(day, 5));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
                case MonthDays.Saturday:
                    Aux = Aux.AddDays(DaySum(day, 6));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);
                default:
                    Aux = Aux.AddDays(DaySum(day, 7));
                    return WeekSum(Settings.MonthSettings.MonthlyFrequency, Aux);

            }
        }

        internal static int DaySum(int day, int weekDay)
        {
            int sum = weekDay - day;
            if(sum == 0) return 0;
            if (sum > 0) return sum;
            return 7+sum;
        }
        internal static DateTime WeekSum(MonthlyFrequency frequency, DateTime Aux)
        {
            switch (frequency)
            {
                case MonthlyFrequency.First:
                    return Aux;
                case MonthlyFrequency.Second:
                    return Aux.AddDays(7);
                case MonthlyFrequency.Third:
                    return Aux.AddDays(14);
                case MonthlyFrequency.Fourth:
                    return Aux.AddDays(21);
                default:
                    if(Aux.AddDays(28).Month == Aux.Month) return Aux.AddDays(28);
                    else return Aux.AddDays(21);
            }            
        }
    }
}
