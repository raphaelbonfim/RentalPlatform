using Domain.Models;
using Domain.Repositories;

namespace Infra.DataAccess.Repositories
{
    public class RentalPlanRepository : RepositoryBase<RentalPlan>, IRentalPlanRepository
    {
        public RentalPlanRepository(IUnitOfWorkDomain unitOfWork) : base(unitOfWork) { }

        public async Task<bool> CheckIfPlansExist(CancellationToken cancellationToken)
        {
            return await Session.QueryOver<RentalPlan>().RowCountAsync(cancellationToken) == 0;
        }
    }
}
