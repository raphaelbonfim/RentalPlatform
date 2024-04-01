using Application.DTOs.DeliveryDriver;
using Application.Services.Interfaces;
using Common.Application;
using Domain.Repositories;

namespace Application.Services
{
    public class UpdateDeliveryDriverCommandService : IUpdateDeliveryDriverCommandService
    {
        private readonly IDeliveryDriverRepository _deliveryDriverRepository;

        public UpdateDeliveryDriverCommandService(IDeliveryDriverRepository deliveryDriverRepository)
        {
            _deliveryDriverRepository = deliveryDriverRepository;
        }

        public async Task ProcessAsync(InUpdateDeliveryDriverDTO dto, CancellationToken cancellationToken)
        {
            //Verificar se existe o motorista
            var deliveryDriver = await _deliveryDriverRepository.GetByIdAsync(dto.Id);

            if (deliveryDriver == null)
            {
                throw new BusinessException("Não existe uma entregador com o Id informado.");
            }

            //alterar a imagem da CNH  
            deliveryDriver.UpdateCNH(dto.ImageBase64);

            //validar o agregado
            if (deliveryDriver.Invalid)
            {
                throw new BusinessException($"Falha ao atualizar a imagem da CNH: {deliveryDriver.ValidationResult.ToString(";")}");
            }

            //se válido, persistir no banco
            await _deliveryDriverRepository.SaveOrUpdateAsync(deliveryDriver, cancellationToken);
        }
    }
}
