
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace StellarMap.Core;

public abstract class StellarObject : IStellarObject
{
    public string? Name { get; init; }

    public IStellarMap Map { get; init; }

    public Identifier Identifier { get; init; } = Identifier.NoIdentifier;
    public Identifier ParentIdentifier { get; set; } = Identifier.NoIdentifier;
    public StellarObjectType ObjectType { get; init;  }

    public Dictionary<string, string> Properties { get; init; }

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

        foreach (var (name, identifier) in identifiers.Value)
        {
            var obj = Map.Get<T>(identifier);
            if (obj.Success) 
                objects.Add(obj);
        }

        return objects;
    }

    protected virtual Result<IDictionary<string, Identifier>> GetIdentifiers<T>() where T : IStellarObject => Result.Error(string.Empty);
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
            if (x.Identifier != y.Identifier) return false;
        }

        if (!(x.ObjectType is null && y.ObjectType is null))
        {
            if (x.ObjectType is null || y.ObjectType is null) return false;
            if (x.ObjectType.Value != y.ObjectType.Value) return false;
        }

        return CommonFunctionality.CompareDictionaries(x.Properties, y.Properties);

    }

    public override bool Equals(object? obj) => Equals(this, obj as StellarObject);

    public int GetHashCode([DisallowNull] StellarObject obj)
    {
        return HashCode.Combine(obj.Name, obj,Identifier, obj.ParentIdentifier, obj.ObjectType, obj.Properties);
    }

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
