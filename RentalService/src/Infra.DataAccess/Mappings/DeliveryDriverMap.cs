using Domain.Models;
using FluentNHibernate;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.DataAccess.Mappings
{
    public class DeliveryDriverMap : ClassMap<DeliveryDriver>
    {
        public DeliveryDriverMap()
        {
            Table("delivery_drivers");

            Version(x => x.ModifiedAt)
                .Column("modified_at")
                .CustomType<UtcDateTimeType>();

            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Map(x => x.Name)
                .Column("name")
                .Not.Nullable();

            Map(x => x.CNPJ)
                .Column("cnpj")
                .Not.Nullable()
                .UniqueKey("uk_cnpj");

            Map(x => x.Birthdate)
                .Column("birthdate")
                .Not.Nullable();

            Component(x => x.CNH, y =>
                {
                    y.Map(x => x.Number).Column("number");
                    y.Map(x => x.ImageUrl).Column("image_url");
                    y.Map(x => x.CnhType).Column("cnh_type");
                });

            HasMany<Delivery>(Reveal.Member<DeliveryDriver>("Deliverieslist"))
                .KeyColumn("delivery_driver_id")
                .ForeignKeyConstraintName("fk_delivery_driver_id")
                .Not.LazyLoad()
                .Cascade.SaveUpdate()
                .Cascade.DeleteOrphan();
        }
    }
}
