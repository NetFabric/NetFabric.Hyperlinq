using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        public static async ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var counter = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        counter++;
                }
            }
            return counter;
        }

        static async ValueTask<int> CountAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicate<TSource>
        {
            var counter = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var result = await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false);
                        counter += result.AsByte();
                    }
                }
            }
            return counter;
        }

        static async ValueTask<int> CountAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, TPredicate predicate, CancellationToken cancellationToken)
            where TEnumerable : notnull, IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncPredicateAt<TSource>
        {
            var counter = 0;
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            await using (enumerator.ConfigureAwait(false))
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var result = await predicate.InvokeAsync(enumerator.Current, index, cancellationToken).ConfigureAwait(false);
                        counter += result.AsByte();
                    }
                }
            }
            return counter;
        }
    }
}
