namespace CoreTests;

public class Builders
{
    public static Planet BuildMercury(IStellarMap map)
    {
        var mercury = StellarObjectBuilder.CreatePlanet("Mercury", MapIdentifierGenerator.Instance, map)
            .WithDescription("The first planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-01")
            .Build();
        return mercury;
    }

    public static Planet BuildVenus(IStellarMap map)
    {
        var venus = PlanetBuilder.Create("Venus", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-02")
            .Build();
        return venus;
    }

    public static Planet BuildEarth(IStellarMap map)
    {
        var moon = StellarObjectBuilder.CreateSatelite("Moon", MapIdentifierGenerator.Instance, map)
            .WithDescription("Earth's moon")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Luna")
            .Build();

        var earth = PlanetBuilder.Create("Earth", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 3nd planet in the Solar System")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-03")
            .AddSatelite(moon)
            .Build();
        return earth;
    }

    public static Planet BuildMars(IStellarMap map)
    {
        var phobos = SateliteBuilder.Create("Phobos", MapIdentifierGenerator.Instance, map).Build();
        var deimos = SateliteBuilder.Create("Deimos", MapIdentifierGenerator.Instance, map).Build();

        var mars = StellarObjectBuilder.CreatePlanet("Mars", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 4th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-04")
            .AddSatelite(phobos)
            .AddSatelite(deimos)
            .Build();
        return mars;
    }

    public static Planet BuildJupiter(IStellarMap map)
    {
        Satelite[] satelites =
        [
            // Inner Moons
            SateliteBuilder.Create("Metis", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Adrastea", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Amalthea", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Thebe", MapIdentifierGenerator.Instance, map).Build(),

            // Galilean Moons
            SateliteBuilder.Create("Io", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Europa", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Ganymede", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Callisto", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Himalia", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Elara", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Pasiphae", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Carme", MapIdentifierGenerator.Instance, map).Build()
        ];



        var jupiter = StellarObjectBuilder.CreatePlanet("Jupiter", MapIdentifierGenerator.Instance, map)
            .WithDescription("The fifth and largets planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-05")
            .AddSatelites(satelites)
            .Build();

        return jupiter;
    }

    public static Planet BuildSaturn(IStellarMap map)
    {
        Satelite[] satelites =
            {
                SateliteBuilder.Create("Titan", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Rhea", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Iapetus", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Dione", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Tethys", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Enceladus", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Mimas", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Hyperion", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Phoebe", MapIdentifierGenerator.Instance, map).Build(),
                SateliteBuilder.Create("Janus", MapIdentifierGenerator.Instance, map).Build(),
            };

        var saturn = PlanetBuilder.Create("Saturn", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 6th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-06")
            .AddSatelites(satelites)
            .Build();

        return saturn;
    }

    public static Planet BuildUranus(IStellarMap map)
    {
        Satelite[] satelites =
        {
            SateliteBuilder.Create("Titania", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Oberon", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Umbriel", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Ariel", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Miranda", MapIdentifierGenerator.Instance, map).Build()
        };

        var uranus = PlanetBuilder.Create("Uranus", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 7th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-07")
            .AddSatelites(satelites)
            .Build();

        return uranus;
    }

    public static Planet BuildNeptune(IStellarMap map)
    {
        Satelite[] satelites =
        {
            SateliteBuilder.Create("Triton", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Proteus", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Nereid", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Larissa", MapIdentifierGenerator.Instance, map).Build()
        };

        var neptune = PlanetBuilder.Create("Neptune", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 8th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-08")
            .AddSatelites(satelites)
            .Build();

        return neptune;
    }

    public static Planet BuildPluto(IStellarMap map)
    {
        Satelite[] satelites =
        {
            SateliteBuilder.Create("Charon", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Nix", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Hydra", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Kerberos", MapIdentifierGenerator.Instance, map).Build(),
            SateliteBuilder.Create("Styx", MapIdentifierGenerator.Instance, map).Build()
        };

        var pluto = PlanetBuilder.Create("Pluto", MapIdentifierGenerator.Instance, map)
            .WithDescription("Pluto is actually a Dwarf Planet.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-01")
            .IsDwarf(true)
            .AddSatelites(satelites)
            .Build();

        return pluto;
    }

    public static Planet BuildCeres(IStellarMap map)
    {
        var ceres = PlanetBuilder.Create("Ceres", MapIdentifierGenerator.Instance, map)
            .WithDescription("Dwarf Planet in asteroid belt")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-02")
            .IsDwarf(true)
            .Build();

        return ceres;
    }

    public static Star BuildSol(IStellarMap map)
    {
        // Planets
        Planet[] planets =
        {
            BuildMercury(map),
            BuildVenus(map),
            BuildEarth(map),
            BuildMars(map),
            BuildJupiter(map),
            BuildSaturn(map),
            BuildUranus(map),
            BuildNeptune(map),
            BuildPluto(map),
            BuildCeres(map)
        };

        // Asteroids
        Asteroid[] asteroids =
        {
            AsteroidBuilder.Create("Vesta", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Pallas", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Hygiea", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Euphrosyne", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Interamnia", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Davida", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Herculina", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Eunomia", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Juno", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Psyche", MapIdentifierGenerator.Instance, map).Build(),
            AsteroidBuilder.Create("Europa", MapIdentifierGenerator.Instance, map).Build()
        };

        // Comets
        Comet[] comets =
        {
            CometBuilder.Create("Haley's", MapIdentifierGenerator.Instance, map).Build(),
            CometBuilder.Create("Caeser's", MapIdentifierGenerator.Instance, map).Build(),
            CometBuilder.Create("Encke's", MapIdentifierGenerator.Instance, map).Build(),
            CometBuilder.Create("Biela's", MapIdentifierGenerator.Instance, map).Build(),
            CometBuilder.Create("Faye's", MapIdentifierGenerator.Instance, map).Build(),
            CometBuilder.Create("Brorsen's", MapIdentifierGenerator.Instance, map).Build(),
            CometBuilder.Create("d'Arrest's", MapIdentifierGenerator.Instance, map).Build()
        };

        var sol = StarBuilder.Create("Sol", MapIdentifierGenerator.Instance, map)
            .WithDescription("The star at the center of the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "Sol")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Sun")
            .AsStellarClass("G2V")
            .AddPlanets(planets)
            .AddAsteroids(asteroids)
            .AddComets(comets)
            .Build();

        return sol;
    }
}
