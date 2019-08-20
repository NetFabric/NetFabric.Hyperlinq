using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrDefaultValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.SingleEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SingleSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SingleMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.FirstOrDefault(wrapped);

            // Act
            var result = ValueReadOnlyCollection.FirstOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>(wrapped);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SinglePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SinglePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefaultPredicate_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.FirstOrDefault(wrapped, predicate);

            // Act
            var result = ValueReadOnlyCollection.FirstOrDefault<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Should().Be(expected);
        }
    }
}