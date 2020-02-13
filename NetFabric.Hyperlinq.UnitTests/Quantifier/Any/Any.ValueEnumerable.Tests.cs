using System;
using System.Collections.Generic;
using System.Diagnostics;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class AnyValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Any(source);

            // Act
            var result = ValueEnumerable
                .Any<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = 
                ValueEnumerable.Any<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Any(source, predicate.AsFunc());

            // Act
            var result = ValueEnumerable
                .Any<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_PredicateAt_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ValueEnumerable
                .Any<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.Count(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc())) != 0;

            // Act
            var result = ValueEnumerable
                .Any<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}