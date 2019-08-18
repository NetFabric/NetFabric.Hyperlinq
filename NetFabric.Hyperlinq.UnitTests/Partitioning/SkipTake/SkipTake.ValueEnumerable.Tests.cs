using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class SkipTakeValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipTake), MemberType = typeof(TestData))]
        public void SkipTake_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Take(System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount);

            // Act
            var result = ValueEnumerable.SkipTake<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, skipCount, takeCount);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.SkipTakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>,
                ValueEnumerable.SkipTakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>.Enumerator,
                int>(result, expected);
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTake_Take), MemberType = typeof(TestData))]
        public void SkipTake_Take_With_ValidData_Should_Succeed(int[] source, int skipCount, int takeCount0, int takeCount1)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Take(System.Linq.Enumerable.Take(System.Linq.Enumerable.Skip(wrapped, skipCount), takeCount0), takeCount1);

            // Act
            var result = ValueEnumerable.SkipTake<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>(wrapped, skipCount, takeCount0).Take(takeCount1);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.SkipTakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>,
                ValueEnumerable.SkipTakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.ValueEnumerable<int>.Enumerator, int>.Enumerator,
                int>(result, expected);
        }
    }
}