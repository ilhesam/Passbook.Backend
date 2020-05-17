using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    // [EnableCors("CorsPolicy")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        private readonly IValidator<RegisterDto> _registerValidator;
        private readonly IValidator<LoginDto> _loginValidator;

        public AccountController(IJwtService jwtService, IUserService userService, IValidator<RegisterDto> registerValidator, IValidator<LoginDto> loginValidator)
        {
            _jwtService = jwtService;
            _userService = userService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            var validate = await _registerValidator.ValidateAsync(model);

            if (!validate.IsValid)
            {
                return BadRequest();
            }

            var identityResult = await _userService.SignUpAsync(model);

            if (identityResult.Succeeded)
            {
                return Ok(new { message = "حساب کاربری شما با موفقیت ایجاد شد!" });
            }

            var error = new { errorMessage = identityResult.Errors.First().Description };

            return BadRequest(error);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto userDto)
        {
            var validate = await _loginValidator.ValidateAsync(userDto);

            if (!validate.IsValid)
            {
                return BadRequest();
            }

            var signInResult = await _userService.SignInAsync(userDto.UserName, userDto.Password);

            if (signInResult.Succeeded)
            {
                var userJwtToken = await _jwtService.GenerateAndSaveUserJwtTokenAsync(userDto);

                return Ok(new
                {
                    message = "ورود به حساب کاربری با موفقیت انجام شد!",
                    token = userJwtToken.AccessToken
                });
            }

            var error = new { errorMessage = "نام کاربری یا رمز عبور وارد شده اشتباه می باشد" };

            if (signInResult.IsLockedOut)
            {
                error = new { errorMessage = "حساب کاربری شما به دلیل 5 بار ورود ناموفق به مدت 5 دقیقه قفل شده است" };
            }

            return BadRequest(error);
        }

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> Logout()
        {
            string authHeader = HttpContext.Request.Headers["Authorization"];
            var token = authHeader.Substring("Bearer ".Length);

            await _jwtService.DeleteUserJwtTokenAsync(token);
            return Ok(new { message = "با موفقیت از حساب کاربری خود خارج شدید" });
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult HelloWorld()
        {
            return Ok("Hello World");
        }

    }
}