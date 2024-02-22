using System.Numerics;

namespace StellarMap.Core;

public class SateliteBuilder : StellarObjectBuilder
{
    protected Satelite _satelite;

    public static SateliteBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        SateliteBuilder sateliteBuilder = new();
        sateliteBuilder._satelite = new(name, identifier, map);
        return sateliteBuilder;
    }

    public static SateliteBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map,
        bool isDwarf = false)
    {
        SateliteBuilder sateliteBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.Planet, map);
        sateliteBuilder._satelite = new(name, identifier, map);
        return sateliteBuilder;
    }

    public Result<Satelite> Build()
    {
        if (!_result.Success) return _result;
        _result = _satelite.Map.Add<Satelite>(_satelite);
        return _result.Success ? _satelite : _result;
    }

    public SateliteBuilder AddProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = AddToProperties(_satelite, name, value);
        return this;
    }

    public SateliteBuilder Description(string description) => AddProperty(PropertiesConstant.DESCRIPTION, description);
}
