using Domain.Models;

namespace Domain.Repositories
{
    public interface IDeliveryDriverRepository
    {
        Task SaveOrUpdateAsync(DeliveryDriver aggregate, CancellationToken cancellationToken = default);
        Task<DeliveryDriver> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<DeliveryDriver> GetByCNPJAsync(string cnpj, CancellationToken cancellationToken = default);
        Task<DeliveryDriver> GetByCNHNumberAsync(string cnhNumber, CancellationToken cancellationToken = default);
    }
}
