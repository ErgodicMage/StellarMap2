using System.Diagnostics.CodeAnalysis;

namespace StellarMap.Components.Core;

public class Planet : IStellarObject, IEqualityComparer<Star>
{
    public string Identifier { get; set; } = string.Empty;
    public string ParentIdentifier { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ObjectType { get; set; } = string.Empty;
    public StellarObjectProperties StellarObjectProperties { get; set; }

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

    public int GetHashCode([DisallowNull] Star obj)
    {
        throw new NotImplementedException();
    }
    #endregion

}
