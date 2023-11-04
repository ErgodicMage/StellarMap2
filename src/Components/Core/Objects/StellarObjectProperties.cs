namespace StellarMap.Core;

public record StellarObjectProperties
{
    public string Name { get; set; } = string.Empty;
    public string Designation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Mass { get; set; }
    public double Density { get; set; }
    public double Gravity { get; set; }
    public double Radius { get; set; }
    public double Area {get; set; }
    public double Valume { get; set; }
    public double Flattening { get; set; }
    public double EscapeVelocity { get; set; }
}
