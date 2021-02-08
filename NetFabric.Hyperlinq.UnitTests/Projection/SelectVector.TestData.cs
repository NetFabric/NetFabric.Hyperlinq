using System;
using System.Numerics;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
#if NET5_0

        public static TheoryData<int[], Func<Vector<int>, Vector<int>>, Func<int, int>> SelectVector =>
            new TheoryData<int[], Func<Vector<int>, Vector<int>>, Func<int, int>>
            {
                //{ new int[] { }, item => item * 2, item => item * 2 },
                //{ new int[] { 0, }, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4, 5}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4, 5, 6}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4, 5, 6, 7}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9}, item => item * 2, item => item * 2 },
                //{ new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, item => item * 2, item => item * 2 },
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18}, item => item * 2, item => item * 2 },
            };

#endif
    }
}
