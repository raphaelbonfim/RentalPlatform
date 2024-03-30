using Domain.Models;

namespace Domain.Repositories
{
    public interface IOrderRepository
    {
        Task SaveOrUpdateAsync(Order aggregate, CancellationToken cancellationToken = default);
        Task<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
