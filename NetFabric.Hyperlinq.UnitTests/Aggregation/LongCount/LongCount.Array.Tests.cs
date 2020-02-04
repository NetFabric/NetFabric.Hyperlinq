using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class LongCountArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void LongCount_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.LongCount(source);

            // Act
            var result = Array.LongCount<int>(source);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void LongCount_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => Array
                .LongCount<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Predicate), MemberType = typeof(TestData))]
        public void LongCount_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.LongCount(source, predicate.AsFunc());

            // Act
            var result = Array
                .LongCount<int>(source, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void LongCount_PredicateAt_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (PredicateAtLong<int>)null;

            // Act
            Action action = () => Array
                .LongCount<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtLong), MemberType = typeof(TestData))]
        public void LongCount_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAtLong<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.LongCount(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = Array
                .LongCount<int>(source, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}