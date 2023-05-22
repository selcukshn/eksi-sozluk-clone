using Common.Models.Command;
using FluentValidation;

namespace Application.Features.Commands.User.Create
{
    public class UserCreateValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidator()
        {
            RuleFor(e => e.Username)
            .NotNull()
            .MinimumLength(6)
            .MaximumLength(40)
            .WithName("Kullanıcı adı")
            .WithMessage("{PropertyName} {MinLength}-{MaxLength} karakter uzunluğunda olmalıdır.");

            RuleFor(e => e.Email)
            .NotNull()
            .WithMessage("E-posta adresi boş olamaz")
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
            .WithMessage("{PropertyName} {MinLength}-{MaxLength} karakter uzunluğunda olmalıdır.")
            .Equal(e => e.RePassword)
            .WithMessage("{PropertyName}'ler birbiri ile uyuşmuyor.");
        }
    }
}