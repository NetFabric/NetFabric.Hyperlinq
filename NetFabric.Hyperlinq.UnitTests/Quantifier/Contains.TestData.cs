using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], int, IEqualityComparer<int>> Contains =>
            new TheoryData<int[], int, IEqualityComparer<int>> 
            {
                { new int[] { }, 9, null },
                { new int[] { 1 }, 1, null },
                { new int[] { 1 }, 9, null },
                { new int[] { 1, 2, 3, 4, 5 }, 5, null },
                { new int[] { 1, 2, 3, 4, 5 }, 9, null },

                { new int[] { }, 9, EqualityComparer<int>.Default },
                { new int[] { 1 }, 1, EqualityComparer<int>.Default },
                { new int[] { 1 }, 9, EqualityComparer<int>.Default },
                { new int[] { 1, 2, 3, 4, 5 }, 5, EqualityComparer<int>.Default },
                { new int[] { 1, 2, 3, 4, 5 }, 9, EqualityComparer<int>.Default },
            };

        public static TheoryData<int[], int, int, int, IEqualityComparer<int>> SkipTakeContains =>
            new TheoryData<int[], int, int, int, IEqualityComparer<int>> 
            {
                { new int[] { }, 0, 9, 9, null },
                { new int[] { 1 }, 0, 9, 1, null },
                { new int[] { 1 }, 0, 9, 9, null },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, 5, null },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, 9, null },

                { new int[] { }, 0, 9, 5, EqualityComparer<int>.Default },
                { new int[] { 1 }, 0, 9, 1, EqualityComparer<int>.Default },
                { new int[] { 1 }, 0, 9, 9, EqualityComparer<int>.Default },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, 5, EqualityComparer<int>.Default },
                { new int[] { 1, 2, 3, 4, 5 }, 0, 9, 9, EqualityComparer<int>.Default },

                { new int[] { 1, 2, 3, 4, 5 }, 9, 9, 5, null },

                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 1, null },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 2, null },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 4, null },
                { new int[] { 1, 2, 3, 4, 5 }, 1, 3, 5, null },
            };
    }
}
