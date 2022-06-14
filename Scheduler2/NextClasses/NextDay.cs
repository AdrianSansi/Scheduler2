namespace Scheduler2
{
    public class NextDay
    {
        public static DateTime DailyFormat(DateTime current, Settings settings)
        {
            switch (settings.DaysPeriodType)
            {
                case DaysPeriodType.Days:
                    return current.AddDays(settings.DayPeriod);
                case DaysPeriodType.Weeks:
                    return current.AddDays(7 * settings.DayPeriod);
                case DaysPeriodType.Months:
                    return current.AddMonths(settings.DayPeriod);
                default:
                    return current.AddYears(settings.DayPeriod);

            }
        }


        public static int WeeklyFormat(Settings settings)
        {
            int weekDay = (int)settings.TimeDate.DayOfWeek;
            if (weekDay == 0) weekDay = 7;
            int auxDay = weekDay;
            int index;
            int i = 0;
            weekDay = (weekDay + 1) % 7;
            if (weekDay == 0) weekDay = 7;
            while (i<8)
            {
                i++;
                index = settings.WeekSettings.WeekDays.IndexOf(weekDay);
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
                        return 7 * settings.WeekPeriod + weekDay - auxDay;
                    }
                }
            }
            return 0;

        }

        public static DateTime MonthyFormat(Settings settings)
        {
            if (settings.MonthSettings.MonthlyFormat == Scheduler2.MonthyFormat.FixedDay)
            {
                return FixedDay(settings);
            }
            
            else
            {
                return DayOfWeek(settings);
            }
            
        }

        internal static DateTime FixedDay(Settings settings)
        {
            int currentMonth = settings.TimeDate.Month;
            int sumMonths = settings.MonthSettings.MonthNum;
            int nextMonth = (sumMonths + currentMonth) % 12;
            if(nextMonth == 0) nextMonth = 12;
            int nextYear = settings.TimeDate.Year+(sumMonths+currentMonth-1)/12;
            DateTime Date = new DateTime(nextYear, nextMonth, settings.MonthSettings.DayNum);
            return Date+settings.StartTime.TimeOfDay;
        }

        internal static DateTime DayOfWeek(Settings settings)
        {
            int currentMonth = settings.TimeDate.Month;
            int sumMonths = settings.MonthSettings.MonthNum;
            int nextMonth = (sumMonths + currentMonth) % 12;
            if (nextMonth == 0) nextMonth = 12;
            int nextYear = settings.TimeDate.Year + (sumMonths + currentMonth-1) / 12;
            DateTime aux = new DateTime(nextYear, nextMonth, 1);
            
            switch (settings.MonthSettings.MonthDays)
            {
                case MonthDays.Day:
                    aux = Day(settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + settings.StartTime.TimeOfDay;
                case MonthDays.Weekday:
                    aux = Weekday(settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + settings.StartTime.TimeOfDay;
                case MonthDays.WeekendDay:
                    aux = WeekendDay(settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + settings.StartTime.TimeOfDay;
                default:
                    aux = SpecificDay(settings, aux);
                    aux -= aux.TimeOfDay;
                    return aux + settings.StartTime.TimeOfDay;
            }
        }

        private static DateTime Day(Settings settings, DateTime aux)
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

        private static DateTime LastDayOfMonth(DateTime aux)
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

        private static DateTime Weekday(Settings settings, DateTime aux)
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

        private static DateTime FirstDayIsWeekDayAndIWantAWeekDay(MonthyFrequency frequency, DateTime aux)
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
                    else if((int)aux.DayOfWeek == 0) return aux.AddDays(2);
                    else return aux;
                case MonthyFrequency.Fourth:
                    aux = aux.AddDays(3);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(2);
                    else if ((int)aux.DayOfWeek == 0) return aux.AddDays(2);
                    else if((int)aux.DayOfWeek == 1) return aux.AddDays(2);
                    else return aux;
                default:
                    aux = LastDayOfMonth(aux);
                    if ((int)aux.DayOfWeek == 6) return aux.AddDays(-1);
                    else if ((int)aux.DayOfWeek == 0) return aux.AddDays(-2);
                    else return aux;
            }
        }
        private static DateTime FirstDayIsSundayAndIWantAWeekDay(MonthyFrequency frequency, DateTime aux)
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

        private static DateTime FirstDayIsSaturdayAndIWantAWeekDay(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux.AddDays(2);
                case MonthyFrequency.Second:
                    return aux.AddDays(3);
                case MonthyFrequency.Third:
                    return aux.AddDays(4);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(5);
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

        private static DateTime WeekendDay(Settings settings, DateTime aux)
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

        private static DateTime FirstDayIsWeekDayAndIWantAWeekendDay(MonthyFrequency frequency, DateTime aux)
        {
            aux = aux.AddDays(6 - (int)aux.DayOfWeek); //now aux is a Saturday
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
                    if ((int)aux.DayOfWeek == 6 || (int)aux.DayOfWeek == 0) return aux;
                    else return aux.AddDays(-(int)aux.DayOfWeek);
            }
        }

        private static DateTime FirstDayIsSundayAndIWantAWeekendDay(MonthyFrequency frequency, DateTime aux)
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

        private static DateTime FirstDayIsSaturdayAndIWantAWeekendDay(MonthyFrequency frequency, DateTime aux)
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

        private static DateTime SpecificDay(Settings settings, DateTime aux)
        {
            aux = new DateTime(aux.Year, aux.Month, 1);
            int day = (int)aux.DayOfWeek;
            if (day == 0) day = 7;
            switch (settings.MonthSettings.MonthDays)
            {
                case MonthDays.Monday:
                    aux = aux.AddDays(DaySum(day,1));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);
                    case MonthDays.Tuesday:
                    aux = aux.AddDays(DaySum(day, 2));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);
                case MonthDays.Wednesday:
                    aux = aux.AddDays(DaySum(day, 3));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);
                case MonthDays.Thursday:
                    aux = aux.AddDays(DaySum(day, 4));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);
                case MonthDays.Friday:
                    aux = aux.AddDays(DaySum(day, 5));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);
                case MonthDays.Saturday:
                    aux = aux.AddDays(DaySum(day, 6));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);
                default:
                    aux = aux.AddDays(DaySum(day, 7));
                    return WeekSum(settings.MonthSettings.MonthlyFrequency, aux);

            }
        }

        private static int DaySum(int day, int weekDay)
        {
            int sum = weekDay - day;
            if(sum == 0) return 0;
            if (sum > 0) return sum;
            return 7+sum;
        }
        private static DateTime WeekSum(MonthyFrequency frequency, DateTime aux)
        {
            switch (frequency)
            {
                case MonthyFrequency.First:
                    return aux;
                case MonthyFrequency.Second:
                    return aux.AddDays(7);
                case MonthyFrequency.Third:
                    return aux.AddDays(14);
                case MonthyFrequency.Fourth:
                    return aux.AddDays(21);
                default:
                    if(aux.AddDays(28).Month == aux.Month) return aux.AddDays(28);
                    else return aux.AddDays(21);
            }            
        }
    }
}
