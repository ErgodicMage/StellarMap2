namespace StellarMap.Core;

public record class Identifier(string Id)
{
    public static readonly Identifier NoIdentifier = new(string.Empty);
}



