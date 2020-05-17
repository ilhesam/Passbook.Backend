using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.ViewModels;
using FluentValidation;

namespace ApplicationCore.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.UserName)
                .MinimumLength(5)
                .WithMessage("نام کاربری نمیتواند کمتر از 5 حرف باشد")
                .MaximumLength(20)
                .WithMessage("نام کاربری نمیتواند بیش از 20 حرف باشد");

            RuleFor(r => r.EmailAddress)
                .MinimumLength(3)
                .WithMessage("آدرس ایمیل نمیتواند کمتر از 3 حرف باشد")
                .MaximumLength(150)
                .WithMessage("آدرس ایمیل نمیتواند بیش از 150 حرف باشد")
                .EmailAddress()
                .WithMessage("آدرس ایمیل به درستی وارد نشده است");

            RuleFor(r => r.Password)
                .MinimumLength(6)
                .WithMessage("رمز عبور نمیتواند کمتر از 6 حرف باشد")
                .MaximumLength(50)
                .WithMessage("رمز عبور نمیتواند بیش از 50 حرف باشد");
        }
    }
}
