using System.Diagnostics.Contracts;

namespace StellarMap.Core.Math;

public readonly record struct Vector(double X, double Y, double Z)
{
    #region Static Vectors
    public static Vector NullVector => new(0, 0, 0);
    public static Vector UnitVector => new(1, 1, 1);
    public static Vector NaN => new(double.NaN, double.NaN, double.NaN);
    #endregion

    #region Functions
    public readonly double Length => System.Math.Sqrt((this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z));

    public readonly Point ToPoint() => new(this.X, this.Y, this.Z);

    public readonly Vector Add(Vector addend) => new(this.X + addend.X, this.Y + addend.Y, this.Z + addend.Z);

    public readonly Vector Subtract(Vector subtrahend) => new(this.X - subtrahend.X, this.Y - subtrahend.Y, this.Z - subtrahend.Z);

    public readonly Vector Negate() => new(-1 * this.X, -1 * this.Y, -1 * this.Z);

    public readonly Vector Scale(double factor) => new(factor * this.X, factor * this.Y, factor * this.Z);

    public readonly double DotProduct(Vector v) => (this.X * v.X) + (this.Y * v.Y) + (this.Z * v.Z);

    public readonly Vector CrossProduct(Vector other)
    {
        double xx = (this.Y * other.Z) - (this.Z * other.Y);
        double yy = (this.Z * other.X) - (this.X * other.Z);
        double zz = (this.X * other.Y) - (this.Y * other.X);
        return new(xx, yy, zz);
    }

    #endregion

    #region HashCode
    public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z);
    #endregion

    #region Operators
    public static Vector operator + (Vector left, Vector right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static Vector operator - (Vector left, Vector right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
    #endregion
}
