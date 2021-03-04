using NetFabric.Assertive;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            const int value = int.MaxValue;
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(value)
                .ConfigureAwait(false);

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
            const string value = default;
            var wrapped = Wrap.AsAsyncValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<string>, Wrap.AsyncEnumerator<string>, string>(value)
                .ConfigureAwait(false);

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
            var value = source
                .Last();
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(value)
                .ConfigureAwait(false);

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
            var value = source
                .Last()
                .ToString();
            var wrapped = Wrap.AsAsyncValueEnumerable(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<string>, Wrap.AsyncEnumerator<string>, string>(value)
                .ConfigureAwait(false);

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
            const int value = int.MaxValue;
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(value, EqualityComparer<int>.Default)
                .ConfigureAwait(false);

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
            var value = source
                .Last();
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(value, EqualityComparer<int>.Default)
                .ConfigureAwait(false);

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
            const int value = int.MaxValue;
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(value, TestComparer<int>.Instance)
                .ConfigureAwait(false);

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
            var value = source
                .Last();
            var wrapped = Wrap.AsAsyncValueEnumerable(source);

            // Act
            var result = await wrapped
                .ContainsAsync<Wrap.AsyncValueEnumerableWrapper<int>, Wrap.AsyncEnumerator<int>, int>(value, TestComparer<int>.Instance)
                .ConfigureAwait(false);

            // Assert
            _ = result.Must()
                .BeTrue();
        }
    }
}