using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationCore.Services
{
    public class JwtService : IJwtService
    {
        protected readonly IUserJwtTokenRepository UserJwtTokenRepository;
        protected readonly IUserService UserService;

        protected readonly string Issuer;
        protected readonly string Key;
        protected readonly double ExpirationInMinutes;

        public JwtService(IConfiguration config, IUserJwtTokenRepository userJwtTokenRepository, IUserService userService)
        {
            UserJwtTokenRepository = userJwtTokenRepository;
            UserService = userService;

            Issuer = config["Jwt:Issuer"];
            Key = config["Jwt:Key"];
            ExpirationInMinutes = double.Parse(config["Jwt:ExpirationInMinutes"]);
        }

        public virtual UserJwtTokenDto GenerateUserJwtToken(LoginDto userDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userDto.UserName),
                new Claim(JwtRegisteredClaimNames.AuthTime, DateTime.Now.ToString("MM/dd/yyyy"))
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Issuer,
                claims: claims,
                expires: DateTime.Now.AddMinutes(ExpirationInMinutes),
                signingCredentials: credentials
            );

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);

            var userJwtTokenDto = new UserJwtTokenDto
            {
                UserName = userDto.UserName,
                AccessToken = encodeToken,
                AccessTokenExpiresDateTime = DateTime.Now.AddMinutes(ExpirationInMinutes),
                TokenPlatform = userDto.Platform
            };

            return userJwtTokenDto;
        }

        public virtual async Task<UserJwtToken> SaveUserJwtTokenAsync(UserJwtTokenDto userJwtTokenDto)
        {
            var tokenHash = HashToken(userJwtTokenDto.AccessToken);

            var userJwtToken = new UserJwtToken
            {
                AccessTokenHash = tokenHash,
                AccessTokenExpiresDateTime = userJwtTokenDto.AccessTokenExpiresDateTime,
                TokenPlatform = userJwtTokenDto.TokenPlatform,
                UserId = await UserService.GetUserIdByUserNameAsync(userJwtTokenDto.UserName)
            };

            return await UserJwtTokenRepository.AddAsync(userJwtToken);
        }

        public virtual async Task<UserJwtTokenDto> GenerateAndSaveUserJwtTokenAsync(LoginDto userDto)
        {
            var userJwtTokenDto = GenerateUserJwtToken(userDto);

            await SaveUserJwtTokenAsync(userJwtTokenDto);

            return userJwtTokenDto;
        }

        public virtual string HashToken(string token) => token.EncodeTextMd5();

        public virtual async Task<bool> IsExistTokenAsync(string token)
        {
            var tokenHash = HashToken(token);

            return await UserJwtTokenRepository.ExistsAsync(u => u.AccessTokenHash == tokenHash);
        }

        public virtual async Task<UserJwtToken> GetUserJwtToken(string token)
        {
            var tokenHash = HashToken(token);

            var userJwtToken = await UserJwtTokenRepository.SingleOrDefaultAsync(
                u => u.AccessTokenHash == tokenHash
            );

            return userJwtToken;
        }

        public virtual async Task DeleteUserJwtTokenAsync(UserJwtToken userJwtToken)
            => await UserJwtTokenRepository.DeleteAsync(userJwtToken);

        public virtual async Task DeleteUserJwtTokenAsync(string token)
        {
            var userJwtToken = await GetUserJwtToken(token);
            await DeleteUserJwtTokenAsync(userJwtToken);
        }
    }
}
