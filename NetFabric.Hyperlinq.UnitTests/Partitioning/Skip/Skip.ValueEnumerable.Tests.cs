using NetFabric.Assertive;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Partitioning.Skip.ValueEnumerable
{
    public class Tests
    {
        [Theory]
        [MemberData(nameof(TestData.SkipEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipMultiple), MemberType = typeof(TestData))]
        public void Skip_With_ValidData_Must_Succeed(int[] source, int count)
        {
            // Arrange
            var wrapped = Wrap
                .AsValueEnumerable(source);
            var expected = source
                .Skip(count);

            // Act
            var result = wrapped
                .Skip<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(count);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
        
    public class SkipEnumerableTests
        : ValueEnumerableTestsBase<
            ValueEnumerableExtensions.SkipEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>, 
            ValueEnumerableExtensions.SkipEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>,
            ValueEnumerableExtensions.SkipTakeEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>>
    {
        public SkipEnumerableTests() 
            : base(array => Wrap
                .AsValueEnumerable(array)
                .Skip<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(0))
        {}
    }
}