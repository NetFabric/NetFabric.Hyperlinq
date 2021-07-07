using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {
        
        public static async ValueTask<Option<TSource>> FirstAsync<TEnumerable, TEnumerator, TSource>(this TEnumerable source, CancellationToken cancellationToken = default) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false) switch
                {
                    true => Option.Some(enumerator.Current),
                    _ => Option.None
                };
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }



        static async ValueTask<Option<TSource>> FirstAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        return Option.Some(item);
                }   
                return Option.None;
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }



        static async ValueTask<Option<TSource>> FirstAtAsync<TEnumerable, TEnumerator, TSource, TPredicate>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false))
                            return Option.Some(item);
                    }   
                }
                return Option.None;
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<Option<TResult>> FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false) switch
                {
                    true => Option.Some(await selector.InvokeAsync(enumerator.Current, cancellationToken).ConfigureAwait(false)),
                    _ => Option.None
                };
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static async ValueTask<Option<TResult>> FirstAtAsync<TEnumerable, TEnumerator, TSource, TResult, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TSelector selector) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TSelector : struct, IAsyncFunction<TSource, int, TResult>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                return await enumerator.MoveNextAsync().ConfigureAwait(false) switch
                {
                    true => Option.Some(await selector.InvokeAsync(enumerator.Current, 0, cancellationToken).ConfigureAwait(false)),
                    _ => Option.None
                };
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }



        static async ValueTask<Option<TResult>> FirstAsync<TEnumerable, TEnumerator, TSource, TResult, TPredicate, TSelector>(this TEnumerable source, CancellationToken cancellationToken, TPredicate predicate, TSelector selector) 
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        return Option.Some(await selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false));
                }   
                return Option.None;
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
