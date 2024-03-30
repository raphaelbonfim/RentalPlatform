using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class CreateOrderInvariatns : AbstractValidator<Order>
    {
        public CreateOrderInvariatns()
        {
            RuleFor(x => x.DeliveryFee)
                .NotEmpty()
                .WithMessage("A taxa de entrega não pode ser vazia.");
        }
    }
}
