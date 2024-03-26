using Domain.Models;
using Domain.Repositories;
using NHibernate.Linq;

namespace Infra.DataAccess.Repositories
{
    public class MotorcycleRepository : RepositoryBase<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(IUnitOfWorkDomain unitOfWork) : base(unitOfWork) { }

        public async Task<Motorcycle> GetByPlateAsync(string plate, CancellationToken cancellationToken = default)
        {
            return await Session
                .Query<Motorcycle>()
                .FirstOrDefaultAsync(x => x.Plate == plate, cancellationToken: cancellationToken);
        }
    }
}
