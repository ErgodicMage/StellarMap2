using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StellarMap.Core;

public class StandardStellarMap : IStellarMap
{
    [JsonPropertyOrder(1)]
    public string Name { get; set; }

    [JsonPropertyOrder(2)]
    public Dictionary<string, string> MetaData { get; set; }

    [JsonPropertyOrder(3)]
    public Dictionary<string, StarSystem>? StarSystems { get; set; }

    [JsonPropertyOrder(4)]
    public Dictionary<string, Star>? Stars { get; set; }

    [JsonPropertyOrder(5)]
    public Dictionary<string, Planet>? Planets { get; set; }

    [JsonPropertyOrder(6)]
    public Dictionary<string, DwarfPlanet>? DwarfPlanets { get; set; }

    [JsonPropertyOrder(7)]
    public Dictionary<string, Satelite>? Satelites { get; set; }

    [JsonPropertyOrder(8)]
    public Dictionary<string, Asteroid>? Asteroids { get; set; }

    [JsonPropertyOrder(9)]
    public Dictionary<string, Comet>? Comets { get; set; }

    #region Constructors
#pragma warning disable CS8618
    public StandardStellarMap() { }
#pragma warning restore CS8618

    public StandardStellarMap(string name)
    {
        Name = name;
        MetaData = new();
    }
    #endregion

    public virtual void DefaultMetaData()
    {
        MetaData.Add("Map", "StandardStellarMap");
        MetaData.Add("Version", "0.1");
        MetaData.Add("Author", "ErogicMage");
        MetaData.Add("Email", "ErgodicMage@gmail.com");
        MetaData.Add("License", "MIT License, 2024");
        MetaData.Add("Github", "https://github.com/ErgodicMage/StellarMap2");
        MetaData.Add("Date", DateOnly.FromDateTime(DateTime.Now).ToString());
    }

    public Result Add<T>(T t) where T : IStellarObject
    {
        var result = GuardClause.Null(t);
        if (!result.Success) return result;
        CreateDictionary<T>();
        var dict = GetDictionary<T>();
        if (!dict.Success) return dict;

        if (dict.Value.ContainsKey(t.Identifier.Id))
            return Result.Ok(); // if it already exists then don't add it
        
        dict.Value.Add(t.Identifier.Id, t);
        return Result.Ok();
    }

    public Result<T> Get<T>(Identifier identifier) where T : IStellarObject
    {
        var result = GetDictionary<T>();
        if (!result.Success) return Result<T>.Error($"Can not find {identifier} in {nameof(T)}s");

        if (result.Value.TryGetValue(identifier.Id, out var value))
            return value;

        return Result.Error($"Can not find {identifier} in {nameof(T)}s");
    }

    #region Dictionary
    protected virtual void CreateDictionary<T>() where T : IStellarObject
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success) return;

        // can not use switch pattern matching expressions because
        // StarSystems ??= new returns a different type than Stars ?? = new() so it doesn't know what to "return"
        switch (foundObjectType.Value.Name)
        {
            case StellarObjectType.STARSYSTEM : StarSystems ??= new(); break;
            case StellarObjectType.STAR : Stars ??= new(); break;
            case StellarObjectType.PLANET : Planets ??= new(); break;
            case StellarObjectType.DWARFPLANET : DwarfPlanets ??= new(); break;
            case StellarObjectType.SATELITE : Satelites ??= new(); break;
            case StellarObjectType.ASTEROID: Asteroids ??= new(); break;
            case StellarObjectType.COMET : Comets ??= new(); break;
        }
    }

    protected virtual Result<Dictionary<string, T>> GetDictionary<T>() where T : IStellarObject
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return Result.Error(foundObjectType.ErrorMessage);

        return foundObjectType.Value.Name switch
        {
            StellarObjectType.STARSYSTEM => (StarSystems as Dictionary<string, T>)!,
            StellarObjectType.STAR => (Stars as Dictionary<string, T>)!,
            StellarObjectType.PLANET => (Planets as Dictionary<string, T>)!,
            StellarObjectType.DWARFPLANET => (DwarfPlanets as Dictionary<string, T>)!,
            StellarObjectType.SATELITE => (Satelites as Dictionary<string, T>)!,
            StellarObjectType.ASTEROID => (Asteroids as Dictionary<string, T>)!,
            StellarObjectType.COMET => (Comets as Dictionary<string, T>)!,
            _ => Result.Error($"{foundObjectType.Value.Name} is not in a StallarMap")
        };
    }
    #endregion

    #region GenObjectCount
    public virtual Result<int> GetObjectCount(StellarObjectType type)
    {
        return type.Name switch
        {
            StellarObjectType.STARSYSTEM => StarSystems is null ? 0 : StarSystems.Count,
            StellarObjectType.STAR => Stars is null ? 0 : Stars.Count,
            StellarObjectType.PLANET => Planets is null ? 0 : Planets.Count,
            StellarObjectType.DWARFPLANET => DwarfPlanets is null ? 0 : DwarfPlanets.Count,
            StellarObjectType.SATELITE => Satelites is null ? 0 : Satelites.Count,
            StellarObjectType.ASTEROID => Asteroids is null ? 0 : Asteroids.Count,
            StellarObjectType.COMET => Comets is null ? 0 : Comets.Count,
            _ => -50001
        };
    }
    #endregion

    #region IEqualityComparer
    public bool Equals(IStellarMap? x, IStellarMap? y) => ReferenceEquals(x, y);

    public override bool Equals(object? obj) => Equals(this, obj as IStellarMap);

    public int GetHashCode([DisallowNull] IStellarMap obj)
        => HashCode.Combine(HashCode.Combine(Name, MetaData), StarSystems, Stars, Planets, DwarfPlanets, Satelites, Asteroids, Comets);

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
