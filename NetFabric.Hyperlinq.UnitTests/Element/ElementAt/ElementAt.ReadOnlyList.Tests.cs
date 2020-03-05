using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAt
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAt_With_OutOfRange_Must_Throw(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);

            // Act
            Action action = () => _ = ReadOnlyList
                .ElementAt<Wrap.ValueReadOnlyList<int>, int>(wrapped, index);

            // Assert
            _ = action.Must()
                .Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAt_With_ValidData_Must_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.ElementAt(wrapped, index);

            // Act
            var result = ReadOnlyList
                .ElementAt<Wrap.ValueReadOnlyList<int>, int>(wrapped, index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}