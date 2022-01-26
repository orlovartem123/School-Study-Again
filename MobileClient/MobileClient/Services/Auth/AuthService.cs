using MobileClient.DataContracts;
using MobileClient.Extensions;
using MobileClient.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileClient.Services.Auth
{
    internal class AuthService
    {
        /// <summary>
        /// Sign in method
        /// </summary>
        /// <returns>Array of errors</returns>
        public static async Task<string> TrySignIn(SignInModel signIn)
        {
            ApiClient.ConnectAuth();

            var result = await ApiClient.PostRequest("MobileAccount/SignIn", signIn);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Application.Current.Properties["login"] = true;
                Application.Current.Properties["authToken"] = (string)result.Data;
                return string.Empty;
            }

            return result.GetErrors();
        }

        /// <summary>
        /// Sign up method
        /// </summary>
        /// <returns>Array of errors</returns>
        //public static string[] TrySignUp(SignUpModel signUp)
        //{

        //}
    }
}
