using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, bool>, int[]> Where =>
            new TheoryData<int[], Func<int, bool>, int[]> 
            {
                { new int[] { }, _ => false, new int[] { } },
                { new int[] { 1 }, _ => false, new int[] { } },
                { new int[] { 1, 2, 3 }, _ => false, new int[] { } },

                { new int[] {}, _ => true, new int[] { } },
                { new int[] { 1 }, _ => true, new int[] { 1 } },
                { new int[] { 1, 2, 3 }, _ => true, new int[] { 1, 2, 3 } },

                { new int[] {}, item => item == 2, new int[] { } },
                { new int[] { 1 }, item => item == 2, new int[] { } },
                { new int[] { 1, 2, 3 }, item => item == 2, new int[] { 2 } },
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, string>, string[]> WhereSelect =>
            new TheoryData<int[], Func<int, bool>, Func<int, string>, string[]> 
            {
                { new int[] { }, _ => false, item => item.ToString(), new string[] { } },
                { new int[] { 1 }, _ => false, item => item.ToString(), new string[] { } },
                { new int[] { 1, 2, 3 }, _ => false, item => item.ToString(), new string[] { } },

                { new int[] {}, _ => true, item => item.ToString(), new string[] { } },
                { new int[] { 1 }, _ => true, item => item.ToString(), new string[] { "1" } },
                { new int[] { 1, 2, 3 }, _ => true, item => item.ToString(), new string[] { "1", "2", "3" } },

                { new int[] {}, item => item == 2, item => item.ToString(), new string[] { } },
                { new int[] { 1 }, item => item == 2, item => item.ToString(), new string[] { } },
                { new int[] { 1, 2, 3 }, item => item == 2, item => item.ToString(), new string[] { "2" } },
            };
    }
}
