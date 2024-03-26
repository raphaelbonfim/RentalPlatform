//using Domain.Models;
//using FluentNHibernate.Mapping;
//using NHibernate.Type;

//namespace Infra.DataAccess.Mappings
//{
//    public class RentalPlanMap : ClassMap<RentalPlan>
//    {
//        public RentalPlanMap()
//        {
//            Table("rental_plan");

//            Version(x => x.ModifiedAt)
//                .Column("modified_at")
//                .CustomType<UtcDateTimeType>();
//        }
//    }
//}
