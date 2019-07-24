using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, bool>> Any =>
            new TheoryData<int[], Func<int, bool>> 
            {
                { new int[] { }, _ => true },

                { new int[] { 1 }, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, _ => true },

                { new int[] { 1 }, _ => false },
                { new int[] { 1, 2, 3, 4, 5 }, _ => false },

                { new int[] { 1 }, item => item == 5 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5 },
            };
    }
}
