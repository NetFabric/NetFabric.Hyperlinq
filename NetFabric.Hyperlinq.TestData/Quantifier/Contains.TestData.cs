using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int, bool> Contains =>
            new TheoryData<int[], int, bool> 
            {
                { new int[] { }, 5, false },
                { new int[] { 1 }, 5, false },
                { new int[] { 1, 2, 3, 4 }, 5, false },
                { new int[] { 1, 2, 3, 4, 5 }, 5, true },
                { new int[] { 1, 2, 3, 4, 5 }, 1, true },
            };
    }
}
