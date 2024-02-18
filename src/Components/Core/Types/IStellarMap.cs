namespace StellarMap.Core;

internal interface IStellarMap
{
    string? Name { get; set; }
    Dictionary<string, string>? MetaData { get; }
    Dictionary<Identifier, Star>? Stars { get; set; }
    Dictionary<Identifier, Planet>? Planets { get; set; }

    Result<T> Get<T>(Identifier identifier) where T : IStellarObject;

    Result Add<T>(T t) where T : IStellarObject;
}
