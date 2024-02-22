namespace StellarMap.Core;

public class PlanetBuilder : StellarObjectBuilder
{
    internal Planet _planet;

    public static PlanetBuilder Create(string name, Identifier identifier, IStellarMap map, bool isDwarf = false)
    {
        PlanetBuilder planetBuilder = new();
        planetBuilder._planet = new(name, identifier, map, isDwarf);
        return planetBuilder;
    }

    public static PlanetBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map, 
        bool isDwarf = false)
    {
        PlanetBuilder planetBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Planet, map);
        planetBuilder._planet = new(name, identifier, map, isDwarf);
        return planetBuilder;
    }

    public Result<Planet> Build() => Build<Planet>(_planet);

    public PlanetBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = AddToProperties(_planet, name, value);
        return this;
    }

    public PlanetBuilder WithDescription(string description) => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public PlanetBuilder IsDwarf(bool isDwarf)
    {
        if (!_result.Success) return this;
        _planet.IsDwarf = isDwarf;
        return this;
    }

    // just store the satelites will add to _planet later to resolve identifiers
    public PlanetBuilder AddSatelite(Satelite satelite) => Add(satelite) as PlanetBuilder;

}
