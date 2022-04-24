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
        public static async Task<List<ElectiveViewModel>> GetElectivesAsync()
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetElectives?teacherId={LocalPropsProviderService.TeacherId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<ElectiveViewModel>>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<ElectiveViewModel> GetElectiveAsync(int electiveId)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetElective?electiveId={electiveId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<ElectiveViewModel>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<string[]> AddElectiveAsync(ElectiveBindingModel elective)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/CreateOrUpdateElective", elective);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }
    }
}
