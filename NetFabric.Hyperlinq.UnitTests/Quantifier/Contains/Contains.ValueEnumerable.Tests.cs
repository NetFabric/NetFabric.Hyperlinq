using System;
using System.Collections.Generic;
using System.Linq;
using NetFabric.Assertive;
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
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, value, null);

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
            var value = default(string);
            var wrapped = Wrap.AsValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<string>, Wrap.Enumerator<string>, string>(wrapped, value, null);

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
            var value = Enumerable.Last(source);
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, value, null);

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
            var value = Enumerable.Last(source).ToString();
            var wrapped = Wrap.AsValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<string>, Wrap.Enumerator<string>, string>(wrapped, value, null);

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
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

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
            var value = Enumerable.Last(source);
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

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
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_With_Comparer_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = Enumerable.Last(source);
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .Contains<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped, value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeTrue();
        }
    }
}