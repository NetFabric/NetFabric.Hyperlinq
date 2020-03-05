using System;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_Must_Succeed(int[] source)
        {
            // Arrange

            // Act
            var result = Array
                .ToArray<int>(source);

            // Assert
            _ = result.Must()
                .BeNotSameAs(source)
                .BeArrayOf<int>()
                .BeEqualTo(source);
        }
    }
}