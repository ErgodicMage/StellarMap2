namespace StellarMap.Core;

public class DwarfPlanet : BaseStellarObject
{
    #region Properties
    public IList<Identifier>? SateliteIdentifiers { get; set; }
    #endregion

    #region Constructors
    public DwarfPlanet() { }

    public DwarfPlanet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.DwarfPlanet) { }
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
}
