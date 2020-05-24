using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces;
using ApplicationCore.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Authorize]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        private readonly IValidator<PasswordAddDto> _passwordAddDtoValidator;
        private readonly IValidator<PasswordEditDto> _passwordEditDtoValidator;

        public PasswordController(IPasswordService passwordService, IJwtService jwtService,
            IValidator<PasswordAddDto> passwordAddDtoValidator, IValidator<PasswordEditDto> passwordEditDtoValidator)
        {
            _passwordService = passwordService;
            _jwtService = jwtService;
            _passwordAddDtoValidator = passwordAddDtoValidator;
            _passwordEditDtoValidator = passwordEditDtoValidator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPasswords()
        {
            var token = HttpContext.GetAuthToken();
            var userJwtToken = await _jwtService.GetUserJwtTokenAsync(token);

            var passwords = await _passwordService.GetUserPasswordsAsync(userJwtToken.UserId);

            return Ok(passwords);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddPassword(PasswordAddDto passwordAddDto)
        {
            var validationResult = await _passwordAddDtoValidator.ValidateAsync(passwordAddDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { errorMessage = "اطلاعات به درستی وارد نشده است" });
            }

            var token = HttpContext.GetAuthToken();
            var userJwtToken = await _jwtService.GetUserJwtTokenAsync(token);

            await _passwordService.AddAsync(userJwtToken.UserId, passwordAddDto);

            return Ok(new { message = "رمز عبور با موفقیت اضافه شد" });
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> EditPassword(string id, PasswordEditDto passwordEditDto)
        {
            var validationResult = await _passwordEditDtoValidator.ValidateAsync(passwordEditDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { errorMessage = "اطلاعات به درستی وارد نشده است" });
            }

            var token = HttpContext.GetAuthToken();
            var userJwtToken = await _jwtService.GetUserJwtTokenAsync(token);
            var userId = userJwtToken.UserId;

            if (!await _passwordService.ExistsAsync(userId, id))
            {
                return NotFound(new { errorMessage = "رمز عبور مدنظر شما یافت نشد" });
            }

            await _passwordService.UpdateAsync(userId, id, passwordEditDto);

            return Ok(new { message = "رمز عبور با موفقیت ویرایش شد" });
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePassword(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var token = HttpContext.GetAuthToken();
            var userJwtToken = await _jwtService.GetUserJwtTokenAsync(token);

            if (!await _passwordService.ExistsAsync(userJwtToken.UserId, id))
            {
                return NotFound(new { errorMessage = "رمز عبور مدنظر شما یافت نشد" });
            }

            await _passwordService.DeleteAsync(id);

            return Ok(new { message = "رمز عبور با موفقیت حذف شد" });
        }
    }
}