using Common.Domain;

namespace Domain.Models
{
    public class Rental : Aggregate
    {
        public Rental() { }

        public Rental(
            Guid deliveryDriverId,
            Guid motorcycleId,
            Guid rentalPlanId,
            DateTime startDate,
            DateTime endDate,
            DateTime forecastEndDate,
            short days,
            float pricePerDay,
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

        public virtual Guid DeliveryDriverId { get; private set; }
        public virtual Guid MotorcycleId { get; private set; }
        public virtual Guid RentalPlanId { get; private set; }
        public virtual DateTime StartDate { get; private set; }
        public virtual DateTime EndDate { get; private set; }
        public virtual DateTime ForecastEndDate { get; private set; }
        public virtual short Days { get; private set; }
        public virtual float PricePerDay { get; private set; }
    }
}
