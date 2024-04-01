using Application.Services.Queries.interfaces;
using Domain.DAO;
using Domain.DAO.DTOs;

namespace Application.Services.Queries
{
    public class GetNotificatedDeliveryDriversQueryService : IGetNotificatedDeliveryDriversQueryService
    {
        private readonly IDeliveryDriverDao _deliveryDriverDao;

        public GetNotificatedDeliveryDriversQueryService(IDeliveryDriverDao deliveryDriverDao)
        {
            _deliveryDriverDao = deliveryDriverDao;
        }

        public async Task<IReadOnlyCollection<OutNotificatedDeliveryDriverQueryDto>> ProcessAsync(Guid orderId, CancellationToken cancellationToken)
        {
            return await _deliveryDriverDao.GetNotificatedDeliveryDrivers(orderId, cancellationToken);
        }
    }
}
