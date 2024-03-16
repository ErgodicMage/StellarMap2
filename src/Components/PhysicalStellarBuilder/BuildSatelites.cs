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

        return StellarObjectBuilder.CreateSatelite("Moon", MapIdentifierGenerator.Instance, map)
            .WithDescription("Earth's moon")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Luna")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Phobos", MapIdentifierGenerator.Instance, map)
            .WithDescription("First and largest natural satellite of Mars.")
            .AddPhysicalProperties (physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Deimos", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second natural satellite of Mars.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Metis", MapIdentifierGenerator.Instance, map)
            .WithDescription("First inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> JupiterAdrastea(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 18.2,
            Dimensions = "20x16x14",
            Volume = 2345
        };

        return SateliteBuilder.Create("Adrastea", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Amalthea", MapIdentifierGenerator.Instance, map)
            .WithDescription("Third inner natural satellite and the 5th largest of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Thebe", MapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth inner natural satellite and the 7th largest of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Io", MapIdentifierGenerator.Instance, map)
            .WithDescription("First Galilean and the 3rd largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Europa", MapIdentifierGenerator.Instance, map)
            .WithDescription("Second Galilean and 4th largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Ganymede", MapIdentifierGenerator.Instance, map)
            .WithDescription("Third Galilean and largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Callisto", MapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth Galilean and 2nd largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Himalia", MapIdentifierGenerator.Instance, map)
            .WithDescription("11th natural and 6th largest satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Elara", MapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
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

        return SateliteBuilder.Create("Pasiphae", MapIdentifierGenerator.Instance, map)
            .WithDescription("60th and 9th largest inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> JupiterCarme(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 23.35,
            Dimensions = "unknown",
            Density = 2.6
        };

        return SateliteBuilder.Create("Carme", MapIdentifierGenerator.Instance, map)
            .WithDescription("74th and 10th largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnTitan(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.3452E23,
            Radius = 2574.73,
            Area = 8.3E7,
            Volume = 7.16E10,
            Density = 1.8798,
            Gravity = 1.352,
            EscapeVelocity = 2.639E-3
        };

        return SateliteBuilder.Create("Titan", MapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Saturn and second largest in the Solar System.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnRhea(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 2.3E21,
            Radius = 763.8,
            Area = 7.337E6,
            Density = 1.236,
            Gravity = 0.264,
            EscapeVelocity = 6.35E-4
        };

        return SateliteBuilder.Create("Rhea", MapIdentifierGenerator.Instance, map)
            .WithDescription("2nd largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnIapetus(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.806E21,
            Radius = 734.5,
            Area = 6.7E6,
            Density = 1.088,
            Gravity = 0.223,
            EscapeVelocity = 5.73E-4
        };

        return SateliteBuilder.Create("Iapetus", MapIdentifierGenerator.Instance, map)
            .WithDescription("3rd largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnDione(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.095E21,
            Radius = 561.4,
            Area = 3.96E6,
            Density = 1.478,
            Gravity = 0.232,
            EscapeVelocity = 5.1E-4
        };

        return SateliteBuilder.Create("Dione", MapIdentifierGenerator.Instance, map)
            .WithDescription("4th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnTethys(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 6.174E20,
            Radius = 531.1,
            Dimensions = "1076.8x1057.4x1052.6",
            Density = 0.984,
            Gravity = 0.146,
            EscapeVelocity = 3.94E-4
        };

        return SateliteBuilder.Create("Tethys", MapIdentifierGenerator.Instance, map)
            .WithDescription("5th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnEnceladus(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.08E20,
            Radius = 252.1,
            Dimensions = "513.2x502.8x496.6",
            Density = 1.609,
            Gravity = 0.113,
            EscapeVelocity = 2.394E-4
        };

        return SateliteBuilder.Create("Enceladus", MapIdentifierGenerator.Instance, map)
            .WithDescription("6th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnMimas(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3.749E19,
            Radius = 198.2,
            Dimensions = "513.2x502.8x496.6",
            Area = 4.9E5,
            Volume = 3.2E7,
            Density = 1.148,
            Gravity = 0.064,
            EscapeVelocity = 1.59E-4
        };

        return SateliteBuilder.Create("Mimas", MapIdentifierGenerator.Instance, map)
            .WithDescription("7th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnHyperion(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 5.62E18,
            Radius = 270,
            Dimensions = "360.2x266.0x205.4",
            Density = 0.544,
            Gravity = 0.021,
            EscapeVelocity = 9.99E-5
        };

        return SateliteBuilder.Create("Hyperion", MapIdentifierGenerator.Instance, map)
            .WithDescription("8th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnPhoebe(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 8.292E18,
            Radius = 106.5,
            Dimensions = "218.8x217.0x203.6",
            Density = 1.638,
            Gravity = 0.039,
            EscapeVelocity = 1E-4
        };

        return SateliteBuilder.Create("Phoebe", MapIdentifierGenerator.Instance, map)
            .WithDescription("9th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> SaturnJanus(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.8975E18,
            Radius = 89.5,
            Volume = 3E6,
            Density = 0.63,
            Gravity = 0.017
        };

        return SateliteBuilder.Create("Janus", MapIdentifierGenerator.Instance, map)
            .WithDescription("10th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> UranusTitania(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3.4E21,
            Radius = 788.4,
            Dimensions = "203x185x152.6",
            Area = 7.82E6,
            Volume = 2.065E9,
            Density = 1.711,
            Gravity = 0.379,
            EscapeVelocity = 7.73E-2
        };

        return SateliteBuilder.Create("Titania", MapIdentifierGenerator.Instance, map)
            .WithDescription("The largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> UranusOberon(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3.076E21,
            Radius = 761.4,
            Dimensions = "203x185x152.6",
            Area = 7.285E6,
            Volume = 1.849E9,
            Density = 1.63,
            Gravity = 0.346,
            EscapeVelocity = 7.27E-2
        };

        return SateliteBuilder.Create("Oberon", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> UranusUmbriel(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.275E21,
            Radius = 584.7,
            Area = 4.296E6,
            Volume = 8.373E8,
            Density = 1.39,
            Gravity = 0.2,
            EscapeVelocity = 5.2E-2
        };

        return SateliteBuilder.Create("Umbriel", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 3rd largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> UranusAriel(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.251E21,
            Radius = 578.9,
            Dimensions = "1162.2x1155.8x11155.4",
            Area = 4.211E6,
            Volume = 8.126E8,
            Density = 1.592,
            Gravity = 0.269,
            EscapeVelocity = 5.59E-2
        };

        return SateliteBuilder.Create("Ariel", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 4th largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> UranusMiranda(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 6.4E19,
            Radius = 235.8,
            Dimensions = "480x468.4x465.8",
            Area = 7.0E5,
            Volume = 5.485E7,
            Density = 1.2,
            Gravity = 0.079,
            EscapeVelocity = 1.93E-2
        };

        return SateliteBuilder.Create("Miranda", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 5th largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> NeptuneTriton(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 2.139E21,
            Radius = 1353.4,
            Area = 2.302E7,
            Volume = 1.038E10,
            Density = 2.061,
            Gravity = 0.779,
            EscapeVelocity = 1.445E-3
        };

        return SateliteBuilder.Create("Triton", MapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> NeptuneProteus(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 4.4E19,
            Radius = 210,
            Dimensions = "424x390x396",
            Area = 5.54E5,
            Volume = 3.4E7,
            Density = 1.3,
            Gravity = 0.07,
            EscapeVelocity = 1.17E-4
        };

        return SateliteBuilder.Create("Proteus", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> NeptuneNereid(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 178.5
        };

        return SateliteBuilder.Create("Nereid", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 3rd largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> NeptuneLarissa(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 4.2E18,
            Radius = 97,
            Dimensions = "216x204x168",
            Area = 1.182E5,
            Volume = 3.5E6,
            Density = 1.2,
            Gravity = 0.03,
            EscapeVelocity = 7.6E-5
        };

        return SateliteBuilder.Create("Larissa", MapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> PlutoCharon(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.586E21,
            Radius = 606,
            Area = 4.6E6,
            Volume = 9.32E8,
            Density = 1.702,
            Gravity = 0.288,
            EscapeVelocity = 0.59
        };

        return SateliteBuilder.Create("Charon", MapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Pluto.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> PlutoNix(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 2.60E16,
            Dimensions = "49.8x33.2x31.1",
            Density = 1.031,
            Gravity = 0.0028,
            EscapeVelocity = 0.0118
        };

        return SateliteBuilder.Create("Nix", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> PlutoHydra(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3.01E16,
            Dimensions = "50.9x36.1x30.9",
            Density = 1.220,
            Gravity = 5.2E-3
        };

        return SateliteBuilder.Create("Hydra", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> PlutoKerberos(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.65E16,
            Dimensions = "19x10x9"
        };

        return SateliteBuilder.Create("Kerberos", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<Satelite> PlutoStyx(IStellarMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 7.5E15,
            Dimensions = "16x9x8"
        };

        return SateliteBuilder.Create("Styx", MapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
}
