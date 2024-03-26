using Application.DTOs.Admin;

namespace Application.Services.Interfaces
{
    public interface ICreateMotorCycleCommandService
    {
        Task<OutCreateMotorcycleDTO> ProcessAsync(InCreateMotorcycleDTO dto, CancellationToken cancellationToken);
    }
}
