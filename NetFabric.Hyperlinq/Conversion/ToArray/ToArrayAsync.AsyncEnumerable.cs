using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncEnumerableExtensions
    {
        
        static async ValueTask<TSource[]> ToArrayAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken)
        {
            var builder = new LargeArrayBuilder<TSource>(initialize: true);
            await builder.AddRangeAsync(source, cancellationToken);
            return builder.ToArray();
        }
    }
}

namespace System.Collections.Generic
{
    internal partial struct LargeArrayBuilder<T>
    {
        public async ValueTask AddRangeAsync(IAsyncEnumerable<T> items, CancellationToken cancellationToken)
        {
            Debug.Assert(items is object);

            var enumerator = items.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                var destination = _current;
                var index = _index;

                // Continuously read in items from the enumerator, updating _count
                // and _index when we run out of space.

                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    var item = enumerator.Current;

                    if ((uint)index >= (uint)destination.Length)
                        AddWithBufferAllocation(item, ref destination, ref index);
                    else
                        destination[index] = item;

                    index++;
                }

                // Final update to _count and _index.
                _count += index - _index;
                _index = index;
            }
        }
    }
}