using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.Commands
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

            //Se nao, criar o aggregado DeliveryDriver
            var deliveryDriver = new DeliveryDriver(dto.Name, dto.CNPJ, dto.Birthdate, dto.CNHNumber, dto.CNHBase64, dto.CNHType);

            //Validar o agregado
            if (deliveryDriver.Invalid)            
                throw new BusinessException($"Falha ao criar o entregador: {deliveryDriver.ValidationResult.ToString(";")}");            

            //Se sim, persistir no banco
            await _deliveryDriverRepository.SaveOrUpdateAsync(deliveryDriver, cancellationToken);

            //Retornar o ID
            return new OutCreateDeliveryDriverDTO() { Id = deliveryDriver.Id };
        }
    }
}
