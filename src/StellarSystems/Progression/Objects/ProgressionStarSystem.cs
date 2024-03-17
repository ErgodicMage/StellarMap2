using StellarMap.Core;

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
        if (!foundObjectType.Success)
            return Result.Error($"Can not find ProgressionObjectType for {nameof(T)}");

        if (foundObjectType.Value.Name == ProgressionObjectType.STAR)
            return base.GetIdentifiers<Star>();

        return Result.Error(string.Empty); 
    }
    #endregion

    #region Add
    public Result Add(ProgressionStar star) => Add<ProgressionStar>(star);
    public Result AddProgressionStar(ProgressionStar star) => Add<ProgressionStar>(star);

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success) return;

        if (foundObjectType.Value.Name == ProgressionObjectType.STAR)
            base.CreateIdentifiers<Star>();
    }
    #endregion
}
