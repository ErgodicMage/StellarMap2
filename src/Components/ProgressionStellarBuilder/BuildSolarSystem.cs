using StellarMap.Progression.Builders;

namespace StellarMap.ProgressionStellarBuilder;

public static class BuildSolarSystem
{
    public static Result<ProgressionStarSystem> SolStarSystem(IProgressionMap map)
    {
        var sol = Sol(map);
        if (!sol.Success) return Result.Error(sol.ErrorMessage);
        return ProgressionStarSystemBuilder.Create("Sol Star System", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The star system that contains the Solar System.")
            .AddStar(sol)
            .Build();
    }

    public static Result<ProgressionStar> Sol(IProgressionMap map)
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

        ProgressionPlanet[] planets = 
        {
            Mercury(map),
            Venus(map),
            Earth(map),
            Mars(map),
            Jupiter(map),
            Saturn(map),
            Uranus(map),
            Neptune(map),
            Pluto(map)
        };

        ProgressionAsteroid[] asteroids =
        {
            Ceres(map),
            Vesta(map),
            Pallas(map),
            Hygiea(map),
            Euphrosyne(map),
            Interamnia(map),
            Davida(map),
            Herculina(map),
            Eunomia(map),
            Juno(map),
            Psyche(map),
            Europa52(map)
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

        var sol = ProgressionStarBuilder.Create("Solar System", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The star at the center of the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "Sol")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Sun")
            .AddPhysicalProperties(physicalProperties)
            .WithProperty(PropertiesConstant.ABSOLUTEMAGNITUDE, "4.83")
            .WithProperty(PropertiesConstant.LUMINOSITY, "3.828E26 W")
            .AsStellarClass("G2V")
            .AddPlanets(planets)
            .AddAsteroids(asteroids)
            .AddComets(comets)
            .Build();

        if(!sol.Success)
            return Result.Error(sol.ErrorMessage);
        return sol;
    }

    #region Planets
    #region Mercury and Venus
    public static Result<ProgressionPlanet> Mercury(IProgressionMap map)
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

        return ProgressionPlanetBuilder.Create("Mercury", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The first planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-01")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionPlanet> Venus(IProgressionMap map)
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

        return ProgressionPlanetBuilder.Create("Venus", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-02")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
    #endregion

    #region Earth
    public static Result<ProgressionPlanet> Earth(IProgressionMap map)
    {
        var moon = Moon(map);
        if (!moon.Success) 
            return Result.Error(moon.ErrorMessage);

        PhysicalProperties earthProperties = new()
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

        return ProgressionPlanetBuilder.Create("Earth", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 3nd planet in the Solar System")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-03")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(earthProperties)
            .AddSatelite(moon)
            .Build();
    }

    public static Result<ProgressionSatelite> Moon(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 7.342E22,
            Radius = 1738.1,
            Dimensions = string.Empty,
            Area = 3.793E7,
            Volume = 2.1958E10,
            Flattening = 0.0012,
            Density = 3.344,
            Gravity = 1.62,
            EscapeVelocity = 2.38
        };

        return ProgressionSateliteBuilder.Create("Moon", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Earth's moon")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Luna")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
    #endregion

    #region Mars
    public static Result<ProgressionPlanet> Mars(IProgressionMap map)
    {
        ProgressionSatelite[] satelites =
        {
            Phobos(map),
            Deimos(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 6.4171E23,
            Radius = 3389.5,
            Area = 1.448E8,
            Volume = 1.6318E11,
            Flattening = 0.00589,
            Density = 3.9335,
            Gravity = 3.721,
            EscapeVelocity = 5.027
        };

        return ProgressionPlanetBuilder.Create("Mars", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 4th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-04")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }

    public static Result<ProgressionSatelite> Phobos(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Phobos", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("First and largest natural satellite of Mars.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Deimos(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Deimos", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Second natural satellite of Mars.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
    #endregion

    #region Jupiter
    public static Result<ProgressionPlanet> Jupiter(IProgressionMap map)
    {
        ProgressionSatelite[] satelites =
        {
            Metis(map),
            Adrastea(map),
            Amalthea(map),
            Thebe(map),
            Io(map),
            Europa(map),
            Ganymede(map),
            Callisto(map),
            Himalia(map),
            Elara(map),
            Pasiphae(map),
            Carme(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.9882E27,
            Radius = 69911,
            Area = 6.1419E10,
            Volume = 1.4313E15,
            Flattening = 0.06487,
            Density = 1.326,
            Gravity = 24.79,
            EscapeVelocity = 59.5
        };

        return ProgressionPlanetBuilder.Create("Jupiter", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The fifth and largets planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-05")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.GASGIANTPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }

    public static Result<ProgressionSatelite> Metis(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 21.5,
            Dimensions = "60x40x34",
            Area = 5800,
            Volume = 42700
        };

        return ProgressionSateliteBuilder.Create("Metis", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("First inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Adrastea(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 18.2,
            Dimensions = "20x16x14",
            Volume = 2345
        };

        return ProgressionSateliteBuilder.Create("Adrastea", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Second inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Amalthea(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Amalthea", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Third inner natural satellite and the 5th largest of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Thebe(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 49.3,
            Dimensions = "116x98x84",
            Volume = 5.0E5,
            Gravity = 0.04,
            EscapeVelocity = 0.025
        };

        return ProgressionSateliteBuilder.Create("Thebe", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth inner natural satellite and the 7th largest of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Io(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Io", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("First Galilean and the 3rd largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Europa(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Europa", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Second Galilean and 4th largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Ganymede(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Ganymede", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Third Galilean and largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Callisto(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Callisto", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth Galilean and 2nd largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Himalia(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Himalia", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("11th natural and 6th largest satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Elara(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 8.7E17,
            Radius = 40,
            Dimensions = "unknown",
            Density = 2.6
        };

        return ProgressionSateliteBuilder.Create("Elara", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Fourth inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Pasiphae(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Pasiphae", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("60th and 9th largest inner natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Carme(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 23.35,
            Dimensions = "unknown",
            Density = 2.6
        };

        return ProgressionSateliteBuilder.Create("Carme", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("74th and 10th largest natural satellite of Jupiter.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    #endregion

    #region Saturn
    public static Result<ProgressionPlanet> Saturn(IProgressionMap map)
    {
        ProgressionSatelite[] satelites =
        {
            Titan(map),
            Rhea(map),
            Iapetus(map),
            Dione(map),
            Tethys(map),
            Enceladus(map),
            Mimas(map),
            Hyperion(map),
            Phoebe(map),
            Janus(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 5.6834E26,
            Radius = 58232,
            Area = 4.27E10,
            Volume = 8.2713E14,
            Flattening = 0.09796,
            Density = 0.867,
            Gravity = 10.44,
            EscapeVelocity = 35.5
        };

        return ProgressionPlanetBuilder.Create("Saturn", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The sixth planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-06")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.GASGIANTPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }


    public static Result<ProgressionSatelite> Titan(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Titan", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Saturn and second largest in the Solar System.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Rhea(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Rhea", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("2nd largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Iapetus(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Iapetus", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("3rd largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Dione(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Dione", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("4th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Tethys(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Tethys", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("5th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Enceladus(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Enceladus", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("6th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Mimas(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Mimas", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("7th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Hyperion(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Hyperion", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("8th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Phoebe(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Phoebe", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("9th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Janus(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.8975E18,
            Radius = 89.5,
            Volume = 3E6,
            Density = 0.63,
            Gravity = 0.017
        };

        return ProgressionSateliteBuilder.Create("Janus", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("10th largest natural satellite of Saturn.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    #endregion

    #region Uranus
    public static Result<ProgressionPlanet> Uranus(IProgressionMap map)
    {
        ProgressionSatelite[] satelites =
        {
            Titania(map),
            Oberon(map),
            Umbriel(map),
            Ariel(map),
            Miranda(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 5.6834E26,
            Radius = 58232,
            Area = 4.27E10,
            Volume = 8.2713E14,
            Flattening = 0.09796,
            Density = 0.867,
            Gravity = 10.44,
            EscapeVelocity = 35.5
        };

        return ProgressionPlanetBuilder.Create("Uranus", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 7th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-07")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.GASGIANTPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }

    public static Result<ProgressionSatelite> Titania(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Titania", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Oberon(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Oberon", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Umbriel(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Umbriel", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 3rd largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Ariel(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Ariel", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 4th largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Miranda(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Miranda", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 5th largest natural satellite of Uranus.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
    #endregion

    #region Neptune
    public static Result<ProgressionPlanet> Neptune(IProgressionMap map)
    {
        ProgressionSatelite[] satelites =
        {
            Triton(map),
            Proteus(map),
            Nereid(map),
            Larissa(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.024E26,
            Radius = 24622,
            Area = 4.27E9,
            Volume = 6.254E13,
            Flattening = 0.09796,
            Density = 1.638,
            Gravity = 11.15,
            EscapeVelocity = 23.5
        };

        return ProgressionPlanetBuilder.Create("Neptune", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 8th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-08")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.GASGIANTPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }

    public static Result<ProgressionSatelite> Triton(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Triton", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Proteus(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Proteus", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Nereid(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Radius = 178.5
        };

        return ProgressionSateliteBuilder.Create("Nereid", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The 3rd largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Larissa(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Larissa", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Neptune.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }
    #endregion

    #region Pluto
    public static Result<ProgressionPlanet> Pluto(IProgressionMap map)
    {
        ProgressionSatelite[] satelites =
        {
            Charon(map),
            Nix(map),
            Hydra(map),
            Kerberos(map),
            Styx(map)
        };

        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.303E22,
            Radius = 2376.6,
            Area = 1.774E7,
            Volume = 7.057E9,
            Density = 1.854,
            Gravity = 0.620,
            EscapeVelocity = 1.212
        };

        return ProgressionPlanetBuilder.Create("Pluto", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("The largets Dwarf Planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-01")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYDWARFPLANET)
            .AddPhysicalProperties(physicalProperties)
            .AddSatelites(satelites)
            .Build();
    }

    public static Result<ProgressionSatelite> Charon(IProgressionMap map)
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

        return ProgressionSateliteBuilder.Create("Charon", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Largest natural satellite of Pluto.")
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Nix(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 2.60E16,
            Dimensions = "49.8x33.2x31.1",
            Density = 1.031,
            Gravity = 0.0028,
            EscapeVelocity = 0.0118
        };

        return ProgressionSateliteBuilder.Create("Nix", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Hydra(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 3.01E16,
            Dimensions = "50.9x36.1x30.9",
            Density = 1.220,
            Gravity = 5.2E-3
        };

        return ProgressionSateliteBuilder.Create("Hydra", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Kerberos(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 1.65E16,
            Dimensions = "19x10x9"
        };

        return ProgressionSateliteBuilder.Create("Kerberos", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionSatelite> Styx(IProgressionMap map)
    {
        PhysicalProperties physicalProperties = new()
        {
            Mass = 7.5E15,
            Dimensions = "16x9x8"
        };

        return ProgressionSateliteBuilder.Create("Styx", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    #endregion
    #endregion

    #region Asteroids
    public static Result<ProgressionAsteroid> Ceres(IProgressionMap map)
    {

        PhysicalProperties physicalProperties = new()
        {
            Mass = 9.3839E20,
            Radius = 939.4,
            Dimensions = "966.2x962.0x891.8",
            Area = 2.772E6,
            Volume = 4.34E8,
            Density = 2.1616,
            Gravity = 0.284,
            EscapeVelocity = 0.516
        };

        return ProgressionAsteroidBuilder.Create("Ceres", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("Dwarf planet in the asteroid belt.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-2")
            .WithProperty(PropertiesConstant.PLANETTYPE, PropertiesConstant.ROCKYDWARFPLANET)
            .AddPhysicalProperties(physicalProperties)
            .Build();
    }

    public static Result<ProgressionAsteroid> Vesta(IProgressionMap map)
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

        return ProgressionAsteroidBuilder.Create("Vesta", ProgressionMapIdentifierGenerator.Instance, map)
            .WithDescription("One of the largest asteroids in the Solar System.")
            .AddPhysicalProperties(properties)
            .Build();
    }

    public static Result<ProgressionAsteroid> Pallas(IProgressionMap map)
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

        return ProgressionAsteroidBuilder.Create("Pallas", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(properties)
            .Build();
    }

    public static Result<ProgressionAsteroid> Hygiea(IProgressionMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 8.74E19,
            Radius = 433,
            Dimensions = "450x430x424",
            Density = 2.06
        };

        return ProgressionAsteroidBuilder.Create("Hygiea", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(properties)
            .Build();
    }

    public static Result<ProgressionAsteroid> Euphrosyne(IProgressionMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 16.5E18,
            Radius = 268,
            Dimensions = "294x280x248",
            Density = 1.64
        };

        return ProgressionAsteroidBuilder.Create("Euphrosyne", ProgressionMapIdentifierGenerator.Instance, map)
            .AddPhysicalProperties(properties)
            .Build();
    }

    public static Result<ProgressionAsteroid> Interamnia(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Interamnia", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<ProgressionAsteroid> Davida(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Davida", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<ProgressionAsteroid> Herculina(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Herculina", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<ProgressionAsteroid> Eunomia(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Eunomia", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<ProgressionAsteroid> Juno(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Juno", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<ProgressionAsteroid> Psyche(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Psyche", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    public static Result<ProgressionAsteroid> Europa52(IProgressionMap map)
    {
        return ProgressionAsteroidBuilder.Create("Europa 52", ProgressionMapIdentifierGenerator.Instance, map)
            .Build();
    }

    #endregion

    #region Comets
    public static Result<Comet> Haleys(IStellarMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 2.2E14,
            Radius = 11,
            Dimensions = "15x8",
            Density = 0.6
        };

        return CometBuilder.Create("Haley's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Haley's Comet")
            .AddPhysicalProperties(properties)
            .Build();
    }

    public static Result<Comet> Caesers(IStellarMap map)
    {
        return CometBuilder.Create("Caeser's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Caeser's Comet")
            .Build();
    }

    public static Result<Comet> Enckes(IStellarMap map)
    {
        return CometBuilder.Create("Encke's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Encke's Comet")
            .Build();
    }

    public static Result<Comet> Bielas(IStellarMap map)
    {
        return CometBuilder.Create("Biela's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Biela's Comet")
            .Build();
    }

    public static Result<Comet> Fayes(IStellarMap map)
    {
        return CometBuilder.Create("Faye's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Faye's Comet")
            .Build();
    }

    public static Result<Comet> Brorsens(IStellarMap map)
    {
        return CometBuilder.Create("Brorsen's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Brorsen's Comet")
            .Build();
    }

    public static Result<Comet> dArrests(IStellarMap map)
    {
        return CometBuilder.Create("d'Arrest's", MapIdentifierGenerator.Instance, map)
            .WithDescription("d'Arrest's Comet")
            .Build();
    }

    #endregion
}
