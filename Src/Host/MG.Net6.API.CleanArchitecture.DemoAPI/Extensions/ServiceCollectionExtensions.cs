using MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;
using MG.Net6.API.CleanArchitecture.DemoAPI.Infrastructure.Filters;
using Microsoft.AspNetCore.Http.Features;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        new RegisterApiResources().Register(services, configuration);
        new RegisterApplicationInsightsTelemetry().Register(services, configuration);
        new RegisterAutoMapper().Register(services, configuration);
        new RegisterConfigSections().Register(services, configuration);
        new RegisterContracts().Register(services, configuration);
        new RegisterCors().Register(services, configuration);
        new RegisterFluentValidator().Register(services, configuration);
        //new RegisterJwtBearerAuthentication().Register(services, configuration);
        new RegisterMediatR().Register(services, configuration);
        new RegisterSwagger().Register(services, configuration);

        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(ApiExceptionFilterAttribute));
        }).AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
        });

        services.Configure<FormOptions>(o =>
        {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = int.MaxValue;
            o.MemoryBufferThreshold = int.MaxValue;
        });

        services.AddHttpContextAccessor();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}