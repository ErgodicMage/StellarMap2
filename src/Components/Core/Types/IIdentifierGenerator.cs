namespace StellarMap.Core;

public interface IIdentifierGenerator
{
    Identifier GenerateIdentifier(StellarObjectType type, IStellarMap map);
}
