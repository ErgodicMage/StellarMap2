using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreTests;

public class ObjectSerializationTests
{
    [Fact]
    public void EarthJsonSerialization()
    {
        StandardStellarMap map = new();
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
        StandardStellarMap map = new();
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
        Planet Earth = new("Earth", MapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Planet, map), map);
        Earth.Properties.Add(PropertiesConstant.DESCRIPTION, "Home of Humans");
        Earth.Properties.Add(PropertiesConstant.DESIGNATION, "SOL-3");
        map.Add<Planet>(Earth);

        Satelite Moon = new("Moon", MapIdentifierGenerator.Instance.GenerateIdentifier(StellarObjectType.Satelite, map), map);
        Moon.Properties.Add(PropertiesConstant.DESCRIPTION, "Earth's moon");
        Moon.Properties.Add(PropertiesConstant.ALTERNATIVENAME, "Luna");
        Moon.Properties.Add(PropertiesConstant.DESIGNATION, "Earth-1");
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