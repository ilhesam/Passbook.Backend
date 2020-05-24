using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels.Common;

namespace ApplicationCore.ViewModels
{
    public class PasswordGetDto : EntityGetDto, IPasswordProperty
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string UsedIn { get; set; }
    }
}
