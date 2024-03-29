using Common.Domain;

namespace Domain.Models
{
    public class Delivery : Entity
    {
        protected Delivery() { }

        public Delivery(DeliveryDriver deliveryDriver, Guid orderId, Guid id = default)
        {
            Id = id;
            NotificationDate = DateTime.Now;
            Avaliable = true;
            OrderId = orderId;
            DeliveryDriver = deliveryDriver;    
        }

        public virtual DeliveryDriver DeliveryDriver { get; protected set; }
        public virtual DateTime NotificationDate { get; protected set; }
        public virtual Guid OrderId { get; protected set; }
        public virtual bool Avaliable { get; protected set; }
        public virtual EDeliveryStatus DeliveryStatus { get; protected set; }
    }
}
