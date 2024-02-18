namespace StellarMap.Core;

public interface IStellarObject
{
    Identifier Identifier { get; set; }
    Identifier ParentIdentifier { get; set; }

    string? Name { get; }

    StellarObjectType? ObjectType { get; }

    StellarObjectProperties StellarObjectProperties { get; set; }

    Result Add<T>(T obj) where T : IStellarObject;

    Result<T> Get<T>(string identifier) where T : IStellarObject;
    Result<T> GetByName<T>(string name) where T : IStellarObject;
    Result<T> GetAll<T>() where T : IStellarObject;
}
