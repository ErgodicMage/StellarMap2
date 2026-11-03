using StellarMap.Core;

namespace StellarMap.ProgressionStellarBuilder;

public static class PhysicaConverters
{
    public static Result<ProgressionAsteroid> Convert(IProgressionMap map, Asteroid a, string name, ProgressionStar star,
        IIdentifierGenerator? identifierGenerator = null)
    {
        identifierGenerator ??= ProgressionMapIdentifierGenerator.Instance;
        ProgressionAsteroid asteroid = new(a.Name!, identifierGenerator.GenerateIdentifier(ProgressionObjectType.ProgressionAsteroid, map),
            map)
        {
            Name = string.IsNullOrEmpty(name) ? a.Name : name,
            ParentIdentifier = star.Identifier,
            Properties = new (a.Properties),
            PhysicalProperties = a.PhysicalProperties,
        };
        return asteroid;
    }

    public static Result<ProgressionSatelite> Convert(IProgressionMap map, Satelite s, string name, ProgressionPlanet planet,
        IIdentifierGenerator? identifierGenerator = null)
    {
        identifierGenerator ??= ProgressionMapIdentifierGenerator.Instance;
        ProgressionSatelite satelite = new(s.Name!, identifierGenerator.GenerateIdentifier(ProgressionObjectType.ProgressionSatelite, map),
            map)
        {
            Name = string.IsNullOrEmpty(name) ? s.Name : name,
            ParentIdentifier = planet.Identifier,
            ObjectType = ProgressionObjectType.ProgressionSatelite,
            Properties = new(s.Properties),
            PhysicalProperties = s.PhysicalProperties,
        };
        return satelite;
    }

    public static Result<ProgressionPlanet> Convert(IProgressionMap map, Planet p, string name, ProgressionStar star,
        IIdentifierGenerator? identifierGenerator = null)
    {
        identifierGenerator ??= ProgressionMapIdentifierGenerator.Instance;
        ProgressionPlanet planet = new(p.Name!, identifierGenerator.GenerateIdentifier(ProgressionObjectType.ProgressionPlanet, map),
            map)
        {
            Name = string.IsNullOrEmpty(name) ? p.Name : name,
            ParentIdentifier = star.Identifier,
            ObjectType = ProgressionObjectType.ProgressionPlanet,
            Properties = new (p.Properties),
            PhysicalProperties = p.PhysicalProperties,
        };

        if (p.Satelites is not null)
        {
            foreach (var satelite in p.Satelites)
            {
                var sateliteResult = map.Get<ProgressionSatelite>(satelite.Value);
                if (!sateliteResult.Success)
                    return Result.Error(sateliteResult.ErrorMessage);
                var convertedSatelite = Convert(map, sateliteResult.Value, satelite.Key, planet, identifierGenerator);
                if (!convertedSatelite.Success)
                    return Result.Error(convertedSatelite.ErrorMessage);
                Result addResult = planet.Add(convertedSatelite.Value);
                if (!addResult.Success)
                    return Result.Error(addResult.ErrorMessage);
            }
        }
        return planet;
    }

    public static Result<ProgressionStar> Convert(IProgressionMap map, Star s, string name, ProgressionStarSystem starSystem,
        IIdentifierGenerator? identifierGenerator = null)
    {
        identifierGenerator ??= ProgressionMapIdentifierGenerator.Instance;
        ProgressionStar star = new(s.Name!, identifierGenerator.GenerateIdentifier(ProgressionObjectType.ProgressionStar, map),
            map)
        {
            Name = string.IsNullOrEmpty(name) ? s.Name : name,
            ParentIdentifier = starSystem is null ? Identifier.NoIdentifier : starSystem.Identifier,
            ObjectType = ProgressionObjectType.ProgressionStar,
            Properties = s.Properties,
            PhysicalProperties = s.PhysicalProperties,
        };

        if (s.Planets is not null)
        {
            foreach (var planet in s.Planets)
            {
                var planetResult = map.Get<ProgressionPlanet>(planet.Value);
                if (!planetResult.Success)
                    return Result.Error(planetResult.ErrorMessage);
                var convertedPlanet = Convert(map, planetResult.Value, planet.Key, star, identifierGenerator);
                if (!convertedPlanet.Success)
                    return Result.Error(convertedPlanet.ErrorMessage);
                Result addResult = star.Add(convertedPlanet.Value);
                if (!addResult.Success)
                    return Result.Error(addResult.ErrorMessage);
            }
        }
        return star;
    }

    public static Result<ProgressionStarSystem> Convert(IProgressionMap map, StarSystem s, string name,
        IIdentifierGenerator? identifierGenerator = null)
    {
        identifierGenerator ??= ProgressionMapIdentifierGenerator.Instance;
        ProgressionStarSystem starSystem = new(s.Name!, identifierGenerator.GenerateIdentifier(ProgressionObjectType.ProgressionStar, map),
            map)
        {
            Name = name,
            ObjectType = ProgressionObjectType.ProgressionStar,
            ParentIdentifier = Identifier.NoIdentifier,
            Properties = s.Properties,
            PhysicalProperties = s.PhysicalProperties,
        };

        if (s.Stars is not null)
        {
            foreach (var star in s.Stars)
            {
                var starResult = map.Get<ProgressionStar>(star.Value);
                if (!starResult.Success)
                    return Result.Error(starResult.ErrorMessage);
                var convertedPlanet = Convert(map, starResult.Value, star.Key, null!, identifierGenerator);
                if (!convertedPlanet.Success)
                    return Result.Error(convertedPlanet.ErrorMessage);
                Result addResult = starSystem.Add(convertedPlanet.Value);
                if (!addResult.Success)
                    return Result.Error(addResult.ErrorMessage);
            }
        }
        return starSystem;
    }
}
