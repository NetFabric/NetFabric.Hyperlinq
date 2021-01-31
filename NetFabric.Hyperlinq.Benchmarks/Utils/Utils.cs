using System;

namespace NetFabric.Hyperlinq.Benchmarks
{
    static class Utils
    {
        public static int[] GetSequentialValues(int count)
        {
            var array = new int[count];

            for (var index = 0; index < count; index++)
                array[index] = index;

            return array;
        }

        public static int[] GetRandomValues(int seed, int count)
        {
            var array = new int[count];

            var random = new Random(seed);
            for (var index = 0; index < count; index++)
                array[index] = random.Next(count);

            return array;
        }
    }
}
