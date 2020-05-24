using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Validators.Common;
using ApplicationCore.ViewModels;
using FluentValidation;

namespace ApplicationCore.Validators.Password
{
    public class PasswordEditDtoValidator : EntityEditDtoValidator<PasswordEditDto>
    {
        public PasswordEditDtoValidator()
        {
            RuleFor(p => p.UserName)
                .MaximumLength(20)
                .WithMessage("نام کاربری نمیتواند بیش از 20 حرف باشد");

            RuleFor(p => p.EmailAddress)
                .MaximumLength(150)
                .WithMessage("آدرس ایمیل نمیتواند بیش از 150 حرف باشد");

            RuleFor(p => p.Password)
                .NotNull()
                .WithMessage("رمز عبور نمیتواند خالی باشد")
                .NotEmpty()
                .WithMessage("رمز عبور نمیتواند خالی باشد");

            RuleFor(p => p.UsedIn)
                .MaximumLength(1000)
                .WithMessage("مکان های مورد استفاده نمیتواند بیش از 1000 حرف باشد");
        }
    }
}
