using MobileClient.Models.Electives;
using MobileClient.Services.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileClient.Services.Electives
{
    public class ElectivesService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        /// <summary>
        /// Get electives from api
        /// </summary>
        /// <returns></returns>
        public static async Task<List<Elective>> GetElectivesAsync()
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetElectives?teacherId={LocalPropsProviderService.TeacherId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<Elective>>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<Elective> GetElectiveAsync(int electiveId)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetElective?electiveId={electiveId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Elective>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<string[]> AddElectiveAsync(ElectiveContract elective)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/CreateOrUpdateElective", elective);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }

        public static async Task<string[]> DeleteElectivesAsync(IList<int> ids)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/DeleteElectives", ids);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }
    }
}
