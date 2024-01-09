namespace StellarMap.Core;

public abstract class BaseStellarObject
{
    public BaseStellarObject() { }


    public Identifier Identifier { get; set; } = Identifier.NoIdentifier;
    public Identifier ParentIdentifier { get; set; } = Identifier.NoIdentifier;
    public string? Name { get => StellarObjectProperties.Name; }
    public string? ObjectType { get => StellarObjectProperties.ObjectType; }
    public StellarObjectProperties StellarObjectProperties { get; set; }
}
