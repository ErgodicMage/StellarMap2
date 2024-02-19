namespace StellarMap.Core;

public class Planet : BaseStellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Properties
    public IList<Identifier>? SateliteIdentifiers { get; set; }
    #endregion

    #region Constructors
    public Planet() { }

    public Planet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Planet) { }
    #endregion

    #region Add
    public Result Add(Satelite satelite) => AddSatelite(satelite);

    public Result AddSatelite(Satelite satelite)
    {
        var result = GuardClause.Null(Map).Null(satelite);
        if (!result.Success) return result;

        return Map!.Add<Satelite>(satelite);
    }
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
