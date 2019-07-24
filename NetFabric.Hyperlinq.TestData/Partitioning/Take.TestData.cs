using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int> Take =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },

                { new int[] { 1 }, -1 },
                { new int[] { 1 }, 0 },
                { new int[] { 1 }, 1 },
                { new int[] { 1 }, 5 },

                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2 },
            };
    }
}
