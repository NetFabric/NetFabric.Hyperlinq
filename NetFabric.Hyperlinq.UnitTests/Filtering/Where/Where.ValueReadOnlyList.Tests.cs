using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereValueReadOnlyListTests
    {
        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ValueReadOnlyList.Where<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>(list, predicate);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.Where), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = System.Linq.Enumerable.Where(wrapped, predicate);

            // Act
            var result = ValueReadOnlyList.Where<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>(wrapped, predicate);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueReadOnlyList.WhereEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>,
                ValueReadOnlyList.WhereEnumerable<Wrap.ValueReadOnlyList<int>, Wrap.ValueEnumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}