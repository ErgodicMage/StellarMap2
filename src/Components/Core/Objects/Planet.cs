namespace StellarMap.Core;

public class Planet : BaseStellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Constructors
    public Planet() { }

    public Planet(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map) { }
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
    public bool Equals(Planet? x, Planet? y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode(Planet obj)
    {
        throw new NotImplementedException();
    }
    #endregion

}
