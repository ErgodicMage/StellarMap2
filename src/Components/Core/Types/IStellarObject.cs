﻿namespace StellarMap.Core;

public interface IStellarObject
{
    string? Name { get; init; }
    string? AlternativeName { get; set; }
    string? Description { get; set; }
    string? Designation { get; set; }

    IStellarMap Map { get; init; }

    Identifier Identifier { get; init; }
    Identifier ParentIdentifier { get; set; }

    StellarObjectType? ObjectType { get; }

    Result Add<T>(T obj) where T : IStellarObject;

    Result<T> Get<T>(string identifier) where T : IStellarObject;
    Result<T> GetByName<T>(string name) where T : IStellarObject;
    Result<T> GetAll<T>() where T : IStellarObject;
}
