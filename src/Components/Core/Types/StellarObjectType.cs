﻿using System.Data;

namespace StellarMap.Core;

public abstract class StellarObjectType
{
    public static readonly StellarObjectType Star = new StarType(1);
    public static readonly StellarObjectType Planet = new PlanetType(1);

    public string Name { get; protected init; }
    public int Value {get; protected init; }

    private StellarObjectType(int value, string name)
    {
        Value = value;
        Name = name;
    }

    private class StarType(int value) : StellarObjectType(value, StellarObjectConstants.Star)
    {
    }

    private class PlanetType(int value) : StellarObjectType(value, StellarObjectConstants.Planet)
    {
    }
}