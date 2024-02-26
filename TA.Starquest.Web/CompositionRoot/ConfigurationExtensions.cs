using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Hosting;
using Ninject.Web.AspNetCore.Hosting;

namespace TA.Starquest.Web.CompositionRoot;

internal static class ConfigurationExtensions
{
    internal static void ConfigureStaticFiles(this IApplicationBuilder app, IWebHostEnvironment env)
    {
        var cacheMaxAgeSeconds = env.IsDevelopment() ? 20 : 604800;
        ;
        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                // using Microsoft.AspNetCore.Http;
                ctx.Context.Response.Headers.Append(
                                                    "Cache-Control",
                                                    $"public, max-age={cacheMaxAgeSeconds}");
            }
        });
    }

    public static T UseHttpSys<T>(this T config)
        where T : IAspNetCoreHostConfiguration
    {
        return config.UseHttpSys(_ => { });
    }

    public static T UseHttpSys<T>(this T config, Action<HttpSysOptions> configureAction)
        where T : IAspNetCoreHostConfiguration
    {
        config.ConfigureHostingModel(builder => { builder.UseHttpSys(configureAction); });
        return config;
    }

    public static T UseIIS<T>(this T config)
        where T : IAspNetCoreHostConfiguration
    {
        config.ConfigureHostingModel(builder =>
        {
            builder
                .UseIIS()
                .UseIISIntegration();
        });
        return config;
    }
}