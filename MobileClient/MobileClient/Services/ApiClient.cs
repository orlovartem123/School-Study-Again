using MobileClient.DataContracts;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileClient.Services
{
    public class ApiClient
    {
        private static readonly HttpClient client = new HttpClient();

        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static void ConnectAuth()
        {
            client.BaseAddress = new Uri(Settings.AuthBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void ConnectApi(string token)
        {
            client.BaseAddress = new Uri(Settings.ApiBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
        }

        public static async Task<CustomHttpResponse> GetRequest<T>(string requestUrl)
        {
            var response = await client.GetAsync(requestUrl);

            var result = JsonSerializer.Deserialize<CustomHttpResponse>(await response.Content.ReadAsStringAsync(), options);
            return result;
        }

        public static async Task<CustomHttpResponse> PostRequest<T>(string requestUrl, T model)
        {
            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, data);

            var result = JsonSerializer.Deserialize<CustomHttpResponse>(await response.Content.ReadAsStringAsync(), options);
            return result;
        }
    }
}
