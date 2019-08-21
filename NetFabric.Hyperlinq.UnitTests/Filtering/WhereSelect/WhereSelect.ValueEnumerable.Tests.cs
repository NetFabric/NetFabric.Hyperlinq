using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereSelectValueEnumerableTests
    {
        [Fact]
        public void WhereSelect_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, int>(enumerable, null, item => item);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        [Fact]
        public void WhereSelect_With_NullSelector_Should_Throw()
        {
            // Arrange
            var enumerable = Wrap.AsValueEnumerable(new int[0]);

            // Act
            Action action = () => ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, int>(enumerable, _ => true, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.WhereSelect), MemberType = typeof(TestData))]
        public void WhereSelect_With_ValidData_Should_Succeed(int[] source, Func<int, bool> predicate, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(wrapped, predicate), selector);

            // Act
            var result = ValueEnumerable.WhereSelect<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>(wrapped, predicate, selector);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.WhereSelectEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>,
                ValueEnumerable.WhereSelectEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerator<int>, int, string>.Enumerator,
                string>(result, expected);
        }
    }
}