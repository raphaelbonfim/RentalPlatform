using Application.DTOs.Admin;

namespace Application.Services.Commands.Interfaces
{
    public interface IDeleteMotorcycleCommandService
    {
        Task ProcessAsync(InDeleteMotorcycleDTO dto, CancellationToken cancellationToken);
    }
}
