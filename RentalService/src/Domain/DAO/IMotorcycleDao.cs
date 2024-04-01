using Domain.DAO.DTOs;

namespace Domain.DAO
{
    public interface IMotorcycleDao
    {
        Task<IReadOnlyCollection<OutMotorcycleQueryDto>> GetAllMotorcycles(string? plate, CancellationToken cancellationToken);
    }
}
