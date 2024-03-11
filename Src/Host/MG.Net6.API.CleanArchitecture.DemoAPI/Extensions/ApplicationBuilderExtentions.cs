﻿using MG.Net6.API.CleanArchitecture.Domain.Configurations;
using Serilog.Context;

namespace MG.Net6.API.CleanArchitecture.DemoAPI.Extensions;
 

public static class ApplicationBuilderExtentions
{
    public static void AddMiddleware(this IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment() || environment.IsStaging() || environment.IsProduction())
        {
            applicationBuilder.UseDeveloperExceptionPage();
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "MG.Net6.API.CleanArchitecture.DemoAPI v1");
            });
        }

        applicationBuilder.UseHttpsRedirection();
        applicationBuilder.UseCors(ApplicationConfig.CORS_POLICY_NAME);
        applicationBuilder.UseRouting();
        //applicationBuilder.UseAuthentication();
        //applicationBuilder.Use(async (httpContext, next) =>
        //{
        //    if (httpContext.User.Identity != null)
        //    {
        //        var userName = httpContext.User.Identity.IsAuthenticated ? httpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value : "";
        //        LogContext.PushProperty("UserName", userName); //Push user in LogContext;  
        //    }
        //    await next.Invoke();
        //});
        //applicationBuilder.UseAuthorization();
    }
}