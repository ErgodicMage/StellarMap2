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

    protected StellarObjectBuilder Add<T>(T stellarObject) where T : IStellarObject
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(stellarObject).Null(stellarObject.Map);
        if (!_result.Success) return this;

        _result = stellarObject.Add<T>(stellarObject);
        return this;
    }
}
