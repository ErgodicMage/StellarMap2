using System.Numerics;

namespace StellarMap.Core;

public class SateliteBuilder
{
    protected Result _result = Result.Ok();
    protected Satelite? _satelite;

    public static SateliteBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        SateliteBuilder sateliteBuilder = new();
        sateliteBuilder._satelite = new(name, identifier, map);
        return sateliteBuilder;
    }

    public static SateliteBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        SateliteBuilder sateliteBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Satelite, map);
        sateliteBuilder._satelite = new(name, identifier, map);
        return sateliteBuilder;
    }

    public Result<Satelite> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<Satelite>(_satelite);
    }

    public SateliteBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_satelite, name, value);
        return this;
    }

    public SateliteBuilder WithDescription(string description) => 
        WithProperty(PropertiesConstant.DESCRIPTION, description);

    public SateliteBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_satelite).Null(properties);
        if (!_result.Success) return this;
        _satelite!.PhysicalProperties = properties;
        return this;
    }
}
