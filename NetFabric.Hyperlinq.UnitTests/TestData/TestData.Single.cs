using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Single =>
            new TheoryData<int[]>
            {
                { new int[] { 1 } },
            };

        public static TheoryData<int[], int> SkipSingle =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1 }, -1 },
                { new int[] { 1 }, 0 },

                { new int[] { 0, 1, 2 }, 2 },
            };

        public static TheoryData<int[], int> TakeSingle =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1 }, 1 },

                { new int[] { 1, 2, 3, 4, 5 }, 1 },
            };

        public static TheoryData<int[], int, int> SkipTakeSingle =>
            new TheoryData<int[], int, int> 
            {
                { new int[] { 1 }, -1, 1 },
                { new int[] { 1 }, 0, 1 },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1 },
            };

        public static TheoryData<int[], Predicate<int>> PredicateSingle =>
            new TheoryData<int[], Predicate<int>>
            {
                { new int[] { 1 }, _ => true },
                { new int[] { 1 }, item => item == 1 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5 },
            };

        public static TheoryData<int[], int, int, Predicate<int>> SkipTakePredicateSingle =>
            new TheoryData<int[], int, int, Predicate<int>>
            {
                { new int[] { 1 }, -1, 9, _ => true },
                { new int[] { 1 }, 0, 9, _ => true },
                { new int[] { 1 }, 0, 9, item => item == 1 },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 1, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 3 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 5 },
            };

        public static TheoryData<int[], PredicateAt<int>> PredicateAtSingle =>
            new TheoryData<int[], PredicateAt<int>>
            {
                { new int[] { 1 }, (_, __) => true },
                { new int[] { 1 }, (item, _) => item == 1 },
                { new int[] { 1 }, (_, index) => index == 0 },

                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item == 3 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => item == 5 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index == 2 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => index == 4 },
            };

        public static TheoryData<int[], int, int, PredicateAt<int>> SkipTakePredicateAtSingle =>
            new TheoryData<int[], int, int, PredicateAt<int>>
            {
                { new int[] { 1 }, -1, 9, (_, __) => true },
                { new int[] { 1 }, 0, 9, (_, __) => true },
                { new int[] { 1 }, 0, 9, (item, _) => item == 1 },
                { new int[] { 1 }, 0, 9, (_, index) => index == 0 },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 1, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item == 3 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item == 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index == 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index == 4 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index == 2 },
            };

        public static TheoryData<int[], Selector<int, string>> SelectorSingle =>
            new TheoryData<int[], Selector<int, string>>
            {
                { new int[] { 1 }, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Selector<int, string>> SkipTakeSelectorSingle =>
            new TheoryData<int[], int, int, Selector<int, string>>
            {
                { new int[] { 1 }, -1, 9, item => item.ToString() },
                { new int[] { 1 }, 0, 9, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, item => item.ToString() },
            };

        public static TheoryData<int[], SelectorAt<int, string>> SelectorAtSingle =>
            new TheoryData<int[], SelectorAt<int, string>>
            {
                { new int[] { 1 }, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], int, int, SelectorAt<int, string>> SkipTakeSelectorAtSingle =>
            new TheoryData<int[], int, int, SelectorAt<int, string>>
            {
                { new int[] { 1 }, -1, 9, (item, index) => $"{item} {index}" },
                { new int[] { 1 }, 0, 9, (item, index) => $"{item} {index}" },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], Predicate<int>, Selector<int, string>> PredicateSelectorSingle =>
            new TheoryData<int[], Predicate<int>, Selector<int, string>>
            {
                { new int[] { 1 }, _ => true, item => item.ToString() },
                { new int[] { 1 }, item => item == 1, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Predicate<int>, Selector<int, string>> SkipTakePredicateSelectorSingle =>
            new TheoryData<int[], int, int, Predicate<int>, Selector<int, string>>
            {
                { new int[] { 1 }, -1, 9, _ => true, item => item.ToString() },
                { new int[] { 1 }, 0, 9, _ => true, item => item.ToString() },
                { new int[] { 1 }, 0, 9, item => item == 1, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 1, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 3, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 5, item => item.ToString() },
            };
    }
}
