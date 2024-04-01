using Application.DTOs.Admin;
using Application.DTOs.DeliveryDriver;

namespace Application.Services.Commands.Interfaces
{
    public interface IUpdateDeliveryDriverCommandService
    {
        Task ProcessAsync(InUpdateDeliveryDriverDTO dto, CancellationToken cancellationToken);
    }
}
