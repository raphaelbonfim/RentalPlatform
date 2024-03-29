using Domain.Models;
using Domain.Repositories;
using NHibernate.Linq;

namespace Infra.DataAccess.Repositories
{
    public class DeliveryDriverRepository : RepositoryBase<DeliveryDriver>, IDeliveryDriverRepository
    {
        public DeliveryDriverRepository(IUnitOfWorkDomain unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<DeliveryDriver> GetByCNHNumberAsync(string cnhNumber, CancellationToken cancellationToken = default)
        {
            return await Session
                 .Query<DeliveryDriver>()
                 .FirstOrDefaultAsync(x => x.CNH.Number == cnhNumber, cancellationToken: cancellationToken);
        }

        public async Task<DeliveryDriver> GetByCNPJAsync(string cnpj, CancellationToken cancellationToken = default)
        {
            return await Session
                 .Query<DeliveryDriver>()
                 .FirstOrDefaultAsync(x => x.CNPJ == cnpj, cancellationToken: cancellationToken);
        }
    }
}
