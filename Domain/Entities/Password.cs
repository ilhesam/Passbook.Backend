using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Password : Entity, IPasswordHashProperty
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public string UsedIn { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
