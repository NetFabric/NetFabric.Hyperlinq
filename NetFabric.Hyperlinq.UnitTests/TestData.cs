using Xunit;

namespace NetFabric.Hyperlinq
{
    public static partial class TestData
    {
        public static TheoryData<int[]> Empty =>
            new TheoryData<int[]>
            {
                { new int[] { } },
            };

        public static TheoryData<int[]> Single =>
            new TheoryData<int[]>
            {
                { new int[] { 5 } },
            };

        public static TheoryData<int[]> Multiple =>
            new TheoryData<int[]> 
            {
                { new int[] { 1, 2, 3, 4, 5 } },
                { new int[] { 3, 1, 4, 5, 2, 3, 1, 4, 5, 2 } },
            };
    }
}
