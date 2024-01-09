using System.Text.Json;

namespace CoreTests;

public class ObjectSerializationTests
{
    [Fact]
    public void EarthJsonSerialization()
    {
        var Earth = CreateEarth();
        var json = JsonSerializer.Serialize<Planet>(Earth);
        Assert.NotEmpty(json);
    }

    [Fact]
    public void EarthJsonSerializationDeserialization()
    {
        var Earth = CreateEarth();
        var json = JsonSerializer.Serialize<Planet>(Earth);
        Assert.NotEmpty(json);

        var newEarth = JsonSerializer.Deserialize<Planet>(json);
        Assert.NotNull(newEarth);
        Assert.Equal(Earth, newEarth);
    }

    private Planet CreateEarth()
    {
        StellarObjectProperties properties = new()
        {
            Name = "Earth",
            Description = "Home of Humans",
            Designation = "SOL-3"
        };
        Planet Earth = new(properties, DefaultIdentifierGenerator.Instance);

        return Earth;
    }
}