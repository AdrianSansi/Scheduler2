
namespace Scheduler2
{
    public static class DescriptionClass
    {
        public static String Description(Settings Settings)
        {
            String description = "Occurs ";
            switch (Settings.Format)
            {
                case Format.Weekly:
                    description += WeeklyDescription(Settings);
                    break;
                case Format.Monthy:
                    description += MonthyDescription(Settings);
                    break;
                default:
                    description += OnceDescription(Settings);
                    break;
            }
            return description;
        }

        internal static String EnumerateWeekDays(Settings settings)
        {
            String[] weekDays = new String[7];
            int i = 0;           
            
            if (settings.WeekSettings.Monday)
            {
                weekDays[i] = " monday";
                i++;
            }
            if (settings.WeekSettings.Tuesday)
            {
                weekDays[i] = " tuesday";
                i++;
            }
            if (settings.WeekSettings.Monday)
            {
                weekDays[i] = " wednesday";
                i++;
            }
            if (settings.WeekSettings.Tuesday)
            {
                weekDays[i] = " thursday";
                i++;
            }
            if (settings.WeekSettings.Monday)
            {
                weekDays[i] = " friday";
                i++;
            }
            if (settings.WeekSettings.Tuesday)
            {
                weekDays[i] = " saturday";
                i++;
            }
            if (settings.WeekSettings.Tuesday)
            {
                weekDays[i] = " sunday";
                i++;
            }

            if (i == 1)
            {
                return weekDays[0];
            }
            else if (i > 1)
            {
                String text = "";
                for (int j = 0; j < i; j++)
                {
                    if (j == i - 2)
                    {
                        text = text + weekDays[j] + " and ";
                    }
                    else if (j == i - 1)
                    {
                        text = text + weekDays[j] + " ";
                    }
                    else
                    {
                        text = text + weekDays[j] + ", ";
                    }
                }
                return text;
            }
            else
            {
                return settings.TimeDate.DayOfWeek.ToString();
            }

        }

        internal static String WeeklyDescription(Settings Settings)
        {
            String description = "";
            description += "every " + Settings.WeekPeriod + " weeks";
            description += "on" + EnumerateWeekDays(Settings);

            if (Settings.StartTime.TimeOfDay == Settings.EndTime.TimeOfDay)
            {
                description += " once at " + Settings.StartTime.TimeOfDay.ToString();
            }
            else
            {
                description += " every " + Settings.TimePeriod + " " + Settings.PeriodType.ToString();
                description += " between " + Settings.StartTime.TimeOfDay.ToString() + " and " + Settings.EndTime.TimeOfDay.ToString();
            }
            description += " starting on " + Settings.StartDate.ToShortDateString();
            return description;
        }
        internal static String MonthyDescription(Settings Settings)
        {
            String description = "";
            if (Settings.MonthSettings.MonthlyFormat == MonthyFormat.FixedDay)
            {
                description += " the day number " + Settings.MonthSettings.DayNum.ToString();
                description += " of very " + Settings.MonthSettings.MonthNum + " months ";
            }
            else
            {
                description += " the " + Settings.MonthSettings.MonthlyFrequency.ToString();
                description += " " + Settings.MonthSettings.MonthDays.ToString();
                description += " of every " + Settings.MonthSettings.MonthNum.ToString() + " months ";
            }

            if (Settings.StartTime.TimeOfDay == Settings.EndTime.TimeOfDay)
            {
                description += " once at " + Settings.StartTime.TimeOfDay.ToString();
            }
            else
            {
                description += " every " + Settings.TimePeriod + " " + Settings.PeriodType.ToString();
                description += " between " + Settings.StartTime.TimeOfDay.ToString() + " and " + Settings.EndTime.TimeOfDay.ToString();
            }
            description += " starting on " + Settings.StartDate.ToShortDateString();
            return description;
        }
        internal static String OnceDescription(Settings Settings)
        {
            String description = "";
            if (Settings.StartTime.TimeOfDay == Settings.EndTime.TimeOfDay)
            {
                description += " once at " + Settings.StartTime.TimeOfDay.ToString();
            }
            else
            {
                description += " every " + Settings.TimePeriod + " " + Settings.PeriodType.ToString();
                description += " between " + Settings.StartTime.TimeOfDay.ToString() + " and " + Settings.EndTime.TimeOfDay.ToString();
            }
            description += " every " + Settings.DayPeriod.ToString() + " " + Settings.DaysPeriodType.ToString();
            description += " starting on " + Settings.StartDate.ToShortDateString();
            return description;
        }
    }
}
