using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace StellarMap.Core;

public class Star : StellarObject, IStellarObject, IEqualityComparer<Star>
{
    #region Properties
    [JsonPropertyOrder(11)]
    public string? StellarClass {get; set; }

    [JsonPropertyOrder(12)]
    public Dictionary<string, Identifier>? Planets {get; set; }

    [JsonPropertyOrder(13)]
    public Dictionary<string, Identifier> DwarfPlanets { get; set; }

    [JsonPropertyOrder(14)]
    public Dictionary<string, Identifier> Asteroids {get; set; }

    [JsonPropertyOrder(15)]
    public Dictionary<string, Identifier> Comets {get; set; }

    #endregion

    #region Constructors
    public Star() { }

    public Star(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Star) { }
    #endregion

    #region Get
    public Result<Planet> GetPlanet(Identifier identifier) => Get<Planet>(identifier);
    public Result<Planet> GetPlanet(string name) => Get<Planet>(name);

    public Result<DwarfPlanet> GetDwarfPlanet(Identifier identifier) => Get<DwarfPlanet>(identifier);
    public Result<DwarfPlanet> GetDwarfPlanet(string name) => Get<DwarfPlanet>(name);

    public Result<Asteroid> GetAsteroid(Identifier identifier) => Get<Asteroid>(identifier);
    public Result<Asteroid> GetAsteroid(string name) => Get<Asteroid>(name);

    public Result<Comet> GetComet(Identifier identifier) => Get<Comet>(identifier);
    public Result<Comet> GetComet(string name) => Get<Comet>(name);

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null)
            return Result.Error($"Can not find StellarObjectType for {nameof(T)}");

        Dictionary<string, Identifier>? dictionary = default;
        foundObjectType
                .When(StellarObjectType.Planet).Then(() => dictionary = Planets)
                .When(StellarObjectType.DwarfPlanet).Then(() => dictionary = DwarfPlanets)
                .When(StellarObjectType.Asteroid).Then(() => dictionary = Asteroids)
                .When(StellarObjectType.Comet).Then(() => dictionary = Comets)
                .Default(() => { });

        return dictionary!;
    }
    #endregion

    #region Add
    public Result Add(Planet planet) => Add<Planet>(planet);
    public Result AddPlanet(Planet planet) => Add<Planet>(planet);

    public Result Add(DwarfPlanet dwarfplanet) => Add<DwarfPlanet>(dwarfplanet);
    public Result AddDwarfPlanet(DwarfPlanet dwarfplanet) => Add<DwarfPlanet>(dwarfplanet);

    public Result Add(Asteroid asteroid) => Add<Asteroid>(asteroid);
    public Result AddAsteroid(Asteroid asteroid) => Add<Asteroid>(asteroid);

    public Result Add(Comet comet) => Add<Comet>(comet);
    public Result AddComet(Comet comet) => Add<Comet>(comet);

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null) return;

        foundObjectType
            .When(StellarObjectType.Planet).Then(() => Planets ??= new())
            .When(StellarObjectType.DwarfPlanet).Then(() => DwarfPlanets ??= new())
            .When(StellarObjectType.Asteroid).Then(() => Asteroids ??= new())
            .When(StellarObjectType.Comet).Then(() => Comets ??= new())
            .Default(() => { });
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(Star? x, Star? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;
        
        if (x.StellarClass != y.StellarClass) return false;

        if (!CommonFunctionality.CompareDictionaries(x.Planets, y.Planets)) return false;
        if (!CommonFunctionality.CompareDictionaries(x.DwarfPlanets, y.DwarfPlanets)) return false;
        if (!CommonFunctionality.CompareDictionaries(x.Asteroids, y.Asteroids)) return false;
        if (!CommonFunctionality.CompareDictionaries(x.Comets, y.Comets)) return false;

        return true;
    }

    public override bool Equals(object? obj) => Equals(this, obj as Star);

    public int GetHashCode(Star obj)
    {
        return HashCode.Combine(base.GetHashCode(obj), Planets, DwarfPlanets, Asteroids, Comets);
    }

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
