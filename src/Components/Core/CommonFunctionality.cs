namespace StellarMap.Core;

public static class CommonFunctionality
{
    public static bool CompareDictionaries<T, U>(Dictionary<T, U>? first, Dictionary<T, U>? second) where T : notnull
    {
        if (first is null && second is null) return true;
        if (first is null || second is null) return false;
        if (ReferenceEquals(first, second)) return true;

        return first.Count == second.Count && !first.Except(second).Any();
    }

    //public static Result<T> Convert<T, U>(this Result<U> result)
    //    where T : class, U
    //    where U : class
    //    => result.Success switch
    //        {
    //            true => Result<T>.Ok((result.Value as T)!),
    //            _ => Result<T>.Error(result.ErrorMessage)
    //        };
}