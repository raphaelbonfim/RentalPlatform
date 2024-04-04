using Application.DTOs.Admin;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Domain.Repositories;

namespace Application.Services.Commands
{
    public class DeleteMotorcycleCommandService : IDeleteMotorcycleCommandService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;
        private readonly IRentalRepository _rentalRepository;

        public DeleteMotorcycleCommandService
            (
            IMotorcycleRepository motorcycleRepository,
            IRentalRepository rentalRepository
            )
        {
            _rentalRepository = rentalRepository;
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task ProcessAsync(InDeleteMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            //Verificar se existe a moto
            var motorcycle = await _motorcycleRepository.GetByIdAsync(dto.Id);
            if (motorcycle == null)
                throw new BusinessException($"Moto com o id: {dto.Id} não encontrada");

            //Se tiver registro de locação Não remover!
            var rental = await _rentalRepository.GetRentalByMotorcycleId(motorcycle.Id);
            if (rental != null)
                throw new BusinessException($"Erro ao excluir moto, ela possui historico de aluguel");

            //Se não, Remover do banco
            await _motorcycleRepository.RemoveAsync(motorcycle, cancellationToken);
        }
    }
}
