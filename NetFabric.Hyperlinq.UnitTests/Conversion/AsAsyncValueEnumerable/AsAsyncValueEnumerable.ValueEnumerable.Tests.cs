using NetFabric.Assertive;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace NetFabric.Hyperlinq.UnitTests.Conversion.AsAsyncValueEnumerable
{
    public class ValueEnumerableTests
    {
        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_With_ValidData_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);

            // Act
            var result = ValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped);

            // Assert
            var enumerator = result.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var index = 0;
                while (true)
                {
                    var isResultCompleted = !await enumerator.MoveNextAsync();
                    var isSourceCompleted = index == source.Length;

                    if (isResultCompleted && isSourceCompleted)
                        return;

                    if (isResultCompleted)
                        throw new Exception("'result' is shorter.");

                    if (isSourceCompleted)
                        throw new Exception("'result' is longer.");

                    if (!EqualityComparer<int>.Default.Equals(enumerator.Current, source[index]))
                        throw new Exception($"Items are not equal at index '{index}'.");

                    index++;
                }
            }
            // TODO: figure out why this doesn't work...
            //_ = result.Must()
            //    .BeAsyncEnumerableOf<int>()
            //    .BeEqualTo(source);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_With_ToArrayAsync_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToArray(source);

            // Act
            var result = await ValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped)
                .ToArrayAsync();

            // Assert
            _ = result.Must()
                .BeArrayOf<int>()
                .BeEqualTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestData.Empty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Single), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.Multiple), MemberType = typeof(TestData))]
        public async ValueTask AsAsyncValueEnumerable_With_ToListAsync_Must_Succeed(int[] source)
        {
            // Arrange
            var wrapped = Wrap.AsValueEnumerable(source);
            var expected = 
                System.Linq.Enumerable.ToList(source);

            // Act
            var result = await ValueEnumerableExtensions
                .AsAsyncValueEnumerable<Wrap.ValueEnumerableWrapper<int>, Wrap.Enumerator<int>, int>(wrapped)
                .ToListAsync();

            // Assert
            _ = result.Must()
                .BeOfType<List<int>>()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected);
        }
    }
}