namespace StellarMap.Core;

public class Star : StellarObject, IStellarObject, IEqualityComparer<Star>
{
    #region Properties
    public List<Identifier>? PlanetIdentifiers {get; set; }

    #endregion

    #region Constructors
    public Star() { }

    public Star(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Star) { }
    #endregion

    #region IEqualityComparer Functions
    public bool Equals(Star? x, Star? y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode(Star obj)
    {
        throw new NotImplementedException();
    }
    #endregion
}
