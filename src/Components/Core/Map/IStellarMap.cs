namespace StellarMap.Components.Core;

public interface IStellarMap
{
    string Name { get; set; }

    Dictionary<string, string> MetaData { get; }

    Dictionary<string, Star>? Stars { get; set; }

    Dictionary<string, Planet>? Planets { get; set; }

    Dictionary<string, DwarfPlanet> DwarfPlanets { get; set; }

    Dictionary<string, Satellite>? Satellites { get; set; }

    Dictionary<string, Asteroid> Asteroids { get; set; }

    Dictionary<string, Comet> Comets { get; set; }

    Result Add<T>(string identifier, T stellarObject);
    Result AddStar(string identifier, Star star);
    Result AddPlanet(string identifier, Planet planet);
    Result AddDwarfPlanet(string identifier, DwarfPlanet dwarfPlanet);
    Result AddSatellite(string identifier, Satellite satellite);
    Result AddAsteroid(string identifier, Asteroid asteroid);
    Result AddComet(string identifier, Comet comet);

    Result<T> Get<T>(string identifier);
    Result<Star> GetStar(string identifier);
    Result<Planet> GetPlanet(string identifier);
    Result<DwarfPlanet> GetDwarfPlanet(string identifier);
    Result<Satellite> GetSatellite(string identifier);
    Result<Asteroid> GetAsteroid(String identifier);
    Result<Comet> GetComet(String identifier);
}
