using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using AutoMapper;
using Domain.Common;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public abstract class AsyncService<TEntity, TEntityAddDto, TEntityEditDto, TEntityGetDto>
        : IAsyncService<TEntity, TEntityAddDto, TEntityEditDto, TEntityGetDto>
        where TEntity : Entity
        where TEntityAddDto : EntityAddDto
        where TEntityEditDto : EntityEditDto
        where TEntityGetDto : EntityGetDto
    {
        private readonly IAsyncRepository<TEntity> _repository;

        protected readonly IMapper Mapper;

        protected AsyncService(IAsyncRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            Mapper = mapper;
        }

        public virtual async Task<List<TEntityGetDto>> ListAllAsync() => await GetAll().ToListAsync();

        public virtual IQueryable<TEntityGetDto> GetAll() => _repository.GetAll()
            .Select(e => MapEntityToGetDto(e));

        public virtual async Task<TEntityGetDto> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return MapEntityToGetDto(entity);
        }

        public virtual async Task<TEntityEditDto> GetEditDtoByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return MapEntityToEditDto(entity);
        }

        public virtual async Task<TEntityGetDto> AddAsync(TEntityAddDto entityAddDto)
        {
            var entity = MapAddDtoToEntity(entityAddDto);

            return await AddAsync(entity);
        }

        public virtual async Task<TEntityGetDto> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);

            return MapEntityToGetDto(entity);
        }

        public virtual async Task<TEntityGetDto> UpdateAsync(string id, TEntityEditDto entityEditDto)
        {
            var entity = MapEditDtoToEntity(entityEditDto);

            return await UpdateAsync(id, entity);
        }

        public virtual async Task<TEntityGetDto> UpdateAsync(string id, TEntity entity)
        {
            var actualEntity = await _repository.GetByIdAsync(id);

            entity.Id = id;
            entity.CreatedDateTime = actualEntity.CreatedDateTime;

            return await UpdateAsync(entity);
        }

        public virtual async Task<TEntityGetDto> UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);

            return Mapper.Map<TEntity, TEntityGetDto>(entity);
        }

        public virtual async Task DeleteAsync(string id) => await _repository.DeleteAsync(id);

        public virtual async Task<bool> ExistsByIdAsync(string id) => await _repository.ExistsByIdAsync(id);

        #region Map Methods

        protected TDestination Map<TSource, TDestination>(TSource source)
            => Mapper.Map<TSource, TDestination>(source);

        protected TEntityGetDto MapEntityToGetDto(TEntity entity)
            => Map<TEntity, TEntityGetDto>(entity);

        protected TEntityEditDto MapEntityToEditDto(TEntity entity)
            => Map<TEntity, TEntityEditDto>(entity);

        protected TEntity MapAddDtoToEntity(TEntityAddDto entityAddDto)
            => Map<TEntityAddDto, TEntity>(entityAddDto);

        protected TEntity MapEditDtoToEntity(TEntityEditDto entityEditDto)
            => Map<TEntityEditDto, TEntity>(entityEditDto);

        #endregion
    }
}
