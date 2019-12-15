using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int> SkipEmpty =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },

                { new int[] { 1 }, 1 },
                { new int[] { 1 }, 5 },

                { new int[] { 0, 1, 2 }, 3 },
            };

        public static TheoryData<int[], int> SkipSingle =>
            new TheoryData<int[], int>
            {
                { new int[] { 1 }, -1 },
                { new int[] { 1 }, 0 },

                { new int[] { 0, 1, 2 }, 2 },
            };

        public static TheoryData<int[], int> SkipMultiple =>
            new TheoryData<int[], int>
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 3 },
            };

        public static TheoryData<int[], int, int> Skip_Skip =>
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
                { new int[] { 1 }, 1, 1 },
                { new int[] { 1 }, 5, 5 },

                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 0 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2 },
            };
    }
}
