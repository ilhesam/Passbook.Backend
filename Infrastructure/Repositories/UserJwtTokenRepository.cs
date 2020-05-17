using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class UserJwtTokenRepository : AsyncRepository<UserJwtToken>, IUserJwtTokenRepository
    {
        public UserJwtTokenRepository(PassbookDbContext db) : base(db)
        {
        }
    }
}
