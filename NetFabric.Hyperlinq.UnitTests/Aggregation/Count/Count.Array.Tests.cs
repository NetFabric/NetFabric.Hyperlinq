using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class CountArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Count_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Count(source);

            // Act
            var result = Array
                .Count<int>(source);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.CountPredicate), MemberType = typeof(TestData))]
        public void CountPredicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Count(source, predicate.AsFunc());

            // Act
            var result = Array
                .Count<int>(source, predicate);

            // Assert
            result.Must()
                .BeEqualTo(expected);
        }
    }
}