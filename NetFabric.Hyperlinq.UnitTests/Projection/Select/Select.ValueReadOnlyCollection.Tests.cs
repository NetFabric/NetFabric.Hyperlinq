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
            Action action = () => ValueReadOnlyCollection.Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(collection, selector);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = System.Linq.Enumerable.Select(wrapped, item => item.ToString());

            // Act
            var result = ValueReadOnlyCollection.Select<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int, string>(wrapped, item => item.ToString());

            // Assert
            result.Must().BeEnumerable(expected);
        }
    }
}