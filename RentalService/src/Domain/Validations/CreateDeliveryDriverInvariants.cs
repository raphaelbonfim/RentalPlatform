using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class CreateDeliveryDriverInvariants : AbstractValidator<DeliveryDriver>
    {
        public CreateDeliveryDriverInvariants()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.");

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .WithMessage("O modelo não pode ser vazio");

            RuleFor(x => x.Birthdate)
                .NotEmpty()
                .WithMessage("A Data de nascimento não pode ser vazio");
        }

    }
}
