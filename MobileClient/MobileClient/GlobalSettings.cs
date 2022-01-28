using System.Globalization;

namespace MobileClient
{
    internal class GlobalSettings
    {
        private static string ServerIp = "192.168.1.112";

        public const string DATABASE_NAME = "localProps.db";

        public const string ResourceId = "MobileClient.Resource";

        public static string AuthBaseAddress { get => $"http://{ServerIp}:5002"; }

        public static string ApiBaseAddress { get => $"http://{ServerIp}:5001"; }
    }
}
