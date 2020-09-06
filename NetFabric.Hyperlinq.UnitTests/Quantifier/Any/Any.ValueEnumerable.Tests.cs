using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Any
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = Enumerable
                .Any(source);

            // Act
            var result = ValueEnumerableExtensions
                .Any<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .Any();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = Enumerable
                .Any(source, predicate.AsFunc());

            // Act
            var result = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_PredicateAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = Wrap.AsValueEnumerable(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .Any();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = Enumerable   
                .Where(source, predicate.AsFunc())
                .Count() != 0;

            // Act
            var result = ValueEnumerableExtensions
                .Where<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}