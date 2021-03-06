namespace Scheduler2
{
    public static class NextDay
    {
        public static DateTime DailyFormat(DateTime current, Settings settings)
        {
            return settings.DaysPeriodType switch
            {
                DaysPeriodType.Days => current.AddDays(settings.DayPeriod),
                DaysPeriodType.Weeks => current.AddDays(7 * settings.DayPeriod),
                DaysPeriodType.Months => current.AddMonths(settings.DayPeriod),
                DaysPeriodType.Years => current.AddYears(settings.DayPeriod),
                _ => current.AddYears(settings.DayPeriod),
            };
        }


        public static int WeeklyFormat(Settings settings)
        {
           
            int weekDay = ChangeWeekDayFormat((int)settings.TimeDate.DayOfWeek);
            int auxDay = weekDay;
            int index;
            int i = 0;
            weekDay = ChangeWeekDayFormat(weekDay + 1);
            
            while (i<8)
            {
                i++;
                index = settings.WeekSettings.WeekDays.IndexOf(weekDay);
                if (index == -1) //El siguiente día no está marcado
                {
                    weekDay = ChangeWeekDayFormat(weekDay + 1); //Paso al siguiente
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

        private static int ChangeWeekDayFormat(int weekDay)
        {
            weekDay %= 7;
            if (weekDay == 0) weekDay = 7;
            return weekDay;
        }

        public static DateTime MonthyFormat(Settings settings)
        {
            if (settings.MonthSettings.MonthyFormat == Scheduler2.MonthyFormat.FixedDay)
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
            DateTime Date = new (nextYear, nextMonth, settings.MonthSettings.DayNum);
            return Date+settings.StartTime.TimeOfDay;
        }

        internal static DateTime DayOfWeek(Settings settings)
        {
            int currentMonth = settings.TimeDate.Month;
            int sumMonths = settings.MonthSettings.MonthNum;
            int nextMonth = (sumMonths + currentMonth) % 12;
            if (nextMonth == 0) nextMonth = 12;
            int nextYear = settings.TimeDate.Year + (sumMonths + currentMonth-1) / 12;
            DateTime aux = new (nextYear, nextMonth, 1);
            
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
            return settings.MonthSettings.MonthyFrequency switch
            {
                MonthyFrequency.First => aux,
                MonthyFrequency.Second => aux.AddDays(1),
                MonthyFrequency.Third => aux.AddDays(2),
                MonthyFrequency.Fourth => aux.AddDays(3),
                MonthyFrequency.Last => LastDayOfMonth(aux),
                _ => LastDayOfMonth(aux),
            };
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
            return (int)aux.DayOfWeek switch
            {
                0 => FirstDayIsSundayAndIWantAWeekDay(settings.MonthSettings.MonthyFrequency, aux),
                6 => FirstDayIsSaturdayAndIWantAWeekDay(settings.MonthSettings.MonthyFrequency, aux),
                _ => FirstDayIsWeekDayAndIWantAWeekDay(settings.MonthSettings.MonthyFrequency, aux),
            };
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
                    if((int)aux.DayOfWeek == 6 || (int)aux.DayOfWeek == 0) return aux.AddDays(2);
                    else return aux;
                case MonthyFrequency.Fourth:
                    aux = aux.AddDays(3);
                    if ((int)aux.DayOfWeek == 6 || (int)aux.DayOfWeek == 0 || (int)aux.DayOfWeek == 1) return aux.AddDays(2);
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
                    return aux.Day switch
                    {
                        29 => aux.AddDays(-1),
                        30 => aux.AddDays(-2),
                        _ => aux,
                    };
            }
        }

        private static DateTime WeekendDay(Settings settings, DateTime aux)
        {
            switch ((int)aux.DayOfWeek)
            {
                case 0:
                    return FirstDayIsSundayAndIWantAWeekendDay(settings.MonthSettings.MonthyFrequency, aux);
                case 6:
                    return FirstDayIsSaturdayAndIWantAWeekendDay(settings.MonthSettings.MonthyFrequency, aux);
                default:
                    return FirstDayIsWeekDayAndIWantAWeekendDay(settings.MonthSettings.MonthyFrequency, aux);
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
            int day = ChangeWeekDayFormat((int)aux.DayOfWeek);
            
            switch (settings.MonthSettings.MonthDays)
            {
                case MonthDays.Monday:
                    aux = aux.AddDays(DaySum(day,1));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);
                    case MonthDays.Tuesday:
                    aux = aux.AddDays(DaySum(day, 2));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);
                case MonthDays.Wednesday:
                    aux = aux.AddDays(DaySum(day, 3));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);
                case MonthDays.Thursday:
                    aux = aux.AddDays(DaySum(day, 4));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);
                case MonthDays.Friday:
                    aux = aux.AddDays(DaySum(day, 5));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);
                case MonthDays.Saturday:
                    aux = aux.AddDays(DaySum(day, 6));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);
                default:
                    aux = aux.AddDays(DaySum(day, 7));
                    return WeekSum(settings.MonthSettings.MonthyFrequency, aux);

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
