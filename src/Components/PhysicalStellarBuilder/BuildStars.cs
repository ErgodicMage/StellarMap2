namespace StellarMap.PhysicalStellarBuilder;

public static class BuildStars
{
    public static Result<Star> Sol(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.9891E30,
            Radius = 695700,
            Dimensions = string.Empty,
            Area = 6.09E12,
            Volume = 1.41E18,
            Flattening = 9E-6,
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
            .AsStellarClass("G2V")
            .AddPlanets(planets)
            .AddDwarfPlanets(dwarfplanets)
            .AddAsteroids(asteroids)
            .AddComets(comets)
            .Build();

        return sol;
    }
}
