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
        public void Contains_With_ValidData_Should_Succeed(int[] source, int value, IEqualityComparer<int> comparer)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Contains(source, value, comparer);

            // Act
            var result = ReadOnlyList
                .Contains<Wrap.ValueReadOnlyList<int>, int>(wrapped, value, comparer);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakeContains), MemberType = typeof(TestData))]
        public void Contains_Skip_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount, int value, IEqualityComparer<int> comparer)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 
                System.Linq.Enumerable.Contains(
                    System.Linq.Enumerable.Take(
                        System.Linq.Enumerable.Skip(source, skipCount), takeCount), value, comparer);

            // Act
            var result = ReadOnlyList
                .Skip<Wrap.ValueReadOnlyList<int>, int>(wrapped, skipCount)
                .Take(takeCount)
                .Contains(value, comparer);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}