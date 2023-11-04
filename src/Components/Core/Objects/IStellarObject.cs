namespace StellarMap.Core.Objects;

public interface IStellarObject
{
    string Identifier { get; set; }

    string ParentIdentifier { get; set; }

    string Name { get; set; }

    string ObjectType { get; set; }

    StellarObjectProperties Properties { get; set; }

    Result Add<T>(T t);

    Result<T> Get<T>(string identifier);
    Result<T> GetbyName<T>(string name);
}
