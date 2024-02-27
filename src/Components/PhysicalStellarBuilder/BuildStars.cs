using StellarMap.Core;

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
            BuildPlanets.Uranus(map)
        };

        var sol = StarBuilder.Create("Sol", MapIdentifierGenerator.Instance, map)
            .WithDescription("The star at the center of the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "Sol")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Sun")
            .AddPhysicalProperties(physicalProperties)
            .AsStellarClass("G2V")
            .AddPlanets(planets)
            .Build();

        return sol;
    }
}
