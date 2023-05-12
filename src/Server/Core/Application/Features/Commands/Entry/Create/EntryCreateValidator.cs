using Common.Models.Command;
using FluentValidation;

namespace Application.Features.Commands.Entry.Create
{
    public class EntryCreateValidator : AbstractValidator<EntryCreateCommand>
    {
        public EntryCreateValidator()
        {
            RuleFor(e => e.UserId)
            .NotEmpty()
            .WithName("Kullanıcı id")
            .WithMessage("{PropertyName} boş olamaz");

            RuleFor(e => e.Subject)
            .NotNull()
            .WithName("Başlık")
            .WithMessage("{PropertyName} boş olamaz")
            .MaximumLength(200)
            .WithMessage("{PropertyName} en fazla {MaxLength} karakter olabilir");

            RuleFor(e => e.Content)
            .NotNull()
            .WithName("İçerik")
            .WithMessage("{PropertyName} boş olamaz")
            .MaximumLength(2000)
            .WithMessage("{PropertyName} en fazla {MaxLength} karakter olabilir");
        }
    }
}