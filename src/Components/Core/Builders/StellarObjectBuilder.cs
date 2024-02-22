using System.ComponentModel.DataAnnotations;

namespace StellarMap.Core;

public static class StellarObjectBuilder
{
    public static StarBuilder CreateStar(string name, IIdentifierGenerator generator, IStellarMap map)
        => StarBuilder.Create(name, generator, map);
    public static StarBuilder CreateStar(string name, Identifier identifier, IStellarMap map)
        => StarBuilder.Create(name, identifier, map);

    public static PlanetBuilder CreatePlanet(string name, IIdentifierGenerator generator, IStellarMap map)
    => PlanetBuilder.Create(name, generator, map);
    public static PlanetBuilder CreatePlanet(string name, Identifier identifier, IStellarMap map)
        => PlanetBuilder.Create(name, identifier, map);

    public static SateliteBuilder CreateSatelite(string name, IIdentifierGenerator generator, IStellarMap map)
    => SateliteBuilder.Create(name, generator, map);
    public static SateliteBuilder CreateSatelite(string name, Identifier identifier, IStellarMap map)
        => SateliteBuilder.Create(name, identifier, map);

    public static AsteroidBuilder CreateAsteroid(string name, IIdentifierGenerator generator, IStellarMap map)
    => AsteroidBuilder.Create(name, generator, map);
    public static AsteroidBuilder CreateAsteroid(string name, Identifier identifier, IStellarMap map)
        => AsteroidBuilder.Create(name, identifier, map);

    public static CometBuilder CreateComet(string name, IIdentifierGenerator generator, IStellarMap map)
    => CometBuilder.Create(name, generator, map);
    public static CometBuilder CreateComet(string name, Identifier identifier, IStellarMap map)
        => CometBuilder.Create(name, identifier, map);

}
