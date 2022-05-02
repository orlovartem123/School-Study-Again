using MobileClient.DataContracts;
using System.Text;

namespace MobileClient.Extensions
{
    public static class CustomHttpExtensions
    {
        public static string GetErrors(this CustomHttpResponse response)
        {
            if (response.Errors == null || response.Errors.Length == 0)
            {
                return string.Empty;
            }

            var result = new StringBuilder();
            foreach (var error in response.Errors)
                result.AppendLine(error);

            var resultString = result.ToString();
            if (resultString.Equals(string.Empty))
                resultString = Resource.DefaultErrorMessage;

            return resultString;
        }
    }
}
