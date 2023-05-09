using Common.Models.Command;
using FluentValidation;

namespace Application.Features.Commands.User.Update
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateValidator()
        {
            RuleFor(e => e.Email)
            .NotNull()
            .EmailAddress()
            .WithName("E-posta adresi")
            .WithMessage("{PropertyName} boş veya yanlış formatta girilmiş.")
            .MaximumLength(100)
            .WithMessage("{PropertyName} en fazla 100 karakter uzunluğunda olabilir.");

            RuleFor(e => e.Username)
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(40)
            .WithName("Kullanıcı adı")
            .WithMessage("{PropertyName} {MinLength}-{MaxLength} karakter uzunluğunda olmalıdır.");
        }
    }
}