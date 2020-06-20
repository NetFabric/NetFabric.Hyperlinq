using System;
using System.Collections.Generic;
using NetFabric.Assertive;
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
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Contains<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, value);

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
            var wrapped = Wrap.AsValueReadOnlyList(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = ReadOnlyListExtensions
                .Contains<Wrap.ValueReadOnlyListWrapper<string>, string>(wrapped, value);

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
            var value = System.Linq.Enumerable.Last(source);
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Contains<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, value);

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
            var value = System.Linq.Enumerable.Last(source).ToString();
            var wrapped = Wrap.AsValueReadOnlyList(source.Select(item => item.ToString()).ToArray());

            // Act
            var result = ReadOnlyListExtensions
                .Contains<Wrap.ValueReadOnlyListWrapper<string>, string>(wrapped, value);

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
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Contains<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, value, EqualityComparer<int>.Default);

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
            var value = System.Linq.Enumerable.Last(source);
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Contains<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, value, EqualityComparer<int>.Default);

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
        public void Contains_Skip_Take_With_Null_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, null);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Null_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var value = 
                System.Linq.Enumerable.Last(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, null);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_DefaultComparer_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_DefaultComparer_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var value = 
                System.Linq.Enumerable.Last(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Comparer_And_NotContains_Must_ReturnFalse(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var value = int.MaxValue;
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeFalse();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Comparer_And_Contains_Must_ReturnTrue(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var value =
                System.Linq.Enumerable.Last(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount));
            var wrapped = Wrap.AsValueReadOnlyList(source);

            // Act
            var result = ReadOnlyListExtensions
                .Skip<Wrap.ValueReadOnlyListWrapper<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, TestComparer<int>.Instance);

            // Assert
            _ = result.Must()
                .BeTrue();
        }
    }
}