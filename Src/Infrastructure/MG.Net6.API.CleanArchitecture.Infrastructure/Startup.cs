using MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb;
using MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb.Repositories;

namespace MG.Net6.API.CleanArchitecture.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IToDoRepository, ToDoRepository> ();
        services.AddSingleton<MGDemoDbContext>();
        return services;
    }
}
