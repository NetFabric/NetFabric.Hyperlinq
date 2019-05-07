using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ReturnTests
    {
        [Theory]
        [MemberData(nameof(TestData.Return), MemberType = typeof(TestData))]
        public void Return_With_Value_Should_Succeed(int value, int[] expected)
        {
            // Arrange

            // Act
            var result = Enumerable.Return(value);

            // Assert
            result.Should().Generate(expected);

            var expectedEnumerator = expected.GetEnumerator();
            var resultEnumerator = result.GetEnumerator();
            {
                if (!resultEnumerator.MoveNext())
                    throw new Exception($"foreach enumeration found an empty result.");

                expectedEnumerator.MoveNext();

                if(!resultEnumerator.Current.Equals(expectedEnumerator.Current))
                    throw new Exception($"foreach enumeration expected value {expectedEnumerator.Current} but found {resultEnumerator.Current}.");

                if (resultEnumerator.MoveNext())
                    throw new Exception($"foreach enumeration found more than one item.");
            }
        } 

        [Theory]
        [InlineData(0, 1)]
        [InlineData(0, -1)]
        public void Indexer_With_IndexOutOfRange_Should_Throw(int value, int index)
        {
            // Arrange

            // Act
            Func<int> action = () => Enumerable.Return(value)[index];

            // Assert
            action.Should().ThrowExactly<IndexOutOfRangeException>();
        }    
    }
}