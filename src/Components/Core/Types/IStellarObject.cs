namespace StellarMap.Core;

public interface IStellarObject : IEqualityComparer<StellarObject>
{
    string? Name { get; init; }

    IStellarMap Map { get; init; }

    Identifier Identifier { get; init; }
    Identifier ParentIdentifier { get; set; }

    StellarObjectType ObjectType { get; init; }

    Dictionary<string, string> Properties { get; init; }

    PhysicalProperties? PhysicalProperties { get; set; }

    Result<T> Get<T>(Identifier identifier) where T : IStellarObject;

    Result<T> Get<T>(string name) where T : IStellarObject;

    Result<IReadOnlyList<T>> GetAll<T>() where T : IStellarObject;

    Result Add<T>(T t) where T : IStellarObject;
}
