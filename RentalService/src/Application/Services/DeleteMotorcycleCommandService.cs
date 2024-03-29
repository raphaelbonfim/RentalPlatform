using Application.DTOs.Admin;
using Application.Services.Interfaces;
using Common.Application;
using Domain.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Application.Services
{
    public class DeleteMotorcycleCommandService : IDeleteMotorcycleCommandService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public DeleteMotorcycleCommandService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task ProcessAsync(InDeleteMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            //Verificar se existe a moto
            var motorcycle = await _motorcycleRepository.GetByIdAsync(dto.Id);

            if (motorcycle == null)
                throw new BusinessException($"Moto com o id: {dto.Id} não encontrada");

            //TODO: Implementar a validação de Historico de Aluguel da moto:
            //Se tiver registro de locação Não remover!

            //Se não, Remover do banco
            await _motorcycleRepository.RemoveAsync(motorcycle, cancellationToken);           
        }
    }
}
