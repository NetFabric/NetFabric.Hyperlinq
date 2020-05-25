using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereIndex
{
    public class MemoryTests
    {
        [Fact]
        public void WhereIndex_With_NullPredicate_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (PredicateAt<int>)null;

            // Act
            Action action = () => _ = Array.Where(source.AsMemory(), predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateAtMultiple), MemberType = typeof(TestData))]
        public void WhereIndex_With_ValidData_Must_Succeed(int[] source, PredicateAt<int> predicate)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Where(source, predicate.AsFunc());

            // Act
            var result = Array.Where(source.AsMemory(), predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}