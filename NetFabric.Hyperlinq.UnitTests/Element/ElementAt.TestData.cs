using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int> ElementAtOutOfRange =>
            new()
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },
                { new[] { 1 }, -1 },
                { new[] { 1 }, 1 },
                { new[] { 1, 2, 3, 4, 5 }, -1 },
                { new[] { 1, 2, 3, 4, 5 }, 5 },
            };

        public static TheoryData<int[], int> ElementAt =>
            new()
            {
                { new[] { 1 }, 0},
                { new[] { 1, 2, 3, 4, 5 }, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 2 },
                { new[] { 1, 2, 3, 4, 5 }, 4 },
            };
    }
}
