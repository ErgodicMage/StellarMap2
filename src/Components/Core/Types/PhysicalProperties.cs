namespace StellarMap.Core;

public sealed record class PhysicalProperties
{
    public double Mass { get; init; }
    public double Radius { get; init; }
    public string? Dimensions { get; init; } = string.Empty;
    public double Area { get; init; }
    public double Volume { get; init; }
    public double Flattening { get; init; }
    public double Density { get; init; }
    public double Gravity { get; init; }
    public double EscapeVelocity { get; init; }
}
