using System;
using System.Buffers;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class LargeArrayBuilderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1_000)]
        public void ToArray_Must_Succeed(int count)
        {
            // Arrange
            var expected = Enumerable
                .Range(0, count)
                .ToArray();
            using var builder = new LargeArrayBuilder<int>(ArrayPool<int>.Shared, false);
            for (var index = 0; index < count; index++)
                builder.Add(expected[index]);

            // Act
            var result = builder.ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void ToArray_MemoryPool_Must_Succeed(int count)
        {
            // Arrange
            var pool = ArrayPool<int>.Shared;
            var expected = Enumerable
                .Range(0, count)
                .ToArray();
            // ReSharper disable once ConvertToUsingDeclaration
            using var builder = new LargeArrayBuilder<int>(pool, false);
            for (var index = 0; index < count; index++)
                builder.Add(expected[index]);

            // Act
            using var result = builder.ToArray(pool, false);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}