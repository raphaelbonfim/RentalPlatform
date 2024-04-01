using Domain.DAO.DTOs;

namespace Application.Services.Queries.interfaces
{
    public interface IGetNotificatedDeliveryDriversQueryService
    {
        Task<IReadOnlyCollection<OutNotificatedDeliveryDriverQueryDto>> ProcessAsync(Guid orderId, CancellationToken cancellationToken);
    }
}
