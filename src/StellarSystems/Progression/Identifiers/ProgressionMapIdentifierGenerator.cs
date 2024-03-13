namespace StellarMap.Progression;

public sealed class ProgressionMapIdentifierGenerator
{
    private ProgressionMapIdentifierGenerator() { }

    public static ProgressionMapIdentifierGenerator Instance = new();

    public Identifier GenerateIdentifier(StellarObjectType type, IStellarMap? map = null)
    {
        var progressionMap = map as IProgressionMap;
        var result = GuardClause.Null(progressionMap);
        if (!result.Success) return Identifier.NoIdentifier;

        int count = 0;
        type
            .When(ProgressionObjectType.ProgressionStarSystem)
                .Then(() => count = progressionMap?.StarSystems is null ? 0 : progressionMap.StarSystems.Count)
            .When(StellarObjectType.StarSystem)
                .Then(() => count = progressionMap?.StarSystems is null ? 0 : progressionMap.StarSystems.Count)
            .When(ProgressionObjectType.ProgressionStar)
                .Then(() => count = progressionMap?.Stars is null ? 0 : progressionMap.Stars.Count)
            .When(StellarObjectType.Star)
                .Then(() => count = progressionMap?.Stars is null ? 0 : progressionMap.Stars.Count)
            .When(ProgressionObjectType.ProgressionPlanet)
                .Then(() => count = progressionMap?.Planets is null ? 0 : progressionMap.Planets.Count)
            .When(StellarObjectType.Planet)
                .Then(() => count = progressionMap?.Planets is null ? 0 : progressionMap.Planets.Count)
            //.When(StellarObjectType.DwarfPlanet).Then(() => count = map?.DwarfPlanets is null ? 0 : map.DwarfPlanets.Count)
            .When(ProgressionObjectType.ProgressionSatelite)
                .Then(() => count = progressionMap?.Satelites is null ? 0 : progressionMap.Satelites.Count)
            .When(StellarObjectType.Satelite)
                .Then(() => count = progressionMap?.Satelites is null ? 0 : progressionMap.Satelites.Count)
            .When(ProgressionObjectType.ProgressionAsteroid)
                .Then(() => count = progressionMap?.Asteroids is null ? 0 : progressionMap.Asteroids.Count)
            .When(StellarObjectType.Asteroid)
                .Then(() => count = progressionMap?.Asteroids is null ? 0 : progressionMap.Asteroids.Count)
            .When(ProgressionObjectType.Habitat)
                .Then(() => count = progressionMap?.Habitats is null ? 0 : progressionMap.Habitats.Count);

        return new Identifier($"{type.Name}-{count + 1:D5}");
    }
}
