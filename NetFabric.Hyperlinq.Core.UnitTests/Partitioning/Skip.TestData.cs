using System;
using Xunit;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int, int> Skip_Skip =>
            new()
            {
                { Array.Empty<int>(), -1, -1 },
                { Array.Empty<int>(), 0, -1 },
                { Array.Empty<int>(), 1, -1 },

                { Array.Empty<int>(), -1, 0 },
                { Array.Empty<int>(), 0, 0 },
                { Array.Empty<int>(), 1, 0 },

                { new[] { 1 }, -1, -1 },
                { new[] { 1 }, 0, 0 },
                { new[] { 1 }, 1, 1 },
                { new[] { 1 }, 5, 5 },

                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, -1 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 0 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 2 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 5, 5 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 10, 10 },
                { new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 20, 20 }
            };
    }
}
