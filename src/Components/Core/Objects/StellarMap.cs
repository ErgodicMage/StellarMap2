
namespace StellarMap.Core;

public class StellarMap : IStellarMap
{
    public string Name { get; set; }
    public Dictionary<string, string> MetaData { get; }
    public Dictionary<Identifier, Star>? Stars { get; set; }
    public Dictionary<Identifier, Planet>? Planets { get; set; }
    public Dictionary<Identifier, Satelite>? Satelites { get; set; }
    public Dictionary<Identifier, DwarfPlanet>? DwarfPlanets { get; set; }
    public Dictionary<Identifier, Asteroid>? Asteroids { get; set; }
    public Dictionary<Identifier, Comet>? Comets { get; set; }

    #region Constructors
#pragma warning disable CS8618
    public StellarMap() { }
#pragma warning restore CS8618

    public StellarMap(string name)
    {
        Name = name;
        MetaData = new();
    }
    #endregion

    public Result Add<T>(T t) where T : IStellarObject
    {
        var result = GuardClause.Null(t);
        if (!result.Success) return result;

        var dict = GetDictionaryCreateIfNeeded<T>(true);
        if (!dict.Success) return dict;
        
        if (!dict.Value.ContainsKey(t.Identifier))
            return Result.Error($"{t.Identifier} already exists in {nameof(T)}s");
        
        dict.Value.Add(t.Identifier, t);
        return Result.Ok();
    }

    public Result<T> Get<T>(Identifier identifier) where T : IStellarObject
    {
        var result = GetDictionaryCreateIfNeeded<T>(false);
        if (!result.Success) return Result<T>.Error($"Can not find {identifier} in {nameof(T)}s");

        if (result.Value.TryGetValue(identifier, out var value))
            return value;

        return Result.Error($"Can not find {identifier} in {nameof(T)}s");
    }

    #region Get Dictionary
    protected virtual Result<Dictionary<Identifier, T>> GetDictionaryCreateIfNeeded<T>(bool create) where T : IStellarObject
    {
        var foundObjectType = StellarObjectType.Get(typeof(T));
        if (!foundObjectType.Success)
            return Result.Error($"Can not find StellarObjectTypr for {nameof(T)}");

        Dictionary<Identifier, T>? dictionary = default;

        switch (foundObjectType.Value.Name)
        {
            case nameof(StellarObjectType.Star):
                if (create) Stars ??= new();
                dictionary = Stars as Dictionary<Identifier, T>;
                break;
            case nameof(StellarObjectType.Planet):
                if (create) Planets ??= new();
                dictionary = Planets as Dictionary<Identifier, T>;
                break;
            case nameof(StellarObjectType.DwarfPlanet):
                if (create) DwarfPlanets ??= new();
                dictionary = DwarfPlanets as Dictionary<Identifier, T>;
                break;
            case nameof(StellarObjectType.Satelite):
                if (create) Satelites ??= new();
                dictionary = Satelites as Dictionary<Identifier, T>;
                break;
            case nameof(StellarObjectType.Asteroid):
                if (create) Asteroids ??= new();
                dictionary = Asteroids as Dictionary<Identifier, T>;
                break;
            case nameof(StellarObjectType.Comet):
                if (create) Comets ??= new();
                dictionary = Comets as Dictionary<Identifier, T>;
                break;
        };
        return dictionary!;
    }
    #endregion
}
