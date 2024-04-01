using Dapper;
using Domain.DAO;
using Domain.DAO.DTOs;

namespace Infra.DataAccess.DAO
{
    public class DeliveryDriverDao : IDeliveryDriverDao
    {
        public async Task<IReadOnlyCollection<OutNotificatedDeliveryDriverQueryDto>> GetNotificatedDeliveryDrivers(Guid orderId, CancellationToken cancellationToken)
        {
            const string sql = "SELECT 	dd.id as DeliveryDriverId, "+
		                        "dd.name as Name, "+
                                "d.notification_date as NotificationDate, " +
                                "d.avaliable as DeliveryAvailableForAcceptance, " +
                                "d.delivery_status as Status " +
                                "FROM delivery_drivers dd " +
                                "INNER JOIN deliveries d ON dd.id = d.delivery_driver_id " +
                                "WHERE d.order_id = @OrderId;";

            using var db = await ConnectionFactory.GetPostgresConnectionAsync();
            var result = await db.QueryAsync<OutNotificatedDeliveryDriverQueryDto>(
                new CommandDefinition(sql, new 
                {
                    OrderId = orderId
                }, 
                cancellationToken: cancellationToken));

            return result.ToList();
        }
    }
}
