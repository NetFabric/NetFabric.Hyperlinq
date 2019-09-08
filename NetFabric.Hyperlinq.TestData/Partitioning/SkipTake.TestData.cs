using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int, int> SkipTakeEmpty =>
            new TheoryData<int[], int, int> 
            {
                { new int[] { }, -1, -1 },
                { new int[] { }, -1, 0 },
                { new int[] { }, 0, -1 },
                { new int[] { }, 0, 0 },
                { new int[] { }, 0, 9 },
                { new int[] { }, 1, 0 },
                { new int[] { }, 1, 9 },

                { new int[] { 1 }, -1, -1 },
                { new int[] { 1 }, -1, 0 },
                { new int[] { 1 }, 0, -1 },
                { new int[] { 1 }, 0, 0 },
                { new int[] { 1 }, 1, 0 },
                { new int[] { 1 }, 1, 9 },

                { new int[] { 0, 1, 2, 3, 4, 5 }, -1, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5 }, 2, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5 }, 0, 0 },
                { new int[] { 0, 1, 2, 3, 4, 5 }, 2, 0 },
                { new int[] { 0, 1, 2, 3, 4, 5 }, 9, 9 },
            };

        public static TheoryData<int[], int, int> SkipTakeSingle =>
            new TheoryData<int[], int, int>
            {
                { new int[] { 1 }, -1, 1 },
                { new int[] { 1 }, -1, 5 },
                { new int[] { 1 }, 0, 1 },
                { new int[] { 1 }, 0, 5 },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 9 },
            };

        public static TheoryData<int[], int, int> SkipTakeMultiple =>
            new TheoryData<int[], int, int>
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9 },
            };

        public static TheoryData<int[], int, int, int> SkipTake_Take =>
            new TheoryData<int[], int, int, int>
            {
                { new int[] { }, 0, 0, -1 },
                { new int[] { }, 0, 0, 0 },
                { new int[] { }, 0, 0, 1 },

                { new int[] { 1 }, 0, 1, -1 },
                { new int[] { 1 }, 0, 1, 0 },
                { new int[] { 1 }, 0, 1, 1 },
                { new int[] { 1 }, 0, 1, 5 },

                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2, 0 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2, 5 },
            };
    }
}
