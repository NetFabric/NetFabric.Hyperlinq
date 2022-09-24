using System;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq.Benchmarks
{
    static class Utils
    {
        [return: NotNull]
        public static int[] GetSequentialValues(int count)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var array = new int[count];

            for (var index = 0; index < count; index++)
                array[index] = index;

            return array;
        }

        [return: NotNull]
        public static int[] GetRandomValues(int seed, int count)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var array = new int[count];

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var random = new Random(seed);
            for (var index = 0; index < count; index++)
                array[index] = random.Next(count);

            return array;
        }
    }
}
