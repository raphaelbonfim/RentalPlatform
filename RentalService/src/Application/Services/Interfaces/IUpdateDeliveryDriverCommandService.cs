using Application.DTOs.Admin;
using Application.DTOs.DeliveryDriver;

namespace Application.Services.Interfaces
{
    public interface IUpdateDeliveryDriverCommandService
    {
        Task ProcessAsync(InUpdateDeliveryDriverDTO dto, CancellationToken cancellationToken);
    }
}
