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
        => GetStar(identifier).Convert<ProgressionStar, Star>();

    public Result<ProgressionStar> GetProgressionStar(string name)
        => GetStar(name).Convert<ProgressionStar, Star>();

    protected override Result<Dictionary<string, Identifier>> GetIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success)
            return Result.Error(foundObjectType.ErrorMessage);

        return foundObjectType.Value.Name switch
        {
            ProgressionObjectType.PROGRESSIONSTAR => base.GetIdentifiers<Star>(),
            _ => Result.Error($"{foundObjectType.Value.Name} is not part of the star system {Name}")
        };
    }
    #endregion

    #region Add
    public Result Add(ProgressionStar star) => Add<ProgressionStar>(star);
    public Result AddProgressionStar(ProgressionStar star) => Add<ProgressionStar>(star);

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (!foundObjectType.Success) return;

        switch (foundObjectType.Value.Name)
        {
            case ProgressionObjectType.PROGRESSIONSTAR: base.CreateIdentifiers<Star>(); break;
            default: base.CreateIdentifiers<T>(); break;
        };
    }
    #endregion
}
