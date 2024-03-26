using Domain.Models;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.DataAccess.Mappings
{
    public class MotorcycleMap : ClassMap<Motorcycle>
    {
        public MotorcycleMap()
        {
            Table("motorcycles");

            Version(x => x.ModifiedAt) // Version, obrigatorio para o NHibernate gerenciar modificações
                .Column("modified_at")
                .CustomType<UtcDateTimeType>();

            Id(x => x.Id)
                .GeneratedBy.Assigned(); //Assigned = Gera o id baseado no que for passado (Guid)

            Map(x => x.Year)
                .Column("year")
                .Not.Nullable();

            Map(x => x.Model)
                .Column("model")
                .Not.Nullable();

            Map(x => x.Plate)
                .Column("plate")
                .Not.Nullable()
                .UniqueKey("uk_plate");
        }
    }
}
