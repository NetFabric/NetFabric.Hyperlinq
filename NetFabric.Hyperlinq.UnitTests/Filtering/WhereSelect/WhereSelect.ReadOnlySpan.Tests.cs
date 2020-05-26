using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.WhereSelect
{
    public class ReadOnlySpanTests
    {
        [Fact]
        public void WhereSelect_Predicate_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = Array
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
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
                .Where((ReadOnlySpan<int>)source.AsSpan(), _ => true)
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
                .Where((ReadOnlySpan<int>)source.AsSpan(), predicate)
                .Select(selector);

            // Assert
            var resultEnumerator = result.GetEnumerator();
            using var expectedEnumerator = expected.GetEnumerator();
            while (true)
            {
                var resultEnded = !resultEnumerator.MoveNext();
                var expectedEnded = !expectedEnumerator.MoveNext();

                if (resultEnded != expectedEnded)
                    throw new Exception("Not same size");

                if (resultEnded)
                    break;

                if (resultEnumerator.Current != expectedEnumerator.Current)
                    throw new Exception("Items are not equal");
            }
        }
    }
}