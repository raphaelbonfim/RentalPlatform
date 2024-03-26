using Common.Domain;

namespace Domain.Models
{
    public class DeliveryDriver : Aggregate
    {
        protected DeliveryDriver() { }

        public DeliveryDriver(string name, string cnpj, CNH cnh, DateTime birthdate, Guid id = default)
        {
            Id = id;
            Name = name;
            CNPJ = cnpj;
            CNH = cnh;
            Birthdate = birthdate;
        }

        protected ICollection<Delivery> Deliverieslist { get; set; }
        public virtual IReadOnlyCollection<Delivery> Deliveries => Deliverieslist.ToList();
        public virtual string Name { get; protected set; }
        public virtual string CNPJ { get; protected set; }
        public virtual CNH CNH { get; protected set; }
        public virtual DateTime Birthdate { get; protected set; }


        public void UpdateCHN() { }
        public void AddDelivery() { }
        public void AcceptDelivery() { }
        public void RejectDelivery() { }
        public void CloseDelivery() { }
    }
}
