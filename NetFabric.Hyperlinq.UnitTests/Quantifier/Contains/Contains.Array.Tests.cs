using System;
using System.Collections.Generic;
using System.Linq;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class ArrayTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_ValueType_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            var value = int.MaxValue;

            // Act
            var result = ArrayExtensions
                .Contains<int>(source, value);

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
            var wrapped = source.Select(item => item.ToString()).ToArray();

            // Act
            var result = ArrayExtensions
                .Contains<string>(wrapped, value);

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
            var value = source.Last();
 
            // Act
            var result = ArrayExtensions
                .Contains<int>(source, value);

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
            var value = source.Last().ToString();
            var wrapped = source.Select(item => item.ToString()).ToArray();

            // Act
            var result = ArrayExtensions
                .Contains<string>(wrapped, value);

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

            // Act
            var result = ArrayExtensions
                .Contains<int>(source, value, EqualityComparer<int>.Default);

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
            var value = source.Last();

            // Act
            var result = ArrayExtensions
                .Contains<int>(source, value, EqualityComparer<int>.Default);

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

            // Act
            var result = ArrayExtensions
                .Contains<int>(source, value, TestComparer<int>.Instance);

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
            var value = source.Last();

            // Act
            var result = ArrayExtensions
                .Contains<int>(source, value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_ValueType_With_Null_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = int.MaxValue;

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(item => item)
                .Contains(value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_ValueType_With_Null_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = source.Last();

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(item => item)
                .Contains(value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_ReferenceType_With_Null_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = default(string);

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .Contains(value);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_ReferenceType_With_Null_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = source.Last().ToString();

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .Contains(value);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_With_DefaultComparer_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = default(string);

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .Contains(value, EqualityComparer<string>.Default);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_With_DefaultComparer_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = source.Last().ToString();

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .Contains(value, EqualityComparer<string>.Default);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_With_Comparer_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = default(string);

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .Contains(value, TestComparer<string>.Instance);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void SkipTake_Select_Contains_With_Comparer_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount, NullableSelector<int, string> selector)
        {
            // Arrange
            var value = source.Last().ToString();

            // Act
            var result = ArrayExtensions
                .Skip(source, skipCount)
                .Take(takeCount)
                .Select(selector)
                .Contains(value, TestComparer<string>.Instance);

            // Assert
            _ = result.Must()
                .BeTrue();
        }
    }
}