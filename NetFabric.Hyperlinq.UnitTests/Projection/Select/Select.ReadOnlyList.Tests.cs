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

            // Act
            Action action = () => ReadOnlyList.Select<Wrap.ReadOnlyList<int>, int, string>(list, null);

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
            var list = Wrap.AsReadOnlyList(source);

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, string>(list, selector);

            // Assert
            result.Should().Generate(expected);

            var index = 0;
            var expectedEnumerator = expected.GetEnumerator();
            var resultEnumerator = result.GetEnumerator();
            {
                while (true)
                {
                    var isResultCompleted = !resultEnumerator.MoveNext();
                    var isExpectedCompleted = !expectedEnumerator.MoveNext();

                    if (isResultCompleted && isExpectedCompleted)
                        break;

                    if (isResultCompleted ^ isExpectedCompleted)
                        throw new Exception($"foreach enumeration expected complete {isExpectedCompleted} but found {isResultCompleted} at index {index}.");

                    if (!resultEnumerator.Current.Equals(expectedEnumerator.Current))
                        throw new Exception($"foreach enumeration expected value {expectedEnumerator.Current} but found {resultEnumerator.Current} at index {index}.");

                    index++;
                }
            }
        }

        [Theory]
        [MemberData(nameof(TestData.SelectSkip), MemberType = typeof(TestData))]
        public void Select_With_Skip_Should_Succeed(IReadOnlyList<int> source, Func<int, long, int> selector, int skipCount, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, int>(source, selector).Skip(skipCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectTake), MemberType = typeof(TestData))]
        public void Select_With_Take_Should_Succeed(IReadOnlyList<int> source, Func<int, long, int> selector, int takeCount, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, int>(source, selector).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectSkipTake), MemberType = typeof(TestData))]
        public void Select_With_SkipTake_Should_Succeed(IReadOnlyList<int> source, Func<int, long, int> selector, int skipCount, int takeCount, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyList.Select<IReadOnlyList<int>, int, int>(source, selector).Skip(skipCount).Take(takeCount);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
    }
}