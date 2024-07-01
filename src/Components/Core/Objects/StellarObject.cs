
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StellarMap.Core;

public abstract class StellarObject : IStellarObject
{
    #region Properties
    [JsonPropertyOrder(1)]
    public string? Name { get; init; }

    [JsonIgnore]
    public IStellarMap Map { get; init; }

    [JsonPropertyOrder(2)]
    public Identifier Identifier { get; init; } = Identifier.NoIdentifier;

    [JsonPropertyOrder(3)]
    public Identifier ParentIdentifier { get; set; } = Identifier.NoIdentifier;
    
    [JsonPropertyOrder(4)]
    public StellarObjectType ObjectType { get; init;  }

    [JsonPropertyOrder(5)]
    public Dictionary<string, string> Properties { get; init; }

    [JsonPropertyOrder(6)]
    public PhysicalProperties? PhysicalProperties {get; set; }
    #endregion

    #region Constructors
#pragma warning disable CS8618
    public StellarObject() { }
#pragma warning restore CS8618

    public StellarObject(string name, Identifier identifier, IStellarMap map, StellarObjectType objectType)
    {
        Name = name;
        Identifier = identifier;
        Map = map;
        ObjectType = objectType;
        Properties = new();
    }
    #endregion

    #region Get
    public virtual Result<T> Get<T>(Identifier identifier) where T : IStellarObject
    {
        var result = GuardClause.Null(Map).Null(Identifier);
        if (!result.Success) return result;

        var identifiers = GetIdentifiers<T>();
        if (!identifiers.Success)
            return Result.Error($"No {typeof(T).Name}s for {GetType().Name} {Name} {Identifier}");

        if (!identifiers.Value.Any(i => i.Value == identifier))
            return Result.Error($"{typeof(T).Name} {identifier} is not found in {GetType().Name} {Name} {Identifier}");

        return Map.Get<T>(identifier);
    }

    public virtual Result<T> Get<T>(string name) where T : IStellarObject
    {
        var result = GuardClause.Null(Map).NullOrWhiteSpace(name);
        if (!result.Success) return result;

        var identifiers = GetIdentifiers<T>();
        if (!identifiers.Success)
            return Result.Error($"{GetType().Name} does not have Object Type {typeof(T).Name}");

        var identifier = identifiers.Value.FirstOrDefault(o => o.Key == name).Value;

        if (identifier is null)
            return Result.Error($"{typeof(T).Name} {name} not found for {GetType().Name} {Name} {Identifier}");

        return Map.Get<T>(identifier);
    }

    public virtual Result<IReadOnlyList<T>> GetAll<T>() where T : IStellarObject
    {
        var result = GuardClause.Null(Map);
        if (!result.Success) return result;

        var identifiers = GetIdentifiers<T>();
        if (!identifiers.Success)
            return Result.Error($"{GetType().Name} does not have Object Type {typeof(T).Name}");

        List<T> objects = new();

        foreach (var (_, identifier) in identifiers.Value)
        {
            var obj = Map.Get<T>(identifier);
            if (obj.Success) 
                objects.Add(obj);
        }

        return objects;
    }

    protected virtual Result<Dictionary<string, Identifier>> GetIdentifiers<T>() where T : IStellarObject 
        => Result.Error("StellarObject does not contain any identifiers");
    #endregion

    #region Add
    public virtual Result Add<T>(T t) where T : IStellarObject
    {
        var result = GuardClause.Null(Map).Null(Identifier);
        if (!result.Success) return result;

        CreateIdentifiers<T>();
        var identifiers = GetIdentifiers<T>();
        if (!identifiers.Success)
            return Result.Error($"No {typeof(T).Name}s for {GetType().Name} {Name} {Identifier}");

        if (identifiers.Value.Any(i => i.Value == t.Identifier))
            return Result.Error($"{t.GetType().Name} {t.Name} {t.Identifier} already exists in {GetType().Name} {Name} {Identifier}");

        t.ParentIdentifier = Identifier;

        identifiers.Value.Add(t.Name!, t.Identifier);

        return Map.Add(t);
    }

    protected virtual void CreateIdentifiers<T>() where T : IStellarObject { }
    #endregion

    #region IEqualityComparer
    public bool Equals(StellarObject? x, StellarObject? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (x.Name is null || y.Name is null || x.Identifier is null || y.Identifier is null) return false;

        if (x.Name != y.Name) return false;
        if (x.Identifier != y.Identifier) return false;

        if (!(x.ParentIdentifier is null && y.ParentIdentifier is null))
        {
            if (x.ParentIdentifier is null || y.ParentIdentifier is null) return false;
            if (x.ParentIdentifier != y.ParentIdentifier) return false;
        }

        if (!(x.ObjectType is null && y.ObjectType is null))
        {
            if (x.ObjectType is null || y.ObjectType is null) return false;
            if (x.ObjectType != y.ObjectType) return false;
        }

        if (!(x.PhysicalProperties is null && y.PhysicalProperties is null))
        {
            if (x.PhysicalProperties is null || y.PhysicalProperties is null) return false;
            if (x.PhysicalProperties != y.PhysicalProperties) return false;
        }

        return CommonFunctionality.CompareDictionaries(x.Properties, y.Properties);

    }

    public override bool Equals(object? obj) => Equals(this, obj as StellarObject);

    public int GetHashCode([DisallowNull] StellarObject obj)
    {
        return HashCode.Combine(obj.Name, obj,Identifier, obj.ParentIdentifier, obj.ObjectType, obj.Properties, obj.PhysicalProperties);
    }

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
