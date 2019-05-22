using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, bool>, bool> All =>
            new TheoryData<int[], Func<int, bool>, bool> 
            {
                { new int[] { }, _ => true, true },

                { new int[] { 1 }, _ => true, true },
                { new int[] { 1, 2, 3, 4, 5 }, _ => true, true },

                { new int[] { 1 }, _ => false, false },
                { new int[] { 1, 2, 3, 4, 5 }, _ => false, false },

                { new int[] { 1 }, item => item == 5, false },
                { new int[] { 1, 2, 3, 4, 5 }, item => item < 10, true },
            };
    }
}
