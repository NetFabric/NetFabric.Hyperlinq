using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int, int> Take_Take =>
            new TheoryData<int[], int, int>
            {
                { new int[] { }, -1, -1 },
                { new int[] { }, 0, -1 },
                { new int[] { }, 1, -1 },

                { new int[] { }, -1, 0 },
                { new int[] { }, 0, 0 },
                { new int[] { }, 1, 0 },

                { new int[] { 1 }, -1, -1 },
                { new int[] { 1 }, 0, 0 },
                { new int[] { 1 }, 0, 1 },
                { new int[] { 1 }, 1, 1 },
                { new int[] { 1 }, 5, 2 },
                { new int[] { 1 }, 5, 5 },

                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 2 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 0 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 1 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4 },
            };
    }
}
