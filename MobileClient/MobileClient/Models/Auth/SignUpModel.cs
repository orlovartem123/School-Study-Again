using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Models.Auth
{
    internal class SignUpModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
