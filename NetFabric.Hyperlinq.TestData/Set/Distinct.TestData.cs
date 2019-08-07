using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Distinct =>
            new TheoryData<int[]>
            {
                { new int[] {} },
                { new int[] { 1 } },
                { new int[] { 1, 1 } },
                { new int[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 } },
            };
    }
}
