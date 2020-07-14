using System;
using System.Buffers;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.ToArray
{
    public class ValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = Enumerable
                .ToArray(wrapped);

            // Act
            var result = ValueReadOnlyCollectionExtensions
                .ToArray<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_With_ValidData_Collections_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueCollection(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            var result = ValueReadOnlyCollectionExtensions
                .ToArray<Wrap.ValueCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ToArray_MemoryPool_Must_Succeed(int[] source)
        {
            // Arrange
            var pool = MemoryPool<int>.Shared;
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = Enumerable
                .ToArray(source);

            // Act
            using var result = ValueEnumerableExtensions
                .ToArray<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Predicate_With_ValidData_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            var result = ValueReadOnlyCollectionExtensions
                .Select<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorMultiple), MemberType = typeof(TestData))]
        public void ToArray_Predicate_MemoryPool_With_ValidData_Must_Succeed(int[] source, NullableSelector<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            using var result = ValueReadOnlyCollectionExtensions
                .Select<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ToArray(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_SelectorAt_With_ValidData_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            var result = ValueReadOnlyCollectionExtensions
                .Select<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ToArray();

            // Assert
            _ = result.Must()
                .BeArrayOf<string>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SelectorAtEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SelectorAtMultiple), MemberType = typeof(TestData))]
        public void ToArray_SelectorAt_MemoryPool_With_ValidData_Must_Succeed(int[] source, NullableSelectorAt<int, string> selector)
        {
            // Arrange
            var pool = MemoryPool<string>.Shared;
            var wrapped = Wrap
                .AsValueReadOnlyCollection(source);
            var expected = Enumerable
                .Select(source, selector.AsFunc())
                .ToArray();

            // Act
            using var result = ValueReadOnlyCollectionExtensions
                .Select<Wrap.ValueReadOnlyCollectionWrapper<int>, Wrap.Enumerator<int>, int, string>(wrapped, selector)
                .ToArray(pool);

            // Assert
            _ = result
                .SequenceEqual(expected)
                .Must().BeTrue();
        }

    }
}