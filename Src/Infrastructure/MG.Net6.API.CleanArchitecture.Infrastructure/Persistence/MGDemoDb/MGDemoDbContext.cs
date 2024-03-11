namespace MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb;

public class MGDemoDbContext
{
    private readonly IConfiguration config;
    private readonly SqlConnectionStringBuilder sqlConnectionStringBuilder;

    public MGDemoDbContext(IConfiguration config)
    {
        this.config = config;
        this.sqlConnectionStringBuilder = new SqlConnectionStringBuilder(this.config.GetConnectionString(ConnectionStringKeys.MG_DEMO_DB_SQL_CONNECTION_STRING));

#if DEBUG
        this.sqlConnectionStringBuilder.Password = "asdasdf";
#else
        this.sqlConnectionStringBuilder.Password = Environment.GetEnvironmentVariable("SQLPassword");
#endif
    }

    public SqlConnection CreateConnection() => new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
    public string ConnectionString() => sqlConnectionStringBuilder.ConnectionString;
}
