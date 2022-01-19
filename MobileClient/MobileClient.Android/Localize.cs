using MobileClient.Localization;
using Xamarin.Forms;
[assembly: Dependency(typeof(MobileClient.Droid.Localize))]

namespace MobileClient.Droid
{
    public class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new System.Globalization.CultureInfo(netLanguage);
        }
    }
}