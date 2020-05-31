using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Validators.Common;
using ApplicationCore.ViewModels;
using FluentValidation;

namespace ApplicationCore.Validators
{
    public class MessageEditDtoValidator : EntityEditDtoValidator<MessageEditDto>
    {
        public MessageEditDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotNull()
                .WithMessage("عنوان پیام نمیتواند خالی باشد")
                .MaximumLength(256)
                .WithMessage("عنوان پیام نمیتواند بیش از 256 کاراکتر باشد");

            RuleFor(m => m.Body)
                .NotNull()
                .WithMessage("بدنه پیام نمیتواند خالی باشد")
                .MaximumLength(2048)
                .WithMessage("بدنه پیام نمیتواند بیش از 2048 کاراکتر باشد");
        }
    }
}
