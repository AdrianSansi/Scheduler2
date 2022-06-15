namespace Scheduler2
{
    public static class NextHour
    {
        public static DateTime Calculate(DateTime current, Settings settings)
        {
            DateTime auxiliar = current.AddHours(settings.TimePeriod);
            return NextDayCheck.checkIfMustBeNextDay(current, auxiliar, settings);            
        }
    }
}
