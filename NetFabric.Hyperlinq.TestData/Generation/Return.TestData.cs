using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int, int[]> Return =>
            new TheoryData<int, int[]> 
            {
                { int.MinValue, new int[] { int.MinValue } },
                { 0, new int[] { 0 } },
                { int.MaxValue, new int[] { int.MaxValue } },
            };
    }
}
