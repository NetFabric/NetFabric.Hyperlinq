using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, long, bool>, bool> Any =>
            new TheoryData<int[], Func<int, long, bool>, bool> 
            {
                { new int[] { }, (_, __) => true, false },

                { new int[] { 1 }, (_, __) => true, true },
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => true, true },

                { new int[] { 1 }, (_, __) => false, false },
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => false, false },

                { new int[] { 1 }, (item, _) => item == 5, false },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item == 5, true },

                { new int[] { 1 }, (_, index) => index == 4, false },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index == 4, true },
            };
    }
}
