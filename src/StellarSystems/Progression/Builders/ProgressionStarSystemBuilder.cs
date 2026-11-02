namespace StellarMap.Progression;

public class ProgressionStarSystemBuilder
{
    public Result _result = Result.Ok();
    public ProgressionStarSystem? _starsystem;

    public static ProgressionStarSystemBuilder Create(string name, Identifier identifier, IProgressionMap map)
    {
        ProgressionStarSystemBuilder starsystemBuilder = new();
        starsystemBuilder._starsystem = new(name, identifier, map);
        return starsystemBuilder;
    }

    public static ProgressionStarSystemBuilder Create(string name, IIdentifierGenerator generator, IProgressionMap map)
    {
        ProgressionStarSystemBuilder starsystemBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(ProgressionObjectType.ProgressionStarSystem, map);
        starsystemBuilder._starsystem = new(name, identifier, map);
        return starsystemBuilder;
    }

    public Result<ProgressionStarSystem> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<ProgressionStarSystem>(_starsystem);
    }

    public ProgressionStarSystemBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_starsystem, name, value);
        return this;
    }

    public ProgressionStarSystemBuilder WithDescription(string description)
        => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public ProgressionStarSystemBuilder AddStar(ProgressionStar? star)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<ProgressionStar>(_starsystem, star);
        return this;
    }

    public ProgressionStarSystemBuilder AddStars(ICollection<ProgressionStar> stars)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<ProgressionStar>(_starsystem, stars);
        return this;
    }

}
