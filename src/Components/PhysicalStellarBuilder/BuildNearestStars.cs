namespace StellarMap.PhysicalStellarBuilder;

public class BuildNearestStars
{
    public static Result NearestStars(IStellarMap map)
    {
        Result result = BuildStars.Sol(map);
        if (!result.Success) return result;

        result = BuildStarSystems.AlphaCentauri(map);
        if (!result.Success) return result;

        result = BuildStars.BanardsStar(map);
        if (!result.Success) return result;

        result = BuildStarSystems.Luhman16(map);
        if (!result.Success) return result;

        result = BuildStars.WISE08550714(map);
        if (!result.Success) return result;

        return Result.Ok();

    }
}
