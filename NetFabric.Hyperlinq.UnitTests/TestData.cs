using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Empty =>
            new TheoryData<int[]>
            {
                { new int[] { } },
            };

        public static TheoryData<int[]> Single =>
            new TheoryData<int[]>
            {
                { new int[] { 5 } },
            };

        public static TheoryData<int[]> Multiple =>
            new TheoryData<int[]> 
            {
                { new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 3, 1, 4, 5, 2, 3, 1, 4, 5, 2 } },
            };

        public static TheoryData<int[], Predicate<int>> Predicate =>
            new TheoryData<int[], Predicate<int>>
            {
                { new int[] { }, _ => false },
                { new int[] { }, _ => true },

                { new int[] { 1 }, _ => false },
                { new int[] { 1 }, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, _ => false },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5 },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 0 },
            };

        public static TheoryData<int[], Predicate<int>, Selector<int, string>> PredicateSelector =>
            new TheoryData<int[], Predicate<int>, Selector<int, string>>
            {
                { new int[] { }, _ => false, item => item.ToString() },
                { new int[] { }, _ => true, item => item.ToString() },

                { new int[] { 1 }, _ => false, item => item.ToString() },
                { new int[] { 1 }, _ => true, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, _ => false, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 0, item => item.ToString() },
            };
    }
}
