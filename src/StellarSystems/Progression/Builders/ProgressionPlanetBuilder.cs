namespace StellarMap.Progression;

public class ProgressionPlanetBuilder
{
    protected Result _result = Result.Ok();
    protected ProgressionPlanet? _planet;

    public static ProgressionPlanetBuilder Create(string name, Identifier identifier, IProgressionMap map)
    {
        ProgressionPlanetBuilder planetBuilder = new();
        planetBuilder._planet = new ProgressionPlanet(name, identifier, map);
        return planetBuilder;
    }

    public static ProgressionPlanetBuilder Create(string name, IIdentifierGenerator generator, IProgressionMap map)
    {
        ProgressionPlanetBuilder planetBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(ProgressionObjectType.ProgressionPlanet, map);
        planetBuilder._planet = new ProgressionPlanet(name, identifier, map);
        return planetBuilder;
    }

    public Result<ProgressionPlanet> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<ProgressionPlanet>(_planet as ProgressionPlanet);
    }

    public ProgressionPlanetBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_planet, name, value);
        return this;
    }

    public ProgressionPlanetBuilder WithDescription(string description) =>
        WithProperty(PropertiesConstant.DESCRIPTION, description);

    public ProgressionPlanetBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_planet).Null(properties);
        if (!_result.Success) return this;
        _planet!.PhysicalProperties = properties;
        return this;
    }

    public ProgressionPlanetBuilder AddHabitat(Habitat habitat)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Habitat>(_planet, habitat);
        return this;
    }

    public ProgressionPlanetBuilder AddHabitats(ICollection<Habitat> habitats)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Habitat>(_planet, habitats);
        return this;
    }
}
