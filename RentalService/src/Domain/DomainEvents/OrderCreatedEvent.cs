using Common.Messaging;

namespace Domain.DomainEvents
{
    public class OrderCreatedEvent : IntegrationMessage
    {
        public OrderCreatedEvent(Guid orderId)
        {
            OrderId = orderId;
        }
        public Guid OrderId { get; set; }
    }
}
