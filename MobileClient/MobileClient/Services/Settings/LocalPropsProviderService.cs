using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Services.Settings
{
    public class LocalPropsProviderService
    {
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
    }
}
