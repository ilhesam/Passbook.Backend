using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore.Services
{
    public class PasswordService : AsyncService
        <Password, PasswordAddDto, PasswordEditDto, PasswordGetDto>,
        IPasswordService
    {
        protected readonly IPasswordRepository PasswordRepository;
        protected readonly string CryptoPassword;

        public PasswordService(IPasswordRepository repository, IMapper mapper, IConfiguration config) : base(repository, mapper)
        {
            PasswordRepository = repository;
            CryptoPassword = config["Crypto:Password"];
        }

        public virtual async Task<List<PasswordGetDto>> GetUserPasswordsAsync(string userId)
            => await PasswordRepository.GetAllByUserId(userId)
                .Select(p => Mapper.Map<Password, PasswordGetDto>(p))
                .ToListAsync();

        public async Task<bool> ExistsAsync(string userId, string passwordId)
            => await PasswordRepository.ExistsAsync
                (p => p.Id == passwordId && p.UserId == userId);

        public async Task<PasswordGetDto> AddAsync(string userId, PasswordAddDto passwordAddDto)
        {
            var password = MapAddDtoToEntity(passwordAddDto);
            password.UserId = userId;

            return await AddAsync(password);
        }

        public async Task<PasswordGetDto> UpdateAsync(string userId, string passwordId, PasswordEditDto passwordEditDto)
        {
            var entity = MapEditDtoToEntity(passwordEditDto);
            entity.UserId = userId;

            return await UpdateAsync(passwordId, entity);
        }
    }
}
