using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class CloseRentalMotorcycleInvariants : AbstractValidator<Rental>
    {
        public CloseRentalMotorcycleInvariants()
        {
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage("A data de devolução da moto não pode ser vazia.");

            RuleFor(x => x.TotalValue)
                .GreaterThan(0)
                .WithMessage("Total inválido");
        }
    }
}
