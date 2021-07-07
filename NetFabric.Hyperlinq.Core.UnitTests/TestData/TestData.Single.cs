using System;
using Xunit;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Single =>
            new()
            {
                new[] { 1 }
            };

        public static TheoryData<int[], int> SkipSingle =>
            new()
            {
                { new[] { 1 }, -1 },
                { new[] { 1 }, 0 },

                { new[] { 0, 1, 2 }, 2 }
            };

        public static TheoryData<int[], int> TakeSingle =>
            new()
            {
                { new[] { 1 }, 1 },

                { new[] { 1, 2, 3, 4, 5 }, 1 }
            };

        public static TheoryData<int[], int, int> SkipTakeSingle =>
            new()
            {
                { new[] { 1 }, -1, 1 },
                { new[] { 1 }, 0, 1 },

                { new[] { 1, 2, 3, 4, 5 }, -1, 1 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 1 },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1 },
                { new[] { 1, 2, 3, 4, 5 }, 4, 1 }
            };

        public static TheoryData<int[], int, int> TakeSkipSingle =>
            new()
            {
                { new[] { 1 }, 1, -1 },
                { new[] { 1 }, 1, 0 },

                { new[] { 1, 2, 3, 4, 5 }, 1, -1 },
                { new[] { 1, 2, 3, 4, 5 }, 1, 0 },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1 },
            };

        public static TheoryData<int[], Func<int, bool>> PredicateSingle =>
            new()
            {
                { new[] { 1 }, _ => true },
                { new[] { 1 }, item => item == 1 },

                { new[] { 1, 2, 3, 4, 5 }, item => item == 1 },
                { new[] { 1, 2, 3, 4, 5 }, item => item == 3 },
                { new[] { 1, 2, 3, 4, 5 }, item => item == 5 }
            };

        public static TheoryData<int[], int, int, Func<int, bool>> SkipTakePredicateSingle =>
            new()
            {
                { new[] { 1 }, -1, 9, _ => true },
                { new[] { 1 }, 0, 1, _ => true },
                { new[] { 1 }, 0, 9, _ => true },
                { new[] { 1 }, 0, 9, item => item == 1 },

                { new[] { 1, 2, 3, 4, 5 }, -1, 1, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 1, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 4, 1, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 1 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 3 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 5 }
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, bool>> PredicatePredicateSingle =>
            new()
            {
                { new[] { 1 }, _ => true, _ => true },

                { new[] { 1, 2, 3, 4, 5 }, item => item == 3, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, _ => true, item => item == 3 }
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>> SkipTakePredicatePredicateSingle =>
            new()
            {
                { new[] { 1 }, 0, 9, _ => true, _ => true },

                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 3, _ => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, item => item == 3 }
            };

        public static TheoryData<int[], Func<int, int, bool>> PredicateAtSingle =>
            new()
            {
                { new[] { 1 }, (_, __) => true },
                { new[] { 1 }, (item, _) => item == 1 },
                { new[] { 1 }, (_, index) => index == 0 },

                { new[] { 1, 2, 3, 4, 5 }, (item, _) => item == 1 },
                { new[] { 1, 2, 3, 4, 5 }, (item, _) => item == 3 },
                { new[] { 1, 2, 3, 4, 5 }, (item, _) => item == 5 },
                { new[] { 1, 2, 3, 4, 5 }, (_, index) => index == 0 },
                { new[] { 1, 2, 3, 4, 5 }, (_, index) => index == 2 },
                { new[] { 1, 2, 3, 4, 5 }, (_, index) => index == 4 }
            };

        public static TheoryData<int[], int, int, Func<int, int, bool>> SkipTakePredicateAtSingle =>
            new()
            {
                { new[] { 1 }, -1, 1, (_, __) => true },
                { new[] { 1 }, 0, 1, (_, __) => true },
                { new[] { 1 }, 0, 1, (item, _) => item == 1 },
                { new[] { 1 }, 0, 1, (_, index) => index == 0 },

                { new[] { 1 }, -1, 9, (_, __) => true },
                { new[] { 1 }, 0, 9, (_, __) => true },
                { new[] { 1 }, 0, 9, (item, _) => item == 1 },
                { new[] { 1 }, 0, 9, (_, index) => index == 0 },

                { new[] { 1, 2, 3, 4, 5 }, -1, 1, (_, __) => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 1, (_, __) => true },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1, (_, __) => true },
                { new[] { 1, 2, 3, 4, 5 }, 4, 1, (_, __) => true },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item == 1 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item == 3 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (item, _) => item == 5 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index == 0 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index == 2 },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, (_, index) => index == 4 },
                { new[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index == 0 },
                { new[] { 1, 2, 3, 4, 5 }, 2, 9, (_, index) => index == 2 }
            };

        public static TheoryData<int[], Func<int, string>> SelectorSingle =>
            new()
            {
                { new[] { 1 }, item => item.ToString() }
            };

        public static TheoryData<int[], int, int, Func<int, string>> SkipTakeSelectorSingle =>
            new()
            {
                { new[] { 1 }, 0, 1, item => item.ToString() },

                { new[] { 1 }, -1, 9, item => item.ToString() },
                { new[] { 1 }, 0, 9, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, 0, 1, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 4, 1, item => item.ToString() }
            };

        public static TheoryData<int[], Func<int, int, string>> SelectorAtSingle =>
            new()
            {
                { new[] { 1 }, (item, index) => $"{item} {index}" }
            };

        public static TheoryData<int[], int, int, Func<int, int, string>> SkipTakeSelectorAtSingle =>
            new()
            {
                { new[] { 1 }, -1, 1, (item, index) => $"{item} {index}" },
                { new[] { 1 }, 0, 1, (item, index) => $"{item} {index}" },

                { new[] { 1 }, -1, 9, (item, index) => $"{item} {index}" },
                { new[] { 1 }, 0, 9, (item, index) => $"{item} {index}" },

                { new[] { 1, 2, 3, 4, 5 }, 0, 1, (item, index) => $"{item} {index}" },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1, (item, index) => $"{item} {index}" },
                { new[] { 1, 2, 3, 4, 5 }, 4, 1, (item, index) => $"{item} {index}" }
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, string>> PredicateSelectorSingle =>
            new()
            {
                { new[] { 1 }, _ => true, item => item.ToString() },
                { new[] { 1 }, item => item == 1, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, item => item == 1, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, item => item == 3, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, item => item == 5, item => item.ToString() }
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, string>> SkipTakePredicateSelectorSingle =>
            new()
            {
                { new[] { 1 }, -1, 1, _ => true, item => item.ToString() },
                { new[] { 1 }, 0, 1, _ => true, item => item.ToString() },
                { new[] { 1 }, 0, 1, item => item == 1, item => item.ToString() },

                { new[] { 1 }, -1, 9, _ => true, item => item.ToString() },
                { new[] { 1 }, 0, 9, _ => true, item => item.ToString() },
                { new[] { 1 }, 0, 9, item => item == 1, item => item.ToString() },

                { new[] { 1, 2, 3, 4, 5 }, -1, 1, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 1, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 2, 1, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 4, 1, _ => true, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 1, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 3, item => item.ToString() },
                { new[] { 1, 2, 3, 4, 5 }, 0, 9, item => item == 5, item => item.ToString() }
            };
    }
}
