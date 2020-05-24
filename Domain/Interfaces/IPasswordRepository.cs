using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPasswordRepository : IAsyncRepository<Password>
    {
        IQueryable<Password> GetAllByUserId(string userId);
    }
}
