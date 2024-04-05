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

        public virtual void AddDelivery(Guid orderId)
        {
            //TODO: Implementar: Quando a mensagem OrderCreatedEvent (notificação) recebida do broker for processada,
            //esse método adicionaria o delivery com o OrderId recebido
        }

        public virtual void AcceptDelivery(Guid deliveryId)
        {
            //TODO: Implementar: Quando o entregador aceitar no app a entrega,
            //marcaremos a entrega como "Accepted" e publicaremos a mensagem OrderAceptedEvent para que o agregado order atualize seu status para "Accepted"
            //e atualizará todos as outras notiticações dos outros entregadores de que esse pedido não está mais disponível.
        }

        public virtual void RejectDelivery(Guid deliveryId)
        {
            //TODO: Implementar: Quando o entregador rejeitar no app a entrega, marcaremos a entrega como "Rejected", para efeito de histórico
        }

        public virtual void CloseDelivery(Guid deliveryId)
        {
            //TODO: Implementar: Quando o entregador finalizar a entrega, marcaremos ela como "Delivered" e publicaremos a mensagem,
            // OrderDeliveredEvent para que o agregado order atualize seu status para "Delivered".
        }
    }
}
