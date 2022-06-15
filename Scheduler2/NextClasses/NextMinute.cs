
namespace Scheduler2
{
    internal class NextMinute
    {
        public static DateTime Calculate(DateTime current, Settings settings)
        {            
            DateTime auxiliar = current.AddMinutes(settings.TimePeriod);
            return NextDayCheck.checkIfMustBeNextDay(current, auxiliar, settings);            
        }
    }
}
