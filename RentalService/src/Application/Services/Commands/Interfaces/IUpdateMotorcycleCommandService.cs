using Application.DTOs.Admin;

namespace Application.Services.Commands.Interfaces
{
    public interface IUpdateMotorcycleCommandService
    {
        Task ProcessAsync(InUpdateMotorcycleDTO dto, CancellationToken cancellationToken);
    }
}
