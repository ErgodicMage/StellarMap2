namespace StellarMap.Core;

public sealed class DefaultIdentifierGenerator : IIdentifierGenerator
{
    private DefaultIdentifierGenerator() { }

    public Identifier GenerateIdentifier(StellarObjectType type, IStellarMap? _ = null)
        => new ($"{type.Name}-{Guid.NewGuid()}");

    public static readonly DefaultIdentifierGenerator Instance = new ();
}
