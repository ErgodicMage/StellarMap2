namespace StellarMap.Core;

public class CometBuilder : StellarObjectBuilder
{
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
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Planet, map);
        cometBuilder._comet = new(name, identifier, map);
        return cometBuilder;
    }

    public Result<Comet> Build()
    {
        if (!_result.Success) return _result;
        _result = _comet.Map.Add<Comet>(_comet);
        return _result.Success ? _comet : _result;
    }

    public CometBuilder AddProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = AddToProperties(_comet, name, value);
        return this;
    }

    public CometBuilder Description(string description) => AddProperty(PropertiesConstant.DESCRIPTION, description);

}
