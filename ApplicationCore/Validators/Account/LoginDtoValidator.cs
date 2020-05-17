using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels;
using FluentValidation;

namespace ApplicationCore.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l => l.UserName)
                .MinimumLength(5)
                .WithMessage("نام کاربری نمیتواند کمتر از 5 حرف باشد")
                .MaximumLength(20)
                .WithMessage("نام کاربری نمیتواند بیش از 20 حرف باشد");

            RuleFor(l => l.Password)
                .MinimumLength(6)
                .WithMessage("رمز عبور نمیتواند کمتر از 6 حرف باشد")
                .MaximumLength(50)
                .WithMessage("رمز عبور نمیتواند بیش از 50 حرف باشد");
        }
    }
}
