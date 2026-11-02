namespace StellarMap.Progression;

[JsonConverter(typeof(JsonStringEnumConverter<ERBridgeType>))]
public enum ERBridgeType
{
    None,
    StarSystem,
}
