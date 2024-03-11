using MG.Net6.API.CleanArchitecture.DemoAPI.Contracts;
using Polly.Extensions.Http;
using Polly;
using System.Net.Http.Headers;
using MG.Net6.API.CleanArchitecture.Domain.Configurations;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.DependencyInjection;

 

public class RegisterApiResources : IDependencyInjectionService
{
    public void Register(IServiceCollection services, IConfiguration config)
    {
       
    }
}