using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreTests;

public class ObjectSerializationTests
{
    [Fact]
    public void EarthJsonSerialization()
    {
        StandardStellarMap map = new()
        {
            Name = "Earth",
        };

        var earth = Builders.BuildEarth(map);
        Assert.NotNull(earth);

        var jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        
        var json = JsonSerializer.Serialize<Planet>(earth, jsonOptions);
        Assert.NotNull(json);
        Assert.False(string.IsNullOrEmpty(json));
    }

    [Fact]
    public void EarthJsonSerializationDeserialization()
    {
        StandardStellarMap map = new()
        {
            Name = "Earth",
        };

        var earth = Builders.BuildEarth(map);
        Assert.NotNull(earth);

        var jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize<Planet>(earth, jsonOptions);
        Assert.NotNull(json);
        Assert.False(string.IsNullOrEmpty(json));

        var newEarth = JsonSerializer.Deserialize<Planet>(json, jsonOptions);
        Assert.NotNull(newEarth);
        //Assert.Equal(Earth, newEarth);
    }

    [Fact]
    public void MapSerialization()
    {
        StandardStellarMap map = new()
        {
            Name = "Solar System",
        };

        var sol = Builders.BuildSol(map);
        Assert.NotNull(sol);
        var jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize<IStellarMap>(map, jsonOptions);
        Assert.NotNull(json);
        Assert.False(string.IsNullOrEmpty(json));

        var newMap = JsonSerializer.Deserialize<StandardStellarMap>(json, jsonOptions);
        Assert.NotNull(newMap);
    }
}