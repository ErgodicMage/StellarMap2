namespace StellarMap.PhysicalStellarBuilder;

public static class BuildSatelites
{
    public static Result<Satelite> Moon(IStellarMap map)
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
}
