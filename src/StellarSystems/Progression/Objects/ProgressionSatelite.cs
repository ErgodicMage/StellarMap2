namespace StellarMap.Progression;

public class ProgressionSatelite : Satelite
{
    #region Properties
    [JsonPropertyOrder(101)]
    public Dictionary<string, Identifier>? Habitats { get; set; }
    #endregion

    #region Constructors
    public ProgressionSatelite() { }

    public ProgressionSatelite(string name, Identifier identifier, IStellarMap map)
        : base(name, identifier, map)
        => ObjectType = ProgressionObjectType.ProgressionSatelite;
    #endregion

    #region Get
    public Result<Habitat> GetHabitat(Identifier identifier) => Get<Habitat>(identifier);
    public Result<Habitat> GetHabitat(string name) => Get<Habitat>(name);

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return Result.Error(foundObjectType.ErrorMessage);

        return foundObjectType.Value.Name switch
        {
            ProgressionObjectType.HABITAT => Habitats!,
            _ => Result.Error($"{foundObjectType.Value.Name} is not part of the satellite {Name}")
        };
    }
    #endregion

    #region Add
    public Result Add(Habitat habitat) => Add<Habitat>(habitat);
    public Result AddHabitat(Habitat habitat) => Add<Habitat>(habitat);

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = StellarObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return;

        if (foundObjectType.Value.Name == ProgressionObjectType.HABITAT)
            Habitats ??= new();
        else
            base.CreateIdentifiers<T>();
    }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(ProgressionSatelite? x, ProgressionSatelite? y)
    {
        if (x is null || y is null) return false;
        if (ReferenceEquals(x, y)) return true;
        if (!base.Equals(x, y)) return false;
        return CommonFunctionality.CompareDictionaries(x.Habitats, y.Habitats);
    }

    public override bool Equals(object? obj) => Equals(this, obj as ProgressionPlanet);

    public int GetHashCode(ProgressionSatelite obj) => HashCode.Combine(base.GetHashCode(obj), obj.Habitats);

    public override int GetHashCode() => GetHashCode(this);
    #endregion
}
