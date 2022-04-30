using MobileClient.DataContracts;
using MobileClient.Models.Medals;
using MobileClient.Services.Settings;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileClient.Services.Medals
{
    public class MedalsService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static async Task<List<Medal>> GetMedalsAsync()
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetMedals?teacherId={LocalPropsProviderService.TeacherId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<Medal>>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<Medal> GetMedalAsync(int medalId)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetMedal?medalId={medalId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Medal>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<string[]> AddEditMedalAsync(MedalContract medal)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/CreateOrUpdateMedal", medal);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }

        public static async Task<string[]> DeleteMedalsAsync(IList<int> ids)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/DeleteMedals", ids);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }
    }
}
