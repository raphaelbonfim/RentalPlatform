using Domain.Models;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.DataAccess.Mappings
{
    public class RentalMap : ClassMap<Rental>
    {
        public RentalMap()
        {
            Table("rentals");

            Version(x => x.ModifiedAt)
                .Column("modified_at")
                .CustomType<UtcDateTimeType>();

            Id(x => x.Id)
                .GeneratedBy.Assigned();

            Map(x => x.DeliveryDriverId)
                .Column("delivery_driver_id")
                .Not.Nullable();

            Map(x => x.MotorcycleId)
               .Column("motorcycle_id")
               .Not.Nullable();

            Map(x => x.RentalPlanId)
                .Column("rental_plan_id")
                .Not.Nullable();

            Map(x => x.StartDate)
                .Column("start_date")
                .Not.Nullable();

            Map(x => x.EndDate)
                .Column("end_date");               

            Map(x => x.ForecastEndDate)
                .Column("forecast_end_date")
                .Not.Nullable();

            Map(x => x.Days)
                .Column("days")
                .Not.Nullable();

            Map(x => x.PricePerDay)
                .Column("price_per_day")
                .Not.Nullable();
        }
    }
}
