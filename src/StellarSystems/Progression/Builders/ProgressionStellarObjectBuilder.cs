using StellarMap.Progression.Builders;

namespace StellarMap.Progression;

public static class ProgressionStellarObjectBuilder
{
    public static ProgressionAsteroidBuilder CreateProgressionAsteroid(string name, Identifier identifier, IProgressionMap map)
        => ProgressionAsteroidBuilder.Create(name, identifier, map);

    public static ProgressionAsteroidBuilder CreateProgressionAsteroid(string name, IIdentifierGenerator generator, IProgressionMap map)
        => ProgressionAsteroidBuilder.Create(name, generator, map);

    public static HabitatBuilder CreateHabitat(string name, Identifier identifier, IProgressionMap map)
        => HabitatBuilder.Create(name, identifier, map);
    public static HabitatBuilder CreateHabitat(string name, IIdentifierGenerator generator, IProgressionMap map)
        => HabitatBuilder.Create(name, generator, map);

    public static ProgressionSateliteBuilder CreateProgressionSatelite(string name, Identifier identifier, IProgressionMap map)
        => ProgressionSateliteBuilder.Create(name, identifier, map);
    public static ProgressionSateliteBuilder CreateProgressionSatelite(string name, IIdentifierGenerator generator, IProgressionMap map)
        => ProgressionSateliteBuilder.Create(name, generator, map);

    public static ProgressionPlanetBuilder CreateProgressionPlanet(string name, Identifier identifier, IProgressionMap map)
        => ProgressionPlanetBuilder.Create(name, identifier, map);
    public static ProgressionPlanetBuilder CreateProgressionPlanet(string name, IIdentifierGenerator generator, IProgressionMap map)
        => ProgressionPlanetBuilder.Create(name, generator, map);

    public static ProgressionStarBuilder CreateProgressionStar(string name, Identifier identifier, IProgressionMap map)
        => ProgressionStarBuilder.Create(name, identifier, map);
    public static ProgressionStarBuilder CreateProgressionStar(string name, IIdentifierGenerator generator, IProgressionMap map)
        => ProgressionStarBuilder.Create(name, generator, map);

    public static ProgressionStarSystemBuilder CreateProgressionStarSystem(string name, Identifier identifier, IProgressionMap map)
        => ProgressionStarSystemBuilder.Create(name, identifier, map);
    public static ProgressionStarSystemBuilder CreateProgressionStarSystem(string name, IIdentifierGenerator generator, IProgressionMap map)
        => ProgressionStarSystemBuilder.Create(name, generator, map);
}
