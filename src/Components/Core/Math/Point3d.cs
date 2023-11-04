using System.Diagnostics.Contracts;
using System.Globalization;

namespace StellarMap.Core.Math;

public record struct Point3d(double X, double Y, double Z) : IEquatable<Point3d>, IFormattable
{
    #region Static Point3ds
    /// <summary>
    /// Gets a point at the origin
    /// </summary>
    public static Point3d Origin { get; } = new (0, 0, 0);

    /// <summary>
    /// Gets a point where all values are NAN
    /// </summary>
    public static Point3d NaN { get; } = new (double.NaN, double.NaN, double.NaN);
    #endregion

    #region Functions
    /// <summary>
    /// Creates a new vector from the point, assuming zero origin
    /// </summary>
    /// <returns>A new vector from the origin to the point</returns>
    [Pure]
    public readonly Vector3d ToVector3d() => new (this.X, this.X, this.Z);

    /// <summary>
    /// Adds a point and a vector together
    /// </summary>
    /// <param name="addend">The vector to add</param>
    /// <returns>A new point at the summed location</returns>
    [Pure]
    public readonly Point3d Add(Vector3d addend) => new (this.X + addend.X, this.Y + addend.Y, this.Z + addend.Z);

    /// <summary>
    /// Subtracts the first point from the vector
    /// </summary>
    /// <param name="vector">The vector to subtract</param>
    /// <returns>A new point at the difference</returns>
    [Pure]
    public readonly Point3d Subrtact(Vector3d vector) => new (this.X - vector.X, this.Y - vector.Y, this.Z - vector.Z);
    #endregion

    #region HashCode
    /// <inheritdoc />
    [Pure]
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
    /// <summary>
    /// Adds a point and a vector together
    /// </summary>
    /// <param name="point">A point</param>
    /// <param name="vector">A vector</param>
    /// <returns>A new point at the summed location</returns>
    [Pure]
    public static Point3d operator + (Point3d point, Vector3d vector) 
        => new(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

    /// <summary>
    /// Subtracts a vector from a point
    /// </summary>
    /// <param name="point">A point</param>
    /// <param name="vector">A vector</param>
    /// <returns>A new point at the difference</returns>
    [Pure]
    public static Point3d operator - (Point3d point, Vector3d vector) 
        => new(point.X - vector.X, point.Y - vector.Y, point.Z - vector.Z);
    #endregion

    #region IFormatable interface
    /// <inheritdoc />
    [Pure]
    public override readonly string ToString() => ToString(null, CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of this instance using the provided <see cref="IFormatProvider"/>
    /// </summary>
    /// <param name="provider">A <see cref="IFormatProvider"/></param>
    /// <returns>The string representation of this instance.</returns>
    [Pure]
    public readonly string ToString(IFormatProvider provider) => ToString(null, provider);

    /// <inheritdoc />
    [Pure]
    public readonly string ToString(string? format, IFormatProvider? provider = null)
    {
        NumberFormatInfo numberFormatInfo = provider != null ? NumberFormatInfo.GetInstance(provider) : CultureInfo.InvariantCulture.NumberFormat;
        string separator = numberFormatInfo.NumberDecimalSeparator == "," ? ";" : ",";
        return string.Format("({0}{1} {2}{1} {3})", this.X.ToString(format, numberFormatInfo), separator, this.Y.ToString(format, numberFormatInfo), this.Z.ToString(format, numberFormatInfo));
    }
    #endregion

    #region Parse
    [Pure]
    public static bool TryParse(string? text, out Point3d result)
    {
        if (TryParse(text, out var x, out var y, out var z))
        {
            result = new Point3d(x, y, z);
            return true;
        }
        result = Point3d.NaN;
        return false;
    }

    [Pure]
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
