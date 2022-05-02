using MobileClient.DataContracts;
using MobileClient.Extensions;
using MobileClient.Models.Auth;
using MobileClient.Services.Settings;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileClient.Services.Auth
{
    internal class AuthService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

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
                LocalPropsProviderService.AuthToken = obj.Token;
                LocalPropsProviderService.Login = true;

                var info = await GetTeacherInfo(obj.TeacherId);

                LocalPropsProviderService.TeacherId = info.Id.ToString();
                LocalPropsProviderService.Name = info.Name;
                LocalPropsProviderService.SurName = info.Surname;

                return string.Empty;
            }

            return result.GetErrors();
        }

        /// <summary>
        /// Sign up method
        /// </summary>
        /// <returns>Errors in form error\n error\n</returns>
        public static async Task<string> TrySignUp(SignUpModel signUp, TeacherInfo info)
        {
            ApiClient.ConnectAuth();

            var result = await ApiClient.PostRequest("MobileAccount/SignUp", signUp);

            if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                result = await ApiClient.GetRequest("MobileAccount/Token");
                var obj = JsonSerializer.Deserialize<TokenResponseContent>(result.Data.ToString());
                LocalPropsProviderService.AuthToken = obj.Token;
                LocalPropsProviderService.Login = true;

                var contract = new TeacherContract
                {
                    Name = info.Name,
                    Surname = info.Surname,
                    Position = "teacher",
                    Email = signUp.Login,
                    Login = signUp.Login,
                    Password = signUp.Password,
                    ExtId = obj.TeacherId
                };

                var createTeacherResult = await CreateTeacher(contract);

                LocalPropsProviderService.TeacherId = createTeacherResult.Id.ToString();
                LocalPropsProviderService.Name = createTeacherResult.Name;
                LocalPropsProviderService.SurName = createTeacherResult.Surname;

                return string.Empty;
            }

            return result.GetErrors();
        }

        public static async Task<Teacher> GetTeacherInfo(string extId)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/TeacherAccount/GetInfoByExtId?extId={extId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Teacher>(result.Data.ToString(), _jsonOptions);
            }

            throw new Exception("Cant get teacher");
        }

        public static async Task<Teacher> CreateTeacher(TeacherContract contract)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/TeacherAccount/CreateTeacher", contract);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Teacher>(result.Data.ToString(), _jsonOptions);
            }

            throw new Exception("Cant create teacher");
        }
    }
}
