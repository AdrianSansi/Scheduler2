
namespace Scheduler2
{
    internal static class NextMinute
    {
        public static DateTime Calculate(DateTime current, Settings settings)
        {            
            DateTime auxiliar = current.AddMinutes(settings.TimePeriod);
            return NextDayCheck.CheckIfMustBeNextDay(current, auxiliar, settings);            
        }
    }
}
