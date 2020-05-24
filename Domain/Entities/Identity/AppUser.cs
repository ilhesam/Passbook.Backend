using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<UserJwtToken> JwtTokens { get; set; }

        public virtual ICollection<Password> Passwords { get; set; }
    }
}
