using Application.DTOs.Admin;

namespace Application.Services.Interfaces
{
    public interface IUpdateMotorcycleCommandService
    {
        Task ProcessAsync(InUpdateMotorcycleDTO dto, CancellationToken cancellationToken);
    }
}
