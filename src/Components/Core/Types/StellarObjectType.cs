namespace StellarMap.Core;

public record StellarObjectType(string Name)
{
    public const string StellarBody = "StellarBody";
    public const string STARSYSTEM = "StarSystem";
    public const string STAR = "Star";
    public const string PLANET = "Planet";
    public const string DWARFPLANET = "DwarfPlanet";
    public const string SATELITE = "Satelite";
    public const string ASTEROID = "Asteroid";
    public const string COMET = "Comet";

    public static readonly StellarObjectType StarSystem = Register(new StarSystemType());
    public static readonly StellarObjectType Star = Register(new StarType());
    public static readonly StellarObjectType Planet = Register(new PlanetType());
    public static readonly StellarObjectType DwarfPlanet = Register(new DwarfPlanetType());
    public static readonly StellarObjectType Satelite = Register(new SateliteType());
    public static readonly StellarObjectType Asteroid = Register(new AsteroidType());
    public static readonly StellarObjectType Comet = Register(new CometType());

    private static Dictionary<string, StellarObjectType>? _objectTypes;

    protected static StellarObjectType Register(StellarObjectType type)
    {
        ArgumentNullException.ThrowIfNull(type); // note I want to specifically throw an exception here instead of using GuardClause
        _objectTypes ??= new();
        _objectTypes.TryAdd(type.Name, type);
        return type;
    }

    public static Result<StellarObjectType> FromName(string name)
    {
        Result result = GuardClause.NullOrWhiteSpace(name);
        if (!result.Success) return result;

        if (_objectTypes!.TryGetValue(name, out var objectType))
            return objectType;
        
        return Result.Error($"{name} is not a StellarObjectType");
    }

    private record StarSystemType() : StellarObjectType(STARSYSTEM) { }
    private record StarType() : StellarObjectType(STAR) { }
    private record PlanetType() : StellarObjectType(PLANET) { }
    private record DwarfPlanetType() : StellarObjectType(DWARFPLANET) { }
    private record SateliteType() : StellarObjectType(SATELITE) { }
    private record AsteroidType() : StellarObjectType(ASTEROID) { }
    private record CometType() : StellarObjectType(COMET) { }
}


