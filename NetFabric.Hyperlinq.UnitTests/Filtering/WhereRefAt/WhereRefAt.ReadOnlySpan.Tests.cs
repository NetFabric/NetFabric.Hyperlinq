using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereRefIndex
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void WhereAtRef_With_ValidData_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var function = Wrap.AsFunctionIn(predicate);
            var expected = Enumerable
                .Where(source, predicate);

            // Act
            var result = ArrayExtensions
                .Where((ReadOnlySpan<int>)source.AsSpan(), function);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}