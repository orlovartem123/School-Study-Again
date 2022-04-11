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
                return JsonSerializer.Deserialize<List<ElectiveViewModel>>(result.Data.ToString());
            }

            return null;
        }
    }
}
