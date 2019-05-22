using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectReadOnlyListTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(new int[0]);
            var selector = (Func<int, string>)null;

            // Act
            Action action = () => ReadOnlyList.Select<Wrap.ReadOnlyList<int>, int, string>(list, selector);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Select), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(int[] source, Func<int, string> selector, string[] expected)
        {
            // Arrange
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, string>(list, selector);

            // Assert
            result.Should().Generate(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectSkip), MemberType = typeof(TestData))]
        public void Select_With_Skip_Should_Succeed(IReadOnlyList<int> source, Func<int, int> selector, int skipCount, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, int>(source, selector).Skip(skipCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectTake), MemberType = typeof(TestData))]
        public void Select_With_Take_Should_Succeed(IReadOnlyList<int> source, Func<int, int> selector, int takeCount, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, int>(source, selector).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectSkipTake), MemberType = typeof(TestData))]
        public void Select_With_SkipTake_Should_Succeed(IReadOnlyList<int> source, Func<int, int> selector, int skipCount, int takeCount, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, int>(source, selector).Skip(skipCount).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
    }
}