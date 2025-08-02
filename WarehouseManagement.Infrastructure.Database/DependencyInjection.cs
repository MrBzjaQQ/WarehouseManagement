using Microsoft.Extensions.DependencyInjection;

namespace WarehouseManagement.Infrastructure.Database;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddScoped<IDatabaseMigrator, DatabaseMigrator>();
        return services;
    }
}