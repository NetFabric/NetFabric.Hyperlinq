using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, string>, string[]> Select =>
            new TheoryData<int[], Func<int, string>, string[]> 
            {
                { new int[] {}, item => item.ToString(), new string[] {} },
                { new int[] { 1 }, item => item.ToString(), new string[] { "1" } },
                { new int[] { 1, 2, 3 }, item => item.ToString(), new string[] { "1", "2", "3" } },
            };

        public static TheoryData<int[], Func<int, int>, int, int[]> SelectSkip =>
            new TheoryData<int[], Func<int, int>, int, int[]> 
            {
                { new int[] { }, item => item, -1, new int[] { } },
                { new int[] { }, item => item, 0, new int[] { } },
                { new int[] { }, item => item, 2, new int[] { } },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1, new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2, new int[] { 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10, new int[] { } },
            };

        public static TheoryData<int[], Func<int, int>, int, int[]> SelectTake =>
            new TheoryData<int[], Func<int, int>, int, int[]> 
            {
                { new int[] { }, item => item, -1, new int[] { } },
                { new int[] { }, item => item, 0, new int[] { } },
                { new int[] { }, item => item, 2, new int[] { } },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2, new int[] { 1, 2 } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10, new int[] { 1, 2, 3, 4, 5 } },
            };

        public static TheoryData<int[], Func<int, int>, int, int, int[]> SelectSkipTake =>
            new TheoryData<int[], Func<int, int>, int, int, int[]> 
            {
                { new int[] { }, item => item, -1, -1, new int[] { } },
                { new int[] { }, item => item, 0, -1, new int[] { } },
                { new int[] { }, item => item, -1, 0, new int[] { } },
                { new int[] { }, item => item, 0, 0, new int[] { } },
                { new int[] { }, item => item, 2, 0, new int[] { } },
                { new int[] { }, item => item, 0, 2, new int[] { } },
                { new int[] { }, item => item, 2, 2, new int[] { } },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1, -1, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, -1, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, 2, new int[] { 1, 2 } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2, 2, new int[] { 3, 4 } },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, 10, new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10, 10, new int[] { } },
            };    
    }
}
