namespace StellarMap.Progression;

public abstract class ProgressionObjectType : StellarObjectType
{
    public static readonly ProgressionObjectType ProgressionStarSystem = new ProgressionStarSystemType();
    public static readonly ProgressionObjectType ProgressionStar = new ProgressionStarType();
    public static readonly ProgressionObjectType ProgressionPlanet = new ProgressionPlanetType();
    public static readonly ProgressionObjectType ProgressionSatelite = new ProgressionSateliteType();
    public static readonly ProgressionObjectType ProgressionAsteroid = new ProgressionAsteroidType();
    public static readonly ProgressionObjectType Habitat = new HabitatType();

    protected ProgressionObjectType(string name, int value) : base(name, value)
    { }

    private sealed class ProgressionStarSystemType() : ProgressionObjectType(nameof(ProgressionStarSystem), 11)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new ProgressionStarSystem(name, identifier, map);
    }

    private sealed class ProgressionStarType() : ProgressionObjectType(nameof(ProgressionStar), 12)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new ProgressionStar(name, identifier, map);
    }

    private sealed class ProgressionPlanetType() : ProgressionObjectType(nameof(ProgressionPlanet), 13)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new ProgressionPlanet(name, identifier, map);
    }

    private sealed class ProgressionSateliteType() : ProgressionObjectType(nameof(ProgressionSatelite), 14)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new ProgressionSatelite(name, identifier, map);
    }

    private sealed class ProgressionAsteroidType() : ProgressionObjectType(nameof(ProgressionAsteroid), 15)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new ProgressionAsteroid(name, identifier, map);
    }

    private sealed class HabitatType() : ProgressionObjectType(nameof(Habitat), 16)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new Habitat(name, identifier, map);
    }
}
