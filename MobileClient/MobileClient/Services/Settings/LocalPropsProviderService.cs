namespace MobileClient.Services.Settings
{
    public class LocalPropsProviderService
    {
        public static string UserName
        {
            get => App.Database.GetProps().UserName;
            set
            {
                var settings = App.Database.GetProps();
                settings.UserName = value;
                App.Database.ApplySettings(settings);
            }
        }

        public static bool Login
        {
            get => App.Database.GetProps().Login;
            set
            {
                var settings = App.Database.GetProps();
                settings.Login = value;
                App.Database.ApplySettings(settings);
            }
        }

        public static string AuthToken
        {
            get => App.Database.GetProps().AuthToken;
            set
            {
                var settings = App.Database.GetProps();
                settings.AuthToken = value;
                App.Database.ApplySettings(settings);
            }
        }

        public static string TeacherId
        {
            get
            {
                var result = App.Database.GetProps().TeacherId;

                if (int.TryParse(result, out int resultInt))
                {
                    return resultInt.ToString();
                }

                return "-900";
            }
            set
            {
                var settings = App.Database.GetProps();
                settings.TeacherId = value;
                App.Database.ApplySettings(settings);
            }
        }
    }
}
