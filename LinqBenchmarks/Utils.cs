using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LinqBenchmarks;

static class Utils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEven(this int value)
        => (value & 0x01) == 0;

    public static IEnumerable<T> Enumerable<T>(int count)
    {
        if (count < 0) 
            throw new ArgumentOutOfRangeException(nameof(count));
        return GetEnumerable(count);

        static IEnumerable<T> GetEnumerable(int count)
        {
            for (var value = 0; value < count; value++)
                yield return default;
        }
    }

    public static IAsyncEnumerable<T> AsyncEnumerable<T>(int count)
    {
        if (count < 0) 
            throw new ArgumentOutOfRangeException(nameof(count));
        return GetEnumerableAsync(count);

        static async IAsyncEnumerable<T> GetEnumerableAsync(int count)
        {
            for (var value = 0; value < count; value++)
            {
                await Task.Delay(1);
                yield return default;
            }
        }
    }    
}