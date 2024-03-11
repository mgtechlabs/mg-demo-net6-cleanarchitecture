using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using MG.Net6.API.CleanArchitecture.Domain.Configurations;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

public class RegisterCors : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
        string[] allowedOrigins = config.GetSection(ApplicationConfig.CORS_POLICIES_SECTION).Get<string[]>();
        services.AddCors(options =>
        {
            options.AddPolicy(ApplicationConfig.CORS_POLICY_NAME, builder =>
            {
                builder.WithOrigins(allowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
        });
    }
}
