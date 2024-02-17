using System.Diagnostics.Contracts;

namespace StellarMap.Core.Math;
public readonly record struct SphericalPoint(double Radius, double Inclination, double Azimuth)
{
    #region Static Point3ds
    /// <summary>
    /// Gets a point at the origin
    /// </summary>
    public static SphericalPoint Origin { get; } = new(0, 0, 0);

    /// <summary>
    /// Gets a point where all values are NAN
    /// </summary>
    public static SphericalPoint NaN { get; } = new(double.NaN, double.NaN, double.NaN);
    #endregion

    #region Conversion
    public readonly Point ToPoint()
    {
        var x = Radius * System.Math.Sin(Inclination) * System.Math.Cos(Azimuth);
        var y = Radius * System.Math.Sin(Inclination) * System.Math.Sin(Azimuth);
        var z = Radius * System.Math.Cos(Inclination);
        return new(x, y, z);
    }
    #endregion
}
