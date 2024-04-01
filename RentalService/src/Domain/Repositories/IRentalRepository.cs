using Domain.Models;

namespace Domain.Repositories
{
    public interface IRentalRepository
    {
        Task SaveOrUpdateAsync(Rental aggregate, CancellationToken cancellationToken = default);
        Task<Rental> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Rental> GetRentalByMotorcycleId(Guid motorcycleId, CancellationToken cancellationToken = default);
    }
}
