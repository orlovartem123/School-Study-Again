using MobileClient.DataContracts.Interfaces;
using System.Text;

namespace MobileClient.Models.Auth
{
    internal class SignInModel : IDataContractModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Validate()
        {
            var errors = new StringBuilder();

            if (string.IsNullOrEmpty(Login))
                errors.AppendLine(Resource.EmptyLoginError);

            if (string.IsNullOrEmpty(Password))
                errors.AppendLine(Resource.EmptyPasswordError);

            return errors.ToString();
        }
    }
}
