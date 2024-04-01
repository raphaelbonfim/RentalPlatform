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
                .Column("days")
                .Not.Nullable();

            Map(x => x.Price)
                .Column("price")
                .Not .Nullable();

            Map(x => x.PaymentFine)
                .Column("payment_fine")
                .Not.Nullable();

            Map(x => x.Description)
                .Column("description")
                .Not.Nullable();

            Map(x => x.ExtraDailyFee)
                .Column("extra_daily_fee");
        }
    }
}
