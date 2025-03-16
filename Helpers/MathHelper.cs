namespace Helpers;

public static class MathHelper
{
    public static bool IsRemainderNotZero(this int i, int divider) => i % divider != 0;
}
