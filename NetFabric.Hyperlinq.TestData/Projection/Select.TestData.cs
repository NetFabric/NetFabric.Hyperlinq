using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, string>> Select =>
            new TheoryData<int[], Func<int, string>> 
            {
                { new int[] {}, item => item.ToString() },
                { new int[] { 1 }, item => item.ToString() },
                { new int[] { 1, 2, 3 }, item => item.ToString() },
            };

        public static TheoryData<int[], Func<int, int>, int> SelectSkip =>
            new TheoryData<int[], Func<int, int>, int> 
            {
                { new int[] { }, item => item, -1 },
                { new int[] { }, item => item, 0 },
                { new int[] { }, item => item, 2},

                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10 },
            };

        public static TheoryData<int[], Func<int, int>, int> SelectTake =>
            new TheoryData<int[], Func<int, int>, int> 
            {
                { new int[] { }, item => item, -1 },
                { new int[] { }, item => item, 0 },
                { new int[] { }, item => item, 2 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10 },
            };

        public static TheoryData<int[], Func<int, int>, int, int> SelectSkipTake =>
            new TheoryData<int[], Func<int, int>, int, int> 
            {
                { new int[] { }, item => item, -1, -1 },
                { new int[] { }, item => item, 0, -1 },
                { new int[] { }, item => item, -1, 0 },
                { new int[] { }, item => item, 0, 0 },
                { new int[] { }, item => item, 2, 0 },
                { new int[] { }, item => item, 0, 2 },
                { new int[] { }, item => item, 2, 2 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, -1, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 2, 2 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 0, 10 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item, 10, 10 },
            };    
    }
}
