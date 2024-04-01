using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class CreateRentalInvariants : AbstractValidator<Rental>
    {
        public CreateRentalInvariants()
        {
            RuleFor(x => x.DeliveryDriverId)
                .NotEmpty()
                .WithMessage("O Id do entregador não pode ser vazio.");

            RuleFor(x => x.MotorcycleId)
                .NotEmpty()
                .WithMessage("O Id da moto não pode ser vazio.");

            RuleFor(x => x.RentalPlanId)
                .NotEmpty()
                .WithMessage("O Id do plano não pode ser vazio.");

            RuleFor(x => x.Days)
                .NotEmpty()
                .WithMessage("Os dias do plano não podem ser vazios.");

            RuleFor(x => x.PricePerDay)
                .NotEmpty()
                .WithMessage("O preço por dia não pode ser vazio.");
        }
    }
}
