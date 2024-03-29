using Application.DTOs.DeliveryDriver;
using Application.Services.Interfaces;
using Domain.Repositories;

namespace Application.Services
{
    public class CreateRentalCommandService : ICreateRentalCommandService
    {
        private readonly IRentalRepository _rentalRepository;

        public CreateRentalCommandService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public Task<OutCreateRentalDTO> ProcessAsync(InCreateRentalDTO dto, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
