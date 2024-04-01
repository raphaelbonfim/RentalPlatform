using Application.Services.Queries.interfaces;
using Domain.DAO;
using Domain.DAO.DTOs;

namespace Application.Services.Queries
{
    public class GetAllMotorcyclesQueryService : IGetAllMotorcyclesQueryService
    {
        private readonly IMotorcycleDao _motorcycleDao;

        public GetAllMotorcyclesQueryService(IMotorcycleDao motorcycleDao)
        {
            _motorcycleDao = motorcycleDao;
        }

        public async Task<IReadOnlyCollection<OutMotorcycleQueryDto>> ProcessAsync(string? plate, CancellationToken cancellationToken)
        {
            return await _motorcycleDao.GetAllMotorcycles(plate, cancellationToken);
        }
    }
}
