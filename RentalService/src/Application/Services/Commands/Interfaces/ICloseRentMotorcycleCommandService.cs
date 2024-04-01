using Application.DTOs.DeliveryDriver;

namespace Application.Services.Commands.Interfaces
{
    public interface ICloseRentMotorcycleCommandService
    {
        Task<OutCloseRentMotorcycleDTO> ProcessAsync(InCloseRentMotorcycleDTO dto, CancellationToken cancellation);

    }
}
