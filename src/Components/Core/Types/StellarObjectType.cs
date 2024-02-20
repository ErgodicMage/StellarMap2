using System.Data;

namespace StellarMap.Core;

public abstract class StellarObjectType
{
    public static readonly StellarObjectType Star = Register(new StarType(1));
    public static readonly StellarObjectType Planet = Register(new PlanetType(2));
    public static readonly StellarObjectType DwarfPlanet = Register(new DwarfPlanetType(3));
    public static readonly StellarObjectType Satelite = Register(new SateliteType(4));
    public static readonly StellarObjectType Asteroid = Register(new AsteroidType(5));
    public static readonly StellarObjectType Comet = Register(new CometType(6));

    public string Name { get; protected init; }
    public int Value {get; protected init; }
    public Type Type { get; protected init; }

    protected static List<StellarObjectType> ObjectTypes = new();

    public static Result<StellarObjectType> Get(int value)
    {
        var typeFound = ObjectTypes.FirstOrDefault(x => x.Value == value);
        if (typeFound is null)
            return Result.Error($"StellarObjectType {value} not found");
        return typeFound;
    }

    public static Result<StellarObjectType> Get(string name)
    {
        var typeFound = ObjectTypes.FirstOrDefault(x => x.Name == name);
        if (typeFound is null)
            return Result.Error($"StellarObjectType {name} not found");
        return typeFound;
    }

    public static Result<StellarObjectType> Get(Type type)
    {
        var typeFound = ObjectTypes.FirstOrDefault(x => x.Type == type);
        if (typeFound is null)
            return Result.Error($"StellarObjectType {type.Name} not found");
        return typeFound;
    }

    protected StellarObjectType(int value, string name, Type type)
    {
        Value = value;
        Name = name;
        Type = type;
    }

    protected static StellarObjectType Register(StellarObjectType objectType)
    {
        ObjectTypes.Add(objectType);
        return objectType;
    }

    private class StarType(int value) : StellarObjectType(value, StellarObjectConstants.Star, typeof(Star))
    {
    }

    private class PlanetType(int value) : StellarObjectType(value, StellarObjectConstants.Planet, typeof(Planet))
    {
    }

    private class DwarfPlanetType(int value) : StellarObjectType(value, StellarObjectConstants.DwarfPlanet, typeof(DwarfPlanet))
    {
    }

    private class SateliteType(int value) : StellarObjectType(value, StellarObjectConstants.Satellite, typeof(Satelite))
    {
    }

    private class AsteroidType(int value) : StellarObjectType(value, StellarObjectConstants.Asteroid, typeof(Asteroid))
    {
    }

    private class CometType(int value) : StellarObjectType(value, StellarObjectConstants.Comet, typeof(Comet))
    {
    }
}
