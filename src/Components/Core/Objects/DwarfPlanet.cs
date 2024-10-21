using System.Text.Json.Serialization;

namespace StellarMap.Core;

public class DwarfPlanet : StellarObject, IStellarObject, IEqualityComparer<DwarfPlanet>
{
    #region Properties
    [JsonPropertyOrder(11)]
    public Dictionary<string, Identifier>? Satelites { get; set; }
    #endregion

    #region Constructors
    public DwarfPlanet() { }

    public DwarfPlanet(string name, Identifier identifier, IStellarMap map)
        : base(name, identifier, map, StellarObjectType.DwarfPlanet)
    { }
    #endregion

    #region Get
    public Result<Satelite> GetSatelite(Identifier identifier) => Get<Satelite>(identifier);
    public Result<Satelite> GetSatelite(string name) => Get<Satelite>(name);

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return Result.Error(foundObjectType.ErrorMessage);

        return foundObjectType.Value.Name switch
        {
            StellarObjectType.SATELITE => Satelites!,
            _ => Result.Error($"{foundObjectType.Value.Name} is not part of the dwarf planet {Name}")
        };
    }

    #endregion

    #region Add
    public Result Add(Satelite satelite) => Add<Satelite>(satelite);
    public Result AddSatelite(Satelite satelite) => Add<Satelite>(satelite);

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            Result.Error(foundObjectType.ErrorMessage);

        _ = foundObjectType.Value.Name switch
        {
            StellarObjectType.SATELITE => Satelites ??= new()
        };
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(DwarfPlanet? x, DwarfPlanet? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;
        return CommonFunctionality.CompareDictionaries(x.Satelites, y.Satelites);
    }

    public override bool Equals(object? obj) => Equals(this, obj as DwarfPlanet);

    public int GetHashCode(DwarfPlanet obj) => HashCode.Combine(base.GetHashCode(obj), obj.Satelites);

    public override int GetHashCode() => GetHashCode(this);
    #endregion

}
