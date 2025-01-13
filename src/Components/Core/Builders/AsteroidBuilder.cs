namespace StellarMap.Core;

public class AsteroidBuilder
{
    protected Result _result = Result.Ok();
    protected Asteroid? _asteroid;

    public static AsteroidBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        AsteroidBuilder asteroidBuilder = new();
        asteroidBuilder._asteroid = new(name, identifier, map);
        return asteroidBuilder;
    }

    public static AsteroidBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        AsteroidBuilder asteroidBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Asteroid, map);
        asteroidBuilder._asteroid = new(name, identifier, map);
        return asteroidBuilder;
    }

    public Result<Asteroid> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<Asteroid>(_asteroid);
    }

    public AsteroidBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_asteroid, name, value);
        return this;
    }

    public AsteroidBuilder WithDescription(string description) => 
        WithProperty(PropertiesConstant.DESCRIPTION, description);

    public AsteroidBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_asteroid).Null(properties);
        if (!_result.Success) return this;
        _asteroid!.PhysicalProperties = properties;
        return this;
    }
}
