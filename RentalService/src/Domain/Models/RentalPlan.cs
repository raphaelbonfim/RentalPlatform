using Common.Domain;

namespace Domain.Models
{
    public class RentalPlan : Aggregate
    {
        public RentalPlan() { }

        public RentalPlan(short days, float price, float paymentFine, Guid id = default)
        {
            Id = id;
            Days = days;
            Price = price;
            PaymentFine = paymentFine;
        }

        public virtual short Days { get; private set; }
        public virtual float Price { get; private set; }
        public virtual float PaymentFine { get; private set; }
    }
}
