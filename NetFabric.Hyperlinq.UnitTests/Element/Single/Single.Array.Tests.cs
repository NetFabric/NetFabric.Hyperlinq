using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public partial class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        public void Single_With_Empty_Should_Throw(int[] source)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Single<int>(source);

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
                .Single<int>(source);

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
                .Single<int>(source);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        public void Single_Skip_Take_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single();

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        public void Single_Skip_Take_With_Single_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));

            // Act
            ref readonly var result = ref Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Single_Skip_Take_With_Multiple_Should_Throw(int[] source, int skipCount, int takeCount)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single();

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
                .Single<int>(source, predicate);

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
                .Single<int>(source, predicate);

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
                .Single<int>(source, predicate);

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
                .Single<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        public void Single_Skip_Take_Predicate_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single(predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        public void Single_Skip_Take_Predicate_With_Single_Should_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Single_Skip_Take_Predicate_With_Multiple_Should_Throw(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single(predicate);

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
                .Single<int>(source, predicate);

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
                .Single<int>(source, predicate);

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
                .Single<int>(source, predicate);

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
                .Single<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        public void Single_Skip_Take_PredicateAt_With_Empty_Should_Throw(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single(predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains no elements");
        }    

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        public void Single_Skip_Take_PredicateAt_With_Single_Should_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Single(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void Single_Skip_Take_PredicateAt_With_Multiple_Should_Throw(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange

            // Act
            Action action = () => _ = Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .Single(predicate);

            // Assert
            _ = action.Must()
                .Throw<InvalidOperationException>()
                .EvaluateTrue(exception => exception.Message == "Sequence contains more than one element");
        }    
    }
}