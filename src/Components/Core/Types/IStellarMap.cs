namespace StellarMap.Core;

public interface IStellarMap : IEqualityComparer<IStellarMap>
{
    string Name { get; set; }
    Dictionary<string, string> MetaData { get; }

    // I had to switch from Identifier to strings for the Dictionary key so it works easier with System.Text.Json serialization
    Dictionary<string, StarSystem>? StarSystems { get; set; }
    Dictionary<string, Star>? Stars { get; set; }
    Dictionary<string, Planet>? Planets { get; set; }
    Dictionary<string, DwarfPlanet>? DwarfPlanets { get; set;}
    Dictionary<string, Satelite>? Satelites { get; set; }
    Dictionary<string, Asteroid>? Asteroids { get; set; }
    Dictionary<string, Comet>? Comets { get; set; }

    Result Add<T>(T t) where T : IStellarObject;

    Result<T> Get<T>(Identifier identifier) where T : IStellarObject;

    Result<int> GetObjectCount(StellarObjectType type);
}
