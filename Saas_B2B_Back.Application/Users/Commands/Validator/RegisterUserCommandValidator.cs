using Saas_B2B_Back.Domain.Entities;
using FluentValidation;
using System.Linq;


namespace Saas_B2B_Back.Application.Users.Commands.Validator
{

    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {

            RuleFor(x => x.Firstname)
            .NotEmpty().WithMessage("نام الزامی است.")
            .MaximumLength(50).WithMessage("نام نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.");

            RuleFor(x => x.Lastname)
                .NotEmpty().WithMessage("نام خانوادگی الزامی است.")
                .MaximumLength(50).WithMessage("نام خانوادگی نمی‌تواند بیشتر از ۵۰ کاراکتر باشد.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("شماره موبایل الزامی است.")
                .Matches(@"^\d{11}$").WithMessage("شماره موبایل باید ۱۱ رقمی باشد.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("فرمت ایمیل معتبر نیست.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("رمز عبور الزامی است.")
                .MinimumLength(6).WithMessage("رمز عبور باید حداقل ۶ کاراکتر باشد.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("رمز عبور و تکرار آن باید یکسان باشند.");

            RuleFor(x => x.NationalCode)
                .Matches(@"^\d{10}$").WithMessage("کد ملی باید ۱۰ رقم باشد.")
                .When(x => !string.IsNullOrEmpty(x.NationalCode));

            RuleFor(x => x.UserGroupId)
                .Must(x => new[] { 1, 2, 3 }.Contains(x))
                .WithMessage("گروه کاربری نامعتبر است.");

            RuleFor(x => x.SexCode)
             .Must(x => x.HasValue && new[] { 1, 2 }.Contains((int)x.Value))
             .WithMessage("جنسیت کاربر نامعتبر می باشد.");


        }
    }
}
