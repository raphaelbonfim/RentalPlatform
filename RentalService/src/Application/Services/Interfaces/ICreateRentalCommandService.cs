using Application.DTOs.DeliveryDriver;

namespace Application.Services.Interfaces
{
    public interface ICreateRentalCommandService
    {
        Task<OutCreateRentalDTO> ProcessAsync(InCreateRentalDTO dto, CancellationToken cancellation);

    }
}
