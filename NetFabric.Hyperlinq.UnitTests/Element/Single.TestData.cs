using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Predicate<int>> SinglePredicateEmpty =>
            new TheoryData<int[], Predicate<int>> 
            {
                { new int[] { }, item => (item & 0x01) == 0 },

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

        public static TheoryData<int[], Predicate<int>> SinglePredicateSingle =>
            new TheoryData<int[], Predicate<int>> 
            {
                { new int[] { 2 }, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 2 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 4 },
            };

        public static TheoryData<int[], Predicate<int>> SinglePredicateMultiple =>
            new TheoryData<int[], Predicate<int>> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 0 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item > 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 2 },
            };
    }
}
