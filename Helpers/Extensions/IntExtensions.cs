namespace Helpers.Extensions;

public static class IntExtensions
{
    public static bool IsRemainderNotZero(this int i, int divider) => i % divider != 0;
}
