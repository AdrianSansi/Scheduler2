
using System.Globalization;


namespace Scheduler2
{
    public static class SetTheCultureFormat
    {
        public static void SetCultureAndLanguage(Settings settings)
        {
            switch (settings.Language)
            {
                case Language.Spanish_Es:
                    CultureInfo.CurrentCulture = new CultureInfo("es-ES", false);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
                    break;
                case Language.English_UK:
                    CultureInfo.CurrentCulture = new CultureInfo("en-GB", false);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
                    break;
                case Language.English_US:
                    CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                    break;
                default:
                    break;
            }
        }
    }
}
