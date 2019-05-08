using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectReadOnlyCollectionTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var collection = Wrap.AsReadOnlyCollection(new int[0]);

            // Act
            Action action = () => ReadOnlyCollection.Select<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int, string>(collection, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Select), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(int[] source, Func<int, long, string> selector, string[] expected)
        {
            // Arrange
            var collection = Wrap.AsReadOnlyCollection(source);

            // Act
            var result = ReadOnlyCollection.Select<Wrap.ReadOnlyCollection<int>, Wrap.ReadOnlyCollection<int>.Enumerator, int, string>(collection, selector);

            // Assert
            result.Should().Generate(expected);
        }
    }
}