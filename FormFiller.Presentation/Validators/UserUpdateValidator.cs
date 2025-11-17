using FluentValidation;
using FormFiller.Presentation.DTOs.User;

namespace FormFiller.Presentation.Validators
{
    public class UserUpdateValidator: AbstractValidator<UserUpdateRequestDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.Username)
                .MinimumLength(3).WithMessage("O nome de usuário deve ter no mínimo 3 caracteres.");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Formato de email inválido.");
            RuleFor(x => x.Phone)
                .Length(10, 11).WithMessage("O telefone deve ter entre 10 e 11 dígitos.");
            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
        }
    }
}