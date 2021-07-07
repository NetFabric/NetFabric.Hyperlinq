using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int, int> Range =>
            new()
            {
                { -1, 0 },
                { 0, 0 },
                { 0, 1 },

                { -1, 1 },
                { -1, 20 },
                { 1, 20 }
            };

        public static TheoryData<int, int, int> Range_SkipTake =>
            new()
            {
                { 1, 5, -1 },
                { 1, 5, 0 },
                { 1, 5, 1 },
                { 1, 5, 2 },
                { 1, 5, 20 }
            };

        public static TheoryData<int, int, int> Range_Contains =>
            new()
            {
                { 0, 0, 0 },
                { 1, 5, -1 },
                { 1, 5, 0 },
                { 1, 5, 1 },
                { 1, 5, 4 },
                { 1, 5, 5 },
                { 1, 5, 20 }
            };
    }
}
