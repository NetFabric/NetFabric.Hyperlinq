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

        public static TheoryData<int[]> SingleSingle =>
            new TheoryData<int[]> 
            {
                { new int[] { 1 } },
            };

        public static TheoryData<int[], Func<int, bool>> SinglePredicateSingle =>
            new TheoryData<int[], Func<int, bool>> 
            {
                { new int[] { 1 }, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 4 },
            };

        public static TheoryData<int[]> SingleMultiple =>
            new TheoryData<int[]> 
            {
                { new int[] { 1, 2 } },
            };

        public static TheoryData<int[], Func<int, bool>> SinglePredicateMultiple =>
            new TheoryData<int[], Func<int, bool>> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, item => item > 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 2 },
            };
    }
}
