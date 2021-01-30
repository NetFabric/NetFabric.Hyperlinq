using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereRef
{
    public class SpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void WhereRef_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var function = Wrap.AsFunctionIn(predicate);
            var expected = Enumerable
                .Where(source, predicate);

            // Act
            var result = ArrayExtensions
                .Where(source.AsSpan(), function);

            // Assert
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}