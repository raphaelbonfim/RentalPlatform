using Application.Services;
using Application.Services.Interfaces;

namespace Application.DependencyInjection
{
    public static class ApplicationLayerExtensions
    {

        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<ICreateMotorCycleCommandService, CreateMotorCycleCommandService>();

            return services;
        }
    }
}
