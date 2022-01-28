using MobileClient.DataContracts.Interfaces;
using MobileClient.Localization;
using System;
using System.Collections.Generic;
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
                errors.AppendLine(ResDataProvider.EmptyLoginError);

            if (string.IsNullOrEmpty(Password))
                errors.AppendLine(ResDataProvider.EmptyPasswordError);

            return errors.ToString();
        }
    }
}
