using MobileClient.DataContracts.Interfaces;
using MobileClient.Localization;
using System.Text;

namespace MobileClient.Models.Auth
{
    internal class SignUpModel : IDataContractModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Validate()
        {
            var errors = new StringBuilder();

            if (string.IsNullOrEmpty(Name))
                errors.AppendLine(Resource.EmptyNameError);

            if (string.IsNullOrEmpty(SurName))
                errors.AppendLine(Resource.EmptySurNameError);

            if (string.IsNullOrEmpty(Login))
                errors.AppendLine(ResDataProvider.EmptyLoginError);

            if (string.IsNullOrEmpty(Password))
                errors.AppendLine(ResDataProvider.EmptyPasswordError);

            if (Password == null || !Password.Equals(ConfirmPassword))
                errors.AppendLine(ResDataProvider.PasswordConfirmError);

            return errors.ToString();
        }
    }
}
