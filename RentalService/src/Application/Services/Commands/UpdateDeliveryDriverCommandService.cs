using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Application.Services.Utils;
using Common.Application;
using Domain.Repositories;

namespace Application.Services.Commands
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
            if (deliveryDriver is null)
                throw new BusinessException("Não existe uma entregador com o Id informado.");

            //alterar a imagem da CNH  
            deliveryDriver.UpdateCNH
            (
                dto.CNHNumber,
                CnhHelper.GetImageUrl(deliveryDriver.Id, dto.CNHBase64),
                CnhHelper.GetCnhType(dto.CNHType)
            );
            if (deliveryDriver.Invalid)
                throw new BusinessException($"Falha ao atualizar a CNH: {deliveryDriver.ValidationResult.ToString(";")}");

            // Salva imagem da CNH
            CnhHelper.SaveCnhImage(dto.CNHBase64, deliveryDriver.CNH.ImageUrl);

            //se válido, persistir no banco
            await _deliveryDriverRepository.SaveOrUpdateAsync(deliveryDriver, cancellationToken);
        }
    }
}
