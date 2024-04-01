using Application.DTOs.DeliveryDriver;
using Domain.DAO.DTOs;

namespace Application.Services.Queries.interfaces
{
    public interface IGetAllMotorcyclesQueryService
    {
        Task<IReadOnlyCollection<OutMotorcycleQueryDto>> ProcessAsync(string? plate, CancellationToken cancellation);
    }
}
