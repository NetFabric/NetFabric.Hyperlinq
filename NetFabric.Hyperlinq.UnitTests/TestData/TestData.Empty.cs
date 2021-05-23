using System;
using Xunit;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Empty =>
            new()
            {
                Array.Empty<int>()
            };

        public static TheoryData<int[], int> SkipEmpty =>
            new()
            {
                { Array.Empty<int>(), -1 },
                { Array.Empty<int>(), 0 },
                { Array.Empty<int>(), 1 },

                { new[] { 1 }, 1 },
                { new[] { 1 }, 5 },

                { new[] { 0, 1, 2 }, 3 },
                { new[] { 0, 1, 2 }, 5 }
            };

        public static TheoryData<int[], int> TakeEmpty =>
            new()
            {
                { Array.Empty<int>(), -1 },
                { Array.Empty<int>(), 0 },
                { Array.Empty<int>(), 1 },

                { new[] { 5 }, -1 },
                { new[] { 5 }, 0 },

                { new[] { 0, 1, 2, 3, 4, 5 }, -1 },
                { new[] { 0, 1, 2, 3, 4, 5 }, 0 }
            };

        public static TheoryData<int[], int, int> SkipTakeEmpty =>
            new()
            {
                { Array.Empty<int>(), -1, -1 },
                { Array.Empty<int>(), -1, 0 },
                { Array.Empty<int>(), 0, -1 },
                { Array.Empty<int>(), 0, 0 },
                { Array.Empty<int>(), 0, 9 },
                { Array.Empty<int>(), 1, 0 },
                { Array.Empty<int>(), 1, 9 },

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
                { new[] { 1, 2, 3, 4, 5 }, 9, 9 }
            };

        public static TheoryData<int[], int, int> TakeSkipEmpty =>
            new()
            {
                { Array.Empty<int>(), -1, -1 },
                { Array.Empty<int>(), -1, 0 },
                { Array.Empty<int>(), 0, -1 },
                { Array.Empty<int>(), 0, 0 },
                { Array.Empty<int>(), 9, 0 },
                { Array.Empty<int>(), 0, 1 },
                { Array.Empty<int>(), 9, 1 },

                { new[] { 1 }, -1, -1 },
                { new[] { 1 }, -1, 0 },
                { new[] { 1 }, 0, -1 },
                { new[] { 1 }, 0, 0 },
                { new[] { 1 }, 0, 1 },
                { new[] { 1 }, 9, 1 },

                { new[] { 1, 2, 3, 4, 5 }, -1, -1 },
                { new[] { 1, 2, 3, 4, 5 }, -1, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 0, -1 },
                { new[] { 1, 2, 3, 4, 5 }, -1, 2 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 2 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9 },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9 }
            };

        public static TheoryData<int[], Func<int, bool>> PredicateEmpty =>
            new()
            {
                { Array.Empty<int>(), _ => false },
                { Array.Empty<int>(), _ => true },

                { new[] { 1 }, _ => false },
                { new[] { 1 }, item => item > 9 },

                { new[] { 1, 2, 3, 4, 5 }, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, item => item > 9 }
            };

        public static TheoryData<int[], int, int, Func<int, bool>> SkipTakePredicateEmpty =>
            new()
            {
                { Array.Empty<int>(), 0, 9, _ => false },
                { Array.Empty<int>(), 0, 0, _ => true },
                { Array.Empty<int>(), 0, 9, item => item > 9 },

                { new[] { 1 }, 0, 0, _ => true },
                { new[] { 1 }, 9, 9, _ => true },
                { new[] { 1 }, 0, 9, _ => false },
                { new[] { 1 }, 0, 9, item => item > 9 },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item > 9 }
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, bool>> PredicatePredicateEmpty =>
            new()
            {
                { Array.Empty<int>(), _ => true, _ => true },

                { new[] { 1, 2, 3, 4, 5 }, _ => false, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, _ => true, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, _ => false, _ => true }
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>> SkipTakePredicatePredicateEmpty =>
            new()
            {
                { Array.Empty<int>(), 0, 9, _ => true, _ => true },

                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, _ => false },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, _ => true }
            };

        public static TheoryData<int[], Func<int, int, bool>> PredicateAtEmpty =>
            new()
            {
                { Array.Empty<int>(), (_, __) => false },
                { Array.Empty<int>(), (_, __) => true },

                { new[] { 1 }, (_, __) => false },
                { new[] { 1 }, (item, _) => item > 9 },
                { new[] { 1 }, (_, index) => index > 9 },

                { new[] { 1, 2, 3, 4, 5 }, (_, __) => false },
                { new[] { 1, 2, 3, 4, 5 }, (item, _) => item > 9 },
                { new[] { 1, 2, 3, 4, 5 }, (_, index) => index > 9 }
            };

        public static TheoryData<int[], int, int, Func<int, int, bool>> SkipTakePredicateAtEmpty =>
            new()
            {
                { Array.Empty<int>(), 0, 9, (_, __) => false },
                { Array.Empty<int>(), 0, 0, (_, __) => true },
                { Array.Empty<int>(), 0, 9, (item, _) => item > 9 },
                { Array.Empty<int>(), 0, 9, (_, index) => index > 9 },

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
                { new[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index > 9 }
            };

        public static TheoryData<int[], Func<int, string>> SelectorEmpty =>
            new()
            {
                { Array.Empty<int>(), item => item.ToString() }
            };

        public static TheoryData<int[], int, int, Func<int, string>> SkipTakeSelectorEmpty =>
            new()
            {
                { Array.Empty<int>(), 0, 0, item => item.ToString() },
                { Array.Empty<int>(), 0, 9, item => item.ToString() },

                { new[] { 1 }, 0, 0, item => item.ToString() },
                { new[] { 1 }, 9, 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, item => item.ToString() }
            };

        public static TheoryData<int[], Func<int, int, string>> SelectorAtEmpty =>
            new()
            {
                { Array.Empty<int>(), (item, index) => $"{item} {index}" }
            };

        public static TheoryData<int[], int, int, Func<int, int, string>> SkipTakeSelectorAtEmpty =>
            new()
            {
                { Array.Empty<int>(), 0, 0, (item, index) => $"{item} {index}" },
                { Array.Empty<int>(), 0, 9, (item, index) => $"{item} {index}" },

                { new[] { 1 }, 0, 0, (item, index) => $"{item} {index}" },
                { new[] { 1 }, 9, 9, (item, index) => $"{item} {index}" },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, (item, index) => $"{item} {index}" },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, (item, index) => $"{item} {index}" }
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, string>> PredicateSelectorEmpty =>
            new()
            {
                { Array.Empty<int>(), _ => false, item => item.ToString() },
                { Array.Empty<int>(), _ => true, item => item.ToString() },

                { new[] { 1 }, _ => false, item => item.ToString() },
                { new[] { 1 }, item => item > 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, _ => false, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, item => item > 9, item => item.ToString() }
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, string>> SkipTakePredicateSelectorEmpty =>
            new()
            {
                { Array.Empty<int>(), 0, 9, _ => false, item => item.ToString() },
                { Array.Empty<int>(), 0, 0, _ => true, item => item.ToString() },
                { Array.Empty<int>(), 0, 9, item => item > 9, item => item.ToString() },

                { new[] { 1 }, 0, 0, _ => true, item => item.ToString() },
                { new[] { 1 }, 9, 9, _ => true, item => item.ToString() },
                { new[] { 1 }, 0, 9, _ => false, item => item.ToString() },
                { new[] { 1 }, 0, 9, item => item > 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, 0, 0, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 9, 9, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => false, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item > 9, item => item.ToString() }
            };
    }
}
