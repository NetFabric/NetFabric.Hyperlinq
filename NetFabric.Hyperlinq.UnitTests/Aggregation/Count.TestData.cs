using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Predicate<int>> CountPredicate =>
            new TheoryData<int[], Predicate<int>> 
            {
                { new int[] { }, _ => true },
                { new int[] { 1 }, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, _ => true },

                { new int[] { }, _ => false },
                { new int[] { 1 }, _ => false },
                { new int[] { 1, 2, 3, 4, 5 }, _ => false },

                { new int[] { }, item => item > 2 },
                { new int[] { 1 }, item => item > 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 2 },
            };
    }
}
