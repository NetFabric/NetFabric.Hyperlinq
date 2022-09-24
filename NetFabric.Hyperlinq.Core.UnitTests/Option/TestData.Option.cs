using System;
using Xunit;

// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<string?> OptionSome =>
            new()
            {
                default,
                string.Empty,
                "string"
            };

        public static TheoryData<int[]> OptionNoneSelectMany =>
            new()
            {
                Array.Empty<int>(),
                new[] { 1 },
                new[] { 1, 2, 3, 4, 5 }
            };

        public static TheoryData<string?, int[]> OptionSomeSelectMany =>
            new()
            {
                { default, Array.Empty<int>() },
                { default, new[] { 1 } },
                { default, new[] { 1, 2, 3, 4, 5 } },
                { string.Empty, Array.Empty<int>() },
                { string.Empty, new[] { 1 } },
                { string.Empty, new[] { 1, 2, 3, 4, 5 } },
                { "string", Array.Empty<int>() },
                { "string", new[] { 1 } },
                { "string", new[] { 1, 2, 3, 4, 5 } }
            };

    }
}