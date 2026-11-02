using System.Diagnostics.CodeAnalysis;

namespace StellarMap.Progression;

public class Portal : IEqualityComparer<Portal>
{
    [JsonPropertyOrder(1)]
    public Identifier StarSystemIdentifier { get; init; }

    [JsonPropertyOrder(2)]
    public Identifier ERBridgeIdentifier { get; set; }

    [JsonPropertyOrder(3)]
    public Point Position { get; init; }

    #region IEqualityComparer Functions
    public bool Equals(Portal? x, Portal? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        return x.StarSystemIdentifier == y.StarSystemIdentifier &&
               x.ERBridgeIdentifier == y.ERBridgeIdentifier &&
               x.Position == y.Position;
    }

    public int GetHashCode([DisallowNull] Portal obj) =>
        HashCode.Combine(obj.StarSystemIdentifier, obj.ERBridgeIdentifier, obj.Position);

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
