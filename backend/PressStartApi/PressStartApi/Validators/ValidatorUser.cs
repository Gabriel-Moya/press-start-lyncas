using FluentValidation;
using FluentValidation.Results;
using PressStartApi.DTO;
using PressStartApi.Models;
using System.Text.RegularExpressions;

namespace PressStartApi.Validations
{
    public class ValidatorUser : AbstractValidator<InsertUserDTO>
    {
        public ValidatorUser()
        {
            Regex regexPhone = new Regex(@"^\(\d{2}\)\s\d{4,5}-\d{4}");
            Regex regexPassword = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[0-9])[0-9a-zA-Z$*&23]{6,}");

            RuleFor(user => user.Name)
                .NotNull()
                .WithMessage("Campo obrigatorio");

            RuleFor(user => user.Lastname)
                .NotNull()
                .WithMessage("Campo obrigatorio");

            RuleFor(user => user.Email)
                .NotNull()
                .EmailAddress()
                .WithMessage("Insira um email valido");

            RuleFor(user => user.Phone)
                .NotNull()
                .WithMessage("Campo obrigatorio")
                .Matches(regexPhone)
                .WithMessage("Por favor, digite um numero valido");

            RuleFor(user => user.BirthDate)
                .NotNull()
                .WithMessage("Campo obrigatorio");

            RuleFor(user => user.Password)
                .NotNull()
                .WithMessage("Por favor, insira uma senha")
                .Matches(regexPassword)
                .WithMessage("Senha nao atende os requisitos minimos de seguranca");
        }
    }
}
