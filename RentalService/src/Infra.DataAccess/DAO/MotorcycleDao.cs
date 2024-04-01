using Domain.DAO;
using Domain.DAO.DTOs;
using Dapper;

namespace Infra.DataAccess.DAO
{
    public class MotorcycleDao : IMotorcycleDao
    {
        public async Task<IReadOnlyCollection<OutMotorcycleQueryDto>> GetAllMotorcycles(string? plate, CancellationToken cancellationToken)
        {
            const string SQL = @"SELECT id as Id, year as Year, model as Model, plate as Plate FROM motorcycles";
            const string SQLwithPlate = @"SELECT id as Id, year as Year, model as Model, plate as Plate FROM motorcycles WHERE upper(plate) = upper(@Plate);";

            var command = plate is null
                ? new CommandDefinition(SQL, cancellationToken: cancellationToken)
                : new CommandDefinition(SQLwithPlate, new { Plate = plate }, cancellationToken:cancellationToken);

            using var db = await ConnectionFactory.GetPostgresConnectionAsync();
            var result = await db.QueryAsync<OutMotorcycleQueryDto>(command);

            return result.ToList();
        }
    }
}
