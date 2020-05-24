using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels;
using Domain.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IPasswordService : IAsyncService
    <Password, PasswordAddDto, PasswordEditDto, PasswordGetDto>
    {
        Task<List<PasswordGetDto>> GetUserPasswordsAsync(string userId);

        Task<bool> ExistsAsync(string userId, string passwordId);

        Task<PasswordGetDto> AddAsync(string userId, PasswordAddDto passwordAddDto);

        Task<PasswordGetDto> UpdateAsync(string userId, string passwordId, PasswordEditDto passwordEditDto);
    }
}