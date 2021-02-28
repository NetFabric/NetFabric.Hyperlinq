using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Any
{
    public class ReadOnlySpanTests
    {

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Any();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Any(predicate);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Any(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = (ReadOnlySpan<int>)source.AsSpan();
            var expected = source
                .Where(predicate).Count() != 0;

            // Act
            var result = wrapped.AsValueEnumerable()
                .Any(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}