using Domain.Models;
using Domain.Repositories;
using NHibernate.Linq;

namespace Infra.DataAccess.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(IUnitOfWorkDomain unitOfWork) : base(unitOfWork) { }     
        
        public async Task<Rental> GetRentalByMotorcycleId(Guid motorcycleId, CancellationToken cancellationToken = default)
        {
            return await Session
                .Query<Rental>()
                .FirstOrDefaultAsync(x => x.MotorcycleId == motorcycleId && x.EndDate == null ,cancellationToken: cancellationToken);
        }
    }
}
