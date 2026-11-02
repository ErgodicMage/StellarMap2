namespace StellarMap.Progression.Objects;

public class ERBridge : StellarObject
{
    #region Properties
    [JsonPropertyOrder(11)]
    public ERBridgeType BridgeType { get; set; }

    [JsonPropertyOrder(12)]
    public Portal[] Portals { get; } = new Portal[2];
    #endregion

    public ERBridge() { }

    public ERBridge(Identifier identifier, IStellarMap map, ERBridgeType bridgeType, Portal portal1, Portal portal2) :
        base(string.Empty, identifier, map, ProgressionObjectType.ERBridge)
    {
        (map as ProgressionMap)?.Add(this);
        BridgeType = bridgeType;
        Portals[0] = portal1;
        Portals[1] = portal2;
        Name = SetName();
        ObjectType = ProgressionObjectType.ERBridge;
    }

    private string SetName()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Bridge: ");
        bool bFirst = true;
        foreach (Portal p in Portals)
        {
            StarSystem? system = (Map as ProgressionMap)?.Get<StarSystem>(p.StarSystemIdentifier);
            if (system is not null)
            {
                if (!bFirst)
                    sb.Append("-");
                sb.Append(system.Name);
                bFirst = false;
            }
        }
        return sb.ToString();
    }

    protected override void CreateIdentifiers<T>()
    {
        var foundObjectType = ProgressionObjectType.FromName(nameof(T));
        if (!foundObjectType.Success) return;

        switch (foundObjectType.Value.Name)
        {
            case ProgressionObjectType.ERBRIDGE: base.CreateIdentifiers<ERBridge>(); break;
            default: base.CreateIdentifiers<T>(); break;
        };
    }
}

