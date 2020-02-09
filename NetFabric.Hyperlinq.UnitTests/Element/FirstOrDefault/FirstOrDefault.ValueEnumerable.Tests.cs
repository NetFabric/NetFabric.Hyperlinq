using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrDefaultValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(wrapped);

            // Act
            var result = ValueEnumerable
                .FirstOrDefault<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefaultPredicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(wrapped, predicate.AsFunc());

            // Act
            var result = ValueEnumerable
                .FirstOrDefault<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}