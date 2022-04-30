﻿using MobileClient.DataContracts;
using MobileClient.Extensions;
using MobileClient.Models.Auth;
using MobileClient.Services.Settings;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileClient.Services.Auth
{
    internal class AuthService
    {
        /// <summary>
        /// Logout method
        /// </summary>
        /// <returns></returns>
        public static async Task Logout()
        {
            ApiClient.ConnectAuth();
            await ApiClient.GetRequest("MobileAccount/Logout");
            LocalPropsProviderService.Login = false;
            LocalPropsProviderService.AuthToken = string.Empty;
        }

        /// <summary>
        /// Check saved auth token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> IsAuthenticatedAsync(string token)
        {
            if (string.IsNullOrEmpty(token.Trim()))
                return false;

            ApiClient.ConnectApi(token);

            try
            {
                var result = await ApiClient.GetRequest("api/Teacher/Ping");

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    return true;
            }
            catch { }

            return false;
        }

        /// <summary>
        /// Sign in method
        /// </summary>
        /// <returns>Errors in form error\n error\n</returns>
        public static async Task<string> TrySignInAsync(SignInModel signIn)
        {
            ApiClient.ConnectAuth();

            var result = await ApiClient.PostRequest("MobileAccount/SignIn", signIn);

            if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result = await ApiClient.GetRequest("MobileAccount/Token");
                var obj = JsonSerializer.Deserialize<TokenResponseContent>(result.Data.ToString());
                LocalPropsProviderService.Login = true;
                LocalPropsProviderService.AuthToken = obj.Token;
                LocalPropsProviderService.TeacherId = obj.TeacherId;
                return string.Empty;
            }

            return result.GetErrors();
        }

        /// <summary>
        /// Sign up method
        /// </summary>
        /// <returns>Errors in form error\n error\n</returns>
        public static async Task<string> TrySignUp(SignUpModel signUp)
        {
            ApiClient.ConnectAuth();

            var result = await ApiClient.PostRequest("MobileAccount/SignUp", signUp);

            if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result = await ApiClient.GetRequest("MobileAccount/Token");
                LocalPropsProviderService.Login = true;
                LocalPropsProviderService.AuthToken = result.Data.ToString();
                return string.Empty;
            }

            return result.GetErrors();
        }
    }
}
