using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace StellarMap.Core.Math;

public readonly record struct Point(double X, double Y, double Z) : IFormattable, IParsable<Point>,
    IAdditionOperators<Point, Point, Point>, ISubtractionOperators<Point, Point, Point>, IUnaryNegationOperators<Point, Point>
{
    #region Static Points
    public static Point Origin => new (0, 0, 0);
    public static Point NaN => new (double.NaN, double.NaN, double.NaN);
    public static Point Unit => new(1, 1, 1);
    #endregion

    #region Functions

    public readonly double LengthSquared() => X * X + Y * Y + Z * Z;
    public readonly double Length() => System.Math.Sqrt(LengthSquared());
    public readonly double Distance(Point p) => (this - p).Length();

    public readonly Vector ToVector() => new(X, X, Z);

    public readonly Point Add(Point p) => new(X + p.X, Y + p.Y, Z + p.Z);
    public readonly Point Add(Vector v) => new(X + v.X, Y + v.Y, Z + v.Z);
    public readonly Point Subtract(Point p) => new(X - p.X, Y - p.Y, Z - p.Z);
    public readonly Point Subtract(Vector v) => new(X - v.X, Y - v.Y, Z - v.Z);
    public readonly Point Negate() => new(-X, -Y, -Z);

    public SphericalPoint ToSphericalPoint()
    {
        double radius = Length(this);
        double inclination = System.Math.Acos(Z / radius);
        double azimuthal = System.Math.Sign(Y) * System.Math.Acos(X / radius);
        return new(radius, inclination, azimuthal);
    }
    #endregion

    #region Operators
    public static Point operator + (Point p1, Point p2) => p1.Add(p1);
    public static Point operator + (Point p, Vector v) => p.Add(v);
    public static Point operator - (Point p1, Point p2) => p1.Subtract(p2);
    public static Point operator - (Point p, Vector v) => p.Subtract(v);
    public static Point operator - (Point p) => p.Negate();
    #endregion

    #region IFormatable interface
    public readonly string ToString(string? format, IFormatProvider? provider = null)
    {
        NumberFormatInfo numberFormatInfo = provider != null ? NumberFormatInfo.GetInstance(provider) : CultureInfo.InvariantCulture.NumberFormat;
        string separator = numberFormatInfo.NumberDecimalSeparator == "," ? ";" : ",";
        return string.Format("({0}{1}{2}{1}{3})", this.X.ToString(format, numberFormatInfo), separator, 
            this.Y.ToString(format, numberFormatInfo), this.Z.ToString(format, numberFormatInfo));
    }
    #endregion

    #region  Interface
    public static Point Parse(string s, IFormatProvider? provider)
    {
        if (!TryParse(s, provider, out Point result))
            throw new FormatException($"'{s}' is not a valid Point. Expected '(X, Y, Z').");
        return result;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Point result)
    {
        double x = default;
        double y = default;
        double z = default;

        if (TryParse(s, provider, out x, out y, out z))
        {
            result = new(x, y, z);
            return true;
        }
        result = NaN;
        return false;
    }

    public static bool TryParse(string? text, IFormatProvider? provider, out double x, out double y, out double z)
    {
        x = default;
        y = default;
        z = default;

        if (string.IsNullOrEmpty(text))
            return false;

        // right now this is elcheapo - only handles (1.1, 2.4, 3.2) format
        string? temp = text?.Replace("(", "").Replace(")", "");
        string[]? values = temp?.Split(",");

        if (values?.Length == 3 &&
            double.TryParse(values[0], NumberStyles.Float, provider, out x) &&
            double.TryParse(values[1], NumberStyles.Float, provider, out y) &&
            double.TryParse(values[2], NumberStyles.Float, provider, out z))
            return true;

        return false;
    }


    #endregion
}
