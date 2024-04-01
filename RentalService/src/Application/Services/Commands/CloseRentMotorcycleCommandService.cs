using Application.DTOs.DeliveryDriver;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Domain.Repositories;

namespace Application.Services.Commands
{
    public class CloseRentMotorcycleCommandService : ICloseRentMotorcycleCommandService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IRentalPlanRepository _rentalPlanRepository;


        public CloseRentMotorcycleCommandService
            (
            IRentalRepository rentalRepository,
            IRentalPlanRepository rentalPlanRepository
            )
        {
            _rentalRepository = rentalRepository;
            _rentalPlanRepository = rentalPlanRepository;
        }

        public async Task<OutCloseRentMotorcycleDTO> ProcessAsync(InCloseRentMotorcycleDTO dto, CancellationToken cancellation)
        {
            // Verificar se o Rental existe pelo RentalId (a UI deve mostrar o aluguel ativo para o entregador e repassar o ID no payload)
            var rental = await _rentalRepository.GetByIdAsync(dto.RentalId);
            if (rental == null)
                throw new BusinessException($"Contrato de aluguel não encontrado");

            // Pegar as informações do plano
            var rentalPlan = await _rentalPlanRepository.GetByIdAsync(rental.RentalPlanId);
            if (rentalPlan == null)
                throw new BusinessException($"Plano inválido");

            // Finalizar o aluguel
            rental.CloseRental(dto.ReturnedDate, rentalPlan.PaymentFine, rentalPlan.ExtraDailyFee);

            // Verificar se o agregado está válido
            if (rental.Invalid)
                throw new BusinessException($"Falha ao finalizar o aluguel: {rental.ValidationResult.ToString(";")}");

            // Persistir o agregado
            await _rentalRepository.SaveOrUpdateAsync(rental);

            // retornar
            return new OutCloseRentMotorcycleDTO
            {
                ExtraDailyValue = rental.ExtraDailyValue,
                FineValue = rental.FineValue,
                TotalValue = rental.TotalValue
            };
        }
    }
}
