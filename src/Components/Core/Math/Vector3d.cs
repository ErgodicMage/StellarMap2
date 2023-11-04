using System.Diagnostics.Contracts;

namespace StellarMap.Core.Math;

public record struct Vector3d(double X, double Y, double Z)
{
    #region Static Vector3ds
    [Pure]
    public static Vector3d NullVector => new(0, 0, 0);

    /// <summary>
    /// Gets an invalid vector with no values
    /// </summary>
    [Pure]
    public static Vector3d NaN => new(double.NaN, double.NaN, double.NaN);
    #endregion

    #region Functions
    /// <summary>
    /// Gets the Euclidean Norm.
    /// </summary>
    [Pure]
    public readonly double Length => System.Math.Sqrt((this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z));

    /// <summary>
    /// Returns a point equivalent to the vector
    /// </summary>
    /// <returns>A point</returns>
    public readonly Point3d ToPoint3d() => new(this.X, this.Y, this.Z);

    /// <summary>
    /// Add this vector with another
    /// </summary>
    /// <param name="addend">The vector to add</param>
    /// <returns>A new summed vector</returns>
    [Pure]
    public readonly Vector3d Add(Vector3d addend) => new(this.X + addend.X, this.Y + addend.Y, this.Z + addend.Z);

    /// <summary>
    /// Subtract a vector with this.
    /// </summary>
    /// <param name="subtrahend">The vector to subtract</param>
    /// <returns>A new difference vector</returns>
    [Pure]
    public readonly Vector3d Subtract(Vector3d subtrahend) => new(this.X - subtrahend.X, this.Y - subtrahend.Y, this.Z - subtrahend.Z);

    /// <summary>
    /// Inverses the direction of the vector, equivalent to multiplying by -1
    /// </summary>
    /// <returns>A <see cref="Vector3d"/> pointing in the opposite direction.</returns>
    [Pure]
    public readonly Vector3d Negate() => new(-1 * this.X, -1 * this.Y, -1 * this.Z);

    /// <summary>
    /// Scales a vector by a factor, in other words multiplies the vector by a scalar value
    /// </summary>
    /// <param name="factor"></param>
    /// <returns>A new scaled vector</returns>
    [Pure]
    public readonly Vector3d Scale(double factor) => new(factor * this.X, factor * this.Y, factor * this.Z);

    /// <summary>
    /// Returns the dot product of two vectors.
    /// </summary>
    /// <param name="v">The second vector.</param>
    /// <returns>The dot product.</returns>
    [Pure]
    public readonly double DotProduct(Vector3d v) => (this.X * v.X) + (this.Y * v.Y) + (this.Z * v.Z);

    /// <summary>
    /// Returns the cross product of this vector and <paramref name="other"/>
    /// </summary>
    /// <param name="other">A vector</param>
    /// <returns>A new vector with the cross product result</returns>
    [Pure]
    public readonly Vector3d CrossProduct(Vector3d other)
    {
        double xx = (this.Y * other.Z) - (this.Z * other.Y);
        double yy = (this.Z * other.X) - (this.X * other.Z);
        double zz = (this.X * other.Y) - (this.Y * other.X);
        return new(xx, yy, zz);
    }

    #endregion

    #region HashCode
    /// <inheritdoc />
    [Pure]
    public override readonly int GetHashCode()
    {
        unchecked // Overflow is fine, just wrap
        {
            int hash = 103841;
            // Suitable nullity checks etc, of course :)
            hash = hash * 49627 + X.GetHashCode();
            hash = hash * 49627 + Y.GetHashCode();
            hash = hash * 49627 + Z.GetHashCode();
            return hash;
        }
    }
    #endregion

    #region Operators
    /// <summary>
    /// Adds two vectors
    /// </summary>
    /// <param name="left">The first vector</param>
    /// <param name="right">The second vector</param>
    /// <returns>A new summed vector</returns>
    [Pure]
    public static Vector3d operator + (Vector3d left, Vector3d right) => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    /// <summary>
    /// Subtracts two vectors
    /// </summary>
    /// <param name="left">The first vector</param>
    /// <param name="right">The second vector</param>
    /// <returns>A new difference vector</returns>
    [Pure]
    public static Vector3d operator - (Vector3d left, Vector3d right) => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    #endregion
}
