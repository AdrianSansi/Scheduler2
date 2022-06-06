using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler2
{
    internal class NextMinute
    {
        public DateTime WeeklyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            Current = Current.AddMinutes(Settings.TimePeriod);
            if (Current.Day != day | Current.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current = Current - Current.TimeOfDay;
                Current = Current + Settings.StartTime.TimeOfDay;

                return Current.AddDays(NextDay.WeeklyFormat(Settings));
            }
            else
            {
                return Current;
            }
        }

        public DateTime DailyFormat(DateTime Current, Settings Settings)
        {
            int day = Current.Day;
            Current = Current.AddMinutes(Settings.TimePeriod);
            if (Current.Day != day | Current.TimeOfDay > Settings.EndTime.TimeOfDay)
            {
                Current = Current - Current.TimeOfDay;
                Current = Current + Settings.StartTime.TimeOfDay;
                return NextDay.DailyFormat(Current, Settings);
            }
            else
            {
                return Current;
            }

        }
    }
}
