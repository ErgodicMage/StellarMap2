namespace StellarMap.Core;

public record struct Identifier(string Id)
{
    public static readonly Identifier NoIdentifier = new(string.Empty);
}



