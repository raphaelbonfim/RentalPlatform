using Domain.Models;
using FluentValidation;

namespace Domain.Validations
{
    public class UpdateCNHInvariants : AbstractValidator<CNH>
    {
        public UpdateCNHInvariants()
        {
            RuleFor(x => x.ImageUrl)
                .NotNull()
                .WithMessage("O caminho para a imagem da CNH não pode ser vazio.");
        }
    }
}
