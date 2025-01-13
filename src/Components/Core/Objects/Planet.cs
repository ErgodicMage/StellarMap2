using System.Numerics;
using System.Text.Json.Serialization;

namespace StellarMap.Core;

public class Planet : StellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Properties
    [JsonPropertyOrder(11)]
    public Dictionary<string, Identifier>? Satelites { get; set; }    
    #endregion

    #region Constructors
    public Planet() { }

    public Planet(string name, Identifier identifier, IStellarMap map) 
        : base(name, identifier, map, StellarObjectType.Planet) 
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
            _ => Result.Error($"{foundObjectType.Value.Name} is not part of the planet {Name}")
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
            StellarObjectType.SATELITE => Satelites ??= new(),
            _ => null as Dictionary<string, Identifier>

        };
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(Planet? x, Planet? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;
        return CommonFunctionality.CompareDictionaries(x.Satelites, y.Satelites);
    }

    public override bool Equals(object? obj) => Equals(this, obj as Planet);

    public int GetHashCode(Planet obj) => HashCode.Combine(base.GetHashCode(obj), obj.Satelites);

    public override int GetHashCode() => GetHashCode(this);
    #endregion

}
