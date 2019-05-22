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

        public static TheoryData<int[], Func<int, bool>, int> CountPredicate =>
            new TheoryData<int[], Func<int, bool>, int> 
            {
                { new int[] { }, _ => true, 0 },
                { new int[] { 1 }, _ => true, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, _ => true, 5 },

                { new int[] { }, _ => false, 0 },
                { new int[] { 1 }, _ => false, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, _ => false, 0 },

                { new int[] { }, item => item > 2, 0 },
                { new int[] { 1 }, item => item > 2, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 2, 3 },
            };
    }
}
