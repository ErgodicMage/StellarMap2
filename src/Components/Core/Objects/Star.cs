namespace StellarMap.Core;

public class Star : BaseStellarObject, IStellarObject, IEqualityComparer<Star>
{
    #region Constructors
    public Star() { }

    public Star(StellarObjectProperties properties) 
        => StellarObjectProperties = properties with { ObjectType = StellarObjectConstants.Star };

    public Star(StellarObjectProperties properties, Identifier identifier)
    {
        StellarObjectProperties = properties with { ObjectType = StellarObjectConstants.Star };
        Identifier = identifier;
    }

    public Star(StellarObjectProperties properties, IIdentifierGenerator identifierGenerator)
    {
        StellarObjectProperties = properties with { ObjectType = StellarObjectConstants.Star };
        Identifier = identifierGenerator.GenerateIdentifier(StellarObjectConstants.Planet);
    }
    #endregion
    #region Add Functions
    public Result Add<T>(T obj) where T : IStellarObject
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Get Functions
    public Result<T> Get<T>(string identifier) where T : IStellarObject
    {
        throw new NotImplementedException();
    }

    public Result<T> GetByName<T>(string name) where T : IStellarObject
    { 
        throw new NotImplementedException(); 
    }

    public Result<T> GetAll<T>() where T : IStellarObject
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
