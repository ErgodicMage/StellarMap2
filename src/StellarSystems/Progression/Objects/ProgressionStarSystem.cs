namespace StellarMap.Progression;

public class ProgressionStarSystem : StarSystem
{
    #region Constructors
    public ProgressionStarSystem() { }

    public ProgressionStarSystem(string name, Identifier identifier, IStellarMap map)
        : base(name, identifier, map)
        => ObjectType = ProgressionObjectType.ProgressionStarSystem;
    #endregion

    #region Get
    public Result<ProgressionStar> GetProgressionStar(Identifier identifier)
    {
        var result = Get<Star>(identifier);
        if (!result.Success) return Result.Error(result.ErrorMessage);
        var star = result.Value as ProgressionStar;
        return star is not null ? star : Result.Error("Star is not a ProgressionStar");
    }

    public Result<ProgressionStar> GetProgressionStar(string name)
    {
        var result = Get<Star>(name);
        if (!result.Success) return Result.Error(result.ErrorMessage);
        var star = result.Value as ProgressionStar;
        return star is not null ? star : Result.Error("Star is not a ProgressionStar");
    }

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null)
            return Result.Error($"Can not find StellarObjectType for {nameof(T)}");

        Dictionary<string, Identifier>? dictionary = null;
        foundObjectType
                .When(ProgressionObjectType.ProgressionStar).Then(() => dictionary = base.GetIdentifiers<Star>())
                .Default(() => base.GetIdentifiers<T>());

        return dictionary!;
    }
    #endregion

    #region Add
    public Result Add(ProgressionStar star) => Add<ProgressionStar>(star);
    public Result AddProgressionStar(ProgressionStar star) => Add<ProgressionStar>(star);

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null) return;

        foundObjectType
            .When(ProgressionObjectType.ProgressionStar).Then(() => base.CreateIdentifiers<Star>())
            .Default(() => base.CreateIdentifiers<T>());
    }
    #endregion
}
