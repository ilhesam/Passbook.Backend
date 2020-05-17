using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserJwtTokenRepository : IAsyncRepository<UserJwtToken>
    {
    }
}
