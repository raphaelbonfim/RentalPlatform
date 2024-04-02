using Application.DTOs.Admin;
using Application.Messaging;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Common.Messaging;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.Commands
{
    public class CreateOrderCommandService : ICreateOrderCommandService
    {
        private readonly IOrderRepository _orderRepository;
        //private readonly IMessagingSender _messagingSender;

        public CreateOrderCommandService
            (
            IOrderRepository orderRepository
            //IMessagingSender messagingSender
            )
        {
            _orderRepository = orderRepository;
            //_messagingSender = messagingSender;
        }

        public async Task<OutCreateOrderDTO> ProcessAsync(InCreateOrderDTO dto, CancellationToken cancellationToken)
        {
            //Criar o pedido
            var order = new Order(dto.DeliveryFee);

            //validar o pedido
            if (order.Invalid)
                throw new BusinessException($"Falha ao criar o Pedido: {order.ValidationResult.ToString(";")}");

            //Gravar o pedido
            await _orderRepository.SaveOrUpdateAsync(order);

            //Obs: Publicação do evento de Pedido Criado para notificar os entregadores aptos.
            //await _messagingSender.PublishAllAsync(MessagingConstants.OrderCreatedQueue, order.DomainEvents.ToList());

            return new OutCreateOrderDTO() { Id = order.Id };
        }
    }
}
