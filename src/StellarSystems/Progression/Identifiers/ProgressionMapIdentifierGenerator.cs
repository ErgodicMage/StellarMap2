namespace StellarMap.Progression;

public sealed class ProgressionMapIdentifierGenerator
{
    private ProgressionMapIdentifierGenerator() { }

    public static ProgressionMapIdentifierGenerator Instance = new();

    public Identifier GenerateIdentifier(StellarObjectType type, IStellarMap? map = null)
    {
        var progressionMap = map as IProgressionMap;
        var result = GuardClause.Null(map);
        if (!result.Success) return Identifier.NoIdentifier;

        var count = progressionMap!.GetObjectCount(type);
        if (!count.Success) return Identifier.NoIdentifier;

        return new Identifier($"{type.Name}-{count + 1:D5}");
    }
}
