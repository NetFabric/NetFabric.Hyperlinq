using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public static partial class TestData
    {
        public static TheoryData<IReadOnlyList<int>, Func<int, string>, IReadOnlyList<string>> Select =>
            new TheoryData<IReadOnlyList<int>, Func<int, string>, IReadOnlyList<string>> 
            {
                { new int[] {}, new Func<int, string>(item => item.ToString()), new string[] {} },
                { new int[] { 1 }, new Func<int, string>(item => item.ToString()), new string[] { "1" } },
                { new int[] { 1, 2, 3 }, new Func<int, string>(item => item.ToString()), new string[] { "1", "2", "3" } },
            };

        public static TheoryData<IReadOnlyList<int>, Func<int, int>, int, IReadOnlyList<int>> SelectSkip =>
            new TheoryData<IReadOnlyList<int>, Func<int, int>, int, IReadOnlyList<int>> 
            {
                { new int[] { }, new Func<int, int>(item => item), -1, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 0, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 2, new int[] { } },

                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), -1, new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 0, new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 2, new int[] { 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 10, new int[] { } },
            };

        public static TheoryData<IReadOnlyList<int>, Func<int, int>, int, IReadOnlyList<int>> SelectTake =>
            new TheoryData<IReadOnlyList<int>, Func<int, int>, int, IReadOnlyList<int>> 
            {
                { new int[] { }, new Func<int, int>(item => item), -1, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 0, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 2, new int[] { } },

                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), -1, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 2, new int[] { 1, 2 } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 10, new int[] { 1, 2, 3, 4, 5 } },
            };

        public static TheoryData<IReadOnlyList<int>, Func<int, int>, int, int, IReadOnlyList<int>> SelectSkipTake =>
            new TheoryData<IReadOnlyList<int>, Func<int, int>, int, int, IReadOnlyList<int>> 
            {
                { new int[] { }, new Func<int, int>(item => item), -1, -1, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 0, -1, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), -1, 0, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 0, 0, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 2, 0, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 0, 2, new int[] { } },
                { new int[] { }, new Func<int, int>(item => item), 2, 2, new int[] { } },

                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), -1, -1, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 0, -1, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), -1, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 0, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 2, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 0, 2, new int[] { 1, 2 } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 2, 2, new int[] { 3, 4 } },

                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 10, 0, new int[] { } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 0, 10, new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 1, 2, 3, 4, 5 }, new Func<int, int>(item => item), 10, 10, new int[] { } },
            };    
    }
}
