namespace StellarMap.Core;

public class CometBuilder
{
    protected Result _result = Result.Ok();
    protected Comet _comet;

    public static CometBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        CometBuilder cometBuilder = new();
        cometBuilder._comet = new(name, identifier, map);
        return cometBuilder;
    }

    public static CometBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map,
        bool isDwarf = false)
    {
        CometBuilder cometBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Comet, map);
        cometBuilder._comet = new(name, identifier, map);
        return cometBuilder;
    }

    public Result<Comet> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<Comet>(_comet);
    }

    public CometBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_comet, name, value);
        return this;
    }

    public CometBuilder WithDescription(string description) => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public CometBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(properties);
        if (!_result.Success) return this;
        _comet.PhysicalProperties = properties;
        return this;
    }
}
