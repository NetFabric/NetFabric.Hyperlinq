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

        public static TheoryData<int[], Func<int, bool>> PredicateSingle =>
            new TheoryData<int[], Func<int, bool>>
            {
                { new int[] { 1 }, _ => true },
                { new int[] { 1 }, item => item == 1 },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3 },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5 },
            };

        public static TheoryData<int[], int, int, Func<int, bool>> SkipTakePredicateSingle =>
            new TheoryData<int[], int, int, Func<int, bool>>
            {
                { new int[] { 1 }, -1, 9, _ => true },
                { new int[] { 1 }, 0, 1, _ => true },
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

        public static TheoryData<int[], Func<int, bool>, Func<int, bool>> PredicatePredicateSingle =>
            new TheoryData<int[], Func<int, bool>, Func<int, bool>>
            {
                { new int[] { 1 }, _ => true, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, _ => true, item => item == 3 },
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>> SkipTakePredicatePredicateSingle =>
            new TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>>
            {
                { new int[] { 1 }, 0, 9, _ => true, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 3, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, item => item == 3 },
            };

        public static TheoryData<int[], Func<int, int, bool>> PredicateAtSingle =>
            new TheoryData<int[], Func<int, int, bool>>
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

        public static TheoryData<int[], int, int, Func<int, int, bool>> SkipTakePredicateAtSingle =>
            new TheoryData<int[], int, int, Func<int, int, bool>>
            {
                { new int[] { 1 }, -1, 1, (_, __) => true },
                { new int[] { 1 }, 0, 1, (_, __) => true },
                { new int[] { 1 }, 0, 1, (item, _) => item == 1 },
                { new int[] { 1 }, 0, 1, (_, index) => index == 0 },

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

        public static TheoryData<int[], Func<int, string>> SelectorSingle =>
            new TheoryData<int[], Func<int, string>>
            {
                { new int[] { 1 }, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Func<int, string>> SkipTakeSelectorSingle =>
            new TheoryData<int[], int, int, Func<int, string>>
            {
                { new int[] { 1 }, 0, 1, item => item.ToString() },

                { new int[] { 1 }, -1, 9, item => item.ToString() },
                { new int[] { 1 }, 0, 9, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, item => item.ToString() },
            };

        public static TheoryData<int[], Func<int, int, string>> SelectorAtSingle =>
            new TheoryData<int[], Func<int, int, string>>
            {
                { new int[] { 1 }, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], int, int, Func<int, int, string>> SkipTakeSelectorAtSingle =>
            new TheoryData<int[], int, int, Func<int, int, string>>
            {
                { new int[] { 1 }, -1, 1, (item, index) => $"{item} {index}" },
                { new int[] { 1 }, 0, 1, (item, index) => $"{item} {index}" },

                { new int[] { 1 }, -1, 9, (item, index) => $"{item} {index}" },
                { new int[] { 1 }, 0, 9, (item, index) => $"{item} {index}" },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 1, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 1, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 4, 1, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, string>> PredicateSelectorSingle =>
            new TheoryData<int[], Func<int, bool>, Func<int, string>>
            {
                { new int[] { 1 }, _ => true, item => item.ToString() },
                { new int[] { 1 }, item => item == 1, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, item => item == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 3, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => item == 5, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, string>> SkipTakePredicateSelectorSingle =>
            new TheoryData<int[], int, int, Func<int, bool>, Func<int, string>>
            {
                { new int[] { 1 }, -1, 1, _ => true, item => item.ToString() },
                { new int[] { 1 }, 0, 1, _ => true, item => item.ToString() },
                { new int[] { 1 }, 0, 1, item => item == 1, item => item.ToString() },

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
