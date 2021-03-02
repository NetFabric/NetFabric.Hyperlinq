using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Sum
            => new()
            {
                { new int[] { } },
                { new[] { 1 } },
                { new[] { 1, 2, 3, 4, 5, 6, 7 } },
                { new[] { 1, 2, 3, 4, 5, 6, 7, 8 } }, // size of Vector<int>
                { new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 } },
                { new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 } },
            };
        
        public static TheoryData<int?[]> NullableSum
            => new()
            {
                { new int?[] { } },
                { new int?[] { null } },
                { new int?[] { 1 } },
                { new int?[] { null, null, null } },
                { new int?[] { null, 2, 3, 4, null } },
                { new int?[] { 1, 2, null, 4, 5 } },
                { new int?[] { 1, 2, 3, 4, 5 } },
            };
        
    }
}