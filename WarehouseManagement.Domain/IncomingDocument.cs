using System;

namespace WarehouseManagement.Domain;

public sealed class IncomingDocument
{
    public Guid Identifier { get; private set; }
    public string Number { get; private set; }
    public DateTime Date { get; private set; }
}