using Common.Domain;

namespace Domain.Models
{
    public class Rental : Aggregate
    {
        protected Rental() { }

        public Rental(
            Guid deliveryDriverId,
            Guid motorcycleId,
            Guid rentalPlanId,
            DateTime startDate,
            DateTime endDate,
            DateTime forecastEndDate,
            short days,
            double pricePerDay,
            Guid id = default
            )
        {
            Id = id;
            DeliveryDriverId = deliveryDriverId;
            MotorcycleId = motorcycleId;
            RentalPlanId = rentalPlanId;
            StartDate = startDate;
            EndDate = endDate;
            ForecastEndDate = forecastEndDate;
            Days = days;
            PricePerDay = pricePerDay;
        }

        public virtual Guid DeliveryDriverId { get; protected set; }
        public virtual Guid MotorcycleId { get; protected set; }
        public virtual Guid RentalPlanId { get; protected set; }
        public virtual DateTime StartDate { get; protected set; }
        public virtual DateTime EndDate { get; protected set; }
        public virtual DateTime ForecastEndDate { get; protected set; }
        public virtual short Days { get; protected set; }
        public virtual double PricePerDay { get; protected set; }
    }
}
