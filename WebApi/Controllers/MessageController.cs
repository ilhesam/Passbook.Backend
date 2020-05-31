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
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IJwtService _jwtService;

        private readonly IValidator<MessageAddDto> _messageAddDtoValidator;

        public MessageController(IMessageService messageService, IJwtService jwtService, IValidator<MessageAddDto> messageAddDtoValidator)
        {
            _messageService = messageService;
            _jwtService = jwtService;
            _messageAddDtoValidator = messageAddDtoValidator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddMessage(MessageAddDto messageAddDto)
        {
            var validationResult = await _messageAddDtoValidator.ValidateAsync(messageAddDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new { errorMessage = "در اعتبارسنجی مشکلی پیش آمده است" });
            }

            var token = HttpContext.GetAuthToken();
            var userJwtToken = await _jwtService.GetUserJwtTokenAsync(token);

            var messageGetDto = await _messageService.AddAsync(userJwtToken.UserId, messageAddDto);

            return Ok(new { messageObj = messageGetDto, message = "پیام با موفقیت اضافه شد" });
        }
    }
}