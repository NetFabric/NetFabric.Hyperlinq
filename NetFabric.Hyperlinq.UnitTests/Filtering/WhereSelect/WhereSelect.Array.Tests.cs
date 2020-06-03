using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class ArrayTests
    {
        [Fact]
        public void WhereSelect_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = Array
                .Where(source, predicate)
                .Select(item => item.ToString());

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Fact]
        public void WhereSelect_Selector_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var selector = (Selector<int, string>)null;

            // Act
            Action action = () => _ = Array
                .Where(source, _ => true)
                .Select(selector);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "selector");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSelectorMultiple), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Must_Succeed(int[] source, Predicate<int> predicate, Selector<int, string> selector)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Select(
                    System.Linq.Enumerable.Where(source, predicate.AsFunc()), selector.AsFunc());

            // Act
            var result = Array
                .Where(source, predicate)
                .Select(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}