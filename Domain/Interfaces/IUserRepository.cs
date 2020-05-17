using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser> AddAsync(AppUser user);

        Task<AppUser> SingleOrDefaultAsync(Expression<Func<AppUser, bool>> expression);
    }
}
