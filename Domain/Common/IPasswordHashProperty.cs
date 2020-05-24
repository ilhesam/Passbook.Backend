using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public interface IPasswordHashProperty
    {
        string PasswordHash { get; set; }
    }
}
