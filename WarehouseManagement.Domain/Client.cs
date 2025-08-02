namespace WarehouseManagement.Domain;

public sealed class Client 
{
    public Guid Identifier { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public string Status { get; private set; }
}