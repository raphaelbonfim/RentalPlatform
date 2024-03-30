using Application.DTOs.Admin;
using Application.Services.Interfaces;
using Common.Application;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CreateOrderCommandService : ICreateOrderCommandService
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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

            return new OutCreateOrderDTO() { Id = order.Id };
        }
    }
}
