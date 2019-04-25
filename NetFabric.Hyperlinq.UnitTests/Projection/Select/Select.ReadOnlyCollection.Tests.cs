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
            var source = Enumerable.Empty<int>().AsEnumerable();

            // Act
            Action action = () => ReadOnlyCollection.Select<IReadOnlyCollection<int>, IEnumerator<int>, int, string>(source, null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("selector");
        }

        [Theory]
        [MemberData(nameof(TestData.Select), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Should_Succeed(IReadOnlyCollection<int> source, Func<int, long, string> selector, IReadOnlyCollection<string> expected)
        {
            // Arrange

            // Act
            var result = ReadOnlyCollection.Select<IReadOnlyCollection<int>, IEnumerator<int>, int, string>(source, Selector);

            // Assert
            result.Should().Generate(expected);

            var index = 0;
            using(var resultEnumerator = result.GetEnumerator())
            using(var expectedEnumerator = expected.GetEnumerator())
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

            string Selector(int value, int i) => selector(value, i);
        }
    }
}