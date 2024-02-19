
namespace StellarMap.Core;

public abstract class StellarObject : IStellarObject
{
    public string? Name { get; init; }
    public string? AlternativeName { get; set; }
    public string? Description { get; set; }
    public string? Designation { get; set; }

    public IStellarMap Map { get; init; }


    public Identifier Identifier { get; init; } = Identifier.NoIdentifier;
    public Identifier ParentIdentifier { get; set; } = Identifier.NoIdentifier;
    public StellarObjectType ObjectType { get; init;  }

#pragma warning disable CS8618
    public StellarObject() { }
#pragma warning restore CS8618

    public StellarObject(string name, Identifier identifier, IStellarMap map, StellarObjectType objectType)
    {
        Name = name;
        Identifier = identifier;
        Map = map;
        ObjectType = objectType;
    }
}
