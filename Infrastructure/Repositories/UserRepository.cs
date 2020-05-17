using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly PassbookDbContext Db;
        protected readonly DbSet<AppUser> DbSet;

        public UserRepository(PassbookDbContext db)
        {
            Db = db;
            DbSet = Db.Set<AppUser>();
        }

        public virtual async Task<AppUser> AddAsync(AppUser user)
        {
            await DbSet.AddAsync(user);
            await Db.SaveChangesAsync();

            return user;
        }

        public virtual async Task<AppUser> SingleOrDefaultAsync(Expression<Func<AppUser, bool>> expression)
            => await DbSet.SingleOrDefaultAsync(expression);
    }
}
