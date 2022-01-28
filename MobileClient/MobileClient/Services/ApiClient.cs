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
        private static HttpClient client = new HttpClient();

        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static void ConnectAuth()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(GlobalSettings.AuthBaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void ConnectApi(string token)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(GlobalSettings.ApiBaseAddress);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<CustomHttpResponse> GetRequest(string requestUrl)
        {
            var response = await client.GetAsync(requestUrl);

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
