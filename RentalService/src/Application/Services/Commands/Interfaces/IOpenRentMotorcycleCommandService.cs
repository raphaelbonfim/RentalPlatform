using Application.DTOs.DeliveryDriver;

namespace Application.Services.Commands.Interfaces
{
    public interface IOpenRentMotorcycleCommandService
    {
        Task<OutOpenRentMotorcycleDTO> ProcessAsync(InOpenRentMotorcycleDTO dto, CancellationToken cancellation);
    }
}
