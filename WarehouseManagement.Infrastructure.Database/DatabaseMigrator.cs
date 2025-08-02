using Npgsql;
using WarehouseManagement.Infrastructure.Database.Queries;
using WarehouseManagement.Infrastructure.Database.Queries.DatabaseMigrator;

namespace WarehouseManagement.Infrastructure.Database;

public sealed class DatabaseMigrator: IDatabaseMigrator
{
    public async Task CreateDatabaseIfNecessaryAsync(string? connectionString, CancellationToken cancellationToken = default)
    {
        VerifyConnectionStringAndThrow(connectionString);
        
        await using var connection = new NpgsqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        await using var checkCmd = new NpgsqlCommand(SqlResourceLoader.Load(DatabaseMigratorScripts.IsWarehouseManagementDatabaseExists), connection);
        var exists = await checkCmd.ExecuteScalarAsync(cancellationToken) != null;
        if (exists)
        {
            return;
        }
        
        await using var createCmd = new NpgsqlCommand(SqlResourceLoader.Load(DatabaseMigratorScripts.CreateWarehouseManagementDatabase), connection);
        await createCmd.ExecuteNonQueryAsync(cancellationToken);
    }
    
    public async Task MigrateDatabaseIfNecessaryAsync(string? connectionString, CancellationToken cancellationToken = default)
    {
        VerifyConnectionStringAndThrow(connectionString);
        
        // Use ADO.NET to run migrations
        var migrationFiles = SqlResourceLoader.LoadFrom(DatabaseMigratorScripts.AllMigrations);

        await using (var connection = new NpgsqlConnection(connectionString))
        {
            await connection.OpenAsync(cancellationToken);
            
            // Create migrations table if not exists
            await using var createAppliedMigrationsTable = new NpgsqlCommand(SqlResourceLoader.Load(DatabaseMigratorScripts.CreateAppliedMigrationsTable), connection);
            await createAppliedMigrationsTable.ExecuteNonQueryAsync(cancellationToken);

            foreach (var migrationFile in migrationFiles)
            {
                var migrationName = migrationFile.Replace($"{DatabaseMigratorScripts.AllMigrations}.", "");

                // Check if this migration has already been applied
                await using (var checkCommand = new NpgsqlCommand(SqlResourceLoader.Load(DatabaseMigratorScripts.IsMigrationApplied), connection))
                {
                    checkCommand.Parameters.AddWithValue("@name", migrationName);
                    var result = await checkCommand.ExecuteScalarAsync(cancellationToken);
                    var isApplied = result != null;
                    if (isApplied)
                    {
                        continue;
                    }
                }

                // Load and execute the SQL script
                string sqlScript = SqlResourceLoader.Load(migrationFile);
                await using (var command = new NpgsqlCommand(sqlScript, connection))
                {
                    await command.ExecuteNonQueryAsync(cancellationToken);
                }

                // Mark migration as applied
                await using (var insertCommand = new NpgsqlCommand(SqlResourceLoader.Load(DatabaseMigratorScripts.MarkMigrationAsApplied), connection))
                {
                    insertCommand.Parameters.AddWithValue("@name", migrationName);
                    await insertCommand.ExecuteNonQueryAsync(cancellationToken);
                }
            }
        }
    }

    private void VerifyConnectionStringAndThrow(string? connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }
    }
}
