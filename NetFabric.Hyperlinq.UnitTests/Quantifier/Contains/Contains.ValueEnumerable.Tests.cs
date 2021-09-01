using NetFabric.Assertive;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_ValueType_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_ReferenceType_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            const string? value = default;
            var wrapped = Wrap.AsValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<string>, Wrap.Enumerator<string>, string>(value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_ValueType_With_Null_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = source
                .Last();
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_ReferenceType_With_Null_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = source
                .Last()
                .ToString();
            var wrapped = Wrap.AsValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<string>, Wrap.Enumerator<string>, string>(value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_DefaultComparer_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_DefaultComparer_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = source
                .Last();
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_Comparer_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            const int value = int.MaxValue;
            var comparer = new TestComparer<int>();
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(value, comparer);

            // Assert
            _ = result.Must()
                .BeFalse();
            _ = comparer.EqualsCounter.Must()
                .BeEqualTo(source.Length);
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_Comparer_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = source
                .Last();
            var comparer = new TestComparer<int>();
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = wrapped
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(value, comparer);

            // Assert
            _ = result.Must()
                .BeTrue();
            _ = comparer.EqualsCounter.Must()
                .BeEqualTo(source.Length);
        }
    }
}