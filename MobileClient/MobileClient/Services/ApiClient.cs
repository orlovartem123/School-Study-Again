using MobileClient.DataContracts;
using System.Text.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Services
{
    public class ApiClient
    {
        private static HttpClient client = new HttpClient();

        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        private static void DefaultConnectAction(string baseAddress, double requestTimeout)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.Timeout = TimeSpan.FromSeconds(requestTimeout);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void ConnectAuth(double requestTimeout = GlobalSettings.DefaultRequestTimeout)
        {
            DefaultConnectAction(GlobalSettings.AuthBaseAddress, requestTimeout);
        }

        public static void ConnectApi(string token, double requestTimeout = GlobalSettings.DefaultRequestTimeout)
        {
            DefaultConnectAction(GlobalSettings.ApiBaseAddress, requestTimeout);
            client.DefaultRequestHeaders.Add("Authorization", token);
        }

        public static async Task<CustomHttpResponse> GetRequest(string requestUrl)
        {
            var response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<CustomHttpResponse>(await response.Content.ReadAsStringAsync(), options);
                return result;
            }

            return new CustomHttpResponse { StatusCode = response.StatusCode };
        }

        public static async Task<CustomHttpResponse> PostRequest<T>(string requestUrl, T model)
        {
            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, data);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonSerializer.Deserialize<CustomHttpResponse>(await response.Content.ReadAsStringAsync(), options);
                return result;
            }

            return new CustomHttpResponse { StatusCode = response.StatusCode };
        }
    }
}
