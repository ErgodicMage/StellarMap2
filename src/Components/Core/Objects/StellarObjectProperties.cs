namespace StellarMap.Core;

public record struct StellarObjectProperties
{
    public StellarObjectProperties()
    {
    }

    public string Name { get; set; } = string.Empty;
    public string Designation {get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;

    public StellarObjectType? ObjectType { get; set; }
}
