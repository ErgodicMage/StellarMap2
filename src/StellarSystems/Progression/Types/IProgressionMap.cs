namespace StellarMap.Progression;

public interface IProgressionMap : IStellarMap
{
    Dictionary<string, Habitat> Habitats { get; set; }
}
