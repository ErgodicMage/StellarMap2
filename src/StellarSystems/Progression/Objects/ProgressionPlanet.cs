namespace StellarMap.Progression;

public class ProgressionPlanet : Planet
{
    #region Properties
    [JsonPropertyOrder(101)]
    public Dictionary<string, Identifier>? Habitats { get; set; }
    #endregion

    #region Constructors
    public ProgressionPlanet() { }

    public ProgressionPlanet(string name, Identifier identifier, IStellarMap map)
        : base(name, identifier, map)
        => ObjectType = ProgressionObjectType.ProgressionPlanet;
    #endregion

    #region Get
    public Result<ProgressionSatelite> GetProgressionSatelite(Identifier identifier)
        => GetSatelite(identifier).Convert<ProgressionSatelite, Satelite>();
    public Result<ProgressionSatelite> GetProgressionSatelite(string name)
        => GetSatelite(name).Convert<ProgressionSatelite, Satelite>();

    public Result<Habitat> GetHabitat(Identifier identifier) => Get<Habitat>(identifier);
    public Result<Habitat> GetHabitat(string name) => Get<Habitat>(name);

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Habitat) && Habitats is not null)
            return Habitats!;
        return base.GetIdentifiers<T>();
    }
    #endregion

    #region Add
    public Result Add(Habitat habitat) => Add<Habitat>(habitat);
    public Result AddHabitat(Habitat habitat) => Add<Habitat>(habitat);

    protected override void CreateIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Habitat))
            Habitats ??= new();
        else
            base.CreateIdentifiers<T>();
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(ProgressionPlanet? x, ProgressionPlanet? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;
        return CommonFunctionality.CompareDictionaries(x.Habitats, y.Habitats);
    }

    public override bool Equals(object? obj) => Equals(this, obj as ProgressionPlanet);

    public int GetHashCode(ProgressionPlanet obj) => HashCode.Combine(base.GetHashCode(obj), obj.Habitats);

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
