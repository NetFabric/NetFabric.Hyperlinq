using System;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<string?> OptionSome =>
            new()
            {
                default,
                string.Empty,
                "string",
            };

        public static TheoryData<int[]> OptionNoneSelectMany =>
            new()
            {
                new int[] { },
                new[] { 1 },
                new[] { 1, 2, 3, 4, 5 },
            };

        public static TheoryData<string?, int[]> OptionSomeSelectMany =>
            new()
            {
                { default, new int[] { } },
                { default, new[] { 1 } },
                { default, new[] { 1, 2, 3, 4, 5 } },
                { string.Empty, new int[] { } },
                { string.Empty, new[] { 1 } },
                { string.Empty, new[] { 1, 2, 3, 4, 5 } },
                { "string", new int[] { } },
                { "string", new[] { 1 } },
                { "string", new[] { 1, 2, 3, 4, 5 } },
            };

    }
}