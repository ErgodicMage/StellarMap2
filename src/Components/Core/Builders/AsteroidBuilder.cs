namespace StellarMap.Core;

public class AsteroidBuilder : StellarObjectBuilder
{
    protected Asteroid _asteroid;

    public static AsteroidBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        AsteroidBuilder asteroidBuilder = new();
        asteroidBuilder._asteroid = new(name, identifier, map);
        return asteroidBuilder;
    }

    public static AsteroidBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map,
        bool isDwarf = false)
    {
        AsteroidBuilder asteroidBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Planet, map);
        asteroidBuilder._asteroid = new(name, identifier, map);
        return asteroidBuilder;
    }

    public Result<Asteroid> Build()
    {
        if (!_result.Success) return _result;
        _result = _asteroid.Map.Add<Asteroid>(_asteroid);
        return _result.Success ? _asteroid : _result;
    }

    public AsteroidBuilder AddProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = AddToProperties(_asteroid, name, value);
        return this;
    }

    public AsteroidBuilder Description(string description) => AddProperty(PropertiesConstant.DESCRIPTION, description);

}
