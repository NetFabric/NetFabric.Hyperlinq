using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int, int, int> SkipTake_Take =>
            new()
            {
                { new int[] { }, 0, 0, -1 },
                { new int[] { }, 0, 0, 0 },
                { new int[] { }, 0, 0, 1 },

                { new[] { 1 }, 0, 1, -1 },
                { new[] { 1 }, 0, 1, 0 },
                { new[] { 1 }, 0, 1, 1 },
                { new[] { 1 }, 0, 1, 5 },

                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2, -1 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2, 0 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2, 5 },
            };
    }
}
