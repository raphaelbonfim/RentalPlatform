using Domain.Models;

namespace Domain.Repositories
{
    public interface IRentalPlanRepository
    {
        Task SaveOrUpdateAsync(RentalPlan aggregate, CancellationToken cancellationToken = default);
        Task<RentalPlan> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> CheckIfPlansExist(CancellationToken cancellationToken);
    }

}
