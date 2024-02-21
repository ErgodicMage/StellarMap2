namespace StellarMap.Core;

public class Planet : StellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Properties
    public Dictionary<string, Identifier>? Satelites { get; set; }
    
    public bool IsDwarf {get; set; }
    #endregion

    #region Constructors
    public Planet() { }

    public Planet(string name, Identifier identifier, IStellarMap map, bool isDwarf = false) 
        : base(name, identifier, map, StellarObjectType.Planet) 
    { 
        this.IsDwarf = isDwarf;
    }
    #endregion

    #region Get
    public Result<Satelite> GetSatelite(Identifier identifier) => Get<Satelite>(identifier);

    protected override Result<IDictionary<string, Identifier>> GetIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Satelite) && Satelites is not null)
            return Satelites!;
        return Result.Error(string.Empty);
    }

    #endregion

    #region Add
    public Result Add(Satelite satelite) => Add<Satelite>(satelite);
    public Result AddSatelite(Satelite satelite) => Add<Satelite>(satelite);

    protected override void CreateIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Satelite))
            Satelites ??= new();
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
