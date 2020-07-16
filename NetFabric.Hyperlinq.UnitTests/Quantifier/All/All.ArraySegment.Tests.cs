using System;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.All
{
    public class ArraySegmentTests
    {
        [Fact]
        public void All_Predicate_With_NullPredicate_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = new ArraySegment<int>(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .All(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void All_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .All(wrapped, predicate.AsFunc());

            // Act
            var result = ArrayExtensions
                .All(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Fact]
        public void All_PredicateAt_With_NullPredicate_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = new ArraySegment<int>(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .All(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void All_Skip_Take_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, PredicateAt<int> predicate)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var count = Enumerable
                .Count(wrapped);
            var expected = Enumerable
                .Where(wrapped, predicate.AsFunc())
                .Count() == count;

            // Act
            var result = ArrayExtensions
                .All(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}