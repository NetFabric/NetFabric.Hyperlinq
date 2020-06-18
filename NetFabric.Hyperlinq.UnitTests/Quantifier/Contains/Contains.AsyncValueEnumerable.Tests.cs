using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.ContainsAsync
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_ValueType_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var value = int.MaxValue;
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_ReferenceType_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var value = default(string);
            var wrapped = Wrap.AsAsyncValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<string>, Wrap.AsyncEnumerator<string>, string>(wrapped, value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_ValueType_With_Null_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = Enumerable.Last(source);
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_ReferenceType_With_Null_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = Enumerable.Last(source).ToString();
            var wrapped = Wrap.AsAsyncValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<string>, Wrap.AsyncEnumerator<string>, string>(wrapped, value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_DefaultComparer_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var value = int.MaxValue;
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_DefaultComparer_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = Enumerable.Last(source);
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeTrue();
        }


        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_Comparer_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var value = int.MaxValue;
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask ContainsAsync_With_Comparer_And_Contains_Must_ReturnTrue(int[] source)
        {
            // Arrange
            var value = Enumerable.Last(source);
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await AsyncValueEnumerableExtensions
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeTrue();
        }
    }
}