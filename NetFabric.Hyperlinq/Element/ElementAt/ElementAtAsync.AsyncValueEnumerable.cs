using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        public static ValueTask<Option<TSource>> ElementAtAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, int index, CancellationToken cancellationToken = default) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            return index < 0 
                ? new ValueTask<Option<TSource>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken);

            static async ValueTask<Option<TSource>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- is 0)
                            return Option.Some(enumerator.Current);
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return Option.None;
            }
        }

        

        static ValueTask<Option<TSource>> ElementAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, CancellationToken cancellationToken, TPredicate predicate) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            return index < 0 
                ? new ValueTask<Option<TSource>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken, predicate);

            static async ValueTask<Option<TSource>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken, TPredicate predicate)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- is 0)
                            return Option.Some(enumerator.Current);
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return Option.None;
            }
        }

        

        static ValueTask<Option<TSource>> ElementAtAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, int index, CancellationToken cancellationToken, TPredicate predicate) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            return index < 0 
                ? new ValueTask<Option<TSource>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken, predicate);

            static async ValueTask<Option<TSource>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken, TPredicate predicate)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    checked
                    {
                        for (var sourceIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); sourceIndex++)
                        {
                            if (await predicate.InvokeAsync(enumerator.Current, sourceIndex, cancellationToken).ConfigureAwait(false) && index-- is 0)
                                return Option.Some(enumerator.Current);
                        }
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return Option.None;
            }
        }

        

        static ValueTask<Option<TResult>> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, CancellationToken cancellationToken, TSelector selector) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            return index < 0 
                ? new ValueTask<Option<TResult>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken, selector);

            static async ValueTask<Option<TResult>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken, TSelector selector)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (index-- is 0)
                            return Option.Some(await selector.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false));
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return Option.None;
            }
        }

        

        static ValueTask<Option<TResult>> ElementAtAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, int index, CancellationToken cancellationToken, TSelector selector) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
        {
            return index < 0 
                ? new ValueTask<Option<TResult>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken, selector);

            static async ValueTask<Option<TResult>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken, TSelector selector)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    checked
                    {
                        for (var sourceIndex = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); sourceIndex++)
                        {
                            if (sourceIndex == index)
                                return Option.Some(await selector.InvokeAsync(enumerator.Current, sourceIndex, cancellationToken).ConfigureAwait(false));
                        }
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return Option.None;
            }
        }

        

        static ValueTask<Option<TResult>> ElementAtAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, int index, CancellationToken cancellationToken, TPredicate predicate, TSelector selector) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            return index < 0 
                ? new ValueTask<Option<TResult>>(Option.None) 
                : ExecuteAsync(source, index, cancellationToken, predicate, selector);

            static async ValueTask<Option<TResult>> ExecuteAsync(TEnumerable source, int index, CancellationToken cancellationToken, TPredicate predicate, TSelector selector)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        if (await predicate.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false) && index-- is 0)
                            return Option.Some(await selector.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false));
                    }
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
                return Option.None;
            }
        }
    }
}
