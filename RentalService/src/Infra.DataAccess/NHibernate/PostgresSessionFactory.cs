using System.Reflection;
using Common.DataAccess;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

public class PostgresSessionFactory
{
    private readonly ILogger<PostgresSessionFactory> _logger;
    private static ISessionFactory _sessionFactory;

    public static PostgresSessionFactory Factory(ILogger<PostgresSessionFactory> logger)
        => new PostgresSessionFactory(logger);

    public PostgresSessionFactory(ILogger<PostgresSessionFactory> logger)
    {
        _logger = logger;
    }

    public static ISessionFactory GetSessionFactory()
    {
        if (_sessionFactory == null) throw new DataAccessLayerException("Session Factory no longer exists.");

        return _sessionFactory;
    }

    public ISessionFactory CreateSessionFactory(string connectionString)
    {
        _logger.LogInformation("Connecting to the database {DatabaseName}...", GetDatabaseName(connectionString));

        if (string.IsNullOrEmpty(connectionString))
            throw new DataAccessLayerException($"Invalid connection string {connectionString}");

        var configuration = Fluently.Configure()
            .Database(PostgreSQLConfiguration
                .PostgreSQL82.ConnectionString(connectionString).FormatSql())
            .Mappings(m => m.FluentMappings
                .AddFromAssembly(Assembly.GetExecutingAssembly()))
            .ExposeConfiguration(config =>
            {
                config.SetProperty("adonet.batch_size", "1");
                BuildSchema(config);
            });

        try
        {
            _sessionFactory = configuration.BuildSessionFactory();
            _logger.LogInformation("Database {DatabaseName} has been successfully connected", GetDatabaseName(connectionString));
        }
        catch (Exception e)
        {
            _logger.LogInformation(e, "The connection with the database {DatabaseName} failed", GetDatabaseName(connectionString));
            throw new DataAccessLayerException(e.Message);
        }

        return _sessionFactory;
    }

    private static void BuildSchema(Configuration cfg)
    {
        var schemaExport = new SchemaExport(cfg);
        const string path = "db/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        var schemaUpdate = new SchemaUpdate(cfg);
        schemaUpdate.Execute(false, true);

        schemaExport.SetOutputFile(path + "schema.sql")
            .Execute(false, false, false);
    }
        
    private static string GetDatabaseName(string connectionString)
    {
        var serverStartIndex = connectionString.IndexOf("Server=", StringComparison.Ordinal) + 7;
        var serverLength = connectionString.IndexOf(";", serverStartIndex, StringComparison.Ordinal) - serverStartIndex;

        var dbStarIndex = connectionString.IndexOf("Database=", StringComparison.Ordinal) + 9;
        var dbLength = connectionString.IndexOf(";", dbStarIndex, StringComparison.Ordinal) - dbStarIndex;

        var databaseName = connectionString.Substring(serverStartIndex, serverLength) +
                           "." + connectionString.Substring(dbStarIndex, dbLength);

        return databaseName;
    }
}