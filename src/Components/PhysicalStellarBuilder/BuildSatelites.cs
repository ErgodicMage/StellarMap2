namespace StellarMap.PhysicalStellarBuilder;

public static class BuildSatelites
{
    public static Result<Satelite> EarthMoon(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 5.97237E24,
            Radius = 7.342E22,
            Dimensions = string.Empty,
            Area = 3.793E7,
            Volume = 2.1958E10,
            Flattening = 0.0012,
            Density = 3.344,
            Gravity = 1.62,
            EscapeVelocity = 2.38
        };

        var moon = StellarObjectBuilder.CreateSatelite("Moon", MapIdentifierGenerator.Instance, map)
            .WithDescription("Earth's moon")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Luna")
            .AddPhysicalProperties(physicalProperties)
            .Build();

        return moon;
    }

    public static Result<Satelite> MarsPhobos(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.0659E16,
            Radius = 11.2667,
            Dimensions = "27x22X18",
            Area = 1548.3,
            Volume = 5783.6,
            Density = 1.876,
            Gravity = 0.0057,
            EscapeVelocity = 0.01139
        };

        var phobos = SateliteBuilder.Create("Phobos", MapIdentifierGenerator.Instance, map)
            .WithDescription("First and largest natural satellite of Mars.")
            .AddPhysicalProperties (physicalProperties)
            .Build();
        return phobos;
    }

    public static Result<Satelite> MarsDeimos(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.4762E15,
            Radius = 6.2,
            Dimensions = "15x12.2x11",
            Area = 495.155,
            Volume = 999.78,
            Density = 1.471,
            Gravity = 0.003,
            EscapeVelocity = 0.005556
        };

        var deimos = SateliteBuilder.Create("Deimos", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second natural satellite of Mars.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return deimos;
    }
}
