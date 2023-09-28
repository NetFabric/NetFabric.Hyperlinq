using System.Runtime.CompilerServices;

namespace LinqBenchmarks;

static class Utils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEven(this int value)
        => (value & 0x01) == 0;

    public static int[] GetSequentialValues(int count)
    {
        var array = new int[count];

        for (var index = 0; index < array.Length; index++)
            array[index] = index;

        return array;
    }

    public static int[] GetRandomValues(int count, int seed)
    {
        var array = new int[count];
        var random = new Random(seed);

        for (var index = 0; index < array.Length; index++)
            array[index] = random.Next(count);

        return array;
    }
}

