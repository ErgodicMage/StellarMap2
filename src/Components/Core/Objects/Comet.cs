namespace StellarMap.Core;

public class Comet : StellarObject
{
    public Comet() { }

    public Comet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Satelite) { }
}
