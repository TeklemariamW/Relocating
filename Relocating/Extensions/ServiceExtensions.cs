using Azure.Identity;
using Entities;
using Interfaces;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace Relocating.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
    public static void ConfigureIISIntegration(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options =>
        {

        });
    }
    public static void ConfigureLoggerService(this IServiceCollection services)
    {
        services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
    {
        string accountEndpoint = configuration["ConnectionString:CosmonsDB:AccountKey"];
        string databaseId = configuration["ConnectionString:CosmonsDB:DatabaseId"];

        if(environment.IsDevelopment())
        {
            services.AddDbContext<RepositoryContext>(delegate (DbContextOptionsBuilder options)
            {
                options.UseCosmos(accountEndpoint, databaseId);
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }

        if (environment.IsProduction())
        {
            services.AddDbContext<RepositoryContext>(delegate (DbContextOptionsBuilder options)
            {
                options.UseCosmos(accountEndpoint, new DefaultAzureCredential(), databaseId);
            });
        }

        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}
