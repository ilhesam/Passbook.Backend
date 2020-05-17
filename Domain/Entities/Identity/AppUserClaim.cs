using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class AppUserClaim : IdentityUserClaim<string>
    {
    }
}
