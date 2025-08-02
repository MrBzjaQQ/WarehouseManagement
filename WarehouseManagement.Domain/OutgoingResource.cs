namespace WarehouseManagement.Domain;

public sealed class OutgoingResource
{
    public Guid Identifier { get; }
    public Guid ResourceIdentifier { get; }
    public Guid UnitOfMeasurementIdentifier { get; }
    public decimal Quantity { get; }

    public OutgoingResource(Guid identifier, Guid resourceIdentifier, Guid unitOfMeasurementIdentifier, decimal quantity) {
        Identifier = identifier;
        ResourceIdentifier = resourceIdentifier;
        UnitOfMeasurementIdentifier = unitOfMeasurementIdentifier;
        Quantity = quantity;
    }
}