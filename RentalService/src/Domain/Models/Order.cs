using Common.Domain;
using Domain.DomainEvents;
using Domain.Validations;
using FluentValidation.Results;

namespace Domain.Models
{

    public class Order : Aggregate
    {
        protected Order() { }

        public Order(double deliveryFee, Guid id = default)
        {
            Id = id;
            CreationDate = DateTime.Now;
            OrderStatus = EOrderStatus.Avaliable;
            DeliveryFee = deliveryFee;

            CheckInvariants(this, new CreateOrderInvariatns(), new List<ValidationResult>());

            AddDomainEvent(new OrderCreatedEvent(Id)); //Evento que vai pra mensageria
        }

        public virtual DateTime CreationDate { get; protected set; }
        public virtual double DeliveryFee { get; protected set; }
        public virtual Guid? DeliveredBy { get; protected set; } 
        public virtual EOrderStatus OrderStatus { get; protected set; }


        public virtual void Accepted()
        {
            OrderStatus = EOrderStatus.Accepted;
        }

        public virtual void Delivered(Guid deliveryDriverId)
        {
            OrderStatus = EOrderStatus.Delivered;
            DeliveredBy = deliveryDriverId;
        }

    }
}
