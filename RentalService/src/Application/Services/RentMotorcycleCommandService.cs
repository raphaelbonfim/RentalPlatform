using Application.DTOs.DeliveryDriver;
using Application.Services.Interfaces;
using Common.Application;
using Domain.Models;
using Domain.Repositories;


namespace Application.Services;

public class RentMotorcycleCommandService : IRentMotorcycleCommandService
{
    private readonly IRentalPlanRepository _rentalPlanRepository;
    private readonly IDeliveryDriverRepository _deliveryDriverRepository;
    private readonly IRentalRepository _rentalRepository;
    private readonly IMotorcycleRepository _motorcycleRepository;

    public RentMotorcycleCommandService(
        IRentalPlanRepository rentalPlanRepository,
        IDeliveryDriverRepository deliveryDriverRepository,
        IRentalRepository rentalRepository,
        IMotorcycleRepository motorcycleRepository
        )
    {
        _rentalPlanRepository = rentalPlanRepository;
        _deliveryDriverRepository = deliveryDriverRepository;
        _rentalRepository = rentalRepository;
        _motorcycleRepository = motorcycleRepository;
    }

    public async Task<OutRentMotorcycleDTO> ProcessAsync(InRentMotorcycleDTO dto, CancellationToken cancellationToken)
    {
        // Verificar se DD existe
        var deliveryDriver = await _deliveryDriverRepository.GetByIdAsync(dto.DeliveryDriverId);
        if (deliveryDriver == null)
            throw new BusinessException("Entregador não encontrado.");

        // Verificar se o tipo de CNH do DD é A
        if (deliveryDriver.CNH.CnhType != ECnhType.A)
            throw new BusinessException("Categoria da CNH inválida.");

        // Verificar se a moto existe
        var motorcycle = await _motorcycleRepository.GetByIdAsync(dto.MotorcycleId);
        if(motorcycle == null)
            throw new BusinessException("Moto não encontrada.");

        // Verificar se existe algum aluguel ATIVO (EndDate is NULL) para essa moto
        var activeRental = await _rentalRepository.GetRentalByMotorcycleId(motorcycle.Id);
        if(activeRental != null)
        {
            if (activeRental.EndDate == null)
                throw new BusinessException("Já existe um aluguel ativo para essa moto.");
        }        

        // Verificar se o plano existe
        var rentalPlan = await GetRentalPlanAsync(dto.RentalPlanId, cancellationToken);
        if (rentalPlan is null)
            throw new BusinessException("Plano inválido");

        // Criar agregado Rental
        var rental = new Rental
            (
                deliveryDriver.Id,
                motorcycle.Id,
                rentalPlan.Id,
                rentalPlan.Days,
                rentalPlan.Price,
                rentalPlan.PaymentFine
            );


        // Verificar se agregado é válido
        if(rental.Invalid)
            throw new BusinessException($"Falha ao alugar a moto : {rental.ValidationResult.ToString(";")}");

        // Persistir agregado no BD
        await _rentalRepository.SaveOrUpdateAsync(rental);

        // Retornar 
        return new OutRentMotorcycleDTO
        {
            RentalId = rental.Id,
            PickupDate = rental.StartDate,
            ReturnDate = rental.ForecastEndDate,
            ChosenPlanDescription = rentalPlan.Description
        };
    }

    private async Task<RentalPlan> GetRentalPlanAsync(Guid id, CancellationToken cancellationToken)
    {
        var dbIsEmpty = await _rentalPlanRepository.CheckIfPlansExist(cancellationToken);
        if (!dbIsEmpty)
            await SeedPlansAsync(cancellationToken); // Replace this to a Endpoint later

        return await _rentalPlanRepository.GetByIdAsync(id, cancellationToken);
    }

    private async Task SeedPlansAsync(CancellationToken cancellationToken)
    {
        var defaultPlans = new List<RentalPlan>
        {
            new RentalPlan( 7, 30.0, 20, 50,"7 dias com um custo de R$30,00 por dia",
                new Guid("080C8589-B102-42C6-803A-8C3D82210308")),

            new RentalPlan( 15, 28.0, 40, 50,"15 dias com um custo de R$28,00 por dia",
                new Guid("B7580A2F-A3D1-4865-AF97-9CE6CB2EE8BD")),

            new RentalPlan( 30, 22.0, 60, 50,"30 dias com um custo de R$22,00 por dia",
                new Guid("29398624-75F5-4F7A-9E69-22711F2EBDA2"))
        };

        foreach (var plan in defaultPlans)
        {
            await _rentalPlanRepository.SaveOrUpdateAsync(plan, cancellationToken);
        }
    }
}