using System.Diagnostics.Contracts;
using System.Globalization;

namespace StellarMap.Core.Math;

public readonly record struct Point(double X, double Y, double Z)
{
    #region Static Point3s
    public static Point Origin { get; } = new (0, 0, 0);

    public static Point NaN { get; } = new (double.NaN, double.NaN, double.NaN);
    #endregion

    #region Functions
    public readonly SphericalPoint ToSphericalPoint()
    {
        var radius = System.Math.Sqrt(X * X + Y * Y + Z * Z);
        var inclination = System.Math.Acos(Z / radius);
        var azimuthal = System.Math.Sign(Y) * System.Math.Acos(X / radius);
        return new SphericalPoint(radius, inclination, azimuthal);
    }

    public readonly Vector ToVector() => new (this.X, this.X, this.Z);

    /// <summary>
    public readonly Point Add(Vector addend) => new (this.X + addend.X, this.Y + addend.Y, this.Z + addend.Z);

    public readonly Point Subrtact(Vector vector) => new (this.X - vector.X, this.Y - vector.Y, this.Z - vector.Z);
    #endregion

    #region HashCode
    public override readonly int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 81173;
            // Suitable nullity checks etc, of course :)
            hash = hash * 96527 + X.GetHashCode();
            hash = hash * 96527 + Y.GetHashCode();
            hash = hash * 96527 + Z.GetHashCode();
            return hash;
        }
    }
    #endregion

    #region Operators
    public static Point operator + (Point point, Vector vector) => new(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

    public static Point operator - (Point point, Vector vector) => new(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
    #endregion

    #region IFormatable interface
    public override readonly string ToString() => ToString(null, CultureInfo.InvariantCulture);

    public readonly string ToString(IFormatProvider provider) => ToString(null, provider);

    public readonly string ToString(string? format, IFormatProvider? provider = null)
    {
        NumberFormatInfo numberFormatInfo = provider != null ? NumberFormatInfo.GetInstance(provider) : CultureInfo.InvariantCulture.NumberFormat;
        string separator = numberFormatInfo.NumberDecimalSeparator == "," ? ";" : ",";
        return string.Format("({0}{1} {2}{1} {3})", this.X.ToString(format, numberFormatInfo), separator, this.Y.ToString(format, numberFormatInfo), this.Z.ToString(format, numberFormatInfo));
    }
    #endregion

    #region Parse
    public static bool TryParse(string? text, out Point result)
    {
        if (TryParse(text, out var x, out var y, out var z))
        {
            result = new Point(x, y, z);
            return true;
        }
        result = Point.NaN;
        return false;
    }

    public static bool TryParse(string? text, out double x, out double y, out double z)
    {
        x = default;
        y = default;
        z = default;

        Result guardResult = GuardClause.NullOrWhiteSpace(text);
        if (!guardResult.Success) return false;

        // right now this is elcheapo - only handles (1.1, 2.4, 3.2) format
        string? temp = text?.Replace("(", "").Replace(")", "");
        string[]? values = temp?.Split(",");

        if (values?.Length == 3 &&
            double.TryParse(values[0], out x) &&
            double.TryParse(values[1], out y) &&
            double.TryParse(values[2], out z))
            return true;

        return false;
    }

    #endregion
}
