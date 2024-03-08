using System.Text.Json.Serialization;

namespace StellarMap.Core;

public class StarSystem : StellarObject, IStellarObject, IEqualityComparer<StarSystem>
{
    #region Properties
    [JsonPropertyOrder(11)]
    public Dictionary<string, Identifier>? Stars { get; set; }
    #endregion

    #region Constructors
    public StarSystem() { }

    public StarSystem(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.StarSystem) { }
    #endregion

    #region Get
    public Result<Star> GetStar(Identifier identifier) => Get<Star>(identifier);
    public Result<Star> GetStar(string name) => Get<Star>(name);

    protected override Result<IDictionary<string, Identifier>> GetIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Star) && Stars is not null)
            return Stars!;
        return Result.Error(string.Empty);
    }
    #endregion

    #region Add
    public Result Add(Star star) => Add<Star>(star);
    public Result AddStar(Star star) => Add<Star>(star);

    protected override void CreateIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Star))
            Stars ??= new();
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(StarSystem? x, StarSystem? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;
        return CommonFunctionality.CompareDictionaries(x.Stars, y.Stars);
    }

    public override bool Equals(object? obj) => Equals(this, obj as StarSystem);

    public int GetHashCode(StarSystem obj) => HashCode.Combine(base.GetHashCode(obj), obj.Stars);

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
