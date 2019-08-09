using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static async ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var count = 0;
            await foreach (var item in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                checked { count++; }
            }
            return count;
        }
    }
}
