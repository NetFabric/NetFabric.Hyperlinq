using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectValueReadOnlyCollectionTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var collection = Wrap.AsValueReadOnlyCollection(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => ValueReadOnlyCollection.Select<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int, string>(collection, selector);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Select), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(int[] source, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.Select(wrapped, selector);

            // Act
            var result = ValueReadOnlyCollection.Select<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int, string>(wrapped, selector);

            // Assert
            Utils.ValueReadOnlyCollection.ShouldEqual<
                ValueReadOnlyCollection.SelectEnumerable<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int, string>,
                ValueReadOnlyCollection.SelectEnumerable<Wrap.ValueReadOnlyCollection<int>, Wrap.ValueEnumerator<int>, int, string>.Enumerator,
                string>(result, expected);
        }
    }
}