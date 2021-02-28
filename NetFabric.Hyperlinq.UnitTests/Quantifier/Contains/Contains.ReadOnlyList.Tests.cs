using NetFabric.Assertive;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void Contains_ValueType_With_Null_And_NotContains_Must_ReturnFalse(int[] source)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Contains(value);

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
            const string value = default;
            var wrapped = Wrap.AsValueReadOnlyList(source.AsValueEnumerable().Select(item => item.ToString()).ToArray());

            // Act
            var result = wrapped.AsValueEnumerable()
                .Contains(value);

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
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Contains(value);

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
            var wrapped = Wrap.AsValueReadOnlyList(source.AsValueEnumerable().Select(item => item.ToString()).ToArray());

            // Act
            var result = wrapped.AsValueEnumerable()
                .Contains(value);

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
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Contains(value, EqualityComparer<int>.Default);

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
            var value = source
                .Last();
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Contains(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        ////////////////////
        // Skip Take
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Null_And_NotContains_Must_ReturnFalse(int[] source, int skip, int take)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Contains(value, null);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Null_And_Contains_Must_ReturnTrue(int[] source, int skip, int take)
        {
            // Arrange
            var value = source
                .Skip(skip)
                .Take(take)
                .Last();
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Contains(value, null);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_DefaultComparer_And_NotContains_Must_ReturnFalse(int[] source, int skip, int take)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Contains(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_DefaultComparer_And_Contains_Must_ReturnTrue(int[] source, int skip, int take)
        {
            // Arrange
            var value = source
                .Skip(skip)
                .Take(take)
                .Last();
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Contains(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Comparer_And_NotContains_Must_ReturnFalse(int[] source, int skip, int take)
        {
            // Arrange
            const int value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Contains(value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Comparer_And_Contains_Must_ReturnTrue(int[] source, int skip, int take)
        {
            // Arrange
            var value = source
                .Skip(skip)
                .Take(take)
                .Last();
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Contains(value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeTrue();
        }
    }
}