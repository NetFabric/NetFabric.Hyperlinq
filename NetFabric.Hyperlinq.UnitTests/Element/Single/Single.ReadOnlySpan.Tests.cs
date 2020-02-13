using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SingleReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        public void Single_With_Single_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(source);

            // Act
            ref readonly var result = ref Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Single_With_Multiple_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Fact]
        public void Single_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Empty_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Single_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(source, predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Single_Predicate_With_Multiple_Should_Throw(int[] source, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Fact]
        public void Single_PredicateAt_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Empty_Should_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Single_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void Single_PredicateAt_With_Multiple_Should_Throw(int[] source, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }
    }
}