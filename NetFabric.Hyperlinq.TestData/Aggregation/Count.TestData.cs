using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int> Count =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, 0 },
                { new int[] { 1 }, 1 },
                { new int[] { 1, 2, 3, 4, 5}, 5 },
            };

        public static TheoryData<int[], Func<int, long, bool>, int> CountPredicate =>
            new TheoryData<int[], Func<int, long, bool>, int> 
            {
                { new int[] { }, (_, __) => true, 0 },
                { new int[] { 1 }, (_, __) => true, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => true, 5 },

                { new int[] { }, (_, __) => false, 0 },
                { new int[] { 1 }, (_, __) => false, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => false, 0 },

                { new int[] { }, (item, _) => item > 2, 0 },
                { new int[] { 1 }, (item, _) => item > 2, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item > 2, 3 },

                { new int[] { 1, 2, 3, 4, 5 }, (item, index) => item == index, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, index) => item == index + 1, 5 },
            };
    }
}
