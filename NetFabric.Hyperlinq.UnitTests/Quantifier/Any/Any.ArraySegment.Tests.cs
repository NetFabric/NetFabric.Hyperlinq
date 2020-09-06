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
        public void Any_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
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

        [Fact]
        public void Any_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);

            // Act
            var result = ArrayExtensions
                .Any(source);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Fact]
        public void Any_Predicate_With_NullArray_Must_Succeed()
        {
            // Arrange
            var source = default(ArraySegment<int>);
            var expected = Enumerable.Empty<int>();

            // Act
            var result = ArrayExtensions
                .Where(source, _ => true)
                .Any();

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Any_Predicate_With_ValidData_Must_Succeed(int[] source, int skip, int take, Predicate<int> predicate)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .Any(wrapped, predicate.AsFunc());

            // Act
            var result = ArrayExtensions
                .Where(wrapped, predicate)
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
            var wrapped = new ArraySegment<int>(source);
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .Where(wrapped, predicate)
                .Any();

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateAtMultiple), MemberType = typeof(TestData))]
        public void Any_PredicateAt_With_ValidData_Must_Succeed(int[] source, int skip, int take, PredicateAt<int> predicate)
        {
            // Arrange
            var (offset, count) = Utils.SkipTake(source.Length, skip, take);
            var wrapped = new ArraySegment<int>(source, offset, count);
            var expected = Enumerable
                .Where(wrapped, predicate.AsFunc())
                .Count() != 0;

            // Act
            var result = ArrayExtensions
                .Where(wrapped, predicate)
                .Any();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}