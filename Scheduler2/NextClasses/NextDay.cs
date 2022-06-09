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

        public static DateTime MonthyFormat(Settings Settings)
        {
            if (Settings.MonthSettings.MonthlyFormat == Scheduler2.MonthyFormat.FixedDay)
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
                    aux = Day(Settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + Settings.StartTime.TimeOfDay;
                case MonthDays.Weekday:
                    aux = Weekday(Settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + Settings.StartTime.TimeOfDay;
                case MonthDays.WeekendDay:
                    return Settings.TimeDate;
                default:
                    aux = SpecificDay(Settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + Settings.StartTime.TimeOfDay;
            }
        }

        internal static DateTime Day(Settings settings, DateTime aux)
        {
            switch (settings.MonthSettings.MonthlyFrequency)
            {
                case MonthyFrequency.First:
                    return aux;
                case MonthyFrequency.Second:
                    return aux.AddDays(1);
                case MonthyFrequency.Third:
                    return aux.AddDays(2);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(3);
                default:
                    return LastDayOfMonth(aux);
            }
        }

        internal static DateTime LastDayOfMonth(DateTime aux)
        {
            switch (aux.Month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return new DateTime(aux.Year, aux.Month, 31);
                case 4: case 6: case 9: case 11: 
                    return new DateTime(aux.Year, aux.Month, 30);
                default:
                    if (aux.Year%4 == 0) return new DateTime(aux.Year, aux.Month, 29);
                    else  return new DateTime(aux.Year, aux.Month, 28);
            }
        } 

        internal static DateTime Weekday(Settings settings, DateTime aux)
        {
            switch ((int)aux.DayOfWeek)
            {
                case 0:
                    return FirstDayIsSundayAndIWantAWeekDay(settings.MonthSettings.MonthlyFrequency, aux);
                case 6:
                    return FirstDayIsSaturdayAndIWantAWeekDay(settings.MonthSettings.MonthlyFrequency, aux);
                default:
                    return FirstDayIsWeekDayAndIWantAWeekDay(settings.MonthSettings.MonthlyFrequency, aux);
            }
        }

        internal static DateTime FirstDayIsWeekDayAndIWantAWeekDay(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux;
                case MonthyFrequency.Second:
                    aux = aux.AddDays(1);
                    if((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    return aux;
                case MonthyFrequency.Third:
                    aux = aux.AddDays(2);
                    if((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    else if((int)aux.DayOfWeek == 0) return aux.AddDays(1);
                    else return aux;
                case MonthyFrequency.Fourth:
                    aux = aux.AddDays(2);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    else if ((int)aux.DayOfWeek == 0) return aux.AddDays(1);
                    else return aux;
                default:
                    aux = LastDayOfMonth(aux);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(-1);
                    else if ((int)aux.DayOfWeek == 0) return aux.AddDays(-2);
                    else return aux;
            }
        }
        internal static DateTime FirstDayIsSundayAndIWantAWeekDay(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux.AddDays(1);
                case MonthyFrequency.Second:
                    return aux.AddDays(2);
                case MonthyFrequency.Third:
                    return aux.AddDays(3);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(4);
                default:
                    aux = LastDayOfMonth(aux);
                    switch (aux.Day)
                    {
                        case 28: 
                            return aux.AddDays(-1);
                            case 29:
                            return aux.AddDays(-2);
                        default:
                            return aux;
                    }
            }
        }

        internal static DateTime FirstDayIsSaturdayAndIWantAWeekDay(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux.AddDays(1);
                case MonthyFrequency.Second:
                    return aux.AddDays(2);
                case MonthyFrequency.Third:
                    return aux.AddDays(3);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(4);
                default:
                    aux = LastDayOfMonth(aux);
                    switch (aux.Day)
                    {
                        case 29:
                            return aux.AddDays(-1);
                        case 30:
                            return aux.AddDays(-2);
                        default:
                            return aux;
                    }
            }
        }

        internal static DateTime WeekendDay(Settings settings, DateTime aux)
        {
            switch ((int)aux.DayOfWeek)
            {
                case 0:
                    return FirstDayIsSundayAndIWantAWeekendDay(settings.MonthSettings.MonthlyFrequency, aux);
                case 6:
                    return FirstDayIsSaturdayAndIWantAWeekendDay(settings.MonthSettings.MonthlyFrequency, aux);
                default:
                    return FirstDayIsWeekDayAndIWantAWeekendDay(settings.MonthSettings.MonthlyFrequency, aux);
            }
        }

        internal static DateTime FirstDayIsWeekDayAndIWantAWeekendDay(MonthyFrequency frequency, DateTime aux)
        {
            aux = aux.AddDays(6 - (int)aux.DayOfWeek); //now aux is a Saturday
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux;
                case MonthyFrequency.Second:
                    aux = aux.AddDays(1);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    return aux;
                case MonthyFrequency.Third:
                    aux = aux.AddDays(7);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    else if ((int)aux.DayOfWeek == 0) return aux.AddDays(1);
                    else return aux;
                case MonthyFrequency.Fourth:
                    aux = aux.AddDays(8);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    else if ((int)aux.DayOfWeek == 0) return aux.AddDays(1);
                    else return aux;
                default:
                    aux = LastDayOfMonth(aux);
                    if ((int)aux.DayOfWeek == 6 || (int)aux.DayOfWeek == 0) return aux;
                    else return aux.AddDays(-(int)aux.DayOfWeek);
            }
        }

        internal static DateTime FirstDayIsSundayAndIWantAWeekendDay(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux;
                case MonthyFrequency.Second:
                    return aux.AddDays(6);
                case MonthyFrequency.Third:
                    return aux.AddDays(7);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(13);
                default:
                    aux = LastDayOfMonth(aux);
                    switch (aux.Day)
                    {
                        case 31:
                            return aux.AddDays(-2);
                        case 30:
                            return aux.AddDays(-1);
                        default:
                            return aux;
                    }
            }
        }

        internal static DateTime FirstDayIsSaturdayAndIWantAWeekendDay(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux;
                case MonthyFrequency.Second:
                    return aux.AddDays(1);
                case MonthyFrequency.Third:
                    return aux.AddDays(7);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(8);
                default:
                    aux = LastDayOfMonth(aux);
                    switch (aux.Day)
                    {
                        case 31:
                            return aux.AddDays(-1);
                        case 28:
                            return aux.AddDays(-5);
                        default:
                            return aux;
                    }
            }
        }

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
        internal static DateTime WeekSum(MonthyFrequency frequency, DateTime Aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return Aux;
                case MonthyFrequency.Second:
                    return Aux.AddDays(7);
                case MonthyFrequency.Third:
                    return Aux.AddDays(14);
                case MonthyFrequency.Fourth:
                    return Aux.AddDays(21);
                default:
                    if(Aux.AddDays(28).Month == Aux.Month) return Aux.AddDays(28);
                    else return Aux.AddDays(21);
            }            
        }
    }
}
