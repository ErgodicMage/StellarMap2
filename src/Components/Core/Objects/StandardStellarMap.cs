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
    public Dictionary<string, Star>? Stars { get; set; }

    [JsonPropertyOrder(4)]
    public Dictionary<string, Planet>? Planets { get; set; }

    [JsonPropertyOrder(5)]
    public Dictionary<string, Satelite>? Satelites { get; set; }

    [JsonPropertyOrder(6)]
    public Dictionary<string, Asteroid>? Asteroids { get; set; }

    [JsonPropertyOrder(7)]
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
        if (foundObjectType is null) return;

        foundObjectType
            .When(StellarObjectType.Star).Then(() => Stars ??= new())
            .When(StellarObjectType.Planet).Then(() => Planets ??= new())
            .When(StellarObjectType.Satelite).Then(() => Satelites ??= new())
            .When(StellarObjectType.Asteroid).Then(() => Asteroids ??= new())
            .When(StellarObjectType.Comet).Then(() => Comets ??= new())
            .Default(() => { });
    }

    protected virtual Result<Dictionary<string, T>> GetDictionary<T>() where T : IStellarObject
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null)
            return Result.Error($"Can not find StellarObjectTypr for {nameof(T)}");

        Dictionary<string, T>? dictionary = default;
        foundObjectType
                .When(StellarObjectType.Star).Then(() => dictionary = Stars as Dictionary<string, T>)
                .When(StellarObjectType.Planet).Then(() => dictionary = Planets as Dictionary<string, T>)
                .When(StellarObjectType.Satelite).Then(() => dictionary = Satelites as Dictionary<string, T>)
                .When(StellarObjectType.Asteroid).Then(() => dictionary = Asteroids as Dictionary<string, T>)
                .When(StellarObjectType.Comet).Then(() => dictionary = Comets as Dictionary<string, T>)
                .Default(() => { });

        return dictionary!;
    }
    #endregion

    #region IEqualityComparer
    public bool Equals(IStellarMap? x, IStellarMap? y) => ReferenceEquals(x, y);

    public override bool Equals(object? obj) => Equals(this, obj as IStellarMap);

    public int GetHashCode([DisallowNull] IStellarMap obj)
        => HashCode.Combine(Name, MetaData, Stars, Planets, Satelites, Asteroids, Comets);

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
