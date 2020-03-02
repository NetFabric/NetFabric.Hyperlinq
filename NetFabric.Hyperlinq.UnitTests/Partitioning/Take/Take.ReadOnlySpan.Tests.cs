using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Take
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var expected = System.Linq.Enumerable.Take(source, count);

            // Act
            var result = Array
                .Take((ReadOnlySpan<int>)source.AsSpan(), count);

            // Assert
            using var expectedEnumerator = expected.GetEnumerator();
            for (var index = 0; true; index++)
            {
                var resultEnded = index == result.Length;
                var expectedEnded = !expectedEnumerator.MoveNext();

                if (resultEnded != expectedEnded)
                    throw new Exception("Not same size");

                if (resultEnded)
                    break;

                if (result[index] != expectedEnumerator.Current)
                    throw new Exception("Items are not equal");
            }
        }
    }
}