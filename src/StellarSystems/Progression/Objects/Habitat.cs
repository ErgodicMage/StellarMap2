namespace StellarMap.Progression;

public class Habitat : StellarObject
{
    public Habitat() { }

    public Habitat(string name, Identifier identifier, IProgressionMap map) : 
        base(name, identifier, map, ProgressionObjectType.Habitat) { }
}
