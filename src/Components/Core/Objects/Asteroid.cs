
namespace StellarMap.Core;

public class Asteroid : StellarObject
{
    public Asteroid() { }

    public Asteroid(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Asteroid) { }
}
