using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class FirstOrDefaultArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(source);

            // Act
            ref readonly var result = ref Array
                .FirstOrDefault<int>(source);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_Skip_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));

            // Act
            ref readonly var result = ref Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .FirstOrDefault();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void FirstOrDefault_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = Array
                .FirstOrDefault<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(source, predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .FirstOrDefault<int>(source, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_Skip_Take_Predicate_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc());

            // Act
            ref readonly var result = ref Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .FirstOrDefault(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void FirstOrDefault_PredicateAt_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = Array
                .FirstOrDefault<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_PredicateAt_With_ValidData_Should_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .FirstOrDefault<int>(source, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void FirstOrDefault_Skip_Take_PredicateAt_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.FirstOrDefault(
                    System.Linq.Enumerable.Where(
                        System.Linq.Enumerable.Take(
                            System.Linq.Enumerable.Skip(source, skipCount), takeCount), predicate.AsFunc()));

            // Act
            ref readonly var result = ref Array
                .Skip<int>(source, skipCount)
                .Take(takeCount)
                .FirstOrDefault(predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}