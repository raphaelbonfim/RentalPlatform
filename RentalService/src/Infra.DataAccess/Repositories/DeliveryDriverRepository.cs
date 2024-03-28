using Common.Repositories;
using Domain.Models;
using Domain.Repositories;

namespace Infra.DataAccess.Repositories
{
    public class DeliveryDriverRepository : RepositoryBase<DeliveryDriver>, IDeliveryDriverRepository
    {
        public DeliveryDriverRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
