using Common.Domain;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IMotorcycleRepository
    {
        Task SaveOrUpdateAsync(Motorcycle aggregate, CancellationToken cancellationToken = default);
        Task<Motorcycle> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Motorcycle> GetByPlateAsync(string plate, CancellationToken cancellationToken = default);
        Task RemoveAsync(Motorcycle aggregate, CancellationToken cancellationToken = default);

    }
}
