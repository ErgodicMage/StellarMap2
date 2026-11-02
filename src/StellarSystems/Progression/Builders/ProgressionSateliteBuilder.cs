namespace StellarMap.Progression.Builders;

public class ProgressionSateliteBuilder
{
    protected Result _result = Result.Ok();
    protected ProgressionSatelite? _satelite;

    public static ProgressionSateliteBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        ProgressionSateliteBuilder sateliteBuilder = new();
        sateliteBuilder._satelite = new ProgressionSatelite(name, identifier, map);
        return sateliteBuilder;
    }

    public static ProgressionSateliteBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        ProgressionSateliteBuilder sateliteBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(ProgressionObjectType.ProgressionSatelite, map);
        sateliteBuilder._satelite = new ProgressionSatelite(name, identifier, map);
        return sateliteBuilder;
    }

    public Result<ProgressionSatelite> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<ProgressionSatelite>(_satelite as ProgressionSatelite);
    }

    public ProgressionSateliteBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_satelite, name, value);
        return this;
    }

    public ProgressionSateliteBuilder WithDescription(string description) =>
        WithProperty(PropertiesConstant.DESCRIPTION, description);

    public ProgressionSateliteBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_satelite).Null(properties);
        if (!_result.Success) return this;
        _satelite!.PhysicalProperties = properties;
        return this;
    }

    public ProgressionSateliteBuilder AddHabitat(Habitat habitat)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Habitat>(_satelite, habitat);
        return this;
    }

    public ProgressionSateliteBuilder AddHabitats(ICollection<Habitat> habitats)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Habitat>(_satelite, habitats);
        return this;
    }
}
