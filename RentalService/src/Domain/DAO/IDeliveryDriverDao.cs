using Domain.DAO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAO
{
    public interface IDeliveryDriverDao
    {
        Task<IReadOnlyCollection<OutNotificatedDeliveryDriverQueryDto>> GetNotificatedDeliveryDrivers(Guid orderId, CancellationToken cancellationToken);
    }
}
