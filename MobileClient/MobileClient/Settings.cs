using System.Globalization;

namespace MobileClient
{
    internal class Settings
    {
        public const string AuthBaseAddress = "http://192.168.1.112:5002";

        public const string ApiBaseAddress = "http://192.168.1.112:5001/api";

        public static string DefaultErrorMessage { get => CultureInfo.CurrentCulture.EnglishName.Contains("Rus") ? "Неизвестная ошибка" : "Unknown error"; }
    }
}
