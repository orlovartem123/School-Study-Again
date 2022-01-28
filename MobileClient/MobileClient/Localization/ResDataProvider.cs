using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;

namespace MobileClient.Localization
{
    internal class ResDataProvider
    {
        private static readonly ResourceManager resmgr = new ResourceManager(GlobalSettings.ResourceId,
                         typeof(TranslateExtension).GetTypeInfo().Assembly);

        public static string DefaultErrorMessage
        {
            get
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

                return resmgr.GetString("DefaultErrorMessage", ci) ?? "DefaultErrorMessage";
            }
        }

        public static string EmptyLoginError
        {
            get
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

                return resmgr.GetString("EmptyLoginError", ci) ?? "EmptyLoginError";
            }
        }

        public static string EmptyPasswordError
        {
            get
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

                return resmgr.GetString("EmptyPasswordError", ci) ?? "EmptyPasswordError";
            }
        }

        public static string PasswordConfirmError
        {
            get
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

                return resmgr.GetString("PasswordConfirmError", ci) ?? "PasswordConfirmError";
            }
        }
    }
}
