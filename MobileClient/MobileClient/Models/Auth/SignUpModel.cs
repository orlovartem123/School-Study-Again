using MobileClient.DataContracts.Interfaces;
using System.Text;

namespace MobileClient.Models.Auth
{
    internal class SignUpModel : IDataContractModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Validate()
        {
            var errors = new StringBuilder();

            if (string.IsNullOrEmpty(Login))
                errors.AppendLine(Resource.EmptyLoginError);

            if (string.IsNullOrEmpty(Password))
                errors.AppendLine(Resource.EmptyPasswordError);

            if (Password == null || !Password.Equals(ConfirmPassword))
                errors.AppendLine(Resource.PasswordConfirmError);

            return errors.ToString();
        }
    }
}
