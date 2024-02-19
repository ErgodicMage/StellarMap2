namespace StellarMap.Core;

public class Star : BaseStellarObject, IStellarObject, IEqualityComparer<Star>
{
    #region Properties
    public List<Identifier>? PlanetIdentifiers {get; set; }

    #endregion

    #region Constructors
    public Star() { }

    public Star(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map) { }
    #endregion

    #region Add Functions
    public override Result Add<T>(T obj)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Get Functions
    public override Result<T> Get<T>(string identifier)
    {
        throw new NotImplementedException();
    }

    public override Result<T> GetByName<T>(string name)
    { 
        throw new NotImplementedException(); 
    }

    public override Result<T> GetAll<T>()
    {
        throw new NotImplementedException();
    }
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
