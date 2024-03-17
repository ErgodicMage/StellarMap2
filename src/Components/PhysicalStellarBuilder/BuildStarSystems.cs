namespace StellarMap.PhysicalStellarBuilder;

public static class BuildStarSystems
{
    public static Result<StarSystem> AlphaCentauri(IStellarMap map)
    {
        Star[] stars =
        {
            BuildStars.ProximaCentauri(map),
            BuildStars.RigilKentaurus(map),
            BuildStars.Toliman(map)
        };

        return StarSystemBuilder.Create("Alpha Centauri", MapIdentifierGenerator.Instance, map)
            .AddStars(stars)
            .Build();
    }

    public static Result<StarSystem> Luhman16(IStellarMap map)
    {
        Star[] stars =
        {
            StarBuilder.Create("Luhman 16A", MapIdentifierGenerator.Instance, map).AsStellarClass("L").Build(),
            StarBuilder.Create("Luhman 16B", MapIdentifierGenerator.Instance, map).AsStellarClass("T").Build()
        };

        return StarSystemBuilder.Create("Luhman 16", MapIdentifierGenerator.Instance, map)
            .WithDescription("Star system of brown dwarfs")
            .WithProperty(PropertiesConstant.DESIGNATION, "LUH 16, Luhman–WISE 1, WISE J104915.57−531906.1, GJ 11551")
            .WithProperty(PropertiesConstant.SINBAD, "https://simbad.cds.unistra.fr/simbad/sim-id?Ident=WISE+J104915.57-531906.1")
            .Build();
    }
}
