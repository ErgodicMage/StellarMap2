namespace StellarMap.Core;

public class Planet : BaseStellarObject, IStellarObject, IEqualityComparer<Planet>
{
    #region Constructors
    public Planet() { }

    public Planet(StellarObjectProperties properties) 
        => StellarObjectProperties = properties with { ObjectType = StellarObjectTypes.Planet };

    public Planet(StellarObjectProperties properties, Identifier identifier)
    {
        StellarObjectProperties = properties with { ObjectType = StellarObjectTypes.Planet };
        Identifier = identifier;
    }

    public Planet(StellarObjectProperties properties, IIdentifierGenerator identifierGenerator)
    {
        StellarObjectProperties = properties with { ObjectType = StellarObjectTypes.Planet };
        Identifier = identifierGenerator.GenerateIdentifier(StellarObjectTypes.Planet);
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
