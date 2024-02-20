namespace StellarMap.Core;

public readonly record struct Identifier(string Id)
{
    public static readonly Identifier NoIdentifier = new(string.Empty);
}



