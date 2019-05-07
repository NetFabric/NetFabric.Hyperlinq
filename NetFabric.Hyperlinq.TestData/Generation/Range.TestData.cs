using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<long, long, long[]> Range =>
            new TheoryData<long, long, long[]> 
            {
                { -1, 0, new long[] { } },
                { 0, 0, new long[] { } },
                { 0, 1, new long[] { 0 } },

                { -1, 1, new long[] { -1 } },
                { -1, 5, new long[] { -1, 0, 1, 2, 3 } },
                { 1, 5, new long[] { 1, 2, 3, 4, 5 } },
            };

        public static TheoryData<long, long, long, long[]> RangeSkip =>
            new TheoryData<long, long, long, long[]> 
            {
                { 1, 5, -1, new long[] { 1, 2, 3, 4, 5 } },
                { 1, 5, 0, new long[] { 1, 2, 3, 4, 5 } },
                { 1, 5, 2, new long[] { 3, 4, 5 } },
                { 1, 5, 10, new long[] { } },
            };

        public static TheoryData<long, long, long, long[]> RangeTake =>
            new TheoryData<long, long, long, long[]> 
            {
                { 1, 5, -1, new long[] { } },
                { 1, 5, 0, new long[] { } },
                { 1, 5, 2, new long[] { 1, 2 } },
                { 1, 5, 10, new long[] { 1, 2, 3, 4, 5} },
            };

        public static TheoryData<long, long, long, long, long[]> RangeSkipTake =>
            new TheoryData<long, long, long, long, long[]> 
            {
                { 1, 5, 0, 0, new long[] { } },
                { 1, 5, -1, 0, new long[] { } },
                { 1, 5, 0, -1, new long[] { } },
                { 1, 5, -1, -1, new long[] { } },
                { 1, 5, 0, 2, new long[] { 1, 2 } },
                { 1, 5, 0, 10, new long[] { 1, 2, 3, 4, 5} },
                { 1, 5, 2, 2, new long[] { 3, 4 } },
                { 1, 5, 2, 10, new long[] { 3, 4, 5} },
            };
    }
}
