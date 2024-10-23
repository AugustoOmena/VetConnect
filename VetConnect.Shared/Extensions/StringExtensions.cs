namespace VetConnect.Shared.Extensions;

public static class StringExtensions
{
    public static T ToEnumValue<T>(this string value)
        where T : struct
    {
        if (Enum.TryParse(typeof(T), value, true, out var result) && result != null)
        {
            return (T) result;
        }

        return default;
    }
}