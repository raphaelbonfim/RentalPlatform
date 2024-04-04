using Application.DTOs.Admin;
using Application.Services.Commands.Interfaces;
using Common.Application;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services.Commands
{
    public class CreateMotorcycleCommandService : ICreateMotorcycleCommandService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public CreateMotorcycleCommandService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<OutCreateMotorcycleDTO> ProcessAsync(InCreateMotorcycleDTO dto, CancellationToken cancellationToken)
        {    
            //Verificar se existe uma moto com a mesma placa
            var motorcycle = await _motorcycleRepository.GetByPlateAsync(dto.Plate, cancellationToken);
            if (motorcycle != null)            
                throw new BusinessException("Já existe uma moto com essa placa.");         

            //se nao, criar o aggregado motorcycle
            motorcycle = new Motorcycle(dto.Year, dto.Model, dto.Plate);

            //verificar se o aggregado é valido
            if (motorcycle.Invalid)            
                throw new BusinessException($"Falha ao criar a moto : {motorcycle.ValidationResult.ToString(";")}");

            //se sim, persistir no banco
            await _motorcycleRepository.SaveOrUpdateAsync(motorcycle, cancellationToken);

            //retornar o Id
            return new OutCreateMotorcycleDTO() { Id = motorcycle.Id };
        }
    }
}
