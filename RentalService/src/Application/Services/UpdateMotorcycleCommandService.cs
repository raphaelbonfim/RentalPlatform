using Application.DTOs.Admin;
using Application.Services.Interfaces;
using Common.Application;
using Domain.Repositories;

namespace Application.Services
{
    public class UpdateMotorcycleCommandService : IUpdateMotorcycleCommandService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public UpdateMotorcycleCommandService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task ProcessAsync(InUpdateMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            //Verificar se existe a moto com o ID
            var motorcycle = await _motorcycleRepository.GetByIdAsync(dto.Id);

            if(motorcycle == null)
            {
                throw new BusinessException("Não existe uma moto com o Id informado.");
            }

            //alterar a placa da moto
            motorcycle.ChangePlate(dto.Plate);

            //Verificar se o aggregado é valido
            if (motorcycle.Invalid)
            {
                throw new BusinessException($"Falha ao criar a moto : {motorcycle.ValidationResult.ToString(";")}");
            }

            //Se sim, persistir no banco
            await _motorcycleRepository.SaveOrUpdateAsync(motorcycle, cancellationToken);
        }
    }
}
