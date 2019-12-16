using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerable
    {
        public static ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (actionAsync is null) Throw.ArgumentNullException(nameof(actionAsync));

            return ExecuteAsync(source, actionAsync, cancellationToken);

            static async ValueTask ExecuteAsync(TEnumerable source, Func<TSource, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken1)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken1);
                await using(enumerator.ConfigureAwait(false))
                { 
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                        await actionAsync(enumerator.Current, cancellationToken1).ConfigureAwait(false);
                }
            }
        }

        public static ValueTask ForEachAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, int, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            if (actionAsync is null) Throw.ArgumentNullException(nameof(actionAsync));

            return ExecuteAsync(source, actionAsync, cancellationToken);

            static async ValueTask ExecuteAsync(TEnumerable source, Func<TSource, int, CancellationToken, ValueTask> actionAsync, CancellationToken cancellationToken1)
            {
                var enumerator = source.GetAsyncEnumerator();
                await using (enumerator.ConfigureAwait(false)) 
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                        await actionAsync(enumerator.Current, index, cancellationToken1);
                }
            }
        }
    }
}

