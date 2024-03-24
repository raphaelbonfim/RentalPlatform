using Common.Domain;

namespace Domain.Models
{
    public class DeliveryDriver : Aggregate
    {
        public DeliveryDriver() { }

        public DeliveryDriver(string name, string cNPJ, CNH cnh, DateTime birthdate, Guid id = default)
        {
            Id = id;
            Name = name;
            CNPJ = cNPJ;
            CNH = cnh;
            Birthdate = birthdate;
        }

        public virtual string Name { get; private set; }
        public virtual string CNPJ { get; private set; }
        public virtual CNH CNH { get; private set; }
        public virtual DateTime Birthdate { get; private set; }


        public void UpdateCHN() { }
        public void AddDelivery() { }
        public void AcceptDelivery() { }
        public void RejectDelivery() { }
        public void CloseDelivery() { }

    }
}
