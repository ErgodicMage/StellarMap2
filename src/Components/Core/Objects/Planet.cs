namespace StellarMap.Core;

public class Planet : StellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Properties
    public List<Identifier>? SateliteIdentifiers { get; set; }
    #endregion

    #region Constructors
    public Planet() { }

    public Planet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Planet) { }
    #endregion

    #region Get
    public Result<Satelite> GetSatelite(Identifier identifier) => Get(identifier);

    public Result<Satelite> Get(Identifier identifier)
    {
        var result = GuardClause.Null(Map).Null(identifier);
        if (!result.Success) return result;

        if (SateliteIdentifiers is null)
            return Result.Error($"No satelites exists for Planet {Name} {Identifier}");
        return Map.Get<Satelite>(identifier);
    }

    public IList<Satelite> GetAllSatelites()
    {
        List<Satelite> satelites = new();

        if (SateliteIdentifiers is null)
            return satelites;

        foreach (var identifier in SateliteIdentifiers)
        {
            Satelite? satelite = Map.Get<Satelite>(identifier);
            if (satelite is not null)
                satelites.Add(satelite);
        }

        return satelites;
    }

    public Result<Satelite> GetSateliteByName(string name)
    {
        var result = GuardClause.Null(Map).NullOrWhiteSpace(name);
        if (!result.Success) return result;

        IList<Satelite> satelites = GetAllSatelites();
        
        var satelite = satelites.FirstOrDefault(s => s.Name == name);

        if (satelite is null)
            return Result.Error($"Satelite {name} not found for Planet {Name} {Identifier}");

        return satelite;
    }
    #endregion

    #region Add
    public Result Add(Satelite satelite) => AddSatelite(satelite);

    public Result AddSatelite(Satelite satelite)
    {
        var result = GuardClause.Null(Map).Null(satelite);
        if (!result.Success) return result;

        if (SateliteIdentifiers is null)
            SateliteIdentifiers = new();

        var exists = SateliteIdentifiers.Any(i => i == satelite.Identifier);

        if (exists)
            return Result.Error($"{satelite.Name} {satelite.Identifier} already exists for Planet {Name} {Identifier}");

        satelite.ParentIdentifier = Identifier;

        result = Map!.Add<Satelite>(satelite);

        if (result)
            SateliteIdentifiers.Add(satelite.Identifier);

        return result;
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
