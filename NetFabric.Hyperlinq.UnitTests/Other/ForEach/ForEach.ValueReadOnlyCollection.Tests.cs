using FluentAssertions;
using System;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class ForEachValueReadOnlyCollectionTests
    {
        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void ForEach_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(wrapped, item => expected += item);

            // Act
            var result = 0;
            ValueReadOnlyCollection.ForEach<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, item => result += item);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Count), MemberType = typeof(TestData))]
        public void ForEachIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueReadOnlyCollection(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(wrapped, (item, index) => expected += item + index);

            // Act
            var result = 0;
            ValueReadOnlyCollection.ForEach<Wrap.ValueReadOnlyCollection<int>, Wrap.Enumerator<int>, int>(wrapped, (item, index) => result += item + index);

            // Assert
            result.Should().Be(expected);
        }
    }
}