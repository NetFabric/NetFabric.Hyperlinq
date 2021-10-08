using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable HeapView.ObjectAllocation.Evident

namespace NetFabric.Hyperlinq
{
    public static partial class AsyncValueEnumerableExtensions
    {

        public static ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            IEqualityComparer<TKey>? comparer = default, 
            CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TSource, TKey>
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, keySelector, comparer, cancellationToken);

            static async ValueTask<Dictionary<TKey, TSource>> ExecuteAsync(TEnumerable source, TKeySelector keySelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    var dictionary = new Dictionary<TKey, TSource>(0, comparer);
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        dictionary.Add(
                            await keySelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false),
                            item);
                    }

                    return dictionary;
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

        

        static async ValueTask<Dictionary<TKey, TSource>> ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            IEqualityComparer<TKey>? comparer, 
            CancellationToken cancellationToken,
            TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TSource, TKey>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var dictionary = new Dictionary<TKey, TSource>(0, comparer);
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        dictionary.Add(
                            await keySelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false),
                            item);
                }
                return dictionary;
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }



        static async ValueTask<Dictionary<TKey, TSource>> ToDictionaryAtAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TPredicate>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            IEqualityComparer<TKey>? comparer,
            CancellationToken cancellationToken,
            TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TSource, TKey>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    var dictionary = new Dictionary<TKey, TSource>(0, comparer);
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false))
                            dictionary.Add(
                                await keySelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false),
                                item);
                    }

                    return dictionary;
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }


        static async ValueTask<Dictionary<TKey, TResult>> ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TKeySelector, TResult, TPredicate, TSelector>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            IEqualityComparer<TKey>? comparer, 
            CancellationToken cancellationToken,
            TPredicate predicate,
            TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TResult, TKey>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var dictionary = new Dictionary<TKey, TResult>(0, comparer);

            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                    {
                        var result = await selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false);
                        dictionary.Add(await keySelector.InvokeAsync(result, cancellationToken).ConfigureAwait(false), result);
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }

            return dictionary;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////

        public static ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            TElementSelector elementSelector, 
            IEqualityComparer<TKey>? comparer = default, 
            CancellationToken cancellationToken = default)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TSource, TKey>
            where TElementSelector: struct, IAsyncFunction<TSource, TElement>
        {
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteAsync(source, keySelector, elementSelector, comparer, cancellationToken);

            static async ValueTask<Dictionary<TKey, TElement>> ExecuteAsync(TEnumerable source, TKeySelector keySelector, TElementSelector elementSelector, IEqualityComparer<TKey>? comparer, CancellationToken cancellationToken)
            {
                var enumerator = source.GetAsyncEnumerator(cancellationToken);
                try
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    var dictionary = new Dictionary<TKey, TElement>(0, comparer);
                    while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                    {
                        var item = enumerator.Current;
                        dictionary.Add(
                            await keySelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false),
                            await elementSelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false));
                    }
                    return dictionary;
                }
                finally
                {
                    await enumerator.DisposeAsync().ConfigureAwait(false);
                }
            }
        }

        

        static async ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            TElementSelector elementSelector, 
            IEqualityComparer<TKey>? comparer, 
            CancellationToken cancellationToken,
            TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TSource, TKey>
            where TElementSelector: struct, IAsyncFunction<TSource, TElement>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                var dictionary = new Dictionary<TKey, TElement>(0, comparer);
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                        dictionary.Add(
                            await keySelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false), 
                            await elementSelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false));
                }
                return dictionary;
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }

        

        static async ValueTask<Dictionary<TKey, TElement>> ToDictionaryAtAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TPredicate>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            TElementSelector elementSelector, 
            IEqualityComparer<TKey>? comparer, 
            CancellationToken cancellationToken,
            TPredicate predicate)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TSource, TKey>
            where TElementSelector: struct, IAsyncFunction<TSource, TElement>
            where TPredicate : struct, IAsyncFunction<TSource, int, bool>
        {
            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                checked
                {
                    // ReSharper disable once HeapView.ObjectAllocation.Evident
                    var dictionary = new Dictionary<TKey, TElement>(0, comparer);
                    for (var index = 0; await enumerator.MoveNextAsync().ConfigureAwait(false); index++)
                    {
                        var item = enumerator.Current;
                        if (await predicate.InvokeAsync(item, index, cancellationToken).ConfigureAwait(false))
                            dictionary.Add(
                                await keySelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false), 
                                await elementSelector.InvokeAsync(item, cancellationToken).ConfigureAwait(false));
                    }
                    return dictionary;
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }
        }
        


        static async ValueTask<Dictionary<TKey, TElement>> ToDictionaryAsync<TEnumerable, TEnumerator, TSource, TKey, TElement, TKeySelector, TElementSelector, TResult, TPredicate, TSelector>(
            this TEnumerable source, 
            TKeySelector keySelector, 
            TElementSelector elementSelector, 
            IEqualityComparer<TKey>? comparer, 
            CancellationToken cancellationToken,
            TPredicate predicate,
            TSelector selector)
            where TEnumerable : IAsyncValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IAsyncEnumerator<TSource>
            where TKey : notnull
            where TKeySelector: struct, IAsyncFunction<TResult, TKey>
            where TElementSelector: struct, IAsyncFunction<TResult, TElement>
            where TPredicate : struct, IAsyncFunction<TSource, bool>
            where TSelector : struct, IAsyncFunction<TSource, TResult>
        {
            var dictionary = new Dictionary<TKey, TElement>(0, comparer);

            var enumerator = source.GetAsyncEnumerator(cancellationToken);
            try
            {
                while (await enumerator.MoveNextAsync().ConfigureAwait(false))
                {
                    var item = enumerator.Current;
                    if (await predicate.InvokeAsync(item, cancellationToken).ConfigureAwait(false))
                    {
                        var result = await selector.InvokeAsync(item, cancellationToken).ConfigureAwait(false);
                        dictionary.Add(
                            await keySelector.InvokeAsync(result, cancellationToken).ConfigureAwait(false),
                            await elementSelector.InvokeAsync(result, cancellationToken).ConfigureAwait(false));
                    }
                }
            }
            finally
            {
                await enumerator.DisposeAsync().ConfigureAwait(false);
            }

            return dictionary;
        }
    }
}
