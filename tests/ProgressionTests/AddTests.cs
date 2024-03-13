namespace ProgressionTests;

public class AddTests
{
    [Fact]
    public void AddHabitattoPlanet()
    {
        var list = ProgressionObjectType.List;

        ProgressionMap map = new("Add Habitat to Planet");

        var identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(ProgressionObjectType.Habitat, map);
        Habitat habitat = new("ISS", identifier, map);
        Assert.NotNull(habitat);

        identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Satelite, map);
        Satelite satelite = new("Moon", identifier, map);

        identifier = ProgressionMapIdentifierGenerator.Instance.GenerateIdentifier(ProgressionObjectType.ProgressionPlanet, map);
        ProgressionPlanet planet = new("Earth", identifier, map);
        Assert.NotNull(planet);

        planet.AddSatelite(satelite);
        planet.AddHabitat(habitat);
    }
}