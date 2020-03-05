using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Count
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = 
                System.Linq.Enumerable.Count(source);

            // Act
            var result = ValueReadOnlyCollection
                .Count<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}