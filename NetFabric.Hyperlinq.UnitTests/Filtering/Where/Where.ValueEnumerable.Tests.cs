using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereValueEnumerableTests
    {
        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => ValueEnumerable.Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(enumerable, predicate);

            // Assert
            action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Where), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Should_Succeed(int[] source, Predicate<int> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Where(wrapped, predicate.AsFunc());

            // Act
            var result = ValueEnumerable.Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}