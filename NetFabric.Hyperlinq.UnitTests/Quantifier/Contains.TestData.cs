using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int> Contains =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, 9 },
                { new int[] { 1 }, 1 },
                { new int[] { 1 }, 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 9 },
            };

        public static TheoryData<int[], int, int, int> SkipTakeContains =>
            new TheoryData<int[], int, int, int> 
            {
                { new int[] { }, 0, 9, 9 },
                { new int[] { 1 }, 0, 9, 1 },
                { new int[] { 1 }, 0, 9, 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, 9 },

                { new int[] { 1, 2, 3, 4, 5 }, 9, 9, 5 },

                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 4 },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 5 },
            };
    }
}
