namespace StellarMap.Core;

public class PlanetBuilder
{
    protected Result _result = Result.Ok();
    protected Planet _planet;

    public static PlanetBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        PlanetBuilder planetBuilder = new();
        planetBuilder._planet = new(name, identifier, map);
        return planetBuilder;
    }

    public static PlanetBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        PlanetBuilder planetBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Planet, map);
        planetBuilder._planet = new(name, identifier, map);
        return planetBuilder;
    }

    public Result<Planet> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<Planet>(_planet);
    }

    public PlanetBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_planet, name, value);
        return this;
    }

    public PlanetBuilder WithDescription(string description) => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public PlanetBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(properties);
        if (!_result.Success) return this;
        _planet.PhysicalProperties = properties;
        return this;
    }

    // just store the satelites will add to _planet later to resolve identifiers
    public PlanetBuilder AddSatelite(Satelite satelite) //=> Add(_planet, satelite) as PlanetBuilder;
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Satelite>(_planet, satelite);
        return this;
    }

    public PlanetBuilder AddSatelites(ICollection<Satelite> satelites)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(satelites);
        if (!_result.Success) return this;

        foreach (var satelite in satelites)
        {
            _result = BuilderCommonFunctionality.Add<Satelite>(_planet, satelite);
            if (!_result.Success) return this;
        }

        return this;
    }
}
