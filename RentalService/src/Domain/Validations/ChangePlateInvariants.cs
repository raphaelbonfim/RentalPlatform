using Common.Domain.Validations;
using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class ChangePlateInvariants : AbstractValidator<Motorcycle>
    {        
        public ChangePlateInvariants()
        {
            RuleFor(x => x.Plate)
               .Must(PlateValidations.MustBeValidPlate)
               .WithMessage("Placa inválida");
        }       
    }
}
