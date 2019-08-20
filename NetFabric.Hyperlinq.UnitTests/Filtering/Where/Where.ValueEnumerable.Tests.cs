using FluentAssertions;
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
            var predicate = (Func<int, bool>)null;

            // Act
            Action action = () => ValueEnumerable.Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(enumerable, predicate);

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
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Where(wrapped, predicate);

            // Act
            var result = ValueEnumerable.Where<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, predicate);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.WhereEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>,
                ValueEnumerable.WhereEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>.Enumerator, 
                int>(result, expected);
        }
    }
}