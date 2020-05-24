using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class PasswordRepository : AsyncRepository<Password>, IPasswordRepository
    {
        public PasswordRepository(PassbookDbContext db) : base(db)
        {
        }

        public IQueryable<Password> GetAllByUserId(string userId)
            => GetAll().Where(p => p.UserId == userId);
    }
}
