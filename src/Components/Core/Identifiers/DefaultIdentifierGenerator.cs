namespace StellarMap.Core;

public sealed class DefaultIdentifierGenerator : IIdentifierGenerator
{
    private DefaultIdentifierGenerator() { }

    public Identifier GenerateIdentifier(string objectType)
        => new ($"{objectType}-{Guid.NewGuid()}");

    public static readonly DefaultIdentifierGenerator Instance = new ();
}
