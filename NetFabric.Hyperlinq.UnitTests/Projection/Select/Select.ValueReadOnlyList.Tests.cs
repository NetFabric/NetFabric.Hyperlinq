using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SelectValueReadOnlyListTests
    {
        [Fact]
        public void Select_With_NullSelector_Should_Throw()
        {
            // Arrange
            var list = Wrap.AsValueReadOnlyList(new int[0]);

            // Act
            Action action = () => ValueReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, string>(list, null);

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
            var list = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ValueReadOnlyList.Select<Wrap.ValueReadOnlyList<int>, Wrap.ValueReadOnlyList<int>.Enumerator, int, string>(list, selector);

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

                    if(!resultEnumerator.Current.Equals(expectedEnumerator.Current))
                        throw new Exception($"foreach enumeration expected value {expectedEnumerator.Current} but found {resultEnumerator.Current} at index {index}.");

                    index++;
                }
            }
        }
    }
}