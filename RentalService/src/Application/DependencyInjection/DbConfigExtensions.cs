using Domain.Repositories;

namespace Application.DI;

public static class DbConfigExtensions
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        const string dbConnection = "RentalDBConnection";
        var serviceProvider = services.BuildServiceProvider();

        // Repository
        var sessionFactory = PostgresSessionFactory
            .Factory(serviceProvider.GetService<ILogger<PostgresSessionFactory>>())
            .CreateSessionFactory(configuration.GetConnectionString(dbConnection));

        services.AddSingleton(sessionFactory);
        services.AddScoped<IUnitOfWorkDomain>(_ => new UnitOfWorkImpl(sessionFactory.OpenSession()));

        // DAO
        ConnectionFactory.InitPostgres(configuration.GetConnectionString(dbConnection));

        return services;
    }
}