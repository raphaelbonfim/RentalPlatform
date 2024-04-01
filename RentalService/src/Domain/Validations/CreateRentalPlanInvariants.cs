using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class CreateRentalPlanInvariants : AbstractValidator<RentalPlan>
    {
        public CreateRentalPlanInvariants()
        {
            RuleFor(x => x.Days)
              .NotEmpty()
              .WithMessage("Os dias do plano não pode ser vazios.");

            RuleFor(x => x.Price)
                .NotEmpty()                
                .WithMessage("O preço do plano não pode ser vazio.");

            RuleFor(x => x.PaymentFine)
                .NotEmpty()
                .WithMessage("A multa do plano não pode ser vazia.");

            RuleFor(x => x.ExtraDailyFee)
                .NotEmpty()
                .WithMessage("A multa extra por dia não pode ser vazia.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("A descrição do plano não pode ser vazia");        
        }
    }
}
