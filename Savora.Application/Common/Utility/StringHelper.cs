namespace Savora.Application.Common.Utility;
public static class StringHelper
{
    public static bool HasValue(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && !string.IsNullOrEmpty(value);
    }


}
