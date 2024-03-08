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

    public static Result<StarSystem> AlphsCentauri(IStellarMap map)
    {
        Star[] stars =
        {
            BuildStars.ProximaCentauri(map),
            BuildStars.RigilKentaurus(map),
            BuildStars.Toliman(map)
        };

        var alphacentauri = StarSystemBuilder.Create("Alpha Centauri", MapIdentifierGenerator.Instance, map)
            .AddStars(stars)
            .Build();
        return alphacentauri;
    }
}
