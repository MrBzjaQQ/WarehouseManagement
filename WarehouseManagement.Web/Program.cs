using WarehouseManagement.Infrastructure.Database;
using WarehouseManagement.Web.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDatabase();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var appSettings = app.Configuration.Get<AppSettings>();
using var scope = app.Services.CreateScope();
var migrator = scope.ServiceProvider.GetService<IDatabaseMigrator>();
await migrator.CreateDatabaseIfNecessaryAsync(appSettings?.Database.SystemDbConnection);
await migrator.MigrateDatabaseIfNecessaryAsync(appSettings?.Database.DefaultConnection);

app.Run();