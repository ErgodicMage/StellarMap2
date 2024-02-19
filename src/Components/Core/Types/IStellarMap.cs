namespace StellarMap.Core;

public interface IStellarMap
{
    string? Name { get; set; }
    Dictionary<string, string>? MetaData { get; }
    Dictionary<Identifier, Star>? Stars { get; set; }
    Dictionary<Identifier, Planet>? Planets { get; set; }
    Dictionary<Identifier, Satelite>? Satelites { get; set; }
    Dictionary<Identifier, DwarfPlanet>? DwarfPlanets { get; set; }

    Result<T> Get<T>(Identifier identifier) where T : IStellarObject;

    Result Add<T>(T t) where T : IStellarObject;
}
