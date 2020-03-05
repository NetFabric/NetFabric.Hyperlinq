using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.ElementAtOrDefault
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.ElementAtOutOfRange), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_OutOfRange_Must_ReturnDefault(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);

            // Act
            var result = ValueReadOnlyCollection
                .ElementAtOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, index);

            // Assert
            _ = result.Must()
                .BeEqualTo(default);
        }

        [Theory]
        [MemberData(nameof(TestData.ElementAt), MemberType = typeof(TestData))]
        public void ElementAtOrDefault_With_ValidData_Must_Succeed(int[] source, int index)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.ElementAtOrDefault(wrapped, index);

            // Act
            var result = ValueReadOnlyCollection
                .ElementAtOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}