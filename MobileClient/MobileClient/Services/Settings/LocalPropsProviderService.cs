namespace MobileClient.Services.Settings
{
    public class LocalPropsProviderService
    {
        public static string Name
        {
            get => App.Database.GetProps().Name;
            set
            {
                var settings = App.Database.GetProps();
                settings.Name = value;
                App.Database.ApplySettings(settings);
            }
        }

        public static string SurName
        {
            get => App.Database.GetProps().SurName;
            set
            {
                var settings = App.Database.GetProps();
                settings.SurName = value;
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
