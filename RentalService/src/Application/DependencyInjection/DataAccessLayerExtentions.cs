using Domain.DAO;
using Domain.Models;
using Domain.Repositories;
using Infra.DataAccess.DAO;
using Infra.DataAccess.Repositories;

namespace Application.DependencyInjection;

public static class DataAccessLayerExtentions
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        #region Repositories
        services.AddScoped<IMotorcycleRepository, MotorcycleRepository>();        
        services.AddScoped<IDeliveryDriverRepository, DeliveryDriverRepository>();       
        services.AddScoped<IOrderRepository, OrderRepository>();       
        services.AddScoped<IRentalPlanRepository, RentalPlanRepository>();       
        services.AddScoped<IRentalRepository, RentalRepository>();       
         
        #endregion

        #region DAO
        services.AddScoped<IDeliveryDriverDao, DeliveryDriverDao>();
        services.AddScoped<IMotorcycleDao, MotorcycleDao>();
        #endregion

        return services;
    }
}