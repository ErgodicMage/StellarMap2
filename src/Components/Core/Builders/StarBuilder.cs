using System.Numerics;

namespace StellarMap.Core;

public class StarBuilder : StellarObjectBuilder
{
    protected Star _star;

    public static StarBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        StarBuilder starBuilder = new();
        starBuilder._star = new(name, identifier, map);
        return starBuilder;
    }

    public static StarBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        StarBuilder starBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Planet, map);
        starBuilder._star = new(name, identifier, map);
        return starBuilder;
    }

    public Result<Star> Build() => Build<Star>(_star);

    public StarBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = AddToProperties(_star, name, value);
        return this;
    }

    public StarBuilder WithDescription(string description) 
        => WithProperty(PropertiesConstant.DESCRIPTION, description);


    public StarBuilder AddPlanet(Planet planet) => Add(planet) as StarBuilder;

    public StarBuilder AddAsteroid(Asteroid asteroid) => Add(asteroid) as StarBuilder;

    public StarBuilder AddComet(Comet comet) => Add(comet) as StarBuilder;
}
