namespace StellarMap.Progression;

public class HabitatBuilder
{
    protected Result _result = Result.Ok();
    protected Habitat? _habitat;

    public static HabitatBuilder Create(string name, Identifier identifier, IProgressionMap map)
    {
        HabitatBuilder habitatBuilder = new();
        habitatBuilder._habitat = new (name, identifier, map);
        return habitatBuilder;
    }

    public static HabitatBuilder Create(string name, IIdentifierGenerator generator, IProgressionMap map)
    {
        HabitatBuilder habitatBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(ProgressionObjectType.Habitat, map);
        habitatBuilder._habitat = new (name, identifier, map);
        return habitatBuilder;
    }

    public Result<Habitat> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<Habitat>(_habitat);
    }

    public HabitatBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_habitat, name, value);
        return this;
    }

    public HabitatBuilder WithDescription(string description) =>
        WithProperty(PropertiesConstant.DESCRIPTION, description);

    public HabitatBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_habitat).Null(properties);
        if (!_result.Success) return this;
        _habitat!.PhysicalProperties = properties;
        return this;
    }
}
