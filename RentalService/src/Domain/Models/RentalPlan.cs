using Common.Domain;

namespace Domain.Models
{
    public class RentalPlan : Aggregate
    {
        protected RentalPlan() { }

        public RentalPlan(short days, double price, double paymentFine, Guid id = default)
        {
            Id = id;
            Days = days;
            Price = price;
            PaymentFine = paymentFine;
        }

        public virtual short Days { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual double PaymentFine { get; protected set; }
    }
}
