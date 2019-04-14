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
    }
}
