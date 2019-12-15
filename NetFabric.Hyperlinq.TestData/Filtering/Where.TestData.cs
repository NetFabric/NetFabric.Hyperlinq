using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Predicate<int>> Where =>
            new TheoryData<int[], Predicate<int>> 
            {
                { new int[] { }, _ => false },
                { new int[] { 1 }, _ => false },
                { new int[] { 1, 2, 3 }, _ => false },

                { new int[] {}, _ => true },
                { new int[] { 1 }, _ => true },
                { new int[] { 1, 2, 3 }, _ => true },

                { new int[] {}, item => item == 2 },
                { new int[] { 1 }, item => item == 2 },
                { new int[] { 1, 2, 3 }, item => item == 2 },
            };

        public static TheoryData<int[], Predicate<int>, Func<int, string>> WhereSelect =>
            new TheoryData<int[], Predicate<int>, Func<int, string>> 
            {
                { new int[] { }, _ => false, item => item.ToString() },
                { new int[] { 1 }, _ => false, item => item.ToString() },
                { new int[] { 1, 2, 3 }, _ => false, item => item.ToString() },

                { new int[] {}, _ => true, item => item.ToString() },
                { new int[] { 1 }, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3 }, _ => true, item => item.ToString() },

                { new int[] {}, item => item == 2, item => item.ToString() },
                { new int[] { 1 }, item => item == 2, item => item.ToString() },
                { new int[] { 1, 2, 3 }, item => item == 2, item => item.ToString() },
            };
    }
}
