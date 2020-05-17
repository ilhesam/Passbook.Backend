using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ViewModels;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<AppUser> GetUserByUserNameAsync(string userName);

        Task<string> GetUserIdByUserNameAsync(string userName);

        Task<IdentityResult> SignUpAsync(RegisterDto userDto);

        Task<SignInResult> SignInAsync(string userName, string password, bool lookoutOnFailure = true);
    }
}
