using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Projection.Select
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTakeSelectorEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSelectorMultiple), MemberType = typeof(TestData))]
        public void Select_With_ValidData_Must_Succeed(int[] source, int skip, int take, Func<int, string> selector)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take)
                .Select(selector);

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(selector);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<string>()
                .BeEqualTo(expected);
        }
        
        [Theory]
        [MemberData(nameof(TestData.SkipTakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakeMultiple), MemberType = typeof(TestData))]
        public void Select_Sum_With_ValidData_Must_Succeed(int[] source, int skip, int take)
        {
            // Arrange
            var wrapped = Wrap.AsReadOnlyList(source);
            var expected = source
                .Skip(skip)
                .Take(take)
                .Select(item => item)
                .Sum();

            // Act
            var result = wrapped.AsValueEnumerable()
                .Skip(skip)
                .Take(take)
                .Select(item => item)
                .Sum();

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}