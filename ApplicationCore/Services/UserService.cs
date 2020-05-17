using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        protected readonly IUserRepository AppUserRepository;
        protected readonly SignInManager<AppUser> SignInManager;
        protected readonly UserManager<AppUser> UserManager;

        public UserService(IUserRepository appUserRepository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            AppUserRepository = appUserRepository;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        public virtual async Task<AppUser> GetUserByUserNameAsync(string userName)
            => await AppUserRepository.SingleOrDefaultAsync(u => u.NormalizedUserName == userName.ToUpper());

        public virtual async Task<string> GetUserIdByUserNameAsync(string userName)
            => (await GetUserByUserNameAsync(userName)).Id;

        public virtual async Task<IdentityResult> SignUpAsync(RegisterDto userDto)
        {
            var user = new AppUser
            {
                UserName = userDto.UserName,
                Email = userDto.EmailAddress,
                EmailConfirmed = true
            };

            var identityResult = await UserManager.CreateAsync(user, userDto.Password);

            return identityResult;
        }

        public virtual async Task<SignInResult> SignInAsync(string userName, string password, bool lookoutOnFailure = true)
        {
            var user = await GetUserByUserNameAsync(userName);
            var signInResult = await SignInManager.CheckPasswordSignInAsync(user, password, lookoutOnFailure);

            return signInResult;
        }
    }
}
