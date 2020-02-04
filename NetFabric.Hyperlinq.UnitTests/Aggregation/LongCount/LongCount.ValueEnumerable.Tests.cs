using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class LongCountValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void LongCount_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.LongCount(wrapped);

            // Act
            var result = ValueEnumerable
                .LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void LongCount_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => ValueEnumerable
                .LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

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
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.LongCount(wrapped, predicate.AsFunc());

            // Act
            var result = ValueEnumerable
                .LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void LongCount_PredicateAt_With_Null_Should_Throw()
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(new int[0]);
            var predicate = (PredicateAtLong<int>)null;

            // Act
            Action action = () => ValueEnumerable
                .LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

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
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.LongCount(
                    System.Linq.Enumerable.Where(wrapped, predicate.AsFunc()));

            // Act
            var result = ValueEnumerable
                .LongCount<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}