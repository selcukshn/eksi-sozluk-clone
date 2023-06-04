using Common.Models.Command;
using FluentValidation;

namespace Application.Features.Commands.User.Update.Image
{
    public class UserUpdateImageValidator : AbstractValidator<UserUpdateImageCommand>
    {
        public UserUpdateImageValidator()
        {
            RuleFor(e => e.UserId)
            .NotEmpty().WithMessage("{PropertyName} boş olamaz")
            .NotNull().WithMessage("{PropertyName} boş olamaz")
            .WithName("Kullanıcı Id");

            RuleFor(e => e.Image)
            .MaximumLength(2000).WithMessage("{PropertyName} maksimum {MaxLength} olabilir")
            .WithName("Resim");
        }
    }
}