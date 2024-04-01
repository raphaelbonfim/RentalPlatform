using Application.DTOs.DeliveryDriver;

namespace Application.Services.Interfaces
{
    public interface ICreateDeliveryDriverCommandService
    {
        Task<OutCreateDeliveryDriverDTO> ProcessAsync(InCreateDeliveryDriverDTO dto, CancellationToken cancellation);
    }
}
