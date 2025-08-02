namespace WarehouseManagement.Domain;

public sealed class Balance
{
    public Guid Identifier { get; private set; }
    public Guid ResourceIdentifier { get; private set; }
    public Guid UnitOfMeasurementIdentifier { get; private set; }
    public decimal Quantity { get; private set; }
}