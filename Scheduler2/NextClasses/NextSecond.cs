
namespace Scheduler2
{
    internal class NextSecond
    {
        public static DateTime Calculate(DateTime current, Settings settings)
        {
            DateTime auxiliar = current.AddSeconds(settings.TimePeriod);
            return NextDayCheck.checkIfMustBeNextDay(current, auxiliar, settings);
        }
        
    }
}
