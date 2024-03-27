using Common.Domain.Validations;
using Domain.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Domain.Validations
{
    public class CreateMotorcycleInvariants : AbstractValidator<Motorcycle>
    {
        
        public CreateMotorcycleInvariants()
        {
            RuleFor(x => x.Year)
                .InclusiveBetween((short)2000, (short)(DateTime.Today.Year + 1))
                .WithMessage("Ano da moto inválido");

            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("O modelo não pode ser vazio");

            RuleFor(x => x.Plate)
                .Must(PlateValidations.MustBeValidPlate)
                .WithMessage("Placa inválida");                
        }       
    }
}
