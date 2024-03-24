using Common.Domain;

namespace Domain.Models
{
    public class Delivery : Entity
    {
        public Delivery() { }

        public Delivery(DateTime notificationDate, Guid orderId, bool avaliable)
        {
            NotificationDate = notificationDate;
            OrderId = orderId;
            Avaliable = avaliable;
        }

        public virtual DateTime NotificationDate { get; private set; }
        public virtual Guid OrderId { get; private set; }
        public virtual bool Avaliable { get; private set; }
        public virtual EDeliveryStatus DeliveryStatus { get; private set; }
    }
}
