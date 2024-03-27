using Domain.Models;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.DataAccess.Mappings
{
    public class DeliveryMap : ClassMap<Delivery>
    {
        public DeliveryMap()
        {
            Table("deliveries");

            Version(x => x.ModifiedAt)
                .Column("modified_at")
                .CustomType<UtcDateTimeType>();

            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Map(x => x.NotificationDate)
                .Column("notification_date")
                .Not.Nullable();

            Map(x => x.Avaliable)
                .Column("avaliable")
                .Not.Nullable();

            Map(x => x.OrderId)
                .Column("order_id")
                .Not.Nullable();

            Map(x => x.DeliveryStatus)
                .Column("delivery_status")
                .Not.Nullable();

            References(x => x.DeliveryDriver, columnName: "delivery_driver_id");
        }
    }
}
