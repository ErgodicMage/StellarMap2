﻿using System.Xml.Linq;

namespace StellarMap.Progression;

public class ProgressionMap : StandardStellarMap, IProgressionMap
{
    [JsonPropertyOrder(11)]
    public Dictionary<string, Habitat>? Habitats { get; set; }

    #region Constructors
    public ProgressionMap() { }

    public ProgressionMap(string name)
    {
        Name = name;
        MetaData = new();
    }
    #endregion

    #region Get
    public Result<ProgressionStarSystem> GetProgressionStarSystem(Identifier identifier)
        => Get<StarSystem>(identifier).Convert<ProgressionStarSystem, StarSystem>();

    public Result<ProgressionStar> GetProgressionStar(Identifier identifier)
        => Get<Star>(identifier).Convert<ProgressionStar, Star>();

    public Result<ProgressionPlanet> GetProgressionPlanet(Identifier identifier)
        => Get<Planet>(identifier).Convert<ProgressionPlanet, Planet>();

    public Result<ProgressionSatelite> GetProgressionSatelite(Identifier identifier)
        => Get<Satelite>(identifier).Convert<ProgressionSatelite, Satelite>();

    public Result<ProgressionAsteroid> GetProgressionAsteroid(Identifier identifier)
        => Get<Asteroid>(identifier).Convert<ProgressionAsteroid, Asteroid>();

    public Result<Habitat> GetHabitat(Identifier identifier)
        => Get<Habitat>(identifier);
    #endregion

    #region Add
    public Result Add(ProgressionStarSystem starSystem) => Add<StarSystem>(starSystem);

    public Result Add(ProgressionStar star) => Add<Star>(star);

    public Result Add(ProgressionPlanet planet) => Add<Planet>(planet);

    public Result Add(ProgressionSatelite satelite) => Add<Satelite>(satelite);

    public Result Add(ProgressionAsteroid asteroid) => Add<Asteroid>(asteroid);
    #endregion

    #region Dictionary
    protected override void CreateDictionary<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success) return;

        // can not use switch pattern matching expressions because
        // StarSystems ??= new returns a different type than Stars ?? = new() so it doesn't know what to "return"
        switch (foundObjectType.Value.Name)
        {
            case ProgressionObjectType.PROGRESSIONSTARSYSTEM: base.CreateDictionary<StarSystem>(); break;
            case ProgressionObjectType.PROGRESSIONSTAR: base.CreateDictionary<Star>(); break;
            case ProgressionObjectType.PROGRESSIONPLANET: base.CreateDictionary<Planet>(); break;
            case ProgressionObjectType.PROGRESSIONSATELITE: base.CreateDictionary<Satelite>(); break;
            case ProgressionObjectType.PROGRESSIONASTEROID: base.CreateDictionary<Asteroid>(); break;

            case ProgressionObjectType.HABITAT: Habitats ??= new(); break;

            default: base.CreateDictionary<T>(); break;
        };
    }

    protected override Result<Dictionary<string, T>> GetDictionary<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return Result.Error($"Can not find ProgressionObjectType for {nameof(T)}");

#pragma warning disable CS0458
        return foundObjectType.Value.Name switch
        {
            ProgressionObjectType.PROGRESSIONSTARSYSTEM => (base.GetDictionary<StarSystem>() as Dictionary<string, T>)!,
            ProgressionObjectType.PROGRESSIONSTAR => (base.GetDictionary<Star>() as Dictionary<string, T>)!,
            ProgressionObjectType.PROGRESSIONPLANET => (base.GetDictionary<Planet>() as Dictionary<string, T>)!,
            ProgressionObjectType.PROGRESSIONSATELITE => (base.GetDictionary<Satelite>() as Dictionary<string, T>)!,
            ProgressionObjectType.PROGRESSIONASTEROID => (base.GetDictionary<Asteroid>() as Dictionary<string, T>)!,

            ProgressionObjectType.HABITAT => (Habitats as Dictionary<string, T>)!,

            _ => base.GetDictionary<T>()
        };
#pragma warning restore CS0458
    }
    #endregion

    #region GenObjectCount
    public override Result<int> GetObjectCount(StellarObjectType type)
    {
        return type.Name switch
        {
            ProgressionObjectType.PROGRESSIONSTARSYSTEM => base.GetObjectCount(StellarObjectType.StarSystem),
            ProgressionObjectType.PROGRESSIONSTAR => base.GetObjectCount(StellarObjectType.Star),
            ProgressionObjectType.PROGRESSIONPLANET => base.GetObjectCount(StellarObjectType.Planet),
            ProgressionObjectType.PROGRESSIONSATELITE => base.GetObjectCount(StellarObjectType.Satelite),
            ProgressionObjectType.PROGRESSIONASTEROID => base.GetObjectCount(StellarObjectType.Asteroid),
            ProgressionObjectType.HABITAT => Habitats is null ? 0 : Habitats.Count,
            _ => base.GetObjectCount(type)
        };
    }
    #endregion
}
