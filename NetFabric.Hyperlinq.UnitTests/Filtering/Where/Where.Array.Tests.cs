using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ArrayTests
    {
        [Fact]
        public void Where_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .Where<int>(source, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate.AsFunc());

            // Act
            var result = ArrayExtensions
                .Where(source, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.PredicatePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicatePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicatePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Where_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate0, Predicate<int> predicate1)
        {
            // Arrange
            var expected = Enumerable
                .Where(source, predicate0.AsFunc())
                .Where(predicate1.AsFunc());

            // Act
            var result = ArrayExtensions
                .Where(source, predicate0)
                .Where(predicate1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}