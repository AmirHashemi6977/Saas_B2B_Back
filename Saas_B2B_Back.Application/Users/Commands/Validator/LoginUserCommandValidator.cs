using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas_B2B_Back.Application.Users.Commands.Validator
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.PhoneNumber)
               .Matches(@"^\d{11}$").WithMessage("شماره موبایل باید ۱۱ رقمی باشد.")
               .When(x => !string.IsNullOrEmpty(x.PhoneNumber));


            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("فرمت ایمیل معتبر نیست.")
                .When(x => !string.IsNullOrEmpty(x.Email));


            RuleFor(x => x.NationalCode)
                .Matches(@"^\d{10}$").WithMessage("کد ملی باید ۱۰ رقم باشد.")
                .When(x => !string.IsNullOrEmpty(x.NationalCode));

            RuleFor(x => x.Password)
              .NotEmpty().WithMessage("رمز عبور الزامی است.")
              .MinimumLength(6).WithMessage("رمز عبور باید حداقل ۶ کاراکتر باشد.");

        }
    }
}
