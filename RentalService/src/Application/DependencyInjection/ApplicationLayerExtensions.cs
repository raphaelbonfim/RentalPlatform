using Application.Services;
using Application.Services.Interfaces;

namespace Application.DependencyInjection
{
    public static class ApplicationLayerExtensions
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ICreateMotorcycleCommandService, CreateMotorcycleCommandService>();
            services.AddScoped<ICreateDeliveryDriverCommandService, CreateDeliveryDriverCommandService>();
            services.AddScoped<IUpdateMotorcycleCommandService, UpdateMotorcycleCommandService>();
            services.AddScoped<IDeleteMotorcycleCommandService, DeleteMotorcycleCommandService>();
            services.AddScoped<ICreateOrderCommandService, CreateOrderCommandService>();
            services.AddScoped<IUpdateDeliveryDriverCommandService, UpdateDeliveryDriverCommandService>();
            services.AddScoped<IRentMotorcycleCommandService, RentMotorcycleCommandService>();

           
            return services;
        }
    }
}
