using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    public class NextDayCheck
    {
        public static DateTime checkIfMustBeNextDay(DateTime current, DateTime auxiliar, Settings settings)
        {
            int day = current.Day;
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

        private static DateTime SetTimeDate(DateTime current, Settings settings)
        {
            current -= current.TimeOfDay;
            current += settings.StartTime.TimeOfDay;
            return current;
        }
    }
}
