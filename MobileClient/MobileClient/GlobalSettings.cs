using System.Globalization;

namespace MobileClient
{
    internal class GlobalSettings
    {
        public static string ServerIp = "192.168.1.112";

        public const string DATABASE_NAME = "localProps.db";

        public const string ResourceId = "MobileClient.Resource";

        public const double DefaultRequestTimeout = 10;

        public static string AuthBaseAddress { get => $"http://{ServerIp}:5002"; }

        public static string ApiBaseAddress { get => $"http://{ServerIp}:5001"; }
    }
}
