using Application.DTOs.Admin;

namespace Application.Services.Interfaces
{
    public interface ICreateMotorcycleCommandService
    {
        Task<OutCreateMotorcycleDTO> ProcessAsync(InCreateMotorcycleDTO dto, CancellationToken cancellationToken);
    }
}
