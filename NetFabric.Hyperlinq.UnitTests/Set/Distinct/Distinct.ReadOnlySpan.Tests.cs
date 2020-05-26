using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Set.Distinct
{
    public class ReadOnlySpanTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Distinct_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var expected = 
                System.Linq.Enumerable.Distinct(source);

            // Act
            var result = Array
                .Distinct<int>((ReadOnlySpan<int>)source.AsSpan());

            // Assert
            var resultEnumerator = result.GetEnumerator();
            using var expectedEnumerator = expected.GetEnumerator();
            while (true)
            {
                var resultEnded = !resultEnumerator.MoveNext();
                var expectedEnded = !expectedEnumerator.MoveNext();

                if (resultEnded != expectedEnded)
                    throw new Exception("Not same size");

                if (resultEnded)
                    break;

                if (resultEnumerator.Current != expectedEnumerator.Current)
                    throw new Exception("Items are not equal");
            }
        }
    }
}
