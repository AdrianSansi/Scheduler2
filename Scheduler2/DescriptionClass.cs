
using System.Text;

namespace Scheduler2
{
    public static class DescriptionClass
    {

        public static String Description(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.Occurs} ");
            if (CheckOnce(settings))
            {
                description.Append(OnceDescription(settings));
                return description.ToString();
            }
            description.Append(FormatSelect(settings));
            description.Append(EachDayDescription(settings));
            description.Append(StartingTime(settings));
            if(HasEnd(settings)) description.Append(EndTime(settings));
            return description.ToString();

        }

        public static String FormatSelect(Settings settings)
        {
            
            switch (settings.Format)
            {
                case Format.Daily:
                    return DailyDescription(settings);
                                       
                case Format.Monthy:
                    return MonthDescription(settings);
                    
                default:
                    return WeekDescription(settings);
                    
            }
        }

        private static String WeekDescription(Settings settings)
        {
            if (!DaySelected(settings)) throw new ArgumentException("There is no day of week selected");
            else
            {
                var description = new StringBuilder();
                description.Append(WeekPeriod(settings));
                description.Append(EnumerateWeekDays(settings));
                return description.ToString();
            }            
        }

        private static bool DaySelected(Settings settings)
        {
            return settings.WeekSettings.Monday || settings.WeekSettings.Tuesday || settings.WeekSettings.Wednesday || settings.WeekSettings.Thursday || settings.WeekSettings.Friday || settings.WeekSettings.Saturday || settings.WeekSettings.Sunday;
        }
        private static String WeekPeriod(Settings settings)
        {
            var weekPeriod = new StringBuilder();
            int numSemanas = settings.WeekPeriod;
            weekPeriod.Append($"{Strings.Every} {numSemanas} ");
            if (numSemanas == 1) weekPeriod.Append($"{Strings.Week} ");
            else weekPeriod.Append($"{Strings.Weeks} ");
            return weekPeriod.ToString();
        }

        private static String EnumerateWeekDays(Settings settings)
        {
            var daysDescription = new StringBuilder();
            daysDescription.Append($"{Strings.OnWeekDays} ");
            int i = settings.WeekSettings.WeekDays.Count;
            String[] weekDays = StringOfWeekDays(settings);
            if (i == 1)
            {
                daysDescription.Append($"{weekDays[0]} ");
                return daysDescription.ToString();
            }
            else if (i > 1)
            {
                
                for (int j = 0; j < i; j++)
                {
                    daysDescription.Append($"{weekDays[j]}");

                    if (j == i - 2)
                    {
                        daysDescription.Append($" {Strings.And} ");
                    }
                    else if(j < i - 2)
                    {
                        daysDescription.Append(", ");
                    }
                    else if(j == i - 1)
                    {
                        daysDescription.Append(' ');
                    }
                }
                return daysDescription.ToString();
            }
            else
            {
                return settings.TimeDate.DayOfWeek.ToString().ToLower();
            }
        }

        private static String[] StringOfWeekDays(Settings settings)
        {
            //settings.WeekSettings.WeekDays
            int i = 0;
            String[] weekDays = new String[7];


            if (settings.WeekSettings.Monday)
            {
                weekDays[i] = $"{Strings.Monday}";
                i++;
            }
            if (settings.WeekSettings.Tuesday)
            {
                weekDays[i] = $"{Strings.Tuesday}"; 
                i++;
            }
            if (settings.WeekSettings.Wednesday)
            {
                weekDays[i] = $"{Strings.Wednesday}";
                i++;
            }
            if (settings.WeekSettings.Thursday)
            {
                weekDays[i] = $"{Strings.Thursday}"; 
                i++;
            }
            if (settings.WeekSettings.Friday)
            {
                weekDays[i] = $"{Strings.Friday}";
                i++;
            }
            if (settings.WeekSettings.Saturday)
            {
                weekDays[i] = $"{Strings.Saturday}";
                i++;
            }
            if (settings.WeekSettings.Sunday)
            {
                weekDays[i] = $"{Strings.Sunday}";

            }

            return weekDays;

        }
        private static String MonthDescription(Settings settings)
        {
            var description = new StringBuilder();
            if (settings.MonthSettings.MonthyFormat == MonthyFormat.FixedDay)
            {
                description.Append(MonthFixedDay(settings));
            }
            else
            {
                description.Append(MonthyDayOfWeek(settings));
            }
            description.Append($"{Strings.OfVery} {settings.MonthSettings.MonthNum} ");
            if (settings.MonthSettings.MonthNum == 1) description.Append($"{Strings.Month} ");
            else description.Append($"{Strings.Months} ");
            return description.ToString();

        }
        private static String MonthFixedDay(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.The_male} {Strings.Day} {settings.MonthSettings.DayNum} ");
            return description.ToString();
        }
        private static String MonthyDayOfWeek(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.The_male} ");
            description.Append($"{OrderOfTheDay(settings)}");
            description.Append($"{DayOfTheWeek(settings)}");
            
            return description.ToString();
        }
        
        private static string OrderOfTheDay(Settings settings)
        {
            var description = new StringBuilder();
            switch (settings.MonthSettings.MonthyFrequency)
            {
            case MonthyFrequency.First:
                description.Append($"{Strings.First} ");
                break;
            case MonthyFrequency.Second:
                description.Append($"{Strings.Second} ");
                break;
            case MonthyFrequency.Third:
                description.Append($"{Strings.Third} ");
                break;
            case MonthyFrequency.Fourth:
                description.Append($"{Strings.Fourth} ");
                break;
            default:
                description.Append($"{Strings.Last} ");
                break;
            }
            return description.ToString();
        }

        private static string DayOfTheWeek(Settings settings)
        {
            var description = new StringBuilder();
            switch (settings.MonthSettings.MonthDays)
            {
                case MonthDays.Monday:
                    description.Append($"{Strings.Monday} ");
                    break;
                case MonthDays.Tuesday:
                    description.Append($"{Strings.Tuesday} ");
                    break;
                case MonthDays.Wednesday:
                    description.Append($"{Strings.Wednesday} ");
                    break;
                case MonthDays.Thursday:
                    description.Append($"{Strings.Thursday} ");
                    break;
                case MonthDays.Friday:
                    description.Append($"{Strings.Friday} ");
                    break;
                case MonthDays.Saturday:
                    description.Append($"{Strings.Saturday} ");
                    break;
                case MonthDays.Sunday:
                    description.Append($"{Strings.Sunday} ");
                    break;
                case MonthDays.Weekday:
                    description.Append($"{Strings.Weekday} ");
                    break;
                case MonthDays.WeekendDay:
                    description.Append($"{Strings.WeekendDay} ");
                    break;
                default:
                    description.Append($"{Strings.Day} ");
                    break;

            }
            return description.ToString();
        }

        private static string EachDayDescription(Settings settings)
        {
            var description = new StringBuilder();

            if (settings.StartTime.TimeOfDay == settings.EndTime.TimeOfDay)
            {
                description.Append($"{Strings.Once} ");
                description.Append($"{Strings.At} ");
                description.Append($"{settings.StartTime.TimeOfDay} ");
                return description.ToString();
            }            
            description.Append(EveryTimePeriod(settings));
            description.Append(TimePeriod(settings));
            description.Append(TimeRange(settings));
            return description.ToString();
        }

        private static string EveryTimePeriod(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.Every} ");
            description.Append($"{settings.TimePeriod} ");
            return description.ToString();
        }

        private static string TimePeriod(Settings settings)
        {
            var description = new StringBuilder();
            int numPeriod = settings.TimePeriod;
            switch (settings.PeriodType)
            {
                case PeriodType.Hours:
                    if (numPeriod == 1) description.Append($"{Strings.Hour} ");
                    else description.Append($"{Strings.Hours} ");
                    break;
                case PeriodType.Minutes:
                    if (numPeriod == 1) description.Append($"{Strings.Minute} ");
                    else description.Append($"{Strings.Minutes} ");
                    break;
                case PeriodType.Seconds:
                    if (numPeriod == 1) description.Append($"{Strings.Second} ");
                    else description.Append($"{Strings.Seconds} ");
                    break;
            }
            return description.ToString();
        }

        private static String TimeRange(Settings settings)
        {
            var description = new StringBuilder();
            TimeSpan start = settings.StartTime.TimeOfDay;
            TimeSpan end = settings.EndTime.TimeOfDay;
            description.Append($"{Strings.Between} ");
            description.Append($"{start} ");
            description.Append($"{Strings.And} ");
            description.Append($"{end} ");
            return description.ToString();
        }

        private static string StartingTime(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.Starting} ");
            string date = settings.StartDate.ToShortDateString();
            description.Append($"{date}");
            return description.ToString();
        }

        private static string DailyDescription(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.Every} ");
            int dayPeriod = settings.DayPeriod;
            bool everyTime = dayPeriod == 1;
            description.Append($"{dayPeriod} ");
            switch (settings.DaysPeriodType)
            {
                case DaysPeriodType.Days:
                    if (everyTime) description.Append($"{Strings.Day} ");
                    else description.Append($"{Strings.Days} ");
                    break;
                case DaysPeriodType.Weeks:
                    if (everyTime) description.Append($"{Strings.Week} ");
                    else description.Append($"{Strings.Weeks} ");
                    break;
                case DaysPeriodType.Months:
                    if (everyTime) description.Append($"{Strings.Month} ");
                    else description.Append($"{Strings.Months} ");
                    break;
                default:
                    if (everyTime) description.Append($"{Strings.Year} ");
                    else description.Append($"{Strings.Years} ");
                    break;
            }
            return description.ToString();
        }    
        
        private static bool CheckOnce(Settings settings)
        {
            if ((settings.StartDate.Date == settings.EndDate.Date) && (settings.StartTime.TimeOfDay == settings.EndTime.TimeOfDay)){
                return true;
            }
            return false;
        }
        private static string OnceDescription(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($"{Strings.Once} ");
            description.Append($"{Strings.At} ");
            description.Append($"{settings.StartTime.TimeOfDay} ");
            description.Append($"{Strings.OnDate} ");
            description.Append(settings.StartDate.ToShortDateString());
            return description.ToString();
        }
        private static bool HasEnd(Settings settings)
        {
            if (settings.EndDate > DateTime.MaxValue.AddDays(-100)) return false;
            return true;
        }
        private static string EndTime(Settings settings)
        {
            var description = new StringBuilder();
            description.Append($" {Strings.And} ");
            description.Append($"{Strings.Ending} ");
            description.Append($"{Strings.OnDate} ");
            string date = settings.EndDate.ToShortDateString();
            description.Append($"{date}");
            return description.ToString();
        }
    }
}
