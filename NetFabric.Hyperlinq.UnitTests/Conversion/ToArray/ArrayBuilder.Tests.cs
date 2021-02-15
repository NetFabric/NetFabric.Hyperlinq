using System;
using System.Buffers;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ArrayBuilderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1_000)]
        public void Add_Must_Succeed(int count)
        {
            // Arrange
            var expected = Enumerable
                .Range(0, count)
                .ToArray();

            // Act
            using var builder = new ArrayBuilder<int>(ArrayPool<int>.Shared);
            for (var index = 0; index < count; index++)
                builder.Add(expected[index]);

            // Assert
            builder.AsSpan().SequenceEqual(expected);
        }
    }
}