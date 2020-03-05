using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void Where_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyList.Where(list, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Where(source, predicate.AsFunc());

            // Act
            var result = ReadOnlyList.Where(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}