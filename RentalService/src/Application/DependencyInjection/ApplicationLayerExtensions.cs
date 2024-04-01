using Application.Services.Commands;
using Application.Services.Commands.Interfaces;
using Application.Services.Queries;
using Application.Services.Queries.interfaces;

namespace Application.DependencyInjection
{
    public static class ApplicationLayerExtensions
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            #region Commands
            services.AddScoped<ICreateMotorcycleCommandService, CreateMotorcycleCommandService>();
            services.AddScoped<ICreateDeliveryDriverCommandService, CreateDeliveryDriverCommandService>();
            services.AddScoped<IUpdateMotorcycleCommandService, UpdateMotorcycleCommandService>();
            services.AddScoped<IDeleteMotorcycleCommandService, DeleteMotorcycleCommandService>();
            services.AddScoped<ICreateOrderCommandService, CreateOrderCommandService>();
            services.AddScoped<IUpdateDeliveryDriverCommandService, UpdateDeliveryDriverCommandService>();
            services.AddScoped<IOpenRentMotorcycleCommandService, OpenRentMotorcycleCommandService>();
            services.AddScoped<ICloseRentMotorcycleCommandService, CloseRentMotorcycleCommandService>();
            #endregion

            #region Queries
            services.AddScoped<IGetAllMotorcyclesQueryService, GetAllMotorcyclesQueryService>();
            services.AddScoped<IGetNotificatedDeliveryDriversQueryService, GetNotificatedDeliveryDriversQueryService>();
            #endregion

            return services;
        }
    }
}
