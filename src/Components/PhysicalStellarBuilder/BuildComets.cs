namespace StellarMap.PhysicalStellarBuilder;

public static class BuildComets
{
    public static Result<Comet> Haleys(IStellarMap map)
    {
        PhysicalProperties properties = new()
        {
            Mass = 2.2E14,
            Radius = 11,
            Dimensions = "15x8",
            Density = 0.6
        };

        return CometBuilder.Create("Haley's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Haley's Comet")
            .AddPhysicalProperties(properties)
            .Build();
    }

    public static Result<Comet> Caesers(IStellarMap map)
    {
        return CometBuilder.Create("Caeser's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Caeser's Comet")
            .Build();
    }

    public static Result<Comet> Enckes(IStellarMap map)
    {
        return CometBuilder.Create("Encke's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Encke's Comet")
            .Build();
    }

    public static Result<Comet> Bielas(IStellarMap map)
    {
        return CometBuilder.Create("Biela's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Biela's Comet")
            .Build();
    }

    public static Result<Comet> Fayes(IStellarMap map)
    {
        return CometBuilder.Create("Faye's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Faye's Comet")
            .Build();
    }

    public static Result<Comet> Brorsens(IStellarMap map)
    {
        return CometBuilder.Create("Brorsen's", MapIdentifierGenerator.Instance, map)
            .WithDescription("Brorsen's Comet")
            .Build();
    }

    public static Result<Comet> dArrests(IStellarMap map)
    {
        return CometBuilder.Create("d'Arrest's", MapIdentifierGenerator.Instance, map)
            .WithDescription("d'Arrest's Comet")
            .Build();
    }
}
