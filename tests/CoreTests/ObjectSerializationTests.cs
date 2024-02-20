using System.Text.Json;

namespace CoreTests;

public class ObjectSerializationTests
{
    [Fact]
    public void EarthJsonSerialization()
    {
        StellarMap.Core.StellarMap map = new();
        map.Name = "Earth";

        var Earth = CreateEarth(map);
        var json = JsonSerializer.Serialize<Planet>(Earth);
        Assert.NotEmpty(json);
    }

    [Fact]
    public void EarthJsonSerializationDeserialization()
    {
        StellarMap.Core.StellarMap map = new();
        map.Name = "Earth";
        var Earth = CreateEarth(map);
        var json = JsonSerializer.Serialize<Planet>(Earth);
        Assert.NotEmpty(json);

        var newEarth = JsonSerializer.Deserialize<Planet>(json);
        Assert.NotNull(newEarth);
        Assert.Equal(Earth, newEarth);
    }

    private Planet CreateEarth(IStellarMap map)
    {
        Planet Earth = new()
        {
            Name = "Earth",
            Identifier = MapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Planet, map),
            Map = map,
            Description = "Home of Humans",
            Designation = "SOL-3"
        };
        map.Add<Planet>(Earth);
        
        Satelite Moon = new()
        {
            Name = "Moon",
            Identifier = MapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Satelite, map),
            Map = map,
            AlternativeName = "Luna",
            Description = "Earth's moon",
            Designation = "Earth-1"
        };
        Earth.Add(Moon);

        return Earth;
    }
}