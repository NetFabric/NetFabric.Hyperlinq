using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int, int> Repeat =>
            new()
            {
                { 1, 0 },
                { 1, 1 },
                { 1, 5 },
            };

        public static TheoryData<int, int, int> Repeat_SkipTake =>
            new()
            {
                { 1, 0, 0 },
                { 1, 5, -1 },
                { 1, 5, 0 },
                { 1, 5, 1 },
                { 1, 5, 4 },
                { 1, 5, 5 },
                { 1, 5, 10 }
            };
    }
}
