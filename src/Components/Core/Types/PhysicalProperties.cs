namespace StellarMap.Core;

public sealed record class PhysicalProperties
    (
        double Mass,
        double Radius,
        string Dimensions,
        double Area,
        double Volume,
        double Flattening,
        double Density,
        double Gravity,
        double EscapeVelocity
    );
