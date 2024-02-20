﻿namespace StellarMap.Core;

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
        CreateDictionary<T>();
        var dict = GetDictionary<T>();
        if (!dict.Success) return dict;
        
        if (dict.Value.ContainsKey(t.Identifier))
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

    #region Dictionary
    protected virtual void CreateDictionary<T>() where T : IStellarObject
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null) return;

        foundObjectType
            .When(StellarObjectType.Star).Then(() => Stars ??= new())
            .When(StellarObjectType.Planet).Then(() => Planets ??= new())
            .When(StellarObjectType.DwarfPlanet).Then(() => DwarfPlanets ??= new())
            .When(StellarObjectType.Satelite).Then(() => Satelites ??= new())
            .When(StellarObjectType.Asteroid).Then(() => Asteroids ??= new())
            .When(StellarObjectType.Comet).Then(() => Comets ??= new())
            .Default(() => { });
    }

    protected virtual Result<Dictionary<Identifier, T>> GetDictionary<T>() where T : IStellarObject
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null)
            return Result.Error($"Can not find StellarObjectTypr for {nameof(T)}");

        Dictionary<Identifier, T>? dictionary = default;
        foundObjectType
                .When(StellarObjectType.Star).Then(() => dictionary = Stars as Dictionary<Identifier, T>)
                .When(StellarObjectType.Planet).Then(() => dictionary = Planets as Dictionary<Identifier, T>)
                .When(StellarObjectType.DwarfPlanet).Then(() => dictionary = DwarfPlanets as Dictionary<Identifier, T>)
                .When(StellarObjectType.Satelite).Then(() => dictionary = Satelites as Dictionary<Identifier, T>)
                .When(StellarObjectType.Asteroid).Then(() => dictionary = Asteroids as Dictionary<Identifier, T>)
                .When(StellarObjectType.Comet).Then(() => dictionary = Comets as Dictionary<Identifier, T>)
                .Default(() => { });

        return dictionary!;
    }
    #endregion
}
