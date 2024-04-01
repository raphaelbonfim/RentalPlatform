using Application.DTOs.DeliveryDriver;

namespace Application.Services.Commands.Interfaces
{
    public interface ICreateDeliveryDriverCommandService
    {
        Task<OutCreateDeliveryDriverDTO> ProcessAsync(InCreateDeliveryDriverDTO dto, CancellationToken cancellation);
    }
}
