using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<string> OptionSome =>
            new TheoryData<string>
            {
                { (string)null },
                { string.Empty },
                { "string" },
            };

        public static TheoryData<int[]> OptionNoneSelectMany =>
            new TheoryData<int[]>
            {
                { new int[] { } },
                { new int[] { 1 } },
                { new int[] { 1, 2, 3, 4, 5 } },
            };

        public static TheoryData<string, int[]> OptionSomeSelectMany =>
            new TheoryData<string, int[]>
            {
                { (string)null, new int[] { } },
                { (string)null, new int[] { 1 } },
                { (string)null, new int[] { 1, 2, 3, 4, 5 } },
                { string.Empty, new int[] { } },
                { string.Empty, new int[] { 1 } },
                { string.Empty, new int[] { 1, 2, 3, 4, 5 } },
                { "string", new int[] { } },
                { "string", new int[] { 1 } },
                { "string", new int[] { 1, 2, 3, 4, 5 } },
            };

    }
}