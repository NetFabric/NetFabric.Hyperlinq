using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> SingleEmpty =>
            new TheoryData<int[]> 
            {
                { new int[] { } },
            };

        public static TheoryData<int[], Func<int, long, bool>> SinglePredicateEmpty =>
            new TheoryData<int[], Func<int, long, bool>> 
            {
                { new int[] { }, (_, __) => true },

                { new int[] { }, (_, __) => false },
                { new int[] { 1 }, (_, __) => false },
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => false },

                { new int[] { }, (item, _) => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item > 5 },

                { new int[] { }, (_, index) => index == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index > 4 },
            };

        public static TheoryData<int[], int> SingleSingle =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1 }, 1 },
            };

        public static TheoryData<int[], Func<int, long, bool>, int> SinglePredicateSingle =>
            new TheoryData<int[], Func<int, long, bool>, int> 
            {
                { new int[] { 1 }, (_, __) => true, 1 },

                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item == 2, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item > 4, 5 },

                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index == 2, 3 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index > 3, 5 },
            };

        public static TheoryData<int[], int> SingleMultiple =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1, 2 }, 1 },
            };

        public static TheoryData<int[], Func<int, long, bool>, int> SinglePredicateMultiple =>
            new TheoryData<int[], Func<int, long, bool>, int> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => true, 1 },

                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item > 0, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item > 2, 3 },

                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index > -1, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index > 2, 4 },
            };
    }
}
