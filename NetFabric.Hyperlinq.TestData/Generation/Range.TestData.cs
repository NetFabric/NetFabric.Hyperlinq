using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int, int> Range =>
            new TheoryData<int, int> 
            {
                { -1, 0 },
                { 0, 0 },
                { 0, 1 },

                { -1, 1 },
                { -1, 5 },
                { 1, 5 },
            };

        public static TheoryData<int, int, int, int> RangeSkipTake =>
            new TheoryData<int, int, int, int> 
            {
                { 1, 5, 0, 0 },
                { 1, 5, -1, 0 },
                { 1, 5, 0, -1 },
                { 1, 5, -1, -1 },
                { 1, 5, 0, 2 },
                { 1, 5, 0, 10 },
                { 1, 5, 2, 2 },
                { 1, 5, 2, 10 },
            };
    }
}
