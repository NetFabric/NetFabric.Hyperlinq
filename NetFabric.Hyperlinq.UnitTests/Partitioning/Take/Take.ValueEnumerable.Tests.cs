using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class TakeValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.TakeEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.TakeMultiple), MemberType = typeof(TestData))]
        public void Take_With_ValidData_Should_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Take(wrapped, count);

            // Act
            var result = ValueEnumerable.Take<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, count);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.TakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>,
                ValueEnumerable.TakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>.Enumerator,
                int>(result, expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Take_Take), MemberType = typeof(TestData))]
        public void Take_Take_With_ValidData_Should_Succeed(int[] source, int count0, int count1)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = System.Linq.Enumerable.Take(System.Linq.Enumerable.Take(wrapped, count0), count1);

            // Act
            var result = ValueEnumerable.Take<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>(wrapped, count0).Take(count1);

            // Assert
            Utils.ValueEnumerable.ShouldEqual<
                ValueEnumerable.TakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>,
                ValueEnumerable.TakeEnumerable<Wrap.ValueEnumerable<int>, Wrap.Enumerator<int>, int>.Enumerator,
                int>(result, expected);
        }
    }
}