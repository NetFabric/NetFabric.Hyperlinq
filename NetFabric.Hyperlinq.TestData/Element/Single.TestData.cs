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

        public static TheoryData<int[], Func<int, bool>> SinglePredicateEmpty =>
            new TheoryData<int[], Func<int, bool>> 
            {
                { new int[] { }, _ => true },

                { new int[] { }, _ => false },
                { new int[] { 1 }, _ => false },
                { new int[] { 1, 2, 3, 4, 5 }, _ => false },

                { new int[] { }, item => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 5 },
            };

        public static TheoryData<int[], int> SingleSingle =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1 }, 1 },
            };

        public static TheoryData<int[], Func<int, bool>, int> SinglePredicateSingle =>
            new TheoryData<int[], Func<int, bool>, int> 
            {
                { new int[] { 1 }, _ => true, 1 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 2, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 4, 5 },
            };

        public static TheoryData<int[], int> SingleMultiple =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1, 2 }, 1 },
            };

        public static TheoryData<int[], Func<int, bool>, int> SinglePredicateMultiple =>
            new TheoryData<int[], Func<int, bool>, int> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, _ => true, 1 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item > 0, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 2, 3 },
            };
    }
}
