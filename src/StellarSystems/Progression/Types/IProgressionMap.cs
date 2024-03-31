namespace StellarMap.Progression;

public interface IProgressionMap : IStellarMap
{
    Dictionary<string, Habitat>? Habitats { get; set; }

    Result<ProgressionStarSystem> GetProgressionStarSystem(Identifier identifier);
    Result<ProgressionStar> GetProgressionStar(Identifier identifier);
    Result<ProgressionPlanet> GetProgressionPlanet(Identifier identifier);
    Result<ProgressionSatelite> GetProgressionSatelite(Identifier identifier);
    Result<ProgressionAsteroid> GetProgressionAsteroid(Identifier identifier);
}
