namespace CoreTests;

public class Builders
{
    public static Planet BuildMercury(IStellarMap map)
    {
        var mercury = StellarObjectBuilder.CreatePlanet("Mercury", MapIdentifierGenerator.Instance, map)
            .WithDescription("The first planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-01")
            .Build();
        map.Add<Planet>(mercury);
        return mercury;
    }

    public static Planet BuildVenus(IStellarMap map)
    {
        var venus = PlanetBuilder.Create("Venus", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 2nd planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-02")
            .Build();
        map.Add<Planet>(venus);
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
        map.Add<Planet>(earth);
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
        map.Add<Planet>(mars);
        return mars;
    }

    public static Planet BuildJupiter(IStellarMap map)
    {
        // Inner Moons
        var metis = SateliteBuilder.Create("Metis", MapIdentifierGenerator.Instance, map).Build();
        var adrastea = SateliteBuilder.Create("Adrastea", MapIdentifierGenerator.Instance, map).Build();
        var amalthea = SateliteBuilder.Create("Amalthea", MapIdentifierGenerator.Instance, map).Build();
        var thebe = SateliteBuilder.Create("Thebe", MapIdentifierGenerator.Instance, map).Build();

        // Galilean Moons
        var io = SateliteBuilder.Create("Io", MapIdentifierGenerator.Instance, map).Build();
        var europa = SateliteBuilder.Create("Europa", MapIdentifierGenerator.Instance, map).Build();
        var ganymede = SateliteBuilder.Create("Ganymede", MapIdentifierGenerator.Instance, map).Build();
        var callisto = SateliteBuilder.Create("Callisto", MapIdentifierGenerator.Instance, map).Build();
        var himalia = SateliteBuilder.Create("Himalia", MapIdentifierGenerator.Instance, map).Build();
        var elara = SateliteBuilder.Create("Elara", MapIdentifierGenerator.Instance, map).Build();
        var pasiphae = SateliteBuilder.Create("Pasiphae", MapIdentifierGenerator.Instance, map).Build();
        var carme = SateliteBuilder.Create("Carme", MapIdentifierGenerator.Instance, map).Build();

        var jupiter = StellarObjectBuilder.CreatePlanet("Jupiter", MapIdentifierGenerator.Instance, map)
            .WithDescription("The fifth and largets planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-05")
            .AddSatelite(metis)
            .AddSatelite(adrastea)
            .AddSatelite(amalthea)
            .AddSatelite(thebe)
            .AddSatelite(io)
            .AddSatelite(europa)
            .AddSatelite(ganymede)
            .AddSatelite(callisto)
            .AddSatelite(himalia)
            .AddSatelite(elara)
            .AddSatelite(pasiphae)
            .AddSatelite(carme)
            .Build();

        map.Add<Planet>(jupiter);
        return jupiter;
    }

    public static Planet BuildSaturn(IStellarMap map)
    {
        var titan = SateliteBuilder.Create("Titan", MapIdentifierGenerator.Instance, map).Build();
        var rhea = SateliteBuilder.Create("Rhea", MapIdentifierGenerator.Instance, map).Build();
        var iapetus = SateliteBuilder.Create("Iapetus", MapIdentifierGenerator.Instance, map).Build();
        var dione = SateliteBuilder.Create("Dione", MapIdentifierGenerator.Instance, map).Build();
        var tethys = SateliteBuilder.Create("Tethys", MapIdentifierGenerator.Instance, map).Build();
        var enceladus = SateliteBuilder.Create("Enceladus", MapIdentifierGenerator.Instance, map).Build();
        var mimas = SateliteBuilder.Create("Mimas", MapIdentifierGenerator.Instance, map).Build();
        var hyperion = SateliteBuilder.Create("Hyperion", MapIdentifierGenerator.Instance, map).Build();
        var phoebe = SateliteBuilder.Create("Phoebe", MapIdentifierGenerator.Instance, map).Build();
        var janus = SateliteBuilder.Create("Janus", MapIdentifierGenerator.Instance, map).Build();

        var saturn = PlanetBuilder.Create("Saturn", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 6th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-06")
            .AddSatelite(titan)
            .AddSatelite(rhea)
            .AddSatelite(iapetus)
            .AddSatelite(dione)
            .AddSatelite(tethys)
            .AddSatelite(enceladus)
            .AddSatelite(mimas)
            .AddSatelite(hyperion)
            .AddSatelite(phoebe)
            .AddSatelite(janus)
            .Build();
        map.Add<Planet>(saturn);
        return saturn;
    }

    public static Planet BuildUranus(IStellarMap map)
    {
        var titania = SateliteBuilder.Create("Titania", MapIdentifierGenerator.Instance, map).Build();
        var oberon = SateliteBuilder.Create("Oberon", MapIdentifierGenerator.Instance, map).Build();
        var umbriel = SateliteBuilder.Create("Umbriel", MapIdentifierGenerator.Instance, map).Build();
        var ariel = SateliteBuilder.Create("Ariel", MapIdentifierGenerator.Instance, map).Build();
        var miranda = SateliteBuilder.Create("Miranda", MapIdentifierGenerator.Instance, map).Build();

        var uranus = PlanetBuilder.Create("Uranus", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 7th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-07")
            .AddSatelite(titania)
            .AddSatelite(oberon)
            .AddSatelite(umbriel)
            .AddSatelite(ariel)
            .AddSatelite(miranda)
            .Build();
        map.Add<Planet>(uranus);
        return uranus;
    }

    public static Planet BuildNeptune(IStellarMap map)
    {
        var triton = SateliteBuilder.Create("Triton", MapIdentifierGenerator.Instance, map).Build();
        var proteus = SateliteBuilder.Create("Proteus", MapIdentifierGenerator.Instance, map).Build();
        var nereid = SateliteBuilder.Create("Nereid", MapIdentifierGenerator.Instance, map).Build();
        var larissa = SateliteBuilder.Create("Larissa", MapIdentifierGenerator.Instance, map).Build();

        var neptune = PlanetBuilder.Create("Neptune", MapIdentifierGenerator.Instance, map)
            .WithDescription("The 8th planet in the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-08")
            .AddSatelite(triton)
            .AddSatelite(proteus)
            .AddSatelite(nereid)
            .AddSatelite(larissa)
            .Build();
        map.Add<Planet>(neptune);
        return neptune;
    }

    public static Planet BuildPluto(IStellarMap map)
    {
        var charon = SateliteBuilder.Create("Charon", MapIdentifierGenerator.Instance, map).Build();
        var nix = SateliteBuilder.Create("Nix", MapIdentifierGenerator.Instance, map).Build();
        var hydra = SateliteBuilder.Create("Hydra", MapIdentifierGenerator.Instance, map).Build();
        var kerberos = SateliteBuilder.Create("Kerberos", MapIdentifierGenerator.Instance, map).Build();
        var styx = SateliteBuilder.Create("Styx", MapIdentifierGenerator.Instance, map).Build();

        var pluto = PlanetBuilder.Create("Pluto", MapIdentifierGenerator.Instance, map)
            .WithDescription("Pluto is actually a Dwarf Planet.")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-01")
            .IsDwarf(true)
            .AddSatelite(charon)
            .AddSatelite(nix)
            .AddSatelite(hydra)
            .AddSatelite(kerberos)
            .AddSatelite(styx)
            .Build();
        map.Add<Planet>(pluto);
        return pluto;
    }

    public static Planet BuildCeres(IStellarMap map)
    {
        var ceres = PlanetBuilder.Create("Ceres", MapIdentifierGenerator.Instance, map)
            .WithDescription("Dwarf Planet in asteroid belt")
            .WithProperty(PropertiesConstant.DESIGNATION, "SOL-D-02")
            .IsDwarf(true)
            .Build();
        map.Add<Planet>(ceres);
        return ceres;
    }

    public static Star BuildSol(IStellarMap map)
    {
        // Planets
        var mercury = BuildMercury(map);
        var venus = BuildVenus(map);
        var earth = BuildEarth(map);
        var mars = BuildMars(map);
        var jupiter = BuildJupiter(map);
        var saturn = BuildSaturn(map);
        var uranus = BuildUranus(map);
        var neptune = BuildNeptune(map);
        var pluto = BuildPluto(map);
        var ceres = BuildCeres(map);

        // Asteroids
        var vesta = AsteroidBuilder.Create("Vesta", MapIdentifierGenerator.Instance, map).Build();
        var pallas = AsteroidBuilder.Create("Pallas", MapIdentifierGenerator.Instance, map).Build();
        var hygiea = AsteroidBuilder.Create("Hygiea", MapIdentifierGenerator.Instance, map).Build();
        var euphrosyne = AsteroidBuilder.Create("Euphrosyne", MapIdentifierGenerator.Instance, map).Build();
        var interamnia = AsteroidBuilder.Create("Interamnia", MapIdentifierGenerator.Instance, map).Build();
        var davida = AsteroidBuilder.Create("Davida", MapIdentifierGenerator.Instance, map).Build();
        var herculina = AsteroidBuilder.Create("Herculina", MapIdentifierGenerator.Instance, map).Build();
        var eunomia = AsteroidBuilder.Create("Eunomia", MapIdentifierGenerator.Instance, map).Build();
        var juno = AsteroidBuilder.Create("Juno", MapIdentifierGenerator.Instance, map).Build();
        var psyche = AsteroidBuilder.Create("Psyche", MapIdentifierGenerator.Instance, map).Build();
        var europa = AsteroidBuilder.Create("Europa", MapIdentifierGenerator.Instance, map).Build();

        // Comets
        var halleys = CometBuilder.Create("Haley's", MapIdentifierGenerator.Instance, map).Build();
        var caesers = CometBuilder.Create("Caeser's", MapIdentifierGenerator.Instance, map).Build();
        var enckes = CometBuilder.Create("Encke's", MapIdentifierGenerator.Instance, map).Build();
        var bielas = CometBuilder.Create("Biela's", MapIdentifierGenerator.Instance, map).Build();
        var fayes = CometBuilder.Create("Faye's", MapIdentifierGenerator.Instance, map).Build();
        var brorsens = CometBuilder.Create("Brorsen's", MapIdentifierGenerator.Instance, map).Build();
        var darrests = CometBuilder.Create("d'Arrest's", MapIdentifierGenerator.Instance, map).Build();

        var sol =  StarBuilder.Create("Sol", MapIdentifierGenerator.Instance, map)
            .WithDescription("The star at the center of the Solar System.")
            .WithProperty(PropertiesConstant.DESIGNATION, "Sol")
            .WithProperty(PropertiesConstant.ALTERNATIVENAME, "Sun")
            .WithProperty(PropertiesConstant.STELLARCLASS, "G2V")
            .AddPlanet(mercury)
            .AddPlanet(venus)
            .AddPlanet(earth)
            .AddPlanet(mars)
            .AddPlanet(jupiter)
            .AddPlanet(saturn)
            .AddPlanet(uranus)
            .AddPlanet(neptune)
            .AddPlanet(pluto)
            .AddPlanet(ceres)
            .AddAsteroid(vesta)
            .AddAsteroid(pallas)
            .AddAsteroid(hygiea)
            .AddAsteroid(euphrosyne)
            .AddAsteroid(interamnia)
            .AddAsteroid(davida)
            .AddAsteroid(herculina)
            .AddAsteroid(eunomia)
            .AddAsteroid(juno)
            .AddAsteroid(psyche)
            .AddAsteroid(europa)
            .AddComet(halleys)
            .AddComet(caesers)
            .AddComet(enckes)
            .AddComet(bielas)
            .AddComet(fayes)
            .AddComet(brorsens)
            .AddComet(darrests)
            .Build();
        map.Add<Star>(sol);
        return sol;
    }
}
