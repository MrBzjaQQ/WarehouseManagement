namespace WarehouseManagement.Domain;

public sealed class UnitOfMeasurement 
{
    public Guid Identifier { get; private set; }
    public string Name { get; private set; }
    public string Status { get; private set; }
}