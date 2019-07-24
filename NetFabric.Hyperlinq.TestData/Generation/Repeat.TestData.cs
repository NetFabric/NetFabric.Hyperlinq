using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int, int> Repeat =>
            new TheoryData<int, int> 
            {
                { 0, 0 },
                { 0, 1 },
                { 0, 5 },
                { 5, 5 },
            };

        public static TheoryData<int, int, int, int> RepeatSkipTake =>
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
