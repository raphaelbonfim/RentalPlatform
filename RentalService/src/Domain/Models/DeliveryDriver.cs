using Common.Domain;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain.Models
{
    public class DeliveryDriver : Aggregate
    {
        protected DeliveryDriver() { }

        public DeliveryDriver(
            string name,
            string cnpj,
            DateTime birthdate,
            string cnhNumber,
            string cnhImageUrl,
            ECnhType cnhType,
            Guid id = default
            )
        {
            Id = id;
            Name = name;
            CNPJ = cnpj;
            CNH = new CNH(cnhNumber, cnhImageUrl, cnhType);
            Birthdate = birthdate;

            CheckInvariants(this, new CreateDeliveryDriverInvariants(), new List<ValidationResult>
            {
                CNH.ValidationResult
            });
        }

        protected ICollection<Delivery> Deliverieslist { get; set; }
        public virtual IReadOnlyCollection<Delivery> Deliveries => Deliverieslist.ToList();
        public virtual string Name { get; protected set; }
        public virtual string CNPJ { get; protected set; }
        public virtual CNH CNH { get; protected set; }
        public virtual DateTime Birthdate { get; protected set; }

        public virtual void UpdateCNH(string cnhNumber, string cnhImageUrl, ECnhType cnhType)
        {
            CNH = new CNH(cnhNumber, cnhImageUrl, cnhType);

            CheckInvariants(this, new UpdateCNHInvariants(), new List<ValidationResult>
            {
                CNH.ValidationResult
            });
        }

        public virtual void AddDelivery() { }
        public virtual void AcceptDelivery() { }
        public virtual void RejectDelivery() { }
        public virtual void CloseDelivery() { }

    }
}
