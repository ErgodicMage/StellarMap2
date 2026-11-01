using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Numerics;

namespace StellarMap.Core.Math;

public readonly record struct Vector(double X, double Y, double Z) : IFormattable, IParsable<Vector>,
    IAdditionOperators<Vector, Vector, Vector>, ISubtractionOperators<Vector, Vector, Vector>, IUnaryNegationOperators<Vector, Vector>
{
    #region Static Vectors
    public static Vector NullVector => new(0, 0, 0);
    public static Vector UnitVector => new(1, 1, 1);
    public static Vector NaN => new(double.NaN, double.NaN, double.NaN);
    #endregion

    #region Functions
    public static double LengthSquared(Vector v) => v.X * v.X + v.Y * v.Y + v.Z * v.Z;
    public static double Length(Vector v) => System.Math.Sqrt(LengthSquared(v));

    public readonly Vector Add(Vector v) => new(X + v.X, Y + v.Y, Z + v.Z);
    public readonly Vector Add(Point p) => new(X + p.X, Y + p.Y, Z + p.Z);

    public readonly Vector Subtract(Vector v) => new(X - v.X, Y - v.Y, Z - v.Z);
    public readonly Vector Subtract(Point p) => new(X - p.X, Y - p.Y, Z - p.Z);

    public readonly Vector Negate() => new(-X, -Y, -Z);

    public readonly Vector Scale(double factor) => new(factor * X, factor * Y, factor * Z);

    public readonly double DotProduct(Vector v) => (X * v.X) + (Y * v.Y) + (Z * v.Z);

    public readonly Vector CrossProduct(Vector v)
    {
        double xx = (Y * v.Z) - (Z * v.Y);
        double yy = (Z * v.X) - (X * v.Z);
        double zz = (X * v.Y) - (Y * v.X);
        return new(xx, yy, zz);
    }
    #endregion

    #region Operators
    public static Vector operator + (Vector v1, Vector v2) => new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    public static Vector operator + (Vector v, Point p) => new(v.X + p.X, v.Y + p.Y, v.Z + p.Z);

    public static Vector operator - (Vector v1, Vector v2) => new(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    public static Vector operator - (Vector v, Point p) => new(v.X - p.X, v.Y - p.Y, v.Z - p.Z);

    public static Vector operator - (Vector v) => v.Negate();
    #endregion

    #region IFormatable Interface
    public string ToString(string? format, IFormatProvider? provider)
    {
        NumberFormatInfo numberFormatInfo = provider != null ? NumberFormatInfo.GetInstance(provider) : CultureInfo.InvariantCulture.NumberFormat;
        string separator = numberFormatInfo.NumberDecimalSeparator == "," ? ";" : ",";
        return string.Format("[{0}{1}{2}{1}{3}]", X.ToString(format, numberFormatInfo), separator,
            Y.ToString(format, numberFormatInfo), Z.ToString(format, numberFormatInfo));
    }
    #endregion

    #region IParsable Interface
    public static Vector Parse(string s, IFormatProvider? provider)
    {
        if (!TryParse(s, provider, out Vector result))
            throw new FormatException($"'{s}' is not a valid Point. Expected '[X, Y, Z'].");
        return result;
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Vector result)
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
        string? temp = text?.Replace("[", "").Replace("]", "");
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
