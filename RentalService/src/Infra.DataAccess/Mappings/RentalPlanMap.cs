using Domain.Models;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.DataAccess.Mappings
{
    public class RentalPlanMap : ClassMap<RentalPlan>
    {
        public RentalPlanMap()
        {
            Table("rental_plans");

            Version(x => x.ModifiedAt)
                .Column("modified_at")
                .CustomType<UtcDateTimeType>();

            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Map(x => x.Days)
                .Not.Nullable();

            Map(x => x.Price)
                .Not .Nullable();

            Map(x => x.PaymentFine)
                .Not.Nullable();
        }
    }
}
