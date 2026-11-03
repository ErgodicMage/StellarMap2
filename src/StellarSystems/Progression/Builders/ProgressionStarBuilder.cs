namespace StellarMap.Progression;

public class ProgressionStarBuilder
{
    protected Result _result = Result.Ok();
    protected ProgressionStar? _star;

    public static ProgressionStarBuilder Create(string name, Identifier identifier, IStellarMap map)
    {
        ProgressionStarBuilder starBuilder = new();
        starBuilder._star = new ProgressionStar(name, identifier, map);
        return starBuilder;
    }

    public static ProgressionStarBuilder Create(string name, IIdentifierGenerator generator, IStellarMap map)
    {
        ProgressionStarBuilder starBuilder = new();
        Identifier identifier = generator.GenerateIdentifier(ProgressionObjectType.ProgressionStar, map);
        starBuilder._star = new ProgressionStar(name, identifier, map);
        return starBuilder;
    }

    public Result<ProgressionStar> Build()
    {
        if (!_result.Success) return _result;
        return BuilderCommonFunctionality.Build<ProgressionStar>(_star as ProgressionStar);
    }

    public ProgressionStarBuilder WithProperty(string name, string value)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.AddToProperties(_star, name, value);
        return this;
    }

    public ProgressionStarBuilder WithDescription(string description)
        => WithProperty(PropertiesConstant.DESCRIPTION, description);

    public ProgressionStarBuilder AsStellarClass(string stellarClass)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_star).NullOrWhiteSpace(stellarClass);
        if (!_result) return this;
        _star!.StellarClass = stellarClass;
        return this;
    }

    public ProgressionStarBuilder AddPhysicalProperties(PhysicalProperties properties)
    {
        if (!_result.Success) return this;
        _result = GuardClause.Null(_star).Null(properties);
        if (!_result.Success) return this;
        _star!.PhysicalProperties = properties;
        return this;
    }

    public ProgressionStarBuilder AddPlanet(ProgressionPlanet? planet)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<ProgressionPlanet>(_star, planet);
        return this;
    }

    public ProgressionStarBuilder AddPlanets(ICollection<ProgressionPlanet> planets)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<ProgressionPlanet>(_star, planets);
        return this;
    }

    public ProgressionStarBuilder AddAsteroid(ProgressionAsteroid? asteroid)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<ProgressionAsteroid>(_star, asteroid);
        return this;
    }

    public ProgressionStarBuilder AddAsteroids(ICollection<ProgressionAsteroid> asteroids)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<ProgressionAsteroid>(_star, asteroids);
        return this;
    }

    public ProgressionStarBuilder AddComet(Comet? comet)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Comet>(_star, comet);
        return this;
    }

    public ProgressionStarBuilder AddComets(ICollection<Comet> comets)
    {
        if (!_result.Success) return this;
        _result = BuilderCommonFunctionality.Add<Comet>(_star, comets);
        return this;
    }
}
