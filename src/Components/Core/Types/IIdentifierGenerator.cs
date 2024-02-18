namespace StellarMap.Core;

public interface IIdentifierGenerator
{
    Identifier GenerateIdentifier(string objectType);
}
