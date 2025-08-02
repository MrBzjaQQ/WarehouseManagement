using WarehouseManagement.Infrastructure.Database;

namespace WarehouseManagement.Web.Settings;

public sealed record AppSettings
{
    public required DatabaseSettings Database { get; init; }
}