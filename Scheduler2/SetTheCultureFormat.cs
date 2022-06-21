
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
                    break;
                case Language.English_UK:
                    CultureInfo.CurrentCulture = new CultureInfo("en-GB", false);
                    break;
                case Language.English_US:
                    CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
                    break;
                default:
                    break;
            }
        }
    }
}
