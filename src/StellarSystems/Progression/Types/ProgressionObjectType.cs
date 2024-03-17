namespace StellarMap.Progression;

public record ProgressionObjectType : StellarObjectType
{
    public const string PROGRESSIONSTARSYSTEM = "ProgressionStarSystem";
    public const string PROGRESSIONSTAR = "ProgressionStar";
    public const string PROGRESSIONPLANET = "ProgressionPlanet";
    public const string PROGRESSIONSATELITE = "ProgressionSatelite";
    public const string PROGRESSIONASTEROID = "ProgressionAsteroid";
    public const string HABITAT = "Habitat";

    public static readonly ProgressionObjectType ProgressionStarSystem = Register(new ProgressionStarSystemType());
    public static readonly ProgressionObjectType ProgressionStar = new ProgressionStarType();
    public static readonly ProgressionObjectType ProgressionPlanet = new ProgressionPlanetType();
    public static readonly ProgressionObjectType ProgressionSatelite = new ProgressionSateliteType();
    public static readonly ProgressionObjectType ProgressionAsteroid = new ProgressionAsteroidType();
    public static readonly ProgressionObjectType Habitat = new HabitatType();

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
}
