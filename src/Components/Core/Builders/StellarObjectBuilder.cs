using System.ComponentModel.DataAnnotations;

namespace StellarMap.Core;

public abstract class StellarObjectBuilder
{
    protected Result _result = Result.Ok();

    protected static Result AddToProperties(IStellarObject stellarObject, string key, string value)
    {
        var result = GuardClause.Null(stellarObject).NullOrWhiteSpace(key);
        if (!result.Success) return result;

        if (stellarObject.Properties.ContainsKey(key))
            return Result.Error($"{key} already exists in Properties");

        stellarObject.Properties.Add(key, value);
        return Result.Ok();
    }

    protected Result<T> Build<T>(T stellarObject) where T : IStellarObject
    {
        if (!_result.Success) return _result;
        _result = GuardClause.Null(stellarObject).Null(stellarObject.Map);
        if (!_result.Success) return _result;

        _result = stellarObject.Map.Add<T>(stellarObject);
        return _result.Success ? stellarObject : _result;
    }

    protected StellarObjectBuilder Add<T>(StellarObject parent, T objToAdd) where T : IStellarObject
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(objToAdd).Null(objToAdd.Map);
        if (!_result.Success) return this;

        _result = parent.Add<T>(objToAdd);
        return this;
    }

    #region Create Builders
    public static StarBuilder CreateStar(string name, IIdentifierGenerator generator, IStellarMap map)
        => StarBuilder.Create(name, generator, map);
    public static StarBuilder CreateStar(string name, Identifier identifier, IStellarMap map)
        => StarBuilder.Create(name, identifier, map);

    public static PlanetBuilder CreatePlanet(string name, IIdentifierGenerator generator, IStellarMap map)
    => PlanetBuilder.Create(name, generator, map);
    public static PlanetBuilder CreatePlanet(string name, Identifier identifier, IStellarMap map)
        => PlanetBuilder.Create(name, identifier, map);

    public static SateliteBuilder CreateSatelite(string name, IIdentifierGenerator generator, IStellarMap map)
    => SateliteBuilder.Create(name, generator, map);
    public static SateliteBuilder CreateSatelite(string name, Identifier identifier, IStellarMap map)
        => SateliteBuilder.Create(name, identifier, map);

    public static AsteroidBuilder CreateAsteroid(string name, IIdentifierGenerator generator, IStellarMap map)
    => AsteroidBuilder.Create(name, generator, map);
    public static AsteroidBuilder CreateAsteroid(string name, Identifier identifier, IStellarMap map)
        => AsteroidBuilder.Create(name, identifier, map);

    public static CometBuilder CreateComet(string name, IIdentifierGenerator generator, IStellarMap map)
    => CometBuilder.Create(name, generator, map);

    public static CometBuilder CreateComet(string name, Identifier identifier, IStellarMap map)
        => CometBuilder.Create(name, identifier, map);
    #endregion
}
