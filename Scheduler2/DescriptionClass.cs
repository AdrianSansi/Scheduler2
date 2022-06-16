
using System.Text;

namespace Scheduler2
{
    public static class DescriptionClass
    {
        public static String Description(Settings Settings)
        {
            String description = "Occurs ";
            description += Settings.Format switch
            {
                Format.Weekly => WeeklyDescription(Settings),
                Format.Monthy => MonthyDescription(Settings),
                _ => OnceDescription(Settings),
            };
            return description;
        }


        private static String EnumerateWeekDays(Settings settings)
        {
            int i = settings.WeekSettings.WeekDays.Count;
            String[] weekDays = StringOfWeekDays(settings);
            if (i == 1)
            {
                return weekDays[0];
            }
            else if (i > 1)
            {
                var daysDescription = new StringBuilder();
                for (int j = 0; j < i; j++)
                {
                    daysDescription.Append(weekDays[j]);

                    if (j == i - 2)
                    {
                        daysDescription.Append(" and");
                    }
                    else if (j == i - 1)
                    {
                        daysDescription.Append(" ");
                    }
                    else
                    {
                        daysDescription.Append(",");
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
            if (settings.WeekSettings.Friday)
            {
                weekDays[i] = " friday";
                i++;
            }
            if (settings.WeekSettings.Saturday)
            {
                weekDays[i] = " saturday";
                i++;
            }
            if (settings.WeekSettings.Sunday)
            {
                weekDays[i] = " sunday";

            }

            return weekDays;

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
            description += $" starting on {Settings.StartDate:dd/MM/yyyy}";
            return description;
        }
        internal static String MonthyDescription(Settings Settings)
        {
            String description = "";
            if (Settings.MonthSettings.MonthlyFormat == MonthyFormat.FixedDay)
            {
                description += "the day number " + Settings.MonthSettings.DayNum.ToString();
                description += " of very " + Settings.MonthSettings.MonthNum + " months ";
            }
            else
            {
                description += "the " + Settings.MonthSettings.MonthlyFrequency.ToString().ToLower();
                description += " " + Settings.MonthSettings.MonthDays.ToString().ToLower();
                description += " of very " + Settings.MonthSettings.MonthNum.ToString() + " months ";
            }

            if (Settings.StartTime.TimeOfDay == Settings.EndTime.TimeOfDay)
            {
                description += "once at " + Settings.StartTime.TimeOfDay.ToString();
            }
            else
            {
                description += "every " + Settings.TimePeriod + " " + Settings.PeriodType.ToString().ToLower();
                description += " between " + Settings.StartTime.TimeOfDay.ToString() + " and " + Settings.EndTime.TimeOfDay.ToString();
            }
            description += $" starting on {Settings.StartDate:dd/MM/yyyy}";
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
                description += "every " + Settings.TimePeriod + " " + Settings.PeriodType.ToString().ToLower();
                description += " between " + Settings.StartTime.TimeOfDay.ToString() + " and " + Settings.EndTime.TimeOfDay.ToString();
            }
            description += "every " + Settings.DayPeriod.ToString() + " " + Settings.DaysPeriodType.ToString().ToLower();
            description += $" starting on{Settings.StartDate:dd/MM/yyyy}";
            return description;
        }
    }
}
