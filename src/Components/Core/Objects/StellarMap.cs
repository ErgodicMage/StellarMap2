
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

        var dict = CreateDictionaryIfNeeded<T>();
        if (!dict.Success) return dict;
        
        if (!dict.Value.ContainsKey(t.Identifier))
            return Result.Error($"{t.Identifier} already exists in {nameof(T)}s");
        
        dict.Value.Add(t.Identifier, t);
        return Result.Ok();
    }

    public Result<T> Get<T>(Identifier identifier) where T : IStellarObject
    {
        var result = GetDictionary<T>();
        if (!result.Success) return Result<T>.Error($"Can not find {identifier} in {nameof(T)}s");

        if (result.Value.TryGetValue(identifier, out var value))
            return value;

        return Result.Error($"Can not find {identifier} in {nameof(T)}s");
    }

    #region Dictionary Functions
    protected virtual Result<Dictionary<Identifier, T>> GetDictionary<T>() where T : IStellarObject
    {
        var dictionary = default(T) switch
        {
            Star => Stars as Dictionary<Identifier, T>,
            Planet => Planets as Dictionary<Identifier, T>,
            DwarfPlanet => DwarfPlanets as Dictionary<Identifier, T>,
            Satelite => Satelites as Dictionary<Identifier, T>,
            Asteroid => Asteroids as Dictionary<Identifier, T>,
            Comet => Comets as Dictionary<Identifier, T>,
            _ => default
        };

        return dictionary!;
    }

    protected virtual Result<Dictionary<Identifier, T>> CreateDictionaryIfNeeded<T>() where T : IStellarObject
    {
        switch (default(T))
        {
            case Star:
                Stars ??= new();
                break;
            case Planet:
                Planets ??= new();
                break;
            case DwarfPlanet:
                DwarfPlanets ??= new();
                break;
            case Satelite:
                Satelites ??= new();
                break;
            case Asteroid:
                Asteroids ??= new();
                break;
            case Comet:
                Comets ??= new();
                break;
        };

        return GetDictionary<T>();
    }
    #endregion
}
