namespace StellarMap.Core;

public class Asteroid : BaseStellarObject
{
    public Asteroid() { }

    public Asteroid(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Asteroid) { }

}
