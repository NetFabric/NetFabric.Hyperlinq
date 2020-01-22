using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        [Pure]
        public static async ValueTask<TSource> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    for (; await enumerator.MoveNextAsync().ConfigureAwait(false); index--)
                    {
                        if (index == 0)
                            return enumerator.Current;
                    }
                }
            }

            return Throw.ArgumentOutOfRangeException<TSource>(nameof(index));
        }

        [Pure]
        public static async ValueTask<TSource> ElementAtOrDefaultAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default) 
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    for (; await enumerator.MoveNextAsync().ConfigureAwait(false); index--)
                    {
                        if (index == 0)
                            return enumerator.Current;
                    }
                }
            }

            return default!;
        }

        [Pure]
        public static async ValueTask<Maybe<TSource>> TryElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (index >= 0)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                await using (enumerator.ConfigureAwait(false))
                {
                    for (; await enumerator.MoveNextAsync().ConfigureAwait(false); index--)
                    {
                        if (index == 0)
                            return new Maybe<TSource>(enumerator.Current);
                    }
                }
            }

            return default;
        }
    }
}
