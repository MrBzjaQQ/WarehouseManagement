namespace WarehouseManagement.Infrastructure.Database;

public interface IDatabaseMigrator
{
    /// <summary>
    /// Creates database with table AppliedMigrations
    /// </summary>
    /// <param name="connectionString">postgres database connection string</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Nothing</returns>
    Task CreateDatabaseIfNecessaryAsync(string? connectionString, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Applies migrations from Migrations folder
    /// </summary>
    /// <param name="connectionString">Connection string to product database</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Nothing</returns>
    Task MigrateDatabaseIfNecessaryAsync(string? connectionString, CancellationToken cancellationToken = default);
}