using FluentValidation;
using FormFiller.Presentation.DTOs.Schema;

namespace FormFiller.Presentation.Validators;

public class SchemaCreateValidator : AbstractValidator<SchemaCreateDTO>
{
    public SchemaCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome do schema é obrigatório.")
            .MinimumLength(3).WithMessage("O nome do schema deve ter no mínimo 3 caracteres.");
        RuleFor(x => x.GeneratorsIds)
            .NotEmpty().WithMessage("Ao menos um generator é obrigatório.");
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId é obrigatório.");
    }
}
