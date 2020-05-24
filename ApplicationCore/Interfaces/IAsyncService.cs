using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels;
using Domain.Common;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncService<TEntity, TEntityAddDto, TEntityEditDto, TEntityGetDto>
    where TEntity : Entity
    where TEntityAddDto : EntityAddDto
    where TEntityEditDto : EntityEditDto
    where TEntityGetDto : EntityGetDto
    {
        Task<List<TEntityGetDto>> ListAllAsync();

        IQueryable<TEntityGetDto> GetAll();

        Task<TEntityGetDto> GetByIdAsync(string id);

        Task<TEntityEditDto> GetEditDtoByIdAsync(string id);

        Task<TEntityGetDto> AddAsync(TEntityAddDto entityAddDto);

        Task<TEntityGetDto> AddAsync(TEntity entity);

        Task<TEntityGetDto> UpdateAsync(string id, TEntityEditDto entityEditDto);

        Task<TEntityGetDto> UpdateAsync(string id, TEntity entity);

        Task<TEntityGetDto> UpdateAsync(TEntity entity);

        Task DeleteAsync(string id);

        Task<bool> ExistsByIdAsync(string id);
    }
}
