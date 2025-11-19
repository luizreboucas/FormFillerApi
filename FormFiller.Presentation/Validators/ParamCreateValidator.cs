using FluentValidation;
using FormFiller.Presentation.DTOs.Param;

namespace FormFiller.Presentation.Validators
{
    public class ParamCreateValidator: AbstractValidator<ParamCreateDTO>
    {
        public ParamCreateValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("O valor do parâmetro não pode ser vazio.")
                .MaximumLength(200).WithMessage("O valor do parâmetro não pode exceder 50 caracteres.");
            RuleFor(p => p.GeneratorId)
                .NotEmpty().WithMessage("O ID do gerador é obrigatório.");
        }
    }
}
