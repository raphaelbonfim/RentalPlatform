using Common.Repositories;
using Domain.Models;
using Domain.Repositories;

namespace Infra.DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IUnitOfWorkDomain unitOfWork) : base(unitOfWork) { }
    }
}
