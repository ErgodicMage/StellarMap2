namespace StellarMap.PhysicalStellarBuilder;

public static class BuildStars
{
    public static Result<Star> Sol(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.9885E30,
            Radius = 695700,
            Dimensions = string.Empty,
            Area = 6.09E12,
            Volume = 1.41E18,
            Flattening = 0.00005,
            Density = 1.408,
            Gravity = 274,
            EscapeVelocity = 617.7
        };

        Planet[] planets =
        {
            BuildPlanets.Mercury(map),
            BuildPlanets.Venus(map),
            BuildPlanets.Earth(map),
            BuildPlanets.Mars(map),
            BuildPlanets.Jupiter(map),
            BuildPlanets.Saturn(map),
            BuildPlanets.Uranus(map),
            BuildPlanets.Neptune(map)
        };

        DwarfPlanet[] dwarfplanets =
        {
            BuildDwarfPlanets.Pluto(map),
            BuildDwarfPlanets.Ceres(map)
        };

        Asteroid[] asteroids =
        {
            BuildAsteroids.Vesta(map),
            BuildAsteroids.Pallas(map),
            BuildAsteroids.Hygiea(map),
            BuildAsteroids.Euphrosyne(map),
            BuildAsteroids.Interamnia(map),
            BuildAsteroids.Davida(map),
            BuildAsteroids.Herculina(map),
            BuildAsteroids.Eunomia(map),
            BuildAsteroids.Juno(map),
            BuildAsteroids.Psyche(map),
            BuildAsteroids.Europa(map)
        };

        Comet[] comets =
        {
            BuildComets.Haleys(map),
            BuildComets.Caesers(map),
            BuildComets.Enckes(map),
            BuildComets.Bielas(map),
            BuildComets.Fayes(map),
            BuildComets.Brorsens(map),
            BuildComets.dArrests(map)
        };

        var sol = StarBuilder.Create("Sol", MapIdentifierGenerator.Instance, map)
            .WithDescription("The star at the center of the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "Sol")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Sun")
            .AddPhysicalProperties(physicalProperties)
            .WithProperty(PropertiesConstant.ABSOLUTEMAGNITUDE, "4.83")
            .WithProperty(PropertiesConstant.LUMINOSITY, "3.828E26 W")
            .AsStellarClass("G2V")
            .AddPlanets(planets)
            .AddDwarfPlanets(dwarfplanets)
            .AddAsteroids(asteroids)
            .AddComets(comets)
            .Build();

        return sol;
    }

    public static Result<Star> ProximaCentauri(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 2.48E29,
            Radius = 107277,
        };

        Planet[] planets =
        {
            PlanetBuilder.Create("Proxima Centauri d", MapIdentifierGenerator.Instance, map).Build(),
            PlanetBuilder.Create("Proxima Centauri b", MapIdentifierGenerator.Instance, map).Build(),
            PlanetBuilder.Create("Proxima Centauri c", MapIdentifierGenerator.Instance, map).WithDescription("candidate").Build()
        };


        var sol = StarBuilder.Create("Proxima Centauri", MapIdentifierGenerator.Instance, map)
            .WithDescription("The closest star to Sol.")
            .WithProperty(PropertiesConstant.DESIGNATION, "Alf Cen C, Alpha Centauri C, V645 Centauri, GJ 551, HIP 70890")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Alpha Centauri C")
            .AddPhysicalProperties(physicalProperties)
            .WithProperty(PropertiesConstant.ABSOLUTEMAGNITUDE, "4.83")
            .WithProperty(PropertiesConstant.LUMINOSITY, "3.828E26 W")
            .WithProperty(PropertiesConstant.SINBAD, "https://simbad.cds.unistra.fr/simbad/sim-id?Ident=V645+Cen")
            .AsStellarClass("M5.5Ve")
            .AddPlanets(planets)
            .Build();

        return sol;
    }

    public static Result<Star> RigilKentaurus(IStellarMap map)
    {

        Planet[] planets =
        {
            PlanetBuilder.Create("Alfa Centauri A b",MapIdentifierGenerator.Instance, map).WithDescription("candidate").Build(),
        };


        var sol = StarBuilder.Create("Rigil Kentaurus", MapIdentifierGenerator.Instance, map)
            .WithDescription("Largest star in Alpha Centauri.")
            .WithProperty(PropertiesConstant.DESIGNATION, "alf Cen A, Gl 559 A, Hip 71863")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Alpha Centauri A")
            .WithProperty(PropertiesConstant.SINBAD, "https://simbad.cds.unistra.fr/simbad/sim-id?Ident=TYC+9007-5849-1")
            .AsStellarClass("G2V")
            .AddPlanets(planets)
            .Build();

        return sol;
    }

    public static Result<Star> Toliman(IStellarMap map)
    {
        var sol = StarBuilder.Create("Toliman", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second largest star in Alpha Centauri.")
            .WithProperty(PropertiesConstant.DESIGNATION, "alf Cen B, Gl 559 B, Hip 71861")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Alpha Centauri B")
            .WithProperty(PropertiesConstant.SINBAD, "https://simbad.cds.unistra.fr/simbad/sim-id?Ident=TYC+9007-5848-1")
            .AsStellarClass("K1V")
            .Build();

        return sol;
    }
}
