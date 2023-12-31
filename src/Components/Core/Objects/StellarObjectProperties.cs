﻿namespace StellarMap.Components.Core;

public record struct StellarObjectProperties
{
    public StellarObjectProperties()
    {
    }

    public string Name { get; set; } = string.Empty;
    public string Designation {get; set;} = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string? ObjectType { get; set; } = string.Empty;
}
