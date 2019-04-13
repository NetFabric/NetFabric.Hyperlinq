using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public static partial class TestData
    {
        public static TheoryData<IReadOnlyList<int>, int, int, IReadOnlyList<int>> SkipTake =>
            new TheoryData<IReadOnlyList<int>, int, int, IReadOnlyList<int>> 
            {
                { new int[] { }, -1, -1, new int[] { } },
                { new int[] { }, -1, 0, new int[] { } },
                { new int[] { }, 0, -1, new int[] { } },
                { new int[] { }, 0, 0, new int[] { } },
                { new int[] { }, 1, 1,  new int[] { } },

                { new int[] { 1 }, -1, -1, new int[] { } },
                { new int[] { 1 }, -1, 0, new int[] { } },
                { new int[] { 1 }, 0, -1, new int[] { } },
                { new int[] { 1 }, 0, 0, new int[] { } },
                { new int[] { 1 }, 1, 0, new int[] { } },
                { new int[] { 1 }, 0, 1, new int[] { 1 } },
                { new int[] { 1 }, 1, 1, new int[] { } },
                { new int[] { 1 }, 5, 0, new int[] { } },
                { new int[] { 1 }, 0, 5, new int[] { 1 } },
                { new int[] { 1 }, 5, 5, new int[] { } },

                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, -1,  new int[] { }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, -1, 5,  new int[] { 0, 1, 2, 3, 4 }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, -1,  new int[] { }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 0,  new int[] { }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 0,  new int[] { }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 0, 5,  new int[] { 0, 1, 2, 3, 4 }},
                { new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2, 5,  new int[] { 2, 3, 4, 5, 6 }},
            };
    }
}
