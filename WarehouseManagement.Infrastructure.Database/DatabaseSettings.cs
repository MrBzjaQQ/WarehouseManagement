namespace WarehouseManagement.Infrastructure.Database;

public sealed record DatabaseSettings
{
    public required string DefaultConnection { get; init; }
    public required string SystemDbConnection { get; init; }
}