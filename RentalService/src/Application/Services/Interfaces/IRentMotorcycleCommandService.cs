using Application.DTOs.DeliveryDriver;

namespace Application.Services.Interfaces
{
    public interface IRentMotorcycleCommandService
    {
        Task<OutRentMotorcycleDTO> ProcessAsync(InRentMotorcycleDTO dto, CancellationToken cancellation);
    }
}
