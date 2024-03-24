using Common.Domain;

namespace Domain.Models
{

    public class Order : Aggregate
    {
        public Order() { }

        public Order(DateTime creationDate, float deliveryFee, string deliveredBy, EOrderStatus orderStatus, Guid id = default)
        {
            Id = id;
            CreationDate = creationDate;
            DeliveryFee = deliveryFee;
            DeliveredBy = deliveredBy;
            OrderStatus = orderStatus;
        }

        public virtual DateTime CreationDate { get; private set; }
        public virtual float DeliveryFee { get; private set; }
        public virtual string DeliveredBy { get; private set; } //verificar o tipo
        public virtual EOrderStatus OrderStatus { get; private set; }


        public void Accepted()
        {
            OrderStatus = EOrderStatus.Accepted;
        }
        public void Delivered()
        {
            OrderStatus = EOrderStatus.Delivered;
        }

    }
}
