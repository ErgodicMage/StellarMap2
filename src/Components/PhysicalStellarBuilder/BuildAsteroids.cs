namespace StellarMap.PhysicalStellarBuilder;

public static class BuildAsteroids
{
    public static Result<Asteroid> Vesta(IStellarMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 2.590E20,
            Radius = 525.4,
            Dimensions = "572.6x557.2x446.4",
            Area = 8.66E5,
            Volume = 7.4970E7,
            Flattening = 0.2204,
            Density = 3.456,
            Gravity = 0.25,
            EscapeVelocity = 0.36
        };

        var vesta = AsteroidBuilder.Create("Vesta", MapIdentifierGenerator.Instance, map)
            .WithDescription("One of the largest asteroids in the Solar System.")
            .AddPhysicalProperties(properties)
            .Build();
        return vesta;
    }

    public static Result<Asteroid> Pallas(IStellarMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 2.04E20,
            Radius = 511,
            Dimensions = "568x532x448",
            Area = 8.3E5,
            Volume = 7.06E7,
            Density = 2.92,
            Gravity = 0.21,
            EscapeVelocity = 0.324
        };

        var pallas = AsteroidBuilder.Create("Pallas", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(properties)
            .Build();
        return pallas;
    }

    public static Result<Asteroid> Hygiea(IStellarMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 8.74E19,
            Radius = 433,
            Dimensions = "450x430x424",
            Density = 2.06
        };

        var hygiea = AsteroidBuilder.Create("Hygiea", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(properties)
            .Build();
        return hygiea;
    }

    public static Result<Asteroid> Euphrosyne(IStellarMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 16.5E18,
            Radius = 268,
            Dimensions = "294x280x248",
            Density = 1.64
        };

        var euphrosyne = AsteroidBuilder.Create("Euphrosyne", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(properties)
            .Build();
        return euphrosyne;
    }

    public static Result<Asteroid> Interamnia(IStellarMap map)
    {
        return AsteroidBuilder.Create("Interamnia", MapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<Asteroid> Davida(IStellarMap map)
    {
        return AsteroidBuilder.Create("Davida", MapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<Asteroid> Herculina(IStellarMap map)
    {
        return AsteroidBuilder.Create("Herculina", MapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<Asteroid> Eunomia(IStellarMap map)
    {
        return AsteroidBuilder.Create("Eunomia", MapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<Asteroid> Juno(IStellarMap map)
    {
        return AsteroidBuilder.Create("Juno", MapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<Asteroid> Psyche(IStellarMap map)
    {
        return AsteroidBuilder.Create("Psyche", MapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<Asteroid> Europa(IStellarMap map)
    {
        return AsteroidBuilder.Create("Europa", MapIdentifierGenerator.Instance, map)
            .Build();
    }
}
