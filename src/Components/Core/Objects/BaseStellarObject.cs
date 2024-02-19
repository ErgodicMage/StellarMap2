
namespace StellarMap.Core;

public abstract class BaseStellarObject : IStellarObject
{
    #region Properties
    public string? Name { get; init; }
    public string? AlternativeName { get; set; }
    public string? Description { get; set; }
    public string? Designation { get; set; }

    public IStellarMap? Map { get; init; }


    public Identifier Identifier { get; init; } = Identifier.NoIdentifier;
    public Identifier ParentIdentifier { get; set; } = Identifier.NoIdentifier;
    public StellarObjectType? ObjectType { get; init;  }
    #endregion
    
    #region Constructors
    public BaseStellarObject() { }

    public BaseStellarObject(string name, Identifier identifier, IStellarMap map)
    {
        Name = name;
        Identifier = identifier;
        Map = map;
    }
    #endregion

    public abstract Result Add<T>(T obj) where T : IStellarObject;

    #region Get Functions
    public abstract Result<T> Get<T>(string identifier) where T : IStellarObject;

    public abstract Result<T> GetByName<T>(string name) where T : IStellarObject;

    public abstract Result<T> GetAll<T>() where T : IStellarObject;
    #endregion
}
