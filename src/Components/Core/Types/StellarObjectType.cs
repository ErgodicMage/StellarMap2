using System.Data;

namespace StellarMap.Core;

public abstract class StellarObjectType
{
    public static readonly StellarObjectType Star = new StarType(1);
    public static readonly StellarObjectType Planet = new PlanetType(2);
    public static readonly StellarObjectType Satelite = new SateliteType(3);
    public static readonly StellarObjectType DwarfPlanet = new DwarfPlanetType(4);
    public static readonly StellarObjectType Asteroid = new AsteroidType(5);

    public string Name { get; protected init; }
    public int Value {get; protected init; }

    private StellarObjectType(int value, string name)
    {
        Value = value;
        Name = name;
    }

    private class StarType(int value) : StellarObjectType(value, StellarObjectConstants.Star)
    {
    }

    private class PlanetType(int value) : StellarObjectType(value, StellarObjectConstants.Planet)
    {
    }

    private class SateliteType(int value) : StellarObjectType(value, StellarObjectConstants.Satellite)
    {
    }

    private class DwarfPlanetType(int value) : StellarObjectType(value, StellarObjectConstants.DwarfPlanet)
    {
    }

    private class AsteroidType(int value) : StellarObjectType(value, StellarObjectConstants.Asteroid)
    {
    }
}
