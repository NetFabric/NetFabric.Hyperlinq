using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ReadOnlyListTests
    {
        [Fact]
        public void Where_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var list = Wrap
                .AsReadOnlyList(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ReadOnlyListExtensions
                .Where(list, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = Enumerable
                .Skip(source, skipCount)
                .Take(takeCount)
                .Where(predicate.AsFunc());

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Where(predicate);


            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}