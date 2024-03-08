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

    public static Result<StarSystem> Luhman16(IStellarMap map)
    {
        Star[] stars =
        {
            StarBuilder.Create("Luhman 16A", MapIdentifierGenerator.Instance, map).AsStellarClass("L").Build(),
            StarBuilder.Create("Luhman 16B", MapIdentifierGenerator.Instance, map).AsStellarClass("T").Build()
        };

        var luhman16 = StarSystemBuilder.Create("Luhman 16", MapIdentifierGenerator.Instance, map)
            .WithDescription("Star system of brown dwarfs")
            .WithProperty(PropertiesConstant.DESIGNATION, "LUH 16, Luhman–WISE 1, WISE J104915.57−531906.1, GJ 11551")
            .WithProperty(PropertiesConstant.SINBAD, "https://simbad.cds.unistra.fr/simbad/sim-id?Ident=WISE+J104915.57-531906.1")
            .Build();
        return luhman16;
    }
}
