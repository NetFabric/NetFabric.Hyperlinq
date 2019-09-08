using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Select =>
            new TheoryData<int[]> 
            {
                { new int[] {} },
                { new int[] { 1 } },
                { new int[] { 1, 2, 3 } },
            };

        public static TheoryData<int[], int> SelectSkip =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 2},

                { new int[] { 1, 2, 3, 4, 5 }, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 10 },
            };

        public static TheoryData<int[], int> SelectTake =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 2 },

                { new int[] { 1, 2, 3, 4, 5 }, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 10 },
            };

        public static TheoryData<int[], int, int> SelectSkipTake =>
            new TheoryData<int[], int, int> 
            {
                { new int[] { }, -1, -1 },
                { new int[] { }, 0, -1 },
                { new int[] { }, -1, 0 },
                { new int[] { }, 0, 0 },
                { new int[] { }, 2, 0 },
                { new int[] { }, 0, 2 },
                { new int[] { }, 2, 2 },

                { new int[] { 1, 2, 3, 4, 5 }, -1, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2 },

                { new int[] { 1, 2, 3, 4, 5 }, 10, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 10 },
                { new int[] { 1, 2, 3, 4, 5 }, 10, 10 },
            };    
    }
}
