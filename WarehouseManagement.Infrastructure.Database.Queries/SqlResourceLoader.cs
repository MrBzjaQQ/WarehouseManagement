namespace WarehouseManagement.Infrastructure.Database.Queries;

public static class SqlResourceLoader
{
    public static string Load(string resourcePath)
    {
        var assembly = typeof(SqlResourceLoader).Assembly;
        using var stream = assembly.GetManifestResourceStream(resourcePath)
                           ?? throw new InvalidOperationException($"SQL file '{resourcePath}' not found in {assembly.FullName}.");
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
    
    public static string[] LoadFrom(string resourceFolder)
    {
        var assembly = typeof(SqlResourceLoader).Assembly;
        var allResources = assembly.GetManifestResourceNames();
        return allResources
            .Where(res => res.StartsWith(resourceFolder))
            .ToArray();
    }
    
    public static string[] LoadAll()
    {
        var assembly = typeof(SqlResourceLoader).Assembly;
        var allResources = assembly.GetManifestResourceNames();
        return allResources.ToArray();
    }
}