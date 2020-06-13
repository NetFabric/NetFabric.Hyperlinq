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

        public static TheoryData<int[], int> SkipEmpty =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },

                { new int[] { 1 }, 1 },
                { new int[] { 1 }, 5 },

                { new int[] { 0, 1, 2 }, 3 },
                { new int[] { 0, 1, 2 }, 5 },
            };

        public static TheoryData<int[], int> TakeEmpty =>
            new TheoryData<int[], int> 
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },

                { new int[] { 5 }, -1 },
                { new int[] { 5 }, 0 },

                { new int[] { 0, 1, 2, 3, 4, 5 }, -1 },
                { new int[] { 0, 1, 2, 3, 4, 5 }, 0 },
            };

        public static TheoryData<int[], int, int> SkipTakeEmpty =>
            new TheoryData<int[], int, int> 
            {
                { new int[] { }, -1, -1 },
                { new int[] { }, -1, 0 },
                { new int[] { }, 0, -1 },
                { new int[] { }, 0, 0 },
                { new int[] { }, 0, 9 },
                { new int[] { }, 1, 0 },
                { new int[] { }, 1, 9 },

                { new int[] { 1 }, -1, -1 },
                { new int[] { 1 }, -1, 0 },
                { new int[] { 1 }, 0, -1 },
                { new int[] { 1 }, 0, 0 },
                { new int[] { 1 }, 1, 0 },
                { new int[] { 1 }, 1, 9 },

                { new int[] { 1, 2, 3, 4, 5 }, -1, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 9, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 9, 9 },
            };

        public static TheoryData<int[], Predicate<int>> PredicateEmpty =>
            new TheoryData<int[], Predicate<int>>
            {
                { new int[] { }, _ => false },
                { new int[] { }, _ => true },

                { new int[] { 1 }, _ => false },
                { new int[] { 1 }, item => item > 9 },

                { new int[] { 1, 2, 3, 4, 5 }, _ => false },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 9 },
            };

        public static TheoryData<int[], int, int, Predicate<int>> SkipTakePredicateEmpty =>
            new TheoryData<int[], int, int, Predicate<int>>
            {
                { new int[] { }, 0, 9, _ => false },
                { new int[] { }, 0, 0, _ => true },
                { new int[] { }, 0, 9, item => item > 9 },

                { new int[] { 1 }, 0, 0, _ => true },
                { new int[] { 1 }, 9, 9, _ => true },
                { new int[] { 1 }, 0, 9, _ => false },
                { new int[] { 1 }, 0, 9, item => item > 9 },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 0, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 9, 9, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item > 9 },
            };

        public static TheoryData<int[], PredicateAt<int>> PredicateAtEmpty =>
            new TheoryData<int[], PredicateAt<int>>
            {
                { new int[] { }, (_, __) => false },
                { new int[] { }, (_, __) => true },

                { new int[] { 1 }, (_, __) => false },
                { new int[] { 1 }, (item, _) => item > 9 },
                { new int[] { 1 }, (_, index) => index > 9 },

                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => false },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item > 9 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index > 9 },
            };

        public static TheoryData<int[], int, int, PredicateAt<int>> SkipTakePredicateAtEmpty =>
            new TheoryData<int[], int, int, PredicateAt<int>>
            {
                { new int[] { }, 0, 9, (_, __) => false },
                { new int[] { }, 0, 0, (_, __) => true },
                { new int[] { }, 0, 9, (item, _) => item > 9 },
                { new int[] { }, 0, 9, (_, index) => index > 9 },

                { new int[] { 1 }, 0, 0, (_, __) => true },
                { new int[] { 1 }, 0, 9, (_, __) => false },
                { new int[] { 1 }, 0, 9, (item, _) => item > 9 },
                { new int[] { 1 }, 0, 9, (_, index) => index > 9 },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 0, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (_, __) => false },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item > 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index > 9 },

                { new int[] { 1, 2, 3, 4, 5 }, 2, 0, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (_, __) => false },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (item, _) => item > 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index > 9 },
            };

        public static TheoryData<int[], NullableSelector<int, string>> SelectorEmpty =>
            new TheoryData<int[], NullableSelector<int, string>>
            {
                { new int[] { }, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, NullableSelector<int, string>> SkipTakeSelectorEmpty =>
            new TheoryData<int[], int, int, NullableSelector<int, string>>
            {
                { new int[] { }, 0, 9, item => item.ToString() },

                { new int[] { 1 }, 0, 0, item => item.ToString() },
                { new int[] { 1 }, 9, 9, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 0, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 9, 9, item => item.ToString() },
            };

        public static TheoryData<int[], NullableSelectorAt<int, string>> SelectorAtEmpty =>
            new TheoryData<int[], NullableSelectorAt<int, string>>
            {
                { new int[] { }, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], int, int, NullableSelectorAt<int, string>> SkipTakeSelectorAtEmpty =>
            new TheoryData<int[], int, int, NullableSelectorAt<int, string>>
            {
                { new int[] { }, 0, 9, (item, index) => $"{item} {index}" },

                { new int[] { 1 }, 0, 0, (item, index) => $"{item} {index}" },
                { new int[] { 1 }, 9, 9, (item, index) => $"{item} {index}" },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 0, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 9, 9, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], Predicate<int>, NullableSelector<int, string>> PredicateSelectorEmpty =>
            new TheoryData<int[], Predicate<int>, NullableSelector<int, string>>
            {
                { new int[] { }, _ => false, item => item.ToString() },
                { new int[] { }, _ => true, item => item.ToString() },

                { new int[] { 1 }, _ => false, item => item.ToString() },
                { new int[] { 1 }, item => item > 9, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, _ => false, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item > 9, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Predicate<int>, NullableSelector<int, string>> SkipTakePredicateSelectorEmpty =>
            new TheoryData<int[], int, int, Predicate<int>, NullableSelector<int, string>>
            {
                { new int[] { }, 0, 9, _ => false, item => item.ToString() },
                { new int[] { }, 0, 0, _ => true, item => item.ToString() },
                { new int[] { }, 0, 9, item => item > 9, item => item.ToString() },

                { new int[] { 1 }, 0, 0, _ => true, item => item.ToString() },
                { new int[] { 1 }, 9, 9, _ => true, item => item.ToString() },
                { new int[] { 1 }, 0, 9, _ => false, item => item.ToString() },
                { new int[] { 1 }, 0, 9, item => item > 9, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 0, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 9, 9, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item > 9, item => item.ToString() },
            };
    }
}
