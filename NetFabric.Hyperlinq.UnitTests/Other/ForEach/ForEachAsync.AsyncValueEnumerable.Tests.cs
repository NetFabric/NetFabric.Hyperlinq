using NetFabric.Assertive;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Other.ForEach
{
    public class AsyncValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEachAsync_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(Wrap.AsEnumerable(source), item => expected += item);

            // Act
            var result = 0;
            AsyncValueEnumerable.ForEachAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(wrapped, (item, _) =>  { result += item; return default; });

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public void ForEachAsyncIndex_With_ValidData_Should_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsAsyncValueEnumerable(source);
            var expected = 0;
            MoreLinq.Extensions.ForEachExtension.ForEach(Wrap.AsEnumerable(source), (item, index) => expected += item + index);

            // Act
            var result = 0;
            AsyncValueEnumerable.ForEachAsync<Wrap.AsyncValueEnumerable<int>, Wrap.AsyncEnumerator<int>, int>(
                wrapped, 
                (item, index, _) => { result += item + index; return default; });

            // Assert
            _ = result.Must()
                .BeEqualTo(expected);
        }
    }
}