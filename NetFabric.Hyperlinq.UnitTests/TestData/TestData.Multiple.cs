using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Multiple =>
            new TheoryData<int[]>
            {
                { new int[] { 1, 2, 3, 4, 5 } },
            };

        public static TheoryData<int[], int> SkipMultiple =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1 },
                { new int[] { 1, 2, 3, 4, 5 }, 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 2 },
            };

        public static TheoryData<int[], int> TakeMultiple =>
            new TheoryData<int[], int> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 9 },
            };

        public static TheoryData<int[], int, int> SkipTakeMultiple =>
            new TheoryData<int[], int, int> 
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2 },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 3 },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9 },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9 },
            };

        public static TheoryData<int[], Func<int, bool>> PredicateMultiple =>
            new TheoryData<int[], Func<int, bool>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 1 },
            };

        public static TheoryData<int[], int, int, Func<int, bool>> SkipTakePredicateMultiple =>
            new TheoryData<int[], int, int, Func<int, bool>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1, 2, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 3, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, _ => true },

                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 4, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 4, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 9, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 7, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 20, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 20, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 20, item => (item & 0x01) == 0 },

                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 4, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 4, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 9, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 7, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 20, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 20, item => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 20, item => (item & 0x01) == 1 },
            };


        public static TheoryData<int[], Func<int, bool>, Func<int, bool>> PredicatePredicateMultiple =>
            new TheoryData<int[], Func<int, bool>, Func<int, bool>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, _ => true, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, _ => true, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 1, _ => true },
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>> SkipTakePredicatePredicateMultiple =>
            new TheoryData<int[], int, int, Func<int, bool>, Func<int, bool>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, _ => true },

                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, item => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => (item & 0x01) == 1, _ => true },
            };

        public static TheoryData<int[], Func<int, int, bool>> PredicateAtMultiple =>
            new TheoryData<int[], Func<int, int, bool>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5 }, (_, index) => (index & 0x01) == 1 },
            };

        public static TheoryData<int[], int, int, Func<int, int, bool>> SkipTakePredicateAtMultiple =>
            new TheoryData<int[], int, int, Func<int, int, bool>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 3, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (_, __) => true },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (_, __) => true },

                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 4, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 4, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 9, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 7, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 20, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 20, (item, _) => (item & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 20, (item, _) => (item & 0x01) == 0 },

                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 4, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 4, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 9, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 7, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 20, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 20, (item, _) => (item & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 20, (item, _) => (item & 0x01) == 1 },

                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 4, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 4, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 9, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 7, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 20, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 20, (_, index) => (index & 0x01) == 0 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 20, (_, index) => (index & 0x01) == 0 },
                
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 4, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 4, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 4, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 9, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 9, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 7, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 20, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 20, (_, index) => (index & 0x01) == 1 },
                { new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 20, (_, index) => (index & 0x01) == 1 },
            };

        public static TheoryData<int[], Func<int, string>> SelectorMultiple =>
            new TheoryData<int[], Func<int, string>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Func<int, string>> SkipTakeSelectorMultiple =>
            new TheoryData<int[], int, int, Func<int, string>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1, 2, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 3, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, item => item.ToString() },
            };

        public static TheoryData<int[], Func<int, int, string>> SelectorAtMultiple =>
            new TheoryData<int[], Func<int, int, string>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], int, int, Func<int, int, string>> SkipTakeSelectorAtMultiple =>
            new TheoryData<int[], int, int, Func<int, int, string>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1, 2, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 3, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, (item, index) => $"{item} {index}" },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, (item, index) => $"{item} {index}" },
            };

        public static TheoryData<int[], Func<int, bool>, Func<int, string>> PredicateSelectorMultiple =>
            new TheoryData<int[], Func<int, bool>, Func<int, string>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 0, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, item => (item & 0x01) == 1, item => item.ToString() },
            };

        public static TheoryData<int[], int, int, Func<int, bool>, Func<int, string>> SkipTakePredicateSelectorMultiple =>
            new TheoryData<int[], int, int, Func<int, bool>, Func<int, string>>
            {
                { new int[] { 1, 2, 3, 4, 5 }, -1, 2, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 2, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 2, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 3, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, _ => true, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 2, 9, _ => true, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, item => (item & 0x01) == 0, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, item => (item & 0x01) == 0, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, item => (item & 0x01) == 0, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => (item & 0x01) == 0, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 9, item => (item & 0x01) == 0, item => item.ToString() },

                { new int[] { 1, 2, 3, 4, 5 }, -1, 5, item => (item & 0x01) == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 5, item => (item & 0x01) == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, -1, 9, item => (item & 0x01) == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, item => (item & 0x01) == 1, item => item.ToString() },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 9, item => (item & 0x01) == 1, item => item.ToString() },
            };
    }
}
