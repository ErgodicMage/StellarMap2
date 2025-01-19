using System.Numerics;

namespace StellarMap.Core;

public class StarBuilder
{
    protected Result _result = Result.Ok();
    protected Star? _star;

    public static StarBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        StarBuilder starBuilder = new();
        starBuilder._star = new(name, identifier, map);
        return starBuilder;
    }

    public static StarBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        StarBuilder starBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Star, map);
        starBuilder._star = new(name, identifier, map);
        return starBuilder;
    }

    public Result<Star> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<Star>(_star);
    }

    public StarBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_star, name, value);
        return this;
    }

    public StarBuilder WithDescription(string description) 
        => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public StarBuilder AsStellarClass(string stellarClass)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_star).NullOrWhiteSpace(stellarClass);
        if (!_result) return this;
        _star!.StellarClass = stellarClass;
        return this;
    }

    public StarBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_star).Null(properties);
        if (!_result.Success) return this;
        _star!.PhysicalProperties = properties;
        return this;
    }

    public StarBuilder AddPlanet(Planet? planet)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Planet>(_star, planet);
        return this;
    }

    public StarBuilder AddPlanets(ICollection<Planet> planets)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Planet>(_star, planets);
        return this;
    }

    public StarBuilder AddDwarfPlanet(DwarfPlanet? dwarfplanet)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<DwarfPlanet>(_star, dwarfplanet);
        return this;
    }

    public StarBuilder AddDwarfPlanets(ICollection<DwarfPlanet> dwarfplanets)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<DwarfPlanet>(_star, dwarfplanets);
        return this;
    }

    public StarBuilder AddAsteroid(Asteroid? asteroid)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Asteroid>(_star, asteroid);
        return this;
    }

    public StarBuilder AddAsteroids(ICollection<Asteroid> asteroids)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Asteroid>(_star, asteroids);
        return this;
    }

    public StarBuilder AddComet(Comet? comet)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Comet>(_star, comet);
        return this;
    }

    public StarBuilder AddComets(ICollection<Comet> comets)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Comet>(_star, comets);
        return this;
    }
}
