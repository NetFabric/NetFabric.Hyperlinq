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
                { new int[] { }, 5 },
                { new int[] { 1 }, 5 },
                { new int[] { 1, 2, 3, 4 }, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 1 },
            };
    }
}
