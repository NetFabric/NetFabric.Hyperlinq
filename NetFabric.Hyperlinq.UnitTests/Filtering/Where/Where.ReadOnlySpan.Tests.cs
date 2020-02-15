using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereReadOnlySpanArrayTests
    {
        [Fact]
        public void Where_Predicate_With_Null_Should_Throw()
        {
            // Arrange
            var source = new int[0];
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = Array
                .Where<int>((ReadOnlySpan<int>)source.AsSpan(), predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.PredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.PredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Predicate_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Where(source, predicate.AsFunc());

            // Act
            var result = Array
                .Where<int>((ReadOnlySpan<int>)(source.AsSpan()), predicate);

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