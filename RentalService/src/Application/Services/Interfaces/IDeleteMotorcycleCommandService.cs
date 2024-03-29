using Application.DTOs.Admin;

namespace Application.Services.Interfaces
{
    public interface IDeleteMotorcycleCommandService
    {
        Task ProcessAsync(InDeleteMotorcycleDTO dto, CancellationToken cancellationToken);
    }
}
