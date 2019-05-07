using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Conversion =>
            new TheoryData<int[]> 
            {
                { new int[] { } },
                { new int[] { 1 } },
                { new int[] { 1, 2, 3, 4, 5} },
            };
    }
}