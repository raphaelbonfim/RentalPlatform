using Application.DTOs.Admin;
using Application.Services.Interfaces;
using Domain.Models;
using Domain.Repositories;

namespace Application.Services
{
    public class CreateMotorCycleCommandService : ICreateMotorCycleCommandService
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public CreateMotorCycleCommandService(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<OutCreateMotorcycleDTO> ProcessAsync(InCreateMotorcycleDTO dto, CancellationToken cancellationToken)
        {
            //Verificar se existe uma moto com a mesma placa

            var motocycle = await _motorcycleRepository.GetByPlateAsync(dto.Plate, cancellationToken);

            if (motocycle != null)
            {
                throw new Exception("Já existe uma moto com essa placa.");
            }

            //se nao, criar o aggregado motorcycle

            motocycle = new Motorcycle(dto.Year, dto.Model, dto.Plate);

            //verificar se o aggregado é valido

            if (motocycle.Invalid)
            {
                throw new Exception($"Falha ao criar a moto : {string.Join("; " , motocycle.ValidationResult.Errors.Select(x => x.ErrorMessage)) }");
            }

            //se sim, persistir no banco

            await _motorcycleRepository.SaveOrUpdateAsync(motocycle, cancellationToken);

            //retornar o Id

            return new OutCreateMotorcycleDTO() { Id = motocycle.Id };
        }
    }
}
