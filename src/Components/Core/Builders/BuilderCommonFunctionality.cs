﻿using ErgodicMage.Result;

namespace StellarMap.Core;

public static class BuilderCommonFunctionality
{
    public static Result AddToProperties(IStellarObject? stellarObject, string key, string value)
    {
        var result = GuardClause.Null(stellarObject).NullOrWhiteSpace(key);
        if (!result.Success) return result;

        if (stellarObject!.Properties.ContainsKey(key))
            return Result.Error($"{key} already exists in Properties");

        stellarObject.Properties.Add(key, value);
        return Result.Ok();
    }

    public static Result<T> Build<T>(T? stellarObject) where T : IStellarObject
    {
        var result = GuardClause.Null(stellarObject).Null(stellarObject?.Map);
        if (!result.Success) return result;

        result = stellarObject!.Map.Add<T>(stellarObject);
        return result.Success ? stellarObject : result;
    }

    public static Result Add<T>(IStellarObject? parent, T? objToAdd) where T : IStellarObject
    {
        var result = GuardClause.Null(parent).Null(objToAdd).Null(objToAdd?.Map);
        if (!result.Success) return result;

        return parent!.Add<T>(objToAdd!);
    }

    public static Result Add<T>(IStellarObject? parent, ICollection<T> objectsToAdd) where T : IStellarObject
    {
        var result = GuardClause.Null(parent).Null(objectsToAdd).NegativeOrZero(objectsToAdd.Count);
        if (!result.Success) return result;

        foreach (var obj in objectsToAdd)
        {
            result = GuardClause.Null(obj.Map);
            if (!result.Success) return result;
            result = parent!.Add<T>(obj);
            if (!result.Success) return result;
        }
        return result;
    }
}
