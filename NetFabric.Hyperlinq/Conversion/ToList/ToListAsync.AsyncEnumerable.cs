using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncEnumerable
    {
        public static async ValueTask<List<TSource>> ToListAsync<TSource>(IAsyncEnumerable<TSource> source, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var list = new List<TSource>();
            var enumerator = source.GetAsyncEnumerator();
            await using (enumerator.ConfigureAwait(false))
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    list.Add(enumerator.Current);
                }
            }
            return list;
        }
    }
}