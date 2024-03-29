using Common.Domain.Validations;
using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class CreateCNHInvariants : AbstractValidator<CNH>
    {
        public CreateCNHInvariants()
        {
            RuleFor(x => x.Number.ToString())
              .Must(CNHValidations.MustBeValidCNHNumber)
              .WithMessage("O Numero da CNH é Invalido");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("O endereço da imagem não pode ser vazio");
        }
    }
}
