namespace StellarMap.Core;

public class Planet : StellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Properties
    public Dictionary<string, Identifier>? Satelites { get; set; }
    #endregion

    #region Constructors
    public Planet() { }

    public Planet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Planet) { }
    #endregion

    #region Get
    public Result<Satelite> GetSatelite(Identifier identifier) => Get<Satelite>(identifier);

    protected override Result<IReadOnlyDictionary<string, Identifier>> GetIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Satelite) && Satelites is not null)
            return Satelites!.AsReadOnly();
        return Result.Error(string.Empty);
    }

    #endregion

    #region Add
    public Result Add(Satelite satelite) => Add<Satelite>(satelite);
    public Result AddSatelite(Satelite satelite) => Add<Satelite>(satelite);
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(Planet? x, Planet? y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode(Planet obj)
    {
        throw new NotImplementedException();
    }
    #endregion

}
