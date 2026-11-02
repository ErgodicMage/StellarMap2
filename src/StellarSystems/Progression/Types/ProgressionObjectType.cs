namespace StellarMap.Progression;

public record ProgressionObjectType : StellarObjectType
{
    public const string PROGRESSIONSTARSYSTEM = "ProgressionStarSystem";
    public const string PROGRESSIONSTAR = "ProgressionStar";
    public const string PROGRESSIONPLANET = "ProgressionPlanet";
    public const string PROGRESSIONSATELITE = "ProgressionSatelite";
    public const string PROGRESSIONASTEROID = "ProgressionAsteroid";
    public const string HABITAT = "Habitat";
    public const string PORTAL = "Portal";
    public const string ERBRIDGE = "ERBridge";

    public static readonly ProgressionObjectType ProgressionStarSystem = Register(new ProgressionStarSystemType());
    public static readonly ProgressionObjectType ProgressionStar = Register(new ProgressionStarType());
    public static readonly ProgressionObjectType ProgressionPlanet = Register(new ProgressionPlanetType());
    public static readonly ProgressionObjectType ProgressionSatelite = Register(new ProgressionSateliteType());
    public static readonly ProgressionObjectType ProgressionAsteroid = Register(new ProgressionAsteroidType());
    public static readonly ProgressionObjectType Habitat = Register(new HabitatType());
    public static readonly ProgressionObjectType Portal = Register(new PortalType());
    public static readonly ProgressionObjectType ERBridge = Register(new ERBridgeType());

    protected ProgressionObjectType(string name) : base(name)
    { }

    protected static ProgressionObjectType Register(ProgressionObjectType type)
        => (StellarObjectType.Register(type) as ProgressionObjectType)!;

    private record ProgressionStarSystemType() : ProgressionObjectType(PROGRESSIONSTARSYSTEM) { }
    private record ProgressionStarType() : ProgressionObjectType(PROGRESSIONSTAR) { }
    private record ProgressionPlanetType() : ProgressionObjectType(PROGRESSIONPLANET) { }
    private record ProgressionSateliteType() : ProgressionObjectType(PROGRESSIONSATELITE) { }
    private record ProgressionAsteroidType() : ProgressionObjectType(PROGRESSIONASTEROID) { }
    private record HabitatType() : ProgressionObjectType(HABITAT) { }
    private record PortalType() : ProgressionObjectType(PORTAL) { }
    private record ERBridgeType() : ProgressionObjectType(ERBRIDGE) { }
}
