using System.Numerics;

namespace StellarMap.Core;

public class DwarfPlanetBuilder
{
    protected Result _result = Result.Ok();
    protected DwarfPlanet? _dwarfplanet;

    public static DwarfPlanetBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        DwarfPlanetBuilder dwarfplanetBuilder = new();
        dwarfplanetBuilder._dwarfplanet = new(name, identifier, map);
        return dwarfplanetBuilder;
    }

    public static DwarfPlanetBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        DwarfPlanetBuilder dwarfplanetBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.DwarfPlanet, map);
        dwarfplanetBuilder._dwarfplanet = new(name, identifier, map);
        return dwarfplanetBuilder;
    }

    public Result<DwarfPlanet> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<DwarfPlanet>(_dwarfplanet);
    }

    public DwarfPlanetBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_dwarfplanet, name, value);
        return this;
    }

    public DwarfPlanetBuilder WithDescription(string description) => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public DwarfPlanetBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_dwarfplanet).Null(properties);
        if (!_result.Success) return this;
        _dwarfplanet!.PhysicalProperties = properties;
        return this;
    }

    // just store the satelites will add to _planet later to resolve identifiers
    public DwarfPlanetBuilder AddSatelite(Satelite? satelite) //=> Add(_planet, satelite) as PlanetBuilder;
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Satelite>(_dwarfplanet, satelite);
        return this;
    }

    public DwarfPlanetBuilder AddSatelites(ICollection<Satelite> satelites)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Satelite>(_dwarfplanet, satelites);
        return this;
    }

}
