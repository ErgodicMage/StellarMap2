namespace StellarMap.Components.Core;

public interface IStellarObject
{
    string Identifier { get; set; }
    string ParentIdentifier { get; set; }

    string Name { get; set; }

    StellarObjectProperties StellarObjectProperties { get; set; }

    Result Add<T>(T obj) where T : IStellarObject;

    Result<T> Get<T>(string identifier) where T : IStellarObject;
    Result<T> GetByName<T>(string name) where T : IStellarObject;
    Result<T> GetAll<T>() where T : IStellarObject;
}
