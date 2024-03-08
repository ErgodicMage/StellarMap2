namespace StellarMap.PhysicalStellarBuilder;

public class BuildNearestStars
{
    public static Result NearestStars(IStellarMap map)
    {
        Result result = BuildStars.Sol(map);
        if (!result.Success) return result;

        result = BuildStarSystems.AlphsCentauri(map);
        if (!result.Success) return result;

        return Result.Ok();

    }
}
