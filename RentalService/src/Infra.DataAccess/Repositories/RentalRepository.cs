using Common.Repositories;
using Domain.Models;
using Domain.Repositories;

namespace Infra.DataAccess.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(IUnitOfWorkDomain unitOfWork) : base(unitOfWork)
        {
        }


    }
}
