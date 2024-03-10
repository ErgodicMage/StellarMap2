namespace StellarMap.Progression;

public class Habitat : StellarObject
{
    public Habitat() { }

    public Habitat(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Comet) { }
}
