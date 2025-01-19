namespace ProgressionTests;

internal static class Builders
{
    public static ProgressionPlanet BuildEarth(IProgressionMap map)
    {
        var identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(ProgressionObjectType.ProgressionPlanet, map);
        ProgressionPlanet planet = new("Earth", identifier, map);
        Assert.NotNull(planet);
        map.Add(planet);

        identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Satelite, map);
        ProgressionSatelite satelite = new("Moon", identifier, map);
        Assert.NotNull(satelite);
        planet.AddSatelite(satelite);

        identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(ProgressionObjectType.Habitat, map);
        Habitat habitat = new("Earth Station 1", identifier, map);
        Assert.NotNull(habitat);
        planet.AddHabitat(habitat);

        identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(ProgressionObjectType.Habitat, map);
        habitat = new("Earth Station 2", identifier, map);
        Assert.NotNull(habitat);
        planet.AddHabitat(habitat);
        return planet;
    }
}
