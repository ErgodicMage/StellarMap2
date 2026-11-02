namespace StellarMap.Progression;

public class ProgressionAsteroidBuilder
{
    protected Result _result = Result.Ok();
    protected ProgressionAsteroid? _asteroid;

    public static ProgressionAsteroidBuilder Create(string name, Identifier identifier, IProgressionMap map)
    {
        ProgressionAsteroidBuilder asteroidBuilder = new();
        asteroidBuilder._asteroid = new ProgressionAsteroid(name, identifier, map);
        return asteroidBuilder;
    }

    public static ProgressionAsteroidBuilder Create(string name, IIdentifierGenerator generator, IProgressionMap map)
    {
        ProgressionAsteroidBuilder asteroidBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(ProgressionObjectType.ProgressionAsteroid, map);
        asteroidBuilder._asteroid = new ProgressionAsteroid(name, identifier, map);
        return asteroidBuilder;
    }

    public Result<ProgressionAsteroid> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<ProgressionAsteroid>(_asteroid as ProgressionAsteroid);
    }

    public ProgressionAsteroidBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_asteroid, name, value);
        return this;
    }

    public ProgressionAsteroidBuilder WithDescription(string description) =>
        WithProperty(PropertiesConstant.DESCRIPTION, description);

    public ProgressionAsteroidBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_asteroid).Null(properties);
        if (!_result.Success) return this;
        _asteroid!.PhysicalProperties = properties;
        return this;
    }

    public ProgressionAsteroidBuilder AddHabitat(Habitat habitat)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Habitat>(_asteroid, habitat);
        return this;
    }

    public ProgressionAsteroidBuilder AddHabitats(ICollection<Habitat> habitats)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Habitat>(_asteroid, habitats);
        return this;
    }
}
