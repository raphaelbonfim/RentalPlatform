using Domain.Models;
using Domain.Repositories;
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
         
        #endregion

        #region DAO
        //services.AddScoped<ITabelaFipeRepository, TabelaFipeRepository>();
        #endregion

        return services;
    }
}