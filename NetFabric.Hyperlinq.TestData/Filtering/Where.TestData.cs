using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[], Func<int, long, bool>, int[]> Where =>
            new TheoryData<int[], Func<int, long, bool>, int[]> 
            {
                { new int[] { }, (_, __) => false, new int[] { } },
                { new int[] { 1 }, (_, __) => false, new int[] { } },
                { new int[] { 1, 2, 3 }, (_, __) => false, new int[] { } },

                { new int[] {}, (_, __) => true, new int[] { } },
                { new int[] { 1 }, (_, __) => true, new int[] { 1 } },
                { new int[] { 1, 2, 3 }, (_, __) => true, new int[] { 1, 2, 3 } },

                { new int[] {}, (item, _) => item == 2, new int[] { } },
                { new int[] { 1 }, (item, _) => item == 2, new int[] { } },
                { new int[] { 1, 2, 3 }, (item, _) => item == 2, new int[] { 2 } },

                { new int[] {}, (_, index) => index == 2, new int[] { } },
                { new int[] { 1 }, (_, index) => index == 2, new int[] { } },
                { new int[] { 1, 2, 3 }, (_, index) => index == 2, new int[] { 3 } },
            };

        public static TheoryData<int[], Func<int, long, bool>, Func<int, long, string>, string[]> WhereSelect =>
            new TheoryData<int[], Func<int, long, bool>, Func<int, long, string>, string[]> 
            {
                { new int[] { }, (_, __) => false, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1 }, (_, __) => false, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1, 2, 3 }, (_, __) => false, (item, _) => item.ToString(), new string[] { } },

                { new int[] {}, (_, __) => true, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1 }, (_, __) => true, (item, _) => item.ToString(), new string[] { "1" } },
                { new int[] { 1, 2, 3 }, (_, __) => true, (item, _) => item.ToString(), new string[] { "1", "2", "3" } },

                { new int[] {}, (item, _) => item == 2, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1 }, (item, _) => item == 2, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1, 2, 3 }, (item, _) => item == 2, (item, _) => item.ToString(), new string[] { "2" } },
                { new int[] { 1, 2, 3 }, (item, _) => item == 2, (_, index) => index.ToString(), new string[] { "1" } },

                { new int[] {}, (_, index) => index == 2, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1 }, (_, index) => index == 2, (item, _) => item.ToString(), new string[] { } },
                { new int[] { 1, 2, 3 }, (_, index) => index == 2, (item, _) => item.ToString(), new string[] { "3" } },
            };
    }
}
