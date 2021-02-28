using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Aggregation.Count
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = source
                .Count();

            // Act
            var result = wrapped
                .Count<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Count_Predicate_With_ValidData_Must_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = source
                .Count(predicate);

            // Act
            var result = wrapped
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(predicate)
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Count_PredicateAt_With_ValidData_Must_Succeed(int[] source, Func<int, int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = source
                .Where(predicate)
                .Count();

            // Act
            var result = wrapped
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(predicate)
                .Count();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}