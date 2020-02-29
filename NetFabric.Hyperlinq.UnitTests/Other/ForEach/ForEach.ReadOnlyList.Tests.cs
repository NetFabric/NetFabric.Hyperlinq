using NetFabric.Assertive;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Other.ForEach
{
    public class ReadOnlyListTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEach_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(wrapped, item => expected += item);

            // Act
            var result = 0;
            ReadOnlyList.ForEach<Wrap.ValueReadOnlyList<int>, int>(wrapped, item => result += item);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEachIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyList(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(wrapped, (item, index) => expected += item + index);

            // Act
            var result = 0;
            ReadOnlyList.ForEach<Wrap.ValueReadOnlyList<int>, int>(wrapped, (item, index) => result += item + index);

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}