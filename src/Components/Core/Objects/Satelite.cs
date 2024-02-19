namespace StellarMap.Core;

public class Satelite : BaseStellarObject
{
    #region Constructors
    public Satelite() { }

    public Satelite(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Satelite) 
    {
        ObjectType = StellarObjectType.Satelite;
    }
    #endregion
}
