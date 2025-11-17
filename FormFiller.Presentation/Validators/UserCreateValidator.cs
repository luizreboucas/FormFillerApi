using System;
using System.IO.Compression;
using FluentValidation;
using FormFiller.Presentation.DTOs;

namespace FormFiller.Presentation.Validators;

public class UserCreateValidator: AbstractValidator<UserCreateDTO>
{
    public UserCreateValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Nome de usuário é obrigatório.")
            .MinimumLength(3).WithMessage("O nome de usuário deve ter no mínimo 3 caracteres.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Formato de email inválido.");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefone é obrigatório.")
            .Length(10, 11).WithMessage("O telefone deve ter entre 10 e 11 dígitos.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Senha é obrigatória.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
    }
}
