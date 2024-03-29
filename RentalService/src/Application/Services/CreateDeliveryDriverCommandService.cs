using Application.DTOs.DeliveryDriver;
using Application.Services.Interfaces;
using Common.Application;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CreateDeliveryDriverCommandService : ICreateDeliveryDriverCommandService
    {
        private readonly IDeliveryDriverRepository _deliveryDriverRepository;

        public CreateDeliveryDriverCommandService(IDeliveryDriverRepository deliveryDriverRepository)
        {
            _deliveryDriverRepository = deliveryDriverRepository;
        }

        public async Task<OutCreateDeliveryDriverDTO> ProcessAsync(InCreateDeliveryDriverDTO dto, CancellationToken cancellationToken)
        {
            //Verificar se existe um CNPJ no banco
            var deliveryDriverCNPJ = await _deliveryDriverRepository.GetByCNPJAsync(dto.CNPJ);

            if (deliveryDriverCNPJ != null)
            {
                throw new BusinessException("Já existe esse CNPJ cadastrado no banco.");
            }

            //Verificar se existe um NumeroCNH no banco
            var deliveryDriverCNHNumber = await _deliveryDriverRepository.GetByCNHNumberAsync(dto.CNHNumber);

            if (deliveryDriverCNHNumber != null)
            {
                throw new BusinessException("Já existe essa CNH cadastrado no banco.");
            }

            //Converter a img Base64 em imagem e pegar o endereço do localStorage_NomeDoARquivo
            var cnhImageUrl = ReturnCNHImageUrl(dto.CNHBase64);

            //Converter o tipo da CNH de string pra enum
            var cnhType = ConvertCNHType(dto.CNHType);

            //Se nao, criar o aggregado DeliveryDriver

            var deliveryDriver = new DeliveryDriver(dto.Name, dto.CNPJ, dto.Birthdate, dto.CNHNumber, cnhImageUrl, cnhType);

            //Validar se é valido
            if (deliveryDriver.Invalid)
            {
                throw new BusinessException($"Falha ao criar o entregador: {deliveryDriver.ValidationResult.ToString(";")}");
            }

            //Se sim, persistir no banco
            await _deliveryDriverRepository.SaveOrUpdateAsync(deliveryDriver, cancellationToken);

            //Retornar o ID
            return new OutCreateDeliveryDriverDTO() { Id = deliveryDriver.Id };
        }


        //TODO: Implementar método para salvar o arquivo local
        private string ReturnCNHImageUrl(string base64)
        {
            return $"{base64}";
        }

        private ECnhType ConvertCNHType(string inCnhType)
        {
            var cnhType = Enum.Parse<ECnhType>(inCnhType);
            if (cnhType == null)
                throw new BusinessException("Tipo CNH informado Inválido");

            return cnhType;
        }
    }
}
