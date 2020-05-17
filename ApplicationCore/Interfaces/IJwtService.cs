using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels;
using Domain.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IJwtService
    {
        UserJwtTokenDto GenerateUserJwtToken(LoginDto userDto);

        Task<UserJwtToken> SaveUserJwtTokenAsync(UserJwtTokenDto userJwtTokenDto);

        Task<UserJwtTokenDto> GenerateAndSaveUserJwtTokenAsync(LoginDto userDto);

        string HashToken(string token);

        Task<bool> IsExistTokenAsync(string token);

        Task<UserJwtToken> GetUserJwtToken(string token);

        Task DeleteUserJwtTokenAsync(UserJwtToken userJwtToken);

        Task DeleteUserJwtTokenAsync(string token);
    }
}
