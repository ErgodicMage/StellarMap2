using StellarMap.Core;

namespace StellarMap.PhysicalStellarBuilder;

public static class BuildPlanets
{
    public static Result<Planet> Mercury(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3.3011E23,
            Radius = 2439.7,
            Area = 7.48E7,
            Volume = 6.083E10,
            Flattening = 0.0,
            Density = 5.427,
            Gravity = 3.7,
            EscapeVelocity = 4.25
        };

        var mercury = PlanetBuilder.Create("Mercury", MapIdentifierGenerator.Instance, map)
            .WithDescription("The first planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-01")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return mercury;
    }

    public static Result<Planet> Venus(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 4.8675E24,
            Radius = 6051.8,
            Area = 4.6023E8,
            Volume = 9.2843E11,
            Flattening = 0.0,
            Density = 5.243,
            Gravity = 8.87,
            EscapeVelocity = 10.36
        };

        var venus = PlanetBuilder.Create("Venus", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-02")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return venus;
    }

    public static Result<Planet> Earth(IStellarMap map)
    {
        var moon = BuildSatelites.Moon(map);
        if (!moon.Success) return Result.Error(moon.ErrorMessage);

        PhysicalProperties physicalProperties = new()
        {
            Mass = 5.97237E24,
            Radius = 6371.0,
            Area = 5.10072E8,
            Volume = 1.08321E12,
            Flattening = .0033528,
            Density = 5.97237E24,
            Gravity = 9.80665,
            EscapeVelocity = 11.186
        };

        var earth = PlanetBuilder.Create("Earth", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 3nd planet in the Solar System")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-03")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelite(moon)
            .Build();
        return earth;
    }
}
