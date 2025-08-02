namespace WarehouseManagement.Domain;

public sealed class OutgoingDocument
{
    public Guid Identifier { get; private set; }
    public string Number { get; private set; }
    public Guid ClientIdentifier { get; private set; }
    public DateTime Date { get; private set; }
    public string Status { get; private set; }
}