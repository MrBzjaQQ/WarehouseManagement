namespace WarehouseManagement.Infrastructure.Database.Queries.DatabaseMigrator;

public static class DatabaseMigratorScripts
{
    private const string BaseName = "WarehouseManagement.Infrastructure.Database.Queries.DatabaseMigrator.DatabaseMigratorScripts.";
    public const string AllMigrations = "WarehouseManagement.Infrastructure.Database.Queries.Migrations";
    public const string IsMigrationApplied = $"{BaseName}IsMigrationApplied.sql";
    public const string MarkMigrationAsApplied = $"{BaseName}MarkMigrationAsApplied.sql";
    public const string CreateWarehouseManagementDatabase = $"{BaseName}CreateWarehouseManagementDatabase.sql";
    public const string IsWarehouseManagementDatabaseExists = $"{BaseName}IsWarehouseManagementDatabaseExists.sql";
    public const string CreateAppliedMigrationsTable = $"{BaseName}CreateAppliedMigrationsTable.sql";
}