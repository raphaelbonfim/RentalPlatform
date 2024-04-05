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

            if(rental.EndDate != null)
                throw new BusinessException($"Contrato já finalizado");

            //Verificar a data de devolução da moto             
            if (dto.ReturnedDate < rental.StartDate)
                throw new BusinessException($"Erro ao finalizar contrato. A data de retorno não pode ser menor que a data de início do aluguel");
            
            // Finalizar o aluguel
            rental.CloseRental(rentalPlan.PaymentFine, rentalPlan.ExtraDailyFee, dto.ReturnedDate);

            // Verificar se o agregado está válido
            if (rental.Invalid)
                throw new BusinessException($"Falha ao finalizar o aluguel: {rental.ValidationResult.ToString(";")}");

            // Persistir o agregado
            await _rentalRepository.SaveOrUpdateAsync(rental);

            // retornar
            return new OutCloseRentMotorcycleDTO
            {
                RentalValue = rental.RentalValue.ToString("C2"),
                ExtraDailyValue = rental.ExtraDailyValue.ToString("C2"),
                FineValue = rental.FineValue.ToString("C2"),
                TotalValue = rental.TotalValue.ToString("C2")
            };
        }
    }
}
