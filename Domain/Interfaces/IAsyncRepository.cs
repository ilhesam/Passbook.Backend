using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(string id);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> ExistsByIdAsync(string id);
    }
}
