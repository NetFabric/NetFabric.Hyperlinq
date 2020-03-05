using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Element.First
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void First_With_Empty_Must_Throw(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => _ = ValueEnumerable
                .First<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void First_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.First(source);

            // Act
            var result = ValueEnumerable
                .First<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void First_Predicate_With_Empty_Must_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => _ = ValueEnumerable
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void First_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.First(source, predicate.AsFunc());

            // Act
            var result = ValueEnumerable
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_Empty_Must_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);

            // Act
            Action action = () => _ = ValueEnumerable
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .First();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void First_PredicateAt_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.First(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            var result = ValueEnumerable
                .Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate)
                .First();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}