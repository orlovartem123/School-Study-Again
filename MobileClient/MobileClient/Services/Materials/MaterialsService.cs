using MobileClient.DataContracts;
using MobileClient.Models.Materials;
using MobileClient.Services.Settings;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileClient.Services.Materials
{
    public class MaterialsService
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public static async Task<List<Material>> GetMaterialsAsync()
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetMaterials?teacherId={LocalPropsProviderService.TeacherId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<Material>>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<List<Interest>> GetInterestsAsync()
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Student/GetInterests");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<List<Interest>>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<Material> GetMaterialAsync(int materialId)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.GetRequest($"api/Teacher/GetMaterial?materialId={materialId}");

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Material>(result.Data.ToString(), _jsonOptions);
            }

            return null;
        }

        public static async Task<string[]> AddEditMaterialAsync(MaterialContract material)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/CreateOrUpdateMaterial", material);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }

        public static async Task<string[]> DeleteMaterialsAsync(IList<int> ids)
        {
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var result = await ApiClient.PostRequest($"api/Teacher/DeleteMaterials", ids);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            return result.Errors;
        }
    }
}
