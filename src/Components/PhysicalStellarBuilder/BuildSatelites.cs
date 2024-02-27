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

    public static Result<Satelite> JupiterMetis(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 21.5,
            Dimensions = "60x40x34",
            Area = 5800,
            Volume = 42700
        };

        var metis = SateliteBuilder.Create("Metis", MapIdentifierGenerator.Instance, map)
            .WithDescription("First inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return metis;
    }

    public static Result<Satelite> JupiterAdrastea(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 18.2,
            Dimensions = "20x16x14",
            Volume = 2345
        };

        var adrastea = SateliteBuilder.Create("Adrastea", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return adrastea;
    }

    public static Result<Satelite> JupiterAmalthea(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 2.08E18,
            Radius = 83.5,
            Dimensions = "250x146x128",
            Volume = 2.43E6,
            Density = 0.857,
            Gravity = 0.02,
            EscapeVelocity = 5.8E-5
        };

        var amalthea = SateliteBuilder.Create("Amalthea", MapIdentifierGenerator.Instance, map)
            .WithDescription("Third inner natural satellite and the 5th largest of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return amalthea;
    }

    public static Result<Satelite> JupiterThebe(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 49.3,
            Dimensions = "116x98x84",
            Volume = 5.0E5,
            Gravity = 0.04,
            EscapeVelocity = 0.025
        };

        var thebe = SateliteBuilder.Create("Thebe", MapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth inner natural satellite and the 7th largest of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return thebe;
    }

    public static Result<Satelite> JupiterIo(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 8.932E22,
            Radius = 1821.6,
            Area = 4.191E7,
            Volume = 2.53E10,
            Density = 3.528,
            Gravity = 1.796,
            EscapeVelocity = 2.558
        };

        var io = SateliteBuilder.Create("Io", MapIdentifierGenerator.Instance, map)
            .WithDescription("First Galilean and the 3rd largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return io;
    }

    public static Result<Satelite> JupiterEuropa(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 4.798E22,
            Radius = 1560.8,
            Area = 3.09E7,
            Volume = 1.593E10,
            Density = 3.013,
            Gravity = 1.314,
            EscapeVelocity = 2.025
        };

        var europa = SateliteBuilder.Create("Europa", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second Galilean and 4th largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return europa;
    }

    public static Result<Satelite> JupiterGanymede(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.4819E23,
            Radius = 2634.1,
            Area = 8.72E7,
            Volume = 7.66E10,
            Density = 1.936,
            Gravity = 1.428,
            EscapeVelocity = 2.741
        };

        var ganymede = SateliteBuilder.Create("Ganymede", MapIdentifierGenerator.Instance, map)
            .WithDescription("Third Galilean and largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return ganymede;
    }

    public static Result<Satelite> JupiterCallisto(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.076E23,
            Radius = 2410.3,
            Area = 7.30E7,
            Volume = 5.9E10,
            Density = 1.8344,
            Gravity = 1.235,
            EscapeVelocity = 2.440
        };

        var callisto = SateliteBuilder.Create("Callisto", MapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth Galilean and 2nd largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return callisto;
    }

    public static Result<Satelite> JupiterHimalia(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 4.2E18,
            Radius = 85,
            Dimensions = "205.6x141.4x?",
            Area = 9.1E4,
            Volume = 2.6E6,
            Density = 2.6,
            Gravity = 0.062,
            EscapeVelocity = 0.1
        };

        var himalia = SateliteBuilder.Create("Himalia", MapIdentifierGenerator.Instance, map)
            .WithDescription("11th natural and 6th largest satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return himalia;
    }

    public static Result<Satelite> JupiterElara(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 8.7E17,
            Radius = 40,
            Dimensions = "unknown",
            Density = 2.6
        };

        var elara = SateliteBuilder.Create("Elara", MapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return elara;
    }

    public static Result<Satelite> JupiterPasiphae(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3E17,
            Radius = 28.9,
            Dimensions = "unknown",
            Density = 2.6,
            Gravity = 0.022,
            EscapeVelocity = 0.036
        };

        var himalia = SateliteBuilder.Create("Pasiphae", MapIdentifierGenerator.Instance, map)
            .WithDescription("60th and 9th largest inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return himalia;
    }

    public static Result<Satelite> JupiterCarme(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 23.35,
            Dimensions = "unknown",
            Density = 2.6
        };

        var carme = SateliteBuilder.Create("Carme", MapIdentifierGenerator.Instance, map)
            .WithDescription("74th and 10th largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
        return carme;
    }
}
