using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Skip(wrapped, count);

            // Act
            var result = ValueEnumerable.Skip<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            result.Must().BeExactlyAs(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Skip_Skip), MemberType = typeof(TestData))]
        public void Skip_Skip_With_ValidData_Should_Succeed(int[] source, int count0, int count1)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Skip(System.Linq.Enumerable.Skip(wrapped, count0), count1);

            // Act
            var result = ValueEnumerable.Skip<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, count0).Skip(count1);

            // Assert
            result.Must().BeExactlyAs(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Skip_Skip), MemberType = typeof(TestData))]
        public void Skip_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Take(System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount);

            // Act
            var result = ValueEnumerable.Skip<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, skipCount).Take(takeCount);

            // Assert
            result.Must().BeExactlyAs(expected);
        }
    }
}