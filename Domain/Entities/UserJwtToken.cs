using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class UserJwtToken : Entity
    {
        public string AccessTokenHash { get; set; }

        public DateTime AccessTokenExpiresDateTime { get; set; }

        public Platform TokenPlatform { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
