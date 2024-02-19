namespace StellarMap.Core;

public class DwarfPlanet : BaseStellarObject
{
    public DwarfPlanet() { }

    public DwarfPlanet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.DwarfPlanet) { }
}
