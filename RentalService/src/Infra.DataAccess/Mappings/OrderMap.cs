using Domain.Models;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.DataAccess.Mappings
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap() {

            Table("orders");

            Version(x => x.ModifiedAt)
                .Column("modified_at")
                .CustomType<UtcDateTimeType>();

            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Map(x => x.CreationDate)
                .Column("creation_date")
                .Not.Nullable();

            Map(x => x.DeliveryFee)
                .Column("delivery_fee")
                .Not.Nullable();

            Map(x => x.DeliveredBy)
                .Column("delivered_by")
                .Nullable();

            Map(x => x.OrderStatus)
                .Column("order_status")
                .Not.Nullable();
        }
        
    }
}
