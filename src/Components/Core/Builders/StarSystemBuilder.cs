namespace StellarMap.Core;

public class StarSystemBuilder
{
    public Result _result = Result.Ok();
    public StarSystem _starsystem;

    public static StarSystemBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        StarSystemBuilder starsystemBuilder = new();
        starsystemBuilder._starsystem = new(name, identifier, map);
        return starsystemBuilder;
    }

    public static StarSystemBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        StarSystemBuilder starsystemBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(StellarObjectType.StarSystem, map);
        starsystemBuilder._starsystem = new(name, identifier, map);
        return starsystemBuilder;
    }

    public Result<StarSystem> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<StarSystem>(_starsystem);
    }

    public StarSystemBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_starsystem, name, value);
        return this;
    }

    public StarSystemBuilder WithDescription(string description)
        => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public StarSystemBuilder AddStar(Star star)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Star>(_starsystem, star);
        return this;
    }

    public StarSystemBuilder AddStars(ICollection<Star> stars)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(stars);
        if (!_result.Success) return this;

        foreach (var star in stars)
        {
            _result = BuilderCommonFunctionality.Add<Star>(_starsystem, star);
            if (!_result.Success) return this;
        }

        return this;
    }
}
