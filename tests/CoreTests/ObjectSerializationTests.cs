using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreTests;

public class ObjectSerializationTests
{
    [Fact]
    public void EarthJsonSerialization()
    {
        StellarMap.Core.StellarMap map = new();
        map.Name = "Earth";

        var Earth = CreateEarth(map);

        var jsonOptions = new JsonSerializerOptions()
        {
            //Converters = { new IdentifierJsonConverter() },
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize<Planet>(Earth, jsonOptions);
        Assert.NotEmpty(json);
    }

    [Fact]
    public void EarthJsonSerializationDeserialization()
    {
        StellarMap.Core.StellarMap map = new();
        map.Name = "Earth";
        var Earth = CreateEarth(map);

        var jsonOptions = new JsonSerializerOptions()
        {
            //Converters = { new IdentifierJsonConverter() },
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize<Planet>(Earth, jsonOptions);
        Assert.NotEmpty(json);

        var newEarth = JsonSerializer.Deserialize<Planet>(json, jsonOptions);
        Assert.NotNull(newEarth);
        //Assert.Equal(Earth, newEarth);
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

    public sealed class IdentifierJsonConverter : JsonConverter<Identifier>
    {
        public override Identifier? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? json = reader.GetString();
            return json is null ? null : new Identifier(json);
        }

        public override void Write(Utf8JsonWriter writer, Identifier value, JsonSerializerOptions options)
        {
            writer.WriteString("Identifier", value?.ToString());
        }
    }
}