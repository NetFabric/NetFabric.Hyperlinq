using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Any
{
    public class ArraySegmentTests
    {

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Any_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .Any(wrapped);

            // Act
            var result = ArrayExtensions
                .Any(wrapped);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
        
        [Fact]
        public void Any_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = new ArraySegment<int>(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .Any(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .Any(wrapped, predicate.AsFunc());

            // Act
            var result = ArrayExtensions
                .Any(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void Any_PredicateAt_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = new ArraySegment<int>(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .Any(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .Where(wrapped, predicate.AsFunc())
                .Count() != 0;

            // Act
            var result = ArrayExtensions
                .Any(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}