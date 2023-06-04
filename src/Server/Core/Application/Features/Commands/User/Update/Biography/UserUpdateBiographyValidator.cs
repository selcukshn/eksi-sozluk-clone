using Common.Models.Command;
using FluentValidation;

namespace Application.Features.Commands.User.Update.Biography
{
    public class UserUpdateBiographyValidator : AbstractValidator<UserUpdateBiographyCommand>
    {
        public UserUpdateBiographyValidator()
        {
            RuleFor(e => e.UserId)
            .NotEmpty().WithMessage("{PropertyName} boş olamaz")
            .NotNull().WithMessage("{PropertyName} boş olamaz")
            .WithName("Kullanıcı Id");

            RuleFor(e => e.Biography)
            .MaximumLength(400).WithMessage("{PropertyName} maksimum {MaxLength} olabilir")
            .WithName("Biyografi");
        }
    }
}