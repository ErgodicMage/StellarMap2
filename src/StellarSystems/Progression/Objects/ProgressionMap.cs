using System.Xml.Linq;

namespace StellarMap.Progression;

public class ProgressionMap : StandardStellarMap, IProgressionMap
{
    [JsonPropertyOrder(11)]
    public Dictionary<string, Habitat>? Habitats { get; set; }

    #region Constructors
    public ProgressionMap() { }

    public ProgressionMap(string name)
    {
        Name = name;
        MetaData = new();
    }
    #endregion

    #region Dictionary
    protected override void CreateDictionary<T>()
    {
        var list = ProgressionObjectType.List;
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null) return;

        foundObjectType
            .When(ProgressionObjectType.ProgressionStarSystem).Then(() => base.CreateDictionary<StarSystem>())
            .When(ProgressionObjectType.ProgressionStar).Then(() => base.CreateDictionary<Star>())
            .When(ProgressionObjectType.ProgressionPlanet).Then(() => base.CreateDictionary<Planet>())
            .When(ProgressionObjectType.ProgressionSatelite).Then(() => base.CreateDictionary<Satelite>())
            .When(ProgressionObjectType.ProgressionAsteroid).Then(() => base.CreateDictionary<Asteroid>())
            .Default(() => base.CreateDictionary<T>());
    }

    protected override Result<Dictionary<string, T>> GetDictionary<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(typeof(T).Name);
        if (foundObjectType is null)
            return Result.Error($"Can not find ProgressionObjectTypr for {nameof(T)}");

        Dictionary<string, T>? dictionary = null;
        foundObjectType
                .When(ProgressionObjectType.ProgressionStarSystem)
                    .Then(() => dictionary = base.GetDictionary<StarSystem>().Value as Dictionary<string, T>)
                .When(ProgressionObjectType.ProgressionStar)
                    .Then(() => dictionary = base.GetDictionary<Star>().Value as Dictionary<string, T>)
                .When(ProgressionObjectType.ProgressionPlanet)
                    .Then(() => dictionary = base.GetDictionary<Planet>().Value as Dictionary<string, T>)
                .When(ProgressionObjectType.ProgressionSatelite)
                    .Then(() => dictionary = base.GetDictionary<Satelite>().Value as Dictionary<string, T>)
                .When(ProgressionObjectType.ProgressionAsteroid)
                    .Then(() => dictionary = base.GetDictionary<Asteroid>().Value as Dictionary<string, T>)
                .Default(() => dictionary = base.GetDictionary<T>());

        return dictionary!;
    }
    #endregion
}
