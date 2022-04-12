using FluentValidation;
using PressStartApi.DTO.Request;
using System.Text.RegularExpressions;

namespace PressStartApi.Validators
{
    public class ValidatorUpdateUser : AbstractValidator<UpdateUserDTO>
    {
        public ValidatorUpdateUser()
        {
            Regex regexPhone = new Regex(@"^\(\d{2}\)\s\d{4,5}-\d{4}");
            Regex regexPassword = new Regex(@"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[0-9])[0-9a-zA-Z$*&23]{6,}");

            RuleFor(user => user.Name)
                .NotNull()
                .WithMessage("Campo obrigatorio");

            RuleFor(user => user.Lastname)
                .NotNull()
                .NotEmpty()
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

            When(x => x.Password != null && x.Password != "", () =>
            {
                RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor, insira uma senha")
                .Matches(regexPassword)
                .WithMessage("Senha nao atende os requisitos minimos de seguranca");
            });
        }
    }
}
