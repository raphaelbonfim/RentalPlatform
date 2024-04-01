using Common.Domain;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain.Models
{
    public class RentalPlan : Aggregate
    {
        protected RentalPlan() { }

        public RentalPlan(short days, double price, double paymentFine,double extraDailyFee, string description, Guid id = default)
        {
            Id = id;
            Days = days;
            Price = price;
            PaymentFine = paymentFine;
            ExtraDailyFee = extraDailyFee;
            Description = description;

            CheckInvariants(this, new CreateRentalPlanInvariants(), new List<ValidationResult>());
        }

        public virtual short Days { get; protected set; }
        public virtual double Price { get; protected set; }
        public virtual double PaymentFine { get; protected set; }
        public virtual double ExtraDailyFee { get; protected set; }
        public virtual string Description{ get; protected set; }

    }
}
