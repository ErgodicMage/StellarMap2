using StellarMap.Core;

namespace StellarMap.Progression;

public class ProgressionStar : Star
{
    #region Properties
    [JsonPropertyOrder(101)]
    public Dictionary<string, Identifier>? Habitats { get; set; }
    #endregion

    #region Constructors
    public ProgressionStar() { }

    public ProgressionStar(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map)
        => ObjectType = ProgressionObjectType.Star;
    #endregion

    #region Get
    public Result<ProgressionPlanet> GetProgressionPlanet(Identifier identifier)
        => GetPlanet(identifier).Convert<ProgressionPlanet, Planet>();
    public Result<ProgressionPlanet> GetProgressionPlanet(string name)
        => GetPlanet(name).Convert<ProgressionPlanet, Planet>();

    public Result<ProgressionAsteroid> GetProgressionAsteroid(Identifier identifier)
        => GetAsteroid(identifier).Convert<ProgressionAsteroid, Asteroid>();
    public Result<ProgressionAsteroid> GetProgressionAsteroid(string name)
        => GetAsteroid(name).Convert<ProgressionAsteroid, Asteroid>();

    public Result<Habitat> GetHabitat(Identifier identifier) => Get<Habitat>(identifier);
    public Result<Habitat> GetHabitat(string name) => Get<Habitat>(name);

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return Result.Error($"Can not find StellarObjectType for {nameof(T)}");

        return foundObjectType.Value.Name switch
        {
            ProgressionObjectType.PLANET => base.GetIdentifiers<Planet>(),
            ProgressionObjectType.ASTEROID => base.GetIdentifiers<Asteroid>(),
            ProgressionObjectType.HABITAT => Habitats!,
            _ => base.GetIdentifiers<T>()
        };
    }
    #endregion

    #region Add
    public Result Add(ProgressionPlanet planet) => Add<ProgressionPlanet>(planet);
    public Result AddProgressionPlanet(ProgressionPlanet planet) => Add<ProgressionPlanet>(planet);

    public Result Add(ProgressionAsteroid asteroid) => Add<ProgressionAsteroid>(asteroid);
    public Result AddAsteroid(ProgressionAsteroid asteroid) => Add<ProgressionAsteroid>(asteroid);

    public Result Add(Habitat habitat) => Add<Habitat>(habitat);
    public Result AddHabitat(Habitat habitat) => Add<Habitat>(habitat);


    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success) return;

        switch (foundObjectType.Value.Name)
        {
            case ProgressionObjectType.PROGRESSIONPLANET: base.CreateIdentifiers<Planet>(); break;
            case ProgressionObjectType.ASTEROID: base.CreateIdentifiers<Asteroid>(); break;
            case ProgressionObjectType.HABITAT: Habitats ??= new(); break;
            default: base.CreateIdentifiers<T>(); break;
        };
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(ProgressionStar? x, ProgressionStar? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;

        if (!CommonFunctionality.CompareDictionaries(x.Habitats, y.Habitats)) return false;

        return true;
    }

    public override bool Equals(object? obj) => Equals(this, obj as ProgressionStar);

    public int GetHashCode(ProgressionStar obj)
    {
        return HashCode.Combine(base.GetHashCode(obj), Habitats);
    }

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
