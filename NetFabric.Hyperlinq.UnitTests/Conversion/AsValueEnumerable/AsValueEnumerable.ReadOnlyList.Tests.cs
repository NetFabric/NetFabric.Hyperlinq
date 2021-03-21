using NetFabric.Assertive;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsValueEnumerable.ReadOnlyList
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);

            // Act
            var result = wrapped
                .AsValueEnumerable();

            // Assert
            _ = result.Must()
                .BeOfType<ReadOnlyListExtensions.ValueEnumerable<Wrap.ReadOnlyListWrapper<int>, int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(wrapped);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void AsValueEnumerable1_Sum_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap
                .AsReadOnlyList(source);
            var expected = source
                .Skip(skipCount)
                .Take(takeCount)
                .Sum();

            // Act
            var result = wrapped
                .AsValueEnumerable()
                .Skip(skipCount)
                .Take(takeCount)
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }

    public class ValueEnumerableTests
        : ValueEnumerableTestsBase<ReadOnlyListExtensions.ValueEnumerable<Wrap.ReadOnlyListWrapper<int>, int>>
    {
        public ValueEnumerableTests() 
            : base(array => Wrap.AsReadOnlyList(array).AsValueEnumerable())
        {}
    }
}
