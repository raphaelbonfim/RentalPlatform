using Domain.Models;
using FluentValidation;
using System.Buffers.Text;

namespace Domain.Validations
{
    public class CreateDeliveryDriverInvariants : AbstractValidator<DeliveryDriver>
    {
        public CreateDeliveryDriverInvariants(string base64)
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

            RuleFor(x => base64)
                .Must(MustBeAcceptType)
                .WithMessage("Imagem CNH inválida. Tipos aceitos: PNG ou BMP");
        }

        public bool MustBeAcceptType(string base64)
        {
            var pngType = "iVB";
            var bmpType = "Qk2";

            return base64.StartsWith(pngType) || base64.StartsWith(bmpType);
        }

    }
}
