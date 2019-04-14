using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public static partial class TestData
    {
        public static TheoryData<int, int, IReadOnlyList<int>> Range =>
            new TheoryData<int, int, IReadOnlyList<int>> 
            {
                { -1, 0, new int[] { } },
                { 0, 0, new int[] { } },
                { 0, 1, new int[] { 0 } },

                { -1, 1, new int[] { -1 } },
                { -1, 5, new int[] { -1, 0, 1, 2, 3 } },
                { 1, 5, new int[] { 1, 2, 3, 4, 5 } },
            };

        public static TheoryData<int, int, int, IReadOnlyList<int>> RangeSkip =>
            new TheoryData<int, int, int, IReadOnlyList<int>> 
            {
                { 1, 5, -1, new int[] { 1, 2, 3, 4, 5 } },
                { 1, 5, 0, new int[] { 1, 2, 3, 4, 5 } },
                { 1, 5, 2, new int[] { 3, 4, 5 } },
                { 1, 5, 10, new int[] { } },
            };

        public static TheoryData<int, int, int, IReadOnlyList<int>> RangeTake =>
            new TheoryData<int, int, int, IReadOnlyList<int>> 
            {
                { 1, 5, -1, new int[] { } },
                { 1, 5, 0, new int[] { } },
                { 1, 5, 2, new int[] { 1, 2 } },
                { 1, 5, 10, new int[] { 1, 2, 3, 4, 5} },
            };

        public static TheoryData<int, int, int, int, IReadOnlyList<int>> RangeSkipTake =>
            new TheoryData<int, int, int, int, IReadOnlyList<int>> 
            {
                { 1, 5, 0, 0, new int[] { } },
                { 1, 5, -1, 0, new int[] { } },
                { 1, 5, 0, -1, new int[] { } },
                { 1, 5, -1, -1, new int[] { } },
                { 1, 5, 0, 2, new int[] { 1, 2 } },
                { 1, 5, 0, 10, new int[] { 1, 2, 3, 4, 5} },
                { 1, 5, 2, 2, new int[] { 3, 4 } },
                { 1, 5, 2, 10, new int[] { 3, 4, 5} },
            };
    }
}
