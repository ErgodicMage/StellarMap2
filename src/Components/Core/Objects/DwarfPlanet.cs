namespace StellarMap.Core;

public class DwarfPlanet : StellarObject
{
    #region Properties
    public Dictionary<string, Identifier>? Satelites { get; set; }
    #endregion

    #region Constructors
    public DwarfPlanet() { }

    public DwarfPlanet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.DwarfPlanet) { }
    #endregion

    #region Get
    public Result<Satelite> GetSatelite(Identifier identifier) => Get<Satelite>(identifier);

    protected override Result<IDictionary<string, Identifier>> GetIdentifiers<T>()
    {
        if (typeof(T).Name == nameof(Satelite) && Satelites is not null)
            return Satelites;
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
}
