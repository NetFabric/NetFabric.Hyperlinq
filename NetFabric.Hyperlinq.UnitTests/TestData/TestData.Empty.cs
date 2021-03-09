using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Empty =>
            new()
            {
                new int[] { },
            };

        public static TheoryData<int[], int> SkipEmpty =>
            new()
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },

                { new[] { 1 }, 1 },
                { new[] { 1 }, 5 },

                { new[] { 0, 1, 2 }, 3 },
                { new[] { 0, 1, 2 }, 5 },
            };

        public static TheoryData<int[], int> TakeEmpty =>
            new()
            {
                { new int[] { }, -1 },
                { new int[] { }, 0 },
                { new int[] { }, 1 },

                { new[] { 5 }, -1 },
                { new[] { 5 }, 0 },

                { new[] { 0, 1, 2, 3, 4, 5 }, -1 },
                { new[] { 0, 1, 2, 3, 4, 5 }, 0 },
            };

        public static TheoryData<int[], int, int> SkipTakeEmpty =>
            new()
            {
                { new int[] { }, -1, -1 },
                { new int[] { }, -1, 0 },
                { new int[] { }, 0, -1 },
                { new int[] { }, 0, 0 },
                { new int[] { }, 0, 9 },
                { new int[] { }, 1, 0 },
                { new int[] { }, 1, 9 },

                { new[] { 1 }, -1, -1 },
                { new[] { 1 }, -1, 0 },
                { new[] { 1 }, 0, -1 },
                { new[] { 1 }, 0, 0 },
                { new[] { 1 }, 1, 0 },
                { new[] { 1 }, 1, 9 },

                { new[] { 1, 2, 3, 4, 5 }, -1, -1 },
                { new[] { 1, 2, 3, 4, 5 }, -1, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 0, -1 },
                { new[] { 1, 2, 3, 4, 5 }, 2, -1 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 2, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 9, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9 },
            };

        public static TheoryData<int[], Func<int, bool>> PredicateEmpty =>
            new()
            {
                { new int[] { }, _ => false },
                { new int[] { }, _ => true },

                { new[] { 1 }, _ => false },
                { new[] { 1 }, item => item > 9 },

                { new[] { 1, 2, 3, 4, 5 }, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, item => item > 9 },
            };

        public static TheoryData<int[], int, int, Func<int, bool>> SkipTakePredicateEmpty =>
            new()
            {
                { new int[] { }, 0, 9, _ => false },
                { new int[] { }, 0, 0, _ => true },
                { new int[] { }, 0, 9, item => item > 9 },

                { new[] { 1 }, 0, 0, _ => true },
                { new[] { 1 }, 9, 9, _ => true },
                { new[] { 1 }, 0, 9, _ => false },
                { new[] { 1 }, 0, 9, item => item > 9 },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item > 9 },
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, bool>> PredicatePredicateEmpty =>
            new()
            {
                { new int[] { }, _ => true, _ => true },

                { new[] { 1, 2, 3, 4, 5 }, _ => false, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, _ => true, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, _ => false, _ => true },
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>> SkipTakePredicatePredicateEmpty =>
            new()
            {
                { new int[] { }, 0, 9, _ => true, _ => true },

                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, _ => true },
            };

        public static TheoryData<int[], Func<int, int, bool>> PredicateAtEmpty =>
            new()
            {
                { new int[] { }, (_, __) => false },
                { new int[] { }, (_, __) => true },

                { new[] { 1 }, (_, __) => false },
                { new[] { 1 }, (item, _) => item > 9 },
                { new[] { 1 }, (_, index) => index > 9 },

                { new[] { 1, 2, 3, 4, 5 }, (_, __) => false },
                { new[] { 1, 2, 3, 4, 5 }, (item, _) => item > 9 },
                { new[] { 1, 2, 3, 4, 5 }, (_, index) => index > 9 },
            };

        public static TheoryData<int[], int, int, Func<int, int, bool>> SkipTakePredicateAtEmpty =>
            new()
            {
                { new int[] { }, 0, 9, (_, __) => false },
                { new int[] { }, 0, 0, (_, __) => true },
                { new int[] { }, 0, 9, (item, _) => item > 9 },
                { new int[] { }, 0, 9, (_, index) => index > 9 },

                { new[] { 1 }, 0, 0, (_, __) => true },
                { new[] { 1 }, 0, 9, (_, __) => false },
                { new[] { 1 }, 0, 9, (item, _) => item > 9 },
                { new[] { 1 }, 0, 9, (_, index) => index > 9 },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, (_, __) => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (_, __) => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item > 9 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index > 9 },

                { new[] { 1, 2, 3, 4, 5 }, 2, 0, (_, __) => true },
                { new[] { 1, 2, 3, 4, 5 }, 2, 9, (_, __) => false },
                { new[] { 1, 2, 3, 4, 5 }, 2, 9, (item, _) => item > 9 },
                { new[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index > 9 },
            };

        public static TheoryData<int[], Func<int, string>> SelectorEmpty =>
            new()
            {
                { new int[] { }, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Func<int, string>> SkipTakeSelectorEmpty =>
            new()
            {
                { new int[] { }, 0, 0, item => item.ToString() },
                { new int[] { }, 0, 9, item => item.ToString() },

                { new[] { 1 }, 0, 0, item => item.ToString() },
                { new[] { 1 }, 9, 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, item => item.ToString() },
            };

        public static TheoryData<int[], Func<int, int, string>> SelectorAtEmpty =>
            new()
            {
                { new int[] { }, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], int, int, Func<int, int, string>> SkipTakeSelectorAtEmpty =>
            new()
            {
                { new int[] { }, 0, 0, (item, index) => $"{item} {index}" },
                { new int[] { }, 0, 9, (item, index) => $"{item} {index}" },

                { new[] { 1 }, 0, 0, (item, index) => $"{item} {index}" },
                { new[] { 1 }, 9, 9, (item, index) => $"{item} {index}" },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, (item, index) => $"{item} {index}" },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, string>> PredicateSelectorEmpty =>
            new()
            {
                { new int[] { }, _ => false, item => item.ToString() },
                { new int[] { }, _ => true, item => item.ToString() },

                { new[] { 1 }, _ => false, item => item.ToString() },
                { new[] { 1 }, item => item > 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, _ => false, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, item => item > 9, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, string>> SkipTakePredicateSelectorEmpty =>
            new()
            {
                { new int[] { }, 0, 9, _ => false, item => item.ToString() },
                { new int[] { }, 0, 0, _ => true, item => item.ToString() },
                { new int[] { }, 0, 9, item => item > 9, item => item.ToString() },

                { new[] { 1 }, 0, 0, _ => true, item => item.ToString() },
                { new[] { 1 }, 9, 9, _ => true, item => item.ToString() },
                { new[] { 1 }, 0, 9, _ => false, item => item.ToString() },
                { new[] { 1 }, 0, 9, item => item > 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item > 9, item => item.ToString() },
            };
    }
}
