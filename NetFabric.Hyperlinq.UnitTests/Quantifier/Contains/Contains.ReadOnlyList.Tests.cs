using System;
using System.Collections.Generic;
using System.Diagnostics;
using NetFabric.Assertive;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Quantifier.Contains
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_Null_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, null);

            // Act
            var result = ReadOnlyList
                .Contains<Wrap.ValueReadOnlyList<int>, int>(wrapped, value, null);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Contains), MemberType = typeof(TestData))]
        public void Contains_With_Comparer_Should_Succeed(int[] source, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, EqualityComparer<int>.Default);

            // Act
            var result = ReadOnlyList
                .Contains<Wrap.ValueReadOnlyList<int>, int>(wrapped, value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeContains), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Null_Should_Succeed(int[] source, int skipCount, int takeCount, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Contains(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount), value, null);

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, null);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeContains), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_Comparer_Should_Succeed(int[] source, int skipCount, int takeCount, int value)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Contains(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount), value, EqualityComparer<int>.Default);

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, EqualityComparer<int>.Default);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}