using Common.Models.Command;
using FluentValidation;

namespace Application.Features.Commands.User.Login
{
    public class UserLoginValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginValidator()
        {
            RuleFor(e => e.Email)
            .NotNull()
            .EmailAddress()
            .WithName("E-posta adresi")
            .WithMessage("{PropertyName} boş veya yanlış formatta girilmiş.")
            .MaximumLength(100)
            .WithMessage("{PropertyName} en fazla 100 karakter uzunluğunda olabilir.");

            RuleFor(e => e.Password)
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(40)
            .WithName("Şifre")
            .WithMessage("{PropertyName} {MinLength}-{MaxLength} karakter uzunluğunda olmalıdır.");
        }
    }
}