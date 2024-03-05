namespace StellarMap.PhysicalStellarBuilder;

public static class BuildStarSystems
{
    public static Result<StarSystem> SolarSystem(IStellarMap map)
    {
        var sol = BuildStars.Sol(map);
        var solarsystem = StarSystemBuilder.Create("Solar System", MapIdentifierGenerator.Instance, map)
            .AddStar(sol)
            .Build();
        return solarsystem;
    }
}
